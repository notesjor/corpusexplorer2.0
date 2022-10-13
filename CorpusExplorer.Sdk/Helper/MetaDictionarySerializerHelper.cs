using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class MetaDictionarySerializerHelper
  {
    private const int _sizeDateTime = sizeof(long);
    private const int _sizeDouble = sizeof(double);
    private const int _sizeGuid = 16;
    private const int _sizeInt32 = sizeof(int);
    private static readonly byte[] _idDateTime = BitConverter.GetBytes(300);
    private static readonly byte[] _idDouble = BitConverter.GetBytes(200);
    private static readonly byte[] _idGuid = BitConverter.GetBytes(1000);
    private static readonly byte[] _idInt32 = BitConverter.GetBytes(100);
    private static readonly byte[] _idString = BitConverter.GetBytes(400);
    private static readonly byte[] _split = BitConverter.GetBytes(int.MinValue);

    public static Dictionary<string, object> Deserialize(byte[] array)
    {
      return Deserialize(new MemoryStream(array));
    }

    public static Dictionary<string, object> Deserialize(Stream ms)
    {
      var res = new Dictionary<string, object>();
      if (DeserializeInt32(ms) != 400)
        return null;
      var key = DeserializeString(ms);
      
      while (key != null)
      {
        var type = DeserializeInt32(ms);
        object value;

        switch (type)
        {
          case 100:
            value = DeserializeInt32(ms);
            break;
          case 200:
            value = DeserializeDouble(ms);
            break;
          case 300:
            value = DeserializeDateTime(ms);
            break;
          case 400:
            value = DeserializeString(ms);
            break;
          default:
            value = null;
            break;
        }

        if (value == null)
          break;

        key = Configuration.DocumentMetadataLocalization.Translate(key);

        if (res.ContainsKey(key))
          res[key] = value;
        else
          res.Add(key, value);

        if (DeserializeInt32(ms) == int.MinValue)
          break;

        key = DeserializeString(ms);
      }

      return res;
    }

    public static Dictionary<string, object> Deserialize(string stream)
    {
      return Deserialize(Convert.FromBase64String(stream));
    }

    public static Dictionary<Guid, Dictionary<string, object>> DeserializeContainer(byte[] array)
    {
      return DeserializeContainer(new MemoryStream(array));
    }

    public static Dictionary<Guid, Dictionary<string, object>> DeserializeContainer(Stream ms)
    {
      var res = new Dictionary<Guid, Dictionary<string, object>>();
      if (DeserializeInt32(ms) != 1000)
        return null;
      var key = DeserializeGuid(ms);

      while (key != Guid.Empty)
      {
        res.Add(key, Deserialize(ms));

        if (DeserializeInt32(ms) == int.MinValue)
          break;

        key = DeserializeGuid(ms);
      }

      return res;
    }

    public static Dictionary<Guid, Dictionary<string, object>> DeserializeContainer(string stream)
    {
      return DeserializeContainer(Convert.FromBase64String(stream));
    }

    public static byte[] Serialize(Dictionary<string, object> meta)
    {
      using (var ms = new MemoryStream())
      {
        Serialize(ms, meta);
        return ms.ToArray();
      }
    }

    public static void Serialize(Stream stream, Dictionary<string, object> meta)
    {
      if (meta != null)
        foreach (var entry in meta)
        {
          if (entry.Value == null)
            continue;

          // Key
          Serialize(stream, entry.Key);

          // Value
          if (entry.Value is int)
            Serialize(stream, (int) entry.Value);
          else if (entry.Value is double)
            Serialize(stream, (double) entry.Value);
          else if (entry.Value is DateTime)
            Serialize(stream, (DateTime) entry.Value);
          else
            Serialize(stream, entry.Value.ToString());
        }

      stream.Write(_split, 0, _sizeInt32);
    }

    public static byte[] Serialize(Dictionary<Guid, Dictionary<string, object>> meta)
    {
      using (var ms = new MemoryStream())
      {
        Serialize(ms, meta);
        return ms.ToArray();
      }
    }

    public static void Serialize(Stream stream, Dictionary<Guid, Dictionary<string, object>> meta)
    {
      if (meta != null)
        foreach (var entry in meta)
        {
          if (entry.Key == Guid.Empty || entry.Value == null)
            continue;

          var vals = (from x in entry.Value where x.Value != null select x).ToDictionary(x => x.Key, x => x.Value);
          if (vals.Count == 0)
            continue;

          // Key
          Serialize(stream, entry.Key);

          // Value
          Serialize(stream, vals);
        }

      stream.Write(_split, 0, _sizeInt32);
    }

    public static string SerializeToBase64String(Dictionary<string, object> meta)
    {
      return Convert.ToBase64String(Serialize(meta));
    }

    public static string SerializeToBase64String(Dictionary<Guid, Dictionary<string, object>> meta)
    {
      return Convert.ToBase64String(Serialize(meta));
    }

    private static DateTime DeserializeDateTime(Stream ms)
    {
      var buffer = new byte[_sizeDateTime];
      ms.Read(buffer, 0, buffer.Length);
      return new DateTime(BitConverter.ToInt64(buffer, 0));
    }

    private static double DeserializeDouble(Stream ms)
    {
      var buffer = new byte[_sizeDouble];
      ms.Read(buffer, 0, buffer.Length);
      return BitConverter.ToDouble(buffer, 0);
    }

    private static Guid DeserializeGuid(Stream ms)
    {
      var buffer = new byte[_sizeGuid];
      ms.Read(buffer, 0, buffer.Length);
      return new Guid(buffer);
    }

    private static int DeserializeInt32(Stream ms)
    {
      var buffer = new byte[_sizeInt32];
      ms.Read(buffer, 0, buffer.Length);
      return BitConverter.ToInt32(buffer, 0);
    }

    private static string DeserializeString(Stream ms)
    {
      var length = DeserializeInt32(ms);
      if (length == 0)
        return string.Empty;

      var buffer = new byte[length];
      ms.Read(buffer, 0, buffer.Length);
      return Configuration.Encoding.GetString(buffer);
    }

    private static void Serialize(Stream stream, string v)
    {
      stream.Write(_idString, 0, _idString.Length);
      var buffer = Configuration.Encoding.GetBytes(v);
      var buffer2 = BitConverter.GetBytes(buffer.Length);
      stream.Write(buffer2, 0, buffer2.Length);
      stream.Write(buffer, 0, buffer.Length);
    }

    private static void Serialize(Stream stream, DateTime value)
    {
      stream.Write(_idDateTime, 0, _idDateTime.Length);
      var ticks = value.Ticks;
      var buffer = BitConverter.GetBytes(ticks);
      stream.Write(buffer, 0, _sizeDateTime);
    }

    private static void Serialize(Stream stream, Guid value)
    {
      stream.Write(_idGuid, 0, _idGuid.Length);
      var buffer = value.ToByteArray();
      stream.Write(buffer, 0, _sizeGuid);
    }

    private static void Serialize(Stream stream, double value)
    {
      stream.Write(_idDouble, 0, _idDouble.Length);
      var buffer = BitConverter.GetBytes(value);
      stream.Write(buffer, 0, _sizeDouble);
    }

    private static void Serialize(Stream stream, int value)
    {
      stream.Write(_idInt32, 0, _idInt32.Length);
      var buffer = BitConverter.GetBytes(value);
      stream.Write(buffer, 0, _sizeInt32);
    }
  }
}
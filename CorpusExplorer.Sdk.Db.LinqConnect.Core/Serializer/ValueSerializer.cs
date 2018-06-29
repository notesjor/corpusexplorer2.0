using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Db.LinqConnect.Serializer
{
  public static class ValueSerializer
  {
    public static object DeserializeValue(byte[] array)
    {
      if (array == null || array.Length < 2)
        return null;

      switch (array[0])
      {
        case 10:
          return DeserializeValueAsString(array);
        case 20:
          return DeserializeValueAsInteger(array);
        case 21:
          return DeserializeValueAsUnsignedInteger(array);
        case 30:
          return DeserializeValueAsDoubleAsDouble(array);
        case 40:
          return DeserializeValueAsDateTime(array);
        case 50:
          return DeserializeValueAsLong(array);
        case 51:
          return DeserializeValueAsUnsignedLong(array);
        case 250:
          return DeserializeValueAsObject(array);
        default:
          return null;
      }
    }

    public static DateTime DeserializeValueAsDateTime(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 40)
        return DateTime.MinValue;

      try
      {
        return new DateTime(BitConverter.ToInt64(array, 1));
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    public static double DeserializeValueAsDoubleAsDouble(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 30)
        return 0;

      try
      {
        return BitConverter.ToDouble(array, 1);
      }
      catch
      {
        return 0;
      }
    }

    public static int DeserializeValueAsInteger(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 20)
        return 0;
      try
      {
        return BitConverter.ToInt32(array, 1);
      }
      catch
      {
        return 0;
      }
    }

    public static long DeserializeValueAsLong(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 50)
        return 0;

      try
      {
        return BitConverter.ToInt64(array, 1);
      }
      catch
      {
        return 0;
      }
    }

    public static string DeserializeValueAsString(byte[] array, Encoding encoding = null)
    {
      if (array == null || array.Length < 1 || array[0] != 10)
        return null;
      if (array.Length < 2)
        return string.Empty;

      try
      {
        return (encoding ?? Configuration.Encoding).GetString(array, 1, array.Length - 1);
      }
      catch
      {
        return null;
      }
    }

    public static uint DeserializeValueAsUnsignedInteger(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 21)
        return 0;
      try
      {
        return BitConverter.ToUInt32(array, 1);
      }
      catch
      {
        return 0;
      }
    }

    public static ulong DeserializeValueAsUnsignedLong(byte[] array)
    {
      if (array == null || array.Length < 2 || array[0] != 51)
        return 0;

      try
      {
        return BitConverter.ToUInt64(array, 1);
      }
      catch
      {
        return 0;
      }
    }

    public static byte[] SerializeValue(string value, Encoding encoding = null)
    {
      var res = new List<byte> {10};
      if (string.IsNullOrEmpty(value))
        return res.ToArray();

      res.AddRange((encoding ?? Configuration.Encoding).GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(int value)
    {
      var res = new List<byte> {20};
      res.AddRange(BitConverter.GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(uint value)
    {
      var res = new List<byte> {21};
      res.AddRange(BitConverter.GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(double value)
    {
      var res = new List<byte> {30};
      res.AddRange(BitConverter.GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(DateTime value)
    {
      var res = new List<byte> {40};
      res.AddRange(BitConverter.GetBytes(value.Ticks));
      return res.ToArray();
    }

    public static byte[] SerializeValue(long value)
    {
      var res = new List<byte> {50};
      res.AddRange(BitConverter.GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(ulong value)
    {
      var res = new List<byte> {51};
      res.AddRange(BitConverter.GetBytes(value));
      return res.ToArray();
    }

    public static byte[] SerializeValue(object value)
    {
      switch (value)
      {
        case string _:
          return SerializeValue((string) value);
        case int _:
          return SerializeValue((int) value);
        case uint _:
          return SerializeValue((uint) value);
        case double _:
          return SerializeValue((double) value);
        case DateTime _:
          return SerializeValue((DateTime) value);
        case long _:
          return SerializeValue((long) value);
        case ulong _:
          return SerializeValue((ulong) value);
        default:
          return SerializeObject(value);
      }
    }

    private static object DeserializeValueAsObject(byte[] array)
    {
      try
      {
        using (var ms = new MemoryStream())
        {
          ms.Write(array, 1, array.Length);
          ms.Seek(0, SeekOrigin.Begin);
          var bf = new BinaryFormatter();
          return bf.Deserialize(ms);
        }
      }
      catch
      {
        return null;
      }
    }

    private static byte[] SerializeObject(object value)
    {
      var res = new List<byte> {250};
      using (var ms = new MemoryStream())
      {
        var bf = new BinaryFormatter();
        bf.Serialize(ms, value);

        ms.Seek(0, SeekOrigin.Begin);
        var buffer = new byte[ms.Length];
        ms.Read(buffer, 0, buffer.Length);

        res.AddRange(buffer);
      }

      return res.ToArray();
    }
  }
}
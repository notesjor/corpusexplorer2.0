﻿#region

using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using Newtonsoft.Json;
using Polenter.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The serializer.
  /// </summary>
  public static class Serializer
  {
    public static bool LogErrors { get; set; } = true;

    /// <summary>
    ///   The deserialize.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="T" />.
    /// </returns>
    public static T Deserialize<T>(string path)
      where T : class
    {
      try
      {
        var obj = DeserializeBinaryFormatterCompressed(path) ?? // Serialize compress = true
                  DeserializeBinaryFormatterUncompressed(path) ?? // Serialize compress = false                
                  DeserializeNetDataContractCompressed(path) ?? // CEC2a-CEC4a compress = true
                  DeserializeNetDataContractUncompressed(path); // CEC2a-CEC4a compress = false

        if (obj == null) // Diese Deserializer benötigen Reflection
        {
          var type = typeof(T);
          obj = DeserializeDataContractCompressed(path, type) ?? // CEC2b-CEC4b compress = true
                DeserializeDataContractUncompressed(path, type) ?? // CEC2b-CEC4b compress = false
                DeserializeDotNetXml(path, type); // PROJ5
        }

        if (obj == null) // Deserializer für externe Dateiformate
          obj = DeserializeSharpSerializer(path) ??
                DeserializeJson(path);

        return obj as T;
      }
      catch
      {
        return null;
      }
    }

    private static object DeserializeBinaryFormatterCompressed(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          using (var gs = new GZipStream(fs, CompressionMode.Decompress))
          {
            var bf = new BinaryFormatter();
            return bf.Deserialize(gs);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeBinaryFormatterUncompressed(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, (int)new FileInfo(path).Length))
        {
          var bf = new BinaryFormatter();
          return bf.Deserialize(fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeDataContractCompressed(string path, Type type)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          using (var gs = new GZipStream(fs, CompressionMode.Decompress))
          {
            var dcs = new DataContractSerializer(type);
            return dcs.ReadObject(gs);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeDataContractUncompressed(string path, Type type)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          var dcs = new DataContractSerializer(type);
          return dcs.ReadObject(fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeDotNetXml(string path, Type type)
    {
      try
      {
        var serializer = new XmlSerializer(type);
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          return serializer.Deserialize(fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static T DeserializeFromBase64String<T>(string base64String)
      where T : class
    {
      try
      {
        using (var ms = new MemoryStream(Convert.FromBase64String(base64String)))
        {
          var bf = new BinaryFormatter();
          return bf.Deserialize(ms) as T;
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeJson(string path)
    {
      try
      {
        return JsonConvert.DeserializeObject(File.ReadAllText(path));
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeNetDataContractCompressed(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          using (var gs = new GZipStream(fs, CompressionMode.Decompress))
          {
            var bf = new NetDataContractSerializer();
            return bf.Deserialize(gs);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeNetDataContractUncompressed(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          var bf = new NetDataContractSerializer();
          return bf.Deserialize(fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static object DeserializeSharpSerializer(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          var serializer = new SharpSerializer();
          return serializer.Deserialize(fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static T InMemoryDeserialize<T>(byte[] buffer)
    {
      try
      {
        using (var fs = new MemoryStream(buffer))
        {
          using (var gz = new GZipStream(fs, CompressionMode.Decompress))
          {
            var bf = new NetDataContractSerializer();
            return (T)bf.Deserialize(gz);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return default(T);
      }
    }

    public static byte[] InMemorySerialize(object obj)
    {
      try
      {
        using (var fs = new MemoryStream())
        {
          using (var gz = new GZipStream(fs, CompressionLevel.Fastest))
          {
            var bf = new NetDataContractSerializer();
            bf.Serialize(gz, obj);
          }
          return fs.ToArray();
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    /// <summary>
    ///   Serialisiert ein Objekt in eine Datei
    /// </summary>
    /// <param name="obj">
    ///   Objekt
    /// </param>
    /// <param name="path">
    ///   Ausgabepfad
    /// </param>
    /// <param name="useCompression">Soll die Datei mit GZip kompprimiert werden?</param>
    public static void Serialize<T>(T obj, string path, bool useCompression)
    {
      if (useCompression)
        SerializeCompressed(obj, path);
      else
        SerializeUncompressed(obj, path);
    }

    private static void SerializeCompressed<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          using (var gs = new GZipStream(fs, CompressionLevel.Fastest))
          {
            var bf = new BinaryFormatter();
            bf.Serialize(gs, obj);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static void SerializeJson<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          using (var write = new StreamWriter(fs))
          {
            var json = new JsonSerializer();
            json.Serialize(write, obj);
          }
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static string SerializeToBase64String<T>(T obj)
      where T : class
    {
      try
      {
        using (var ms = new MemoryStream())
        {
          var bf = new BinaryFormatter();
          bf.Serialize(ms, obj);
          return Convert.ToBase64String(ms.ToArray());
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static void SerializeUncompressed<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(fs, obj);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static void SerializeXml<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          var serializer = new SharpSerializer();
          serializer.Serialize(obj, fs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static void SerializeXmlWithContract<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          var serializer = new DataContractSerializer(typeof(T));
          serializer.WriteObject(fs, obj);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static void SerializeXmlWithDotNet<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
          var serializer = new XmlSerializer(typeof(T));
          serializer.Serialize(fs, obj);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }
  }
}
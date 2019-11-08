#region

using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
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
        // Standard Serializer
        var obj = DeserializeBinaryFormatterCompressed(path) ?? // Serialize compress = true
                  DeserializeBinaryFormatterUncompressed(path); // Serialize compress = false                
        if (obj != null)
          return obj as T;

        // Deserializer für externe Dateiformate
        obj = DeserializeSharpSerializer(path) ??
              DeserializeJson(path);
        if (obj != null)
          return obj as T;

        // Format CEC2a-CEC4a
        obj = DeserializeNetDataContractCompressed(path) ?? // CEC2a-CEC4a compress = true
              DeserializeNetDataContractUncompressed(path); // CEC2a-CEC4a compress = false
        if (obj != null)
          return obj as T;

        // Format CEC2b-CEC4b / PROJ5
        var type = typeof(T);
        obj = DeserializeDataContractCompressed(path, type) ?? // CEC2b-CEC4b compress = true
              DeserializeDataContractUncompressed(path, type) ?? // CEC2b-CEC4b compress = false
              DeserializeDotNetXml(path, type); // PROJ5
        return obj as T;
      }
      catch
      {
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

    public static void SerializeJson<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        using (var write = new StreamWriter(bs))
        {
          var json = new JsonSerializer();
          json.Serialize(write, obj);
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

    public static void SerializeXml<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          var serializer = new SharpSerializer();
          serializer.Serialize(obj, bs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    public static string SerializeXml<T>(T obj)
    {
      try
      {
        using (var ms = new MemoryStream())
        {
          var serializer = new SharpSerializer();
          serializer.Serialize(obj, ms);

          ms.Seek(0, SeekOrigin.Begin);
          return Configuration.Encoding.GetString(ms.ToArray());
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static void SerializeXmlWithContract<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          var serializer = new DataContractSerializer(typeof(T));
          serializer.WriteObject(bs, obj);
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
        using (var bs = new BufferedStream(fs))
        {
          var serializer = new XmlSerializer(typeof(T));
          serializer.Serialize(bs, obj);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    private static object DeserializeBinaryFormatterCompressed(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var gs = new GZipStream(fs, CompressionMode.Decompress))
        using (var bs = new BufferedStream(gs))
        {
          var bf = new BinaryFormatter();
          return bf.Deserialize(bs);
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
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None,
                                       (int)new FileInfo(path).Length))
        using (var bs = new BufferedStream(fs))
        {
          var bf = new BinaryFormatter();
          return bf.Deserialize(bs);
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
        using (var gs = new GZipStream(fs, CompressionMode.Decompress))
        using (var bs = new BufferedStream(gs))
        {
          var dcs = new DataContractSerializer(type);
          return dcs.ReadObject(bs);
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
        using (var bs = new BufferedStream(fs))
        {
          var dcs = new DataContractSerializer(type);
          return dcs.ReadObject(bs);
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
        using (var bs = new BufferedStream(fs))
        {
          return serializer.Deserialize(bs);
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
        using (var gs = new GZipStream(fs, CompressionMode.Decompress))
        using (var bs = new BufferedStream(gs))
        {
          var bf = new NetDataContractSerializer();
          return bf.Deserialize(bs);
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
        using (var bs = new BufferedStream(fs))
        {
          var bf = new NetDataContractSerializer();
          return bf.Deserialize(bs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static object DeserializeSharpSerializer(string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var bs = new BufferedStream(fs))
        {
          var serializer = new SharpSerializer();
          return serializer.Deserialize(bs);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private static void SerializeCompressed<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var gs = new GZipStream(fs, CompressionLevel.Fastest))
        using (var bs = new BufferedStream(gs))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(bs, obj);
        }
      }
      catch (Exception ex)
      {
        if (LogErrors)
          InMemoryErrorConsole.Log(ex);
      }
    }

    private static void SerializeUncompressed<T>(T obj, string path)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(bs, obj);
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
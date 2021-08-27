#region usings

using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace CorpusExplorer.Sdk.Data.Helper
{
  public static class Serializer
  {
    public static T DeserializeCompressed<T>(string path) where T : class
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        using (var gs = new GZipStream(fs, CompressionMode.Decompress))
        {
          var bf = new BinaryFormatter();
          return bf.Deserialize(gs) as T;
        }
      }
    }

    public static void SerializeCompressed(object obj, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        using (var gs = new GZipStream(fs, CompressionMode.Compress))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(gs, obj);
        }
      }
    }

    public static byte[] SerializeInMemory(object obj)
    {
      byte[] res;
      using (var ms = new MemoryStream())
      {
        using (var gs = new GZipStream(ms, CompressionMode.Compress))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(gs, obj);

          gs.Seek(0, SeekOrigin.Begin);
          res = new byte[gs.Length];
          gs.Read(res, 0, res.Length);
        }
      }
      return res;
    }

    public static T DeserializeInMemory<T>(byte[] data) where T : class
    {
      T res;
      using (var ms = new MemoryStream(data))
      {
        using (var gs = new GZipStream(ms, CompressionMode.Compress))
        {
          var bf = new BinaryFormatter();
          res = bf.Deserialize(gs) as T;
        }
      }
      return res;
    }
  }
}
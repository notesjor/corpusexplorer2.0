using System.IO;
using System.Text;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Helper
{
  public static class XmlSerializerHelper
  {
    public static T Deserialize<T>(string path) where T : class
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        return Deserialize<T>(fs);
    }

    public static T Deserialize<T>(Stream stream, Encoding forceEncoding = null) where T : class
    {
      using (var bs = new BufferedStream(stream))
      using (var read = new StreamReader(bs, forceEncoding ?? Configuration.Encoding))
      {
        var xml = new XmlSerializer(typeof(T));
        return xml.Deserialize(read) as T;
      }
    }

    public static void Serialize<T>(T obj, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        Serialize<T>(obj, fs);
    }

    public static void Serialize<T>(T obj, Stream stream)
    {
      using (var bs = new BufferedStream(stream))
      {
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(bs, obj);
      }
    }
  }
}

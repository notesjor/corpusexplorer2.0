using System;
using System.IO;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper
{
  public abstract class AbstractGenericZipSerializer<T> : AbstractGenericSerializer<T>
    where T : class
  {
    protected abstract string XmlManifestFilename { get; }

    public override T Deserialize(string path)
    {
      DeserializePreValidation(path);
      T res = null;

      var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
      Directory.CreateDirectory(tempPath);

      try
      {
        ZipHelper.Uncompress(path, tempPath);

        using (var fs = new FileStream(Path.Combine(tempPath, XmlManifestFilename), FileMode.Open, FileAccess.Read))
        using (var bs = new BufferedStream(fs))
        {
          var xml = new XmlSerializer(typeof(T));
          res = xml.Deserialize(bs) as T;
        }

        DeserializePostValidation(res, path);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
      finally
      {
        Directory.Delete(tempPath, true);
      }

      return res;
    }

    public override void Serialize(T obj, string path)
    {
      SerializePreValidation(obj, path);

      var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
      Directory.CreateDirectory(tempPath);

      try
      {
        using (var fs = new FileStream(Path.Combine(tempPath, XmlManifestFilename), FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          var xml = new XmlSerializer(typeof(T));
          xml.Serialize(bs, obj);
        }

        SerializePostValidation(obj, path);

        ZipHelper.Compress(tempPath, path);
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
      finally
      {
        Directory.Delete(tempPath, true);
      }
    }
  }
}
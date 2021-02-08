#region

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper.Delegates;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper
{
  public abstract class AbstractGenericSerializer<T>
    where T : class
  {
    public virtual T Deserialize(string path)
    {
      var retryCount = 1000;
      var retry = false;
      do
      {
        try
        {
          DeserializePreValidation(path);
          T res;

          using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
          using (var bs = new BufferedStream(fs))
          using (var read = new StreamReader(bs, Configuration.Encoding))
          {
            var xml = new XmlSerializer(typeof(T));
            res = xml.Deserialize(read) as T;
          }

          DeserializePostValidation(res, path);

          return res;
        }
        catch (Exception ex)
        {
          if (OnException != null)
          {
            retry = OnException.Invoke(path, ex);
            retryCount--;
          }
        }
      } while (retry && retryCount > 0);

      return default(T);
    }

    public event ExceptionDelegate OnException;

    public virtual T Deserialize(MemoryStream ms)
    {
      try
      {
        T res;

        var xml = new XmlSerializer(typeof(T));
        res = xml.Deserialize(ms) as T;

        return res;
      }
      catch (Exception ex)
      {
        return default(T);
      }
    }

    public virtual void Serialize(T obj, string path)
    {
      SerializePreValidation(obj, path);

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fs))
      {
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(bs, obj);
      }

      SerializePostValidation(obj, path);
    }

    public virtual void Serialize(T obj, Stream stream)
    {
      using (var bs = new BufferedStream(stream))
      {
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(bs, obj);
      }
    }

    protected void CheckFileExtension(string path, string ext)
    {
      if (!path.ToLower().EndsWith(ext.ToLower()))
        throw new FileLoadException("File must have a ." + ext + "-Extension");
    }

    // ReSharper disable UnusedParameter.Global
    protected abstract void DeserializePostValidation(T obj, string path);
    protected abstract void DeserializePreValidation(string path);
    protected abstract void SerializePostValidation(T obj, string path);

    protected abstract void SerializePreValidation(T obj, string path);
    // ReSharper restore UnusedParameter.Global
  }
}
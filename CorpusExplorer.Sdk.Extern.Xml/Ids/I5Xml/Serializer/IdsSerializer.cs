using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Serializer
{
  public class IdsSerializer : AbstractGenericSerializer<idsCorpus>
  {
    protected override void DeserializePostValidation(idsCorpus obj, string path)
    {

    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");

      if (!File.Exists(path + ".bak"))
      {
        File.Copy(path, path + ".bak");
        var text = File.ReadAllText(path, Encoding.GetEncoding("ISO-8859-1"));
        File.WriteAllText(path, text, Encoding.UTF8);
      }
    }

    protected override void SerializePostValidation(idsCorpus obj, string path)
    {

    }

    protected override void SerializePreValidation(idsCorpus obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}

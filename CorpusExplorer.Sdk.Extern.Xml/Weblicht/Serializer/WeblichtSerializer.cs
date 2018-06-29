using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Serializer
{
  public class WeblichtSerializer : AbstractGenericSerializer<DSpin>
  {
    protected override void DeserializePostValidation(DSpin obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(DSpin obj, string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding);
      lines[1] = "<D-Spin xmlns=\"http://www.dspin.de/data\" version=\"0.4\">";
      FileIO.Write(path, lines, Configuration.Encoding);
    }

    protected override void SerializePreValidation(DSpin obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}
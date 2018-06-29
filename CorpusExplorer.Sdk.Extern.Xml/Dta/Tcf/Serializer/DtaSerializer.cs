using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Serializer
{
  public class DtaSerializer : AbstractGenericSerializer<DSpin>
  {
    protected override void DeserializePostValidation(DSpin obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "tcf.xml");
    }

    protected override void SerializePostValidation(DSpin obj, string path)
    {
    }

    protected override void SerializePreValidation(DSpin obj, string path)
    {
      CheckFileExtension(path, "tcf.xml");
    }
  }
}
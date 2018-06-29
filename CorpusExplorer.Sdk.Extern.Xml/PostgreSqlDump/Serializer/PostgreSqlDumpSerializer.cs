using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Serializer
{
  public class PostgreSqlDumpSerializer : AbstractGenericSerializer<data>
  {
    protected override void DeserializePostValidation(data obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(data obj, string path)
    {
    }

    protected override void SerializePreValidation(data obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}
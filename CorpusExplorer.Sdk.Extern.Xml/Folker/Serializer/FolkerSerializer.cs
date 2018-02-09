#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Serializer
{
  public class FolkerSerializer : AbstractGenericSerializer<folkertranscription>
  {
    protected override void DeserializePostValidation(folkertranscription obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "flk"); }

    protected override void SerializePostValidation(folkertranscription obj, string path) { }

    protected override void SerializePreValidation(folkertranscription obj, string path)
    {
      CheckFileExtension(path, "flk");
    }
  }
}
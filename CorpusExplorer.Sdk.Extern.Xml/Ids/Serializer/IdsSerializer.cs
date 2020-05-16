using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Serializer
{
  public class IdsSerializer : AbstractGenericSerializer<idsCorpus>
  {
    protected override void DeserializePostValidation(idsCorpus obj, string path)
    {
      
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
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

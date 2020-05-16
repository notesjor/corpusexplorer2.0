using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Serializer
{
  public class BncSerializer : AbstractGenericSerializer<bncDoc>
  {
    protected override void DeserializePostValidation(bncDoc obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(bncDoc obj, string path)
    {
    }

    protected override void SerializePreValidation(bncDoc obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Bawe.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Bawe.Serializer
{
  public class BaweSerializer : AbstractGenericSerializer<TEI2>
  {
    protected override void DeserializePostValidation(TEI2 obj, string path)
    {
      
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(TEI2 obj, string path)
    {
      
    }

    protected override void SerializePreValidation(TEI2 obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}

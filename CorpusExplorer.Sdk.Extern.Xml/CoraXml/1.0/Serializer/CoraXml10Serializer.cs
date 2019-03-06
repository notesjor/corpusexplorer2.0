using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Serializer
{
  public class CoraXml10Serializer : AbstractGenericSerializer<text>
  {
    protected override void DeserializePostValidation(text obj, string path)
    {
      
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
    }

    protected override void SerializePostValidation(text obj, string path)
    {
      
    }

    protected override void SerializePreValidation(text obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}

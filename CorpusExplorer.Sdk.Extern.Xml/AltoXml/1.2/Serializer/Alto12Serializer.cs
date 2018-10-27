using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Serializer
{
  public class Alto12Serializer : AbstractGenericSerializer<alto>
  {
    protected override void DeserializePostValidation(alto obj, string path)
    {
      
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
    }

    protected override void SerializePostValidation(alto obj, string path)
    {
      
    }

    protected override void SerializePreValidation(alto obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}

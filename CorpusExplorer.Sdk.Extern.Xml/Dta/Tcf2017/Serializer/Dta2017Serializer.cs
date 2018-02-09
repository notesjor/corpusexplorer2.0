using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Serializer
{
  public class Dta2017Serializer : AbstractGenericSerializer<DSpin>
  {
    protected override void DeserializePostValidation(DSpin obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "tcf.xml"); }

    protected override void SerializePostValidation(DSpin obj, string path) { }

    protected override void SerializePreValidation(DSpin obj, string path) { CheckFileExtension(path, "tcf.xml"); }
  }
}

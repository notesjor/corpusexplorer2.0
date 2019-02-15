using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model.Extension
{
  public static class sourceDescExtension
  {
    public static biblStruct GetBiblStruct(this sourceDesc sd)
      => sd.Item as biblStruct;
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Extension
{
  public static class InterventionExtension
  {
    public static IEnumerable<p> GetPs(this intervention i)
      => i?.Items.OfType<p>();
  }
}

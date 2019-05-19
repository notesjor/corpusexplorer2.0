using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Extension
{
  public static class AnnoExtension
  {
    public static IEnumerable<lemma> GetLemmas(this anno anno)
      => anno.Items.OfType<lemma>();
    public static IEnumerable<lemma_simple> GetSimpleLemmas(this anno anno)
      => anno.Items1.OfType<lemma_simple>();
    public static IEnumerable<morph> GetMorphs(this anno anno)
      => anno.Items1.OfType<morph>();
    public static IEnumerable<pos> GetPos(this anno anno)
      => anno.Items1.OfType<pos>();
    public static IEnumerable<bound_sent> GetBoundSent(this anno anno)
      => anno.Items2.OfType<bound_sent>();
  }
}

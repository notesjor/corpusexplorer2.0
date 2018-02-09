#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;
using item = CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model.item;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SourceDescListExtension
  {
    public static IEnumerable<item> GetAllCastedItems(this sourceDescList sourceDescList)
    {
      return sourceDescList.Items.OfType<item>().Select(o => o);
    }

    public static IEnumerable<label> GetAllLabels(this sourceDescList sourceDescList)
    {
      return sourceDescList.Items.OfType<label>().Select(o => o);
    }
  }
}
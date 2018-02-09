#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class InterlineartextExtension
  {
    public static IEnumerable<itbundle> GetAllItbundles(this interlineartext interlineartext)
    {
      return interlineartext.Items.OfType<itbundle>().Select(o => o);
    }

    public static IEnumerable<line> GetAllLines(this interlineartext interlineartext)
    {
      return interlineartext.Items.OfType<line>().Select(o => o);
    }

    public static IEnumerable<pagebreak> GetAllPagebreaks(this interlineartext interlineartext)
    {
      return interlineartext.Items.OfType<pagebreak>().Select(o => o);
    }
  }
}
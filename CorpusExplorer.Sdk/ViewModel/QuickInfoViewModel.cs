#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class QuickInfoViewModel : AbstractViewModel
  {
    public int CountCorpora { get; private set; }
    public int CountDocuments { get; private set; }
    public int CountLayers { get; private set; }
    public long CountTokens { get; private set; }

    /// <summary>
    ///   The analyse.
    /// </summary>
    protected override void ExecuteAnalyse()
    {
      CountCorpora = Selection.CountCorpora;
      CountDocuments = Selection.CountDocuments;
      CountLayers = new HashSet<string>(Selection.LayerDisplaynames).Count();
      CountTokens = Selection.CountToken;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}
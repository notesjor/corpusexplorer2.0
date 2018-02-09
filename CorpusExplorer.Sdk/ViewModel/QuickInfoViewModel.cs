#region

using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class QuickInfoViewModel : AbstractViewModel
  {
    public int CounterCorpora { get; private set; }
    public int CounterDocuments { get; private set; }
    public int CounterLayers { get; private set; }
    public int CounterTokens { get; private set; }

    /// <summary>
    ///   The analyse.
    /// </summary>
    protected override void ExecuteAnalyse()
    {
      CounterCorpora = Selection.CountCorpora;
      CounterDocuments = Selection.CountDocuments;
      CounterLayers = Selection.LayerGuids.Count();
      CounterTokens = Selection.CountToken;      
    }

    protected override bool Validate() { return true; }
  }
}
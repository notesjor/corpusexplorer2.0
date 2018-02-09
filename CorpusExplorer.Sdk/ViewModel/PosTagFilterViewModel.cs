using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class PosTagFilterViewModel : AbstractViewModel
  {
    private Dictionary<string, HashSet<string>> _data;

    public IEnumerable<string> AvailableTags => _data.Keys;

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CorrespondingLayerValueBlock>();
      block.Layer1Displayname = "POS";
      block.Layer2Displayname = "Wort";
      block.Calculate();

      _data = block.CorrespondingLayerValues;
    }

    public HashSet<string> GetValidCases(IEnumerable<string> tags)
    {
      var res = new HashSet<string>();

      foreach (var x in tags)
        if (_data.ContainsKey(x))
          foreach (var y in _data[x])
            res.Add(y);

      return res;
    }

    protected override bool Validate() { return Selection.ContainsLayer("POS") && Selection.ContainsLayer("Wort"); }
  }
}
#region

using System.Data;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  public class CutOffPhraseBlock : AbstractBlock
  {
    private TextLiveSearchViewModel _vm;
    public string LayerDisplayname1 { get; set; } = "Wort";
    public string LayerDisplayname2 { get; set; } = "Wort";
    public string LayerQuery1 { get; set; }
    public string LayerQuery2 { get; set; }

    public DataTable GetUniqueDataTableCutOffPhrase() => _vm?.GetUniqueDataTableCutOffPhrase();
    public DataTable GetUniqueDataTableCutOffPhraseGui() => _vm?.GetUniqueDataTableCutOffPhraseGui();

    public override void Calculate()
    {
      var selection = Selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerAnyMatch
        {
          Inverse = false,
          LayerQueries = new[] { LayerQuery1 },
          LayerDisplayname = LayerDisplayname1
        }
      });
      selection = selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerAnyMatch

        {
          Inverse = false,
          LayerQueries = new[] { LayerQuery2 },
          LayerDisplayname = LayerDisplayname2
        }
      });

      _vm = new TextLiveSearchViewModel { Selection = selection };
      _vm.ClearQueries();

      _vm.AddQuery(new FilterQueryDualLayerAFollowedByBMatch
      {
        Inverse = false,
        LayerQuery1 = LayerQuery1,
        LayerQuery2 = LayerQuery2,
        LayerDisplayname1 = LayerDisplayname1,
        LayerDisplayname2 = LayerDisplayname2,
        OrFilterQueries = new[]
        {
          new FilterQueryDualLayerAFollowedByBMatch
          {
            Inverse = false,
            LayerQuery1 = LayerQuery2,
            LayerQuery2 = LayerQuery1,
            LayerDisplayname1 = LayerDisplayname2,
            LayerDisplayname2 = LayerDisplayname1,
          }
        }
      });
      _vm.Execute();
    }
  }
}
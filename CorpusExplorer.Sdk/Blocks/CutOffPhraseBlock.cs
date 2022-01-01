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
    public string LayerDisplayname { get; set; } = "Wort";
    public string LayerQuery1 { get; set; }
    public string LayerQuery2 { get; set; }

    public DataTable UniqueDataTableGui { get; set; }

    public override void Calculate()
    {
      var selection = Selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerAllInOneSentence
        {
          Inverse = false,
          LayerQueries = new[] { LayerQuery1, LayerQuery2 },
          LayerDisplayname = LayerDisplayname
        }
      });

      var vm = new TextLiveSearchViewModel { Selection = selection };
      vm.ClearQueries();

      vm.AddQuery(new FilterQuerySingleLayerAFollowedByBMatch
      {
        Inverse = false,
        LayerQuery1 = LayerQuery1,
        LayerQuery2 = LayerQuery2,
        LayerDisplayname = LayerDisplayname,
        OrFilterQueries = new[]
        {
          new FilterQuerySingleLayerFirstFollowedByAnyOtherMatch
          {
            Inverse = false,
            LayerQueries = new[] { LayerQuery2, LayerQuery1 },
            LayerDisplayname = LayerDisplayname
          }
        }
      });
      vm.Execute();

      UniqueDataTableGui = vm.GetUniqueDataTableCutOffPhrase();
    }
  }
}
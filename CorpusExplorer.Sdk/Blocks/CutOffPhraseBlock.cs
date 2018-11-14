using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CutOffPhraseBlock : AbstractBlock
  {
    public string LayerDisplayname { get; set; } = "Wort";
    public string LayerQuery1 { get; set; }
    public string LayerQuery2 { get; set; }
    public int WordSpan { get; set; }

    public override void Calculate()
    {
      var vm = new TextLiveSearchViewModel { Selection = Selection };
      vm.ClearQueries();
      vm.AddQuery(WordSpan < 1
                    ? (AbstractFilterQuery)
                    new FilterQuerySingleLayerAllInOneSentence
                    {
                      Inverse = false,
                      LayerQueries = new[] {LayerQuery1, LayerQuery2},
                      LayerDisplayname = LayerDisplayname
                    }
                    : new FilterQuerySingleLayerAllInSpanWords
                    {
                      Inverse = false,
                      LayerQueries = new[] {LayerQuery1, LayerQuery2},
                      WordSpan = WordSpan,
                      LayerDisplayname = LayerDisplayname
                    });
      vm.Execute();

      UniqueDataTableGui = vm.GetUniqueDataTableGui();
    }

    public DataTable UniqueDataTableGui { get; set; }
  }
}

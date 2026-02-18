using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CutOffPhraseViewModel : AbstractViewModel, IProvideDataTable
  {
    private CutOffPhraseBlock _block;

    public string LayerQuery2 { get; set; } = "";

    public string LayerQuery1 { get; set; } = "";

    public string LayerDisplayname1 { get; set; } = "Wort";

    public string LayerDisplayname2 { get; set; } = "Wort";

    public DataTable GetUniqueDataTableCutOffPhrase() => _block?.GetUniqueDataTableCutOffPhrase();
    public DataTable GetUniqueDataTableCutOffPhraseGui() => _block?.GetUniqueDataTableCutOffPhraseGui();

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<CutOffPhraseBlock>();
      _block.LayerDisplayname1 = LayerDisplayname1;
      _block.LayerDisplayname2 = LayerDisplayname2;
      _block.LayerQuery1 = LayerQuery1;
      _block.LayerQuery2 = LayerQuery2;
      _block.Calculate();
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname1)
          && !string.IsNullOrEmpty(LayerDisplayname2)
          && !string.IsNullOrEmpty(LayerQuery1)
          && !string.IsNullOrEmpty(LayerQuery2);
    }

    public DataTable GetDataTable() => GetUniqueDataTableCutOffPhraseGui();
  }
}
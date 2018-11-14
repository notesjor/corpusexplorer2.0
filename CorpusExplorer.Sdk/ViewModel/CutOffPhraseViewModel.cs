using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CutOffPhraseViewModel : AbstractViewModel, IProvideDataTable
  {
    private DataTable _dataTable;

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CutOffPhraseBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQuery1 = LayerQuery1;
      block.LayerQuery2 = LayerQuery2;
      block.WordSpan = WordSpan;
      block.Calculate();

      _dataTable = block.UniqueDataTableGui;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname)
          && !string.IsNullOrEmpty(LayerQuery1)
          && !string.IsNullOrEmpty(LayerQuery2);
    }

    public int WordSpan { get; set; } = 15;

    public string LayerQuery2 { get; set; } = "";

    public string LayerQuery1 { get; set; } = "";

    public string LayerDisplayname { get; set; } = "Wort";

    public DataTable GetDataTable()
      => _dataTable;
  }
}

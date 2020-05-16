using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.ViewModel
{
  public class DocumentRollingHashViewModel : AbstractViewModel, IProvideDataTable, IUseSpecificLayer
  {
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DocumentRollingHashBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      DocumentHashes = block.DocumentHashes;
    }

    public Dictionary<Guid, string> DocumentHashes { get; set; }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname);
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("GUID", typeof(string));
      dt.Columns.Add("HASH", typeof(string));

      dt.BeginLoadData();
      foreach (var hash in DocumentHashes)
        dt.Rows.Add(hash.Key.ToString("N"), hash.Value);
      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<string> LayerDisplaynames => new[] { LayerDisplayname };
    public string LayerDisplayname { get; set; } = "Wort";
  }
}

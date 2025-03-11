using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class BurrowsDeltaViewModel : AbstractViewModel, IProvideDataTable
  {
    private BurrowsDeltaBlock _block;

    public IEnumerable<string> KnownAuthorNames => KnownAuthors.Keys;

    public Dictionary<string, Dictionary<string, double>> KnownAuthors => _block.KnownAuthors;

    public string MetadataKey { get; set; } = "Autor";

    public int MFWCount { get; set; } = 2000;

    public KeyValuePair<string, double> GetBestMatchingAuthor(Selection selectionToCompare)
    {
      var tmp = _block.Compare(selectionToCompare).CompareResults;
      var res = new KeyValuePair<string, double>("", 0);
      foreach (var x in tmp.Where(x => x.Value > res.Value))
        res = x;
      return res;
    }

    public Dictionary<string, double> GetMatchingAuthors(Selection selectionToCompare, double threshold)
    {
      return _block.Compare(selectionToCompare)
                   .CompareResults.Where(x => x.Value > threshold)
                   .ToDictionary(x => x.Key, x => x.Value);
    }

    public Dictionary<string, double> GetProfile(Selection selectionToCompare)
    {
      return _block.Compare(selectionToCompare).CompareProfile;
    }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<BurrowsDeltaBlock>();
      _block.MFWCount = MFWCount;
      _block.MetadataKey = MetadataKey;
      _block.Calculate();
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(MetadataKey);
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add($"{MetadataKey} (A)", typeof(string));
      dt.Columns.Add($"{MetadataKey} (B)", typeof(string));
      dt.Columns.Add("Delta", typeof(double));

      dt.BeginLoadData();
      foreach (var x in KnownAuthors)
        foreach (var y in x.Value.Where(y => x.Key != y.Key))
          dt.Rows.Add(x.Key, y.Key, y.Value);
        
      dt.EndLoadData();

      return dt;
    }
  }
}
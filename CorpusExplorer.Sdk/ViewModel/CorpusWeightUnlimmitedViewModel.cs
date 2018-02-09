using CorpusExplorer.Sdk.Properties;

#region

using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CorpusWeightUnlimmitedViewModel : AbstractViewModel, IProvideDataTable
  {
    private DocumentMetadataWeightBlock _block;

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.Category, typeof(string));
      res.Columns.Add(Resources.MetadataLabel, typeof(string));
      res.Columns.Add(Resources.Token, typeof(int));
      res.Columns.Add(Resources.Types, typeof(int));
      res.Columns.Add(Resources.Documents, typeof(int));

      if (_block?.MetaDataDictionary == null)
        return res;
      var dic = _block.GetAggregatedSize();
      if (dic == null)
        return res;

      res.BeginLoadData();
      foreach (var e1 in dic)
      foreach (var e2 in e1.Value)
        res.Rows.Add(e1.Key, e2.Key, e2.Value[0], e2.Value[1], e2.Value[2]);
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<DocumentMetadataWeightBlock>();
      _block.Calculate();
    }

    protected override bool Validate() { return true; }
  }
}
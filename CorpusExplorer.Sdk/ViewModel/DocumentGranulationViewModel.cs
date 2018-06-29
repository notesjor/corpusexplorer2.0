using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentGranulationViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    public DocumentGranulationViewModel()
    {
      DocumentGranulation = 100;
      SentenceGranulation = 10;
    }

    public int DocumentFrequencySum { get; set; }
    public int DocumentGranulation { get; set; }
    public double[] GranulatedDocument { get; set; }
    public double[] GranulatedSentence { get; set; }

    public IEnumerable<string> Layers => Selection.LayerDisplaynames;

    public IEnumerable<string> Queries { get; set; }
    public int SentenceFrequencySum { get; set; }
    public int SentenceGranulation { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Segment", typeof(int));
      res.Columns.Add("Relative Frequenz", typeof(double));

      res.BeginLoadData();
      for (var i = 0; i < GranulatedDocument.Length; i++)
        res.Rows.Add(i, GranulatedDocument[i]);
      res.EndLoadData();

      return res;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block1 = Selection.CreateBlock<DocumentFrequenceDistributionBlock>();
      block1.Granulation = DocumentGranulation;
      block1.LayerDisplayname = LayerDisplayname;
      block1.Queries = Queries;
      block1.Calculate();

      GranulatedDocument = block1.GranulatedDocument;
      DocumentFrequencySum = block1.FrequencySum;

      var block2 = Selection.CreateBlock<SentenceFrequenceDistributionBlock>();
      block2.Granulation = SentenceGranulation;
      block2.LayerDisplayname = LayerDisplayname;
      block2.Queries = Queries;
      block2.Calculate();

      GranulatedSentence = block2.GranulatedSentence;
      SentenceFrequencySum = block2.FrequencySum;
    }

    protected override bool Validate()
    {
      return Queries != null && Queries.Count() != 0;
    }
  }
}
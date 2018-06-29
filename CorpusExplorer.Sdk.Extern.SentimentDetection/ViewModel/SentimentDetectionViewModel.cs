using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Blocks;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.ViewModel
{
  public class SentimentDetectionViewModel : AbstractViewModel, IProvideDataTable
  {
    public SentimentDetectionTagModel Model { get; set; }
    private Guid _selectionGuid = Guid.Empty;

    protected override void ExecuteAnalyse()
    {
      if (Selection.Guid != _selectionGuid)
        Model.Compile(Selection.GetLayerValues("Wort"));

      var block = Selection.CreateBlock<SentimentDetectionBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Model = Model;
      block.Calculate();

      DocumentSentimentCount = block.DocumentSentimentCount;
    }

    public Dictionary<Guid, Dictionary<string, Dictionary<string, int>>> DocumentSentimentCount { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public void Load(string modelPath)
    {
      Model = SentimentDetectionTagModel.Load(modelPath);
    }

    protected override bool Validate()
    {
      return Model != null;
    }

    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Meta-Kategorie", typeof(string));     
      res.Columns.Add("Meta-Wert", typeof(string));      
      res.Columns.Add("Sentiment-Kategorie", typeof(string)); 
      res.Columns.Add("Sentiment-Item", typeof(string));
      res.Columns.Add("Sentiment-Wert", typeof(double));
      res.Columns.Add("Frequenz", typeof(double));
      res.Columns.Add("Sentiment-Wert * Frequenz", typeof(double));

      res.BeginLoadData();

      foreach (var dsel in DocumentSentimentCount)
      {
        var meta = Selection.GetDocumentMetadata(dsel.Key);
        if (meta == null)
          continue;

        foreach (var m in meta)
          foreach (var mk in dsel.Value)
          foreach (var mi in mk.Value)
            res.Rows.Add(m.Key, m.Value, mk.Key, mi.Key, Model.Data[mk.Key][mi.Key], mi.Value, Model.Data[mk.Key][mi.Key] * mi.Value);       
      }

      res.EndLoadData();
      return res;
    }
  }
}

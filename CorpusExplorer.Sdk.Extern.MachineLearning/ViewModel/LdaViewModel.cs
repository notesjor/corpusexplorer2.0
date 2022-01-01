using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks;
using CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel
{
  public class LdaViewModel : AbstractViewModel, IProvideDataTable
  {
    private LdaBlock _block;
    
    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<LdaBlock>();
      _block.Configuration = Configuration;
      _block.Calculate();

      DocumentPredictions = _block.DocumentPredictions;
      Topics = _block.Topics;
    }

    public LdaConfiguration Configuration { get; set; } = new LdaConfiguration();

    public Dictionary<string, float>[] Topics { get; set; }

    public Dictionary<Guid, float[]> DocumentPredictions { get; set; }

    public void Save(string path) => _block.ModelSave(path);

    public void Load(string path) => _block.ModelLoad(path);

    protected override bool Validate() => true;

    public DataTable GetDataTable() 
      => GetDataTableDocuments();

    public DataTable GetDataTableTopics()
    {
      if (_block == null)
        return null;

      var dict = GetTopicDictionary();

      var dt = new DataTable();
      dt.Columns.Add(Configuration.LayerDisplayname, typeof(string));
      var max = DocumentPredictions.First().Value.Length;
      for (var i = 0; i < max; i++)
        dt.Columns.Add($"TOPIC_{i + 1:D3}", typeof(float));

      dt.BeginLoadData();
      foreach (var token in dict)
      {
        var row = new List<object> { token };
        foreach (var topic in Topics)
        {
          if(topic.ContainsKey(token))
            row.Add(topic[token]);
          else
            row.Add(0);
        }

        dt.Rows.Add(row.ToArray());

      }
      dt.EndLoadData();

      return dt;
    }

    private HashSet<string> GetTopicDictionary()
    {
      var dict = new List<string>();
      foreach (var x in Topics)
        dict.AddRange(x.Keys);
      return new HashSet<string>(dict);
    }

    public DataTable GetDataTableDocuments()
    {
      if (_block == null)
        return null;

      var dt = new DataTable();
      dt.Columns.Add("GUID", typeof(string));
      var max = DocumentPredictions.First().Value.Length;
      for (var i = 0; i < max; i++)
        dt.Columns.Add($"TOPIC_{i + 1:D3}", typeof(float));

      dt.BeginLoadData();
      foreach (var d in DocumentPredictions)
      {
        var row = new List<object> { d.Key.ToString() };
        row.AddRange(d.Value.Cast<object>());
        dt.Rows.Add(row.ToArray());
      }
      dt.EndLoadData();

      return dt;
    }
  }
}

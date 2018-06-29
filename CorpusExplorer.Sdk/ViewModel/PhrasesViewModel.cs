#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class PhrasesViewModel : AbstractViewModel
  {
    public string LayerDisplayname { get; set; } = "Wort";
    public int MinimalPhrasesLength { get; set; } = 2;
    public Dictionary<string, double> Phrases { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Phrase", typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      res.BeginLoadData();
      foreach (var p in Phrases)
        res.Rows.Add(p.Key, p.Value);
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<PhrasesBlock>();
      block.Layer2Displayname = LayerDisplayname;
      block.Calculate();

      Phrases = block.Phrases;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname);
    }

    private Dictionary<string, double> FilterAndMergePhrases(Dictionary<string[], double> phrases)
    {
      var dictionary = new Dictionary<string, double>();
      foreach (var phrase in phrases)
      {
        if (phrase.Key.Length < MinimalPhrasesLength)
          continue;

        var key = string.Join(" ", phrase.Key);
        if (dictionary.ContainsKey(key))
          dictionary[key] += phrase.Value;
        else
          dictionary.Add(key, phrase.Value);
      }

      return dictionary;
    }
  }
}
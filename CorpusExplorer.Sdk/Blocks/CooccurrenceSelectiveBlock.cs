using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  [XmlRoot]
  [Serializable]
  public class CooccurrenceSelectiveBlock : AbstractBlock
  {
    public Dictionary<string, double> CooccurrenceFrequency { get; set; }

    public Dictionary<string, double> CooccurrenceSignificance { get; set; }

    [XmlElement]
    public string LayerDisplayname { get; set; } = "Wort";

    [XmlArray]
    public string[] LayerQueries { get; set; }

    public override void Calculate()
    {
      var n = Selection.CountSentences;
      var selection = Selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerExactPhrase
        {
          LayerDisplayname = LayerDisplayname,
          LayerQueries = LayerQueries
        }
      });

      var blockA = selection.CreateBlock<Frequency1LayerOnlyMatchSentenceOneOccurrenceBlock>();
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.Calculate();

      if (blockA.Frequency == null)
        return;

      var a = blockA.SentenceCount;
      CooccurrenceFrequency = blockA.Frequency;

      var blockB = Selection.CreateBlock<Frequency1LayerOneOccurrencePerSentenceBlock>();
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.Calculate();

      // Signifikanz

      var sign = Configuration.GetSignificance(a, n);

      var ignore = new HashSet<string>(LayerQueries);
      var dictionary = new Dictionary<string, double>();
      foreach (var k in CooccurrenceFrequency)
      {
        if (ignore.Contains(k.Key))
          continue;
        try
        {
          var sig = sign.Calculate(blockB.Frequency[k.Key], k.Value);
          if (double.IsInfinity(sig) || double.IsNaN(sig) || sig < Configuration.MinimumSignificance)
            continue;
          dictionary.Add(k.Key, sig);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      }

      CooccurrenceSignificance = dictionary;
    }
  }
}
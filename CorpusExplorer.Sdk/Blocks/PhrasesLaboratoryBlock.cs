using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class PhrasesLaboratoryBlock : AbstractSimple2LayerBlock
  {
    private readonly object _phrasesLock = new object();

    public PhrasesLaboratoryBlock()
    {
      Layer1Displayname = "Wort";
      Layer2Displayname = "POS";
    }

    public PhraseGrammar Grammar { get; set; }
    public Dictionary<Guid, Constituent[][]> Phrases { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="layer1">
    ///   Layer 1
    /// </param>
    /// <param name="doc1">
    ///   Dokument 1
    /// </param>
    /// <param name="layer2">
    ///   Layer 2
    /// </param>
    /// <param name="doc2">
    ///   Dokument 2
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2)
    {
      if (doc1 == null ||
          doc2 == null ||
          doc1.Length != doc2.Length)
        return;

      var array = new Constituent[doc1.Length][];

      Parallel.For(
        0,
        doc1.Length,
        i =>
        {
          if (doc1[i] == null ||
              doc2[i] == null ||
              doc1[i].Length != doc2[i].Length)
            return;

          array[i] = GetBaseConstituents(layer1, doc1[i], layer2, doc2[i]).ToArray();
        });

      lock (_phrasesLock)
      {
        if (!Phrases.ContainsKey(dsel))
          Phrases.Add(dsel, array);
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup() { }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize() { }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      Phrases = new Dictionary<Guid, Constituent[][]>();
    }

    private static List<Constituent> GetBaseConstituents(
      AbstractLayerAdapter layer1,
      int[] sent1,
      AbstractLayerAdapter layer2,
      int[] sent2)
    {
      // Werden hier Änderungen vorgenommen, dann müssen auch in:
      // PhrasesLaboratoryViewModel > GetBaseConstituentsInline
      // berücksichtigt werden

      var termianls = new List<Constituent>();
      for (var i = 0; i < sent1.Length; i++)
      {
        var nt = new Constituent(layer2[sent2[i]], true);
        nt.Add(layer1[sent1[i]], true);
        termianls.Add(nt);
      }
      return termianls;
    }

    public IEnumerable<Constituent> GetParsedConstituent(Guid documentGuid, int sentenceIndex)
    {
      return Grammar.ParseSentence(Phrases[documentGuid][sentenceIndex]);
    }

    public IEnumerable<IEnumerable<Constituent>> GetParsedConstituent(Guid documentGuid)
    {
      return Grammar.ParseDocument(Phrases[documentGuid]);
    }

    public IEnumerable<Constituent> GetParsedConstituent()
    {
      return from doc in Phrases from s in Grammar.ParseDocument(doc.Value) from c in s select c;
    }

    public Dictionary<string, Dictionary<string, double>> GetParsedConstituentFrequency(string separator = " ")
    {
      var res = new Dictionary<string, Dictionary<string, double>>();
      foreach (var c in GetParsedConstituent())
      {
        var key2 = string.Join(separator, c.Childs.Select(x => x.Label));

        if (res.ContainsKey(c.Label))
          if (res[c.Label].ContainsKey(key2))
            res[c.Label][key2]++;
          else
            res[c.Label].Add(key2, 1);
        else
          res.Add(c.Label, new Dictionary<string, double> {{key2, 1}});
      }
      return res;
    }

    public IEnumerable<Constituent> GetRawConstituent(Guid documentGuid, int sentenceIndex)
    {
      return Phrases[documentGuid][sentenceIndex];
    }

    public IEnumerable<IEnumerable<Constituent>> GetRawConstituent(Guid documentGuid) { return Phrases[documentGuid]; }

    public IEnumerable<Constituent> GetRawConstituent()
    {
      return from doc in Phrases from sen in doc.Value from con in sen select con;
    }
  }
}
#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.PhrasesLaboratory
{
  [Serializable]
  public class PhraseGrammar
  {
    public PhraseGrammar() => Rules = new Dictionary<int, List<AbstractGrammarRule>>();

    public Dictionary<int, List<AbstractGrammarRule>> Rules { get; set; }

    public Dictionary<string, Dictionary<string, double>> CountDocument(Constituent[][] terminals)
    {
      var res = new Dictionary<string, Dictionary<string, double>>();

      var doc = ParseDocument(terminals);

      foreach (var constituent in doc.SelectMany(sentence => sentence))
        DictionaryMergeHelper.Merge2LevelDictionary(ref res, constituent.GetChildFrequency(), (x, y) => x + y);

      return res;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ReturnTypeCanBeEnumerable.Global
    public Constituent[][] ParseDocument(Constituent[][] terminals)
    {
      Parallel.For(0, terminals.Length, Configuration.ParallelOptions,
                   i => { terminals[i] = ParseSentence(terminals[i].ToList()).ToArray(); });

      return terminals;
    }

    public IEnumerable<Constituent> ParseSentence(IEnumerable<Constituent> terminals)
    {
      var sentence = terminals.ToList();

      foreach (var level in Rules)
      {
        int levelCount;
        do
        {
          levelCount = sentence.Count;
          foreach (var rule in level.Value)
          {
            int ruleCount;
            do
            {
              ruleCount = sentence.Count;
              for (var j = 0; j < sentence.Count; j++)
              {
                var items = rule.Match(ref sentence, j);
                if (items == null)
                  continue;

                var arr = items.ToArray();
                sentence.Insert(j, new Constituent(rule.Label, false, arr));
                foreach (var x in arr)
                  sentence.Remove(x);
              }
            } while (rule.IsRecursive &&
                     sentence.Count != ruleCount);
          }
        } while (sentence.Count != levelCount);
      }

      return sentence;
    }
  }
}
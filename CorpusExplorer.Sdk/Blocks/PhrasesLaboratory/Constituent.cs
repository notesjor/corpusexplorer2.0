using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.Blocks.PhrasesLaboratory
{
  [Serializable]
  public class Constituent : CeObject
  {
    private readonly List<Constituent> _items;

    public Constituent(string label, bool isBase)
    {
      Label = label;
      IsBase = isBase;
      _items = new List<Constituent>();
    }

    public Constituent(string label, bool isBase, IEnumerable<Constituent> items)
    {
      Label = label;
      IsBase = isBase;
      _items = items.ToList();
    }

    private Constituent()
    {
    }

    public IEnumerable<Constituent> Childs => _items;

    public bool IsBase { get; }
    public string Label { get; }

    public void Add(string label, bool isBase)
    {
      _items.Add(new Constituent(label, isBase));
    }

    public void Add(Constituent item)
    {
      _items.Add(item);
    }

    public Dictionary<string, Dictionary<string, double>> GetChildFrequency()
    {
      var res = new Dictionary<string, Dictionary<string, double>>();
      var items = new List<string>();

      foreach (var child in Childs)
      {
        items.Add(child.Label);
        if (child.Childs == null ||
            !child.Childs.Any())
          continue;

        DictionaryMergeHelper.Merge2LevelDictionary(ref res, child.GetChildFrequency(), (x, y) => x + y);
      }

      if (res.ContainsKey(Label))
        res[Label].Add(string.Join(" ", items), 1);
      else
        res.Add(Label, new Dictionary<string, double> {{string.Join(" ", items), 1}});

      return res;
    }
  }
}
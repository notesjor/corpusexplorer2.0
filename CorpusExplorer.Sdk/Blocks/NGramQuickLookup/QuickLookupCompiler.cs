using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.NGramQuickLookup
{
  public static class QuickLookupCompiler
  {
    public static Dictionary<int, QuickLookupItem> Compile(Selection selection, string layerDisplayname, IEnumerable<string> queries, string[] separator = null)
    {
      var root = new QuickLookupItem();
      var layer = selection.GetLayers(layerDisplayname).FirstOrDefault();
      if (layer == null)
        return null;

      if (separator == null)
        separator = new[] { " " };
      foreach (var q in queries)
      {
        var token = new Queue<int>(q.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => layer[x]));
        if (token.Count == 0 || token.Any(x => x == -1))
          continue;

        root = AddToChain(root, token, q);
      }
      return root.Items;
    }

    private static QuickLookupItem AddToChain(QuickLookupItem current, Queue<int> token, string q)
    {
      if (token.Count == 0)
      {
        current.LeafValue = q;
        return current;
      }

      var next = token.Dequeue();
      if (!current.Items.ContainsKey(next))
        current.Items.Add(next, new QuickLookupItem());
      AddToChain(current.Items[next], token, q);

      return current;
    }
  }
}

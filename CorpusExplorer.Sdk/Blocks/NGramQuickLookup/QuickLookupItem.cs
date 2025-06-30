using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Blocks.NGramQuickLookup
{
  public sealed class QuickLookupItem
  {
    private string _leafValue;
    private bool _leadSet = false;

    public Dictionary<int, QuickLookupItem> Items { get; private set; } = new Dictionary<int, QuickLookupItem>();

    public string LeafValue
    {
      get => _leafValue;
      set
      {
        _leafValue = value;
        _leadSet = !string.IsNullOrWhiteSpace(value);
      }
    }

    public bool IsLeaf => _leadSet;
  }
}

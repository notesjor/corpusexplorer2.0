using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.ViewModel.QuickInfoText
{
  public class QuickInfoTextResult
  {
    public Guid DocumentGuid { get; set; }
    public Dictionary<string, object> DocumentMetadata { get; set; }
    public HashSet<int> HighlightedSentences { get; set; } = new HashSet<int>();
    public IEnumerable<IEnumerable<string>> Text { get; set; }
  }
}
using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.ViewModel.TextLiveSearch
{
  public class UniqueTextLiveSearchResultEntry
  {
    private readonly List<KeyValuePair<Guid, int>> _sentences = new List<KeyValuePair<Guid, int>>();

    public int Count => _sentences.Count;
    public string Match { get; set; }
    public string Post { get; set; }

    public string Pre { get; set; }

    public IEnumerable<KeyValuePair<Guid, int>> Sentences => _sentences;

    public void AddSentence(Guid documetGuid, int sentenceId)
    {
      _sentences.Add(new KeyValuePair<Guid, int>(documetGuid, sentenceId));
    }
  }
}
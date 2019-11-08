using System;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService.Model
{
  [Serializable]
  public class LexicalResponse
  {
    public LexicalReference[] Antonyms { get; set; }

    public LexicalReference[] Hyperonyms { get; set; }

    public LexicalReference[] Hyponyms { get; set; }

    public string[] Synset { get; set; }
  }
}
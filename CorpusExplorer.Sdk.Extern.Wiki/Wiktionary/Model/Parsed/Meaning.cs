using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wiktionary.Model.Parsed
{
  public class Meaning
  {
    public int Id { get;set; }
    public string Definition { get; set; }
    public List<string> Synonyms { get; set; } = new List<string>();
    public List<string> Antonyms { get; set; } = new List<string>();
    public List<string> Hyperonyms { get; set; } = new List<string>();
    public List<string> Hyponyms { get; set; } = new List<string>();
    public List<string> Samples { get; set; } = new List<string>();
    public List<string> Phrases { get; set; } = new List<string>();
    public List<string> Sayings { get; set; } = new List<string>();
    public List<string> Cowords { get; set; } = new List<string>();
  }
}
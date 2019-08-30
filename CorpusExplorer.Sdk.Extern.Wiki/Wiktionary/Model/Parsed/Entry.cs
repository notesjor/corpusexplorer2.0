using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wiktionary.Model.Parsed
{
  public class Entry
  {
    public string Lemma { get; set; }
    public string POS { get; set; }
    public string Genus { get; set; }
    public List<Form> Forms { get; set; } = new List<Form>();
    public string Etymology { get; set; }
    public string Ipa { get; set; }
    public List<Meaning> Meanings { get; set; } = new List<Meaning>();
    public List<string> WordCombinations { get; set; } = new List<string>();
  }
}

using System;
using System.Collections.Generic;
using System.Windows.Media;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext.PhrasenLaboratory.Model
{
  [Serializable]
  public class PhrasesLaboratorySettings
  {
    public Dictionary<string, KeyValuePair<Brush, Brush>> Colorset { get; set; }
    public PhraseGrammar Grammar { get; set; }
  }
}
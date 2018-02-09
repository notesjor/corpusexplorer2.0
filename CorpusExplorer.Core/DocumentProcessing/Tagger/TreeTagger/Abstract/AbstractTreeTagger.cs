using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Abstract
{
  public abstract class AbstractTreeTagger : AbstractTaggerOneWordPerLine
  {
    private readonly HashSet<string> _languageses = new HashSet<string>
    {
      "Deutsch",
      "Englisch",
      "Französisch",
      "Italienisch",
      "Niederländisch",
      "Spanisch",
      "Polnisch"
    };

    private string _languageSelected;
    protected string _sentenceMark = "$.";

    private readonly Dictionary<string, string> _sentenceMarks = new Dictionary<string, string>
    {
      {"Deutsch", "$."},
      {"Englisch", "."},
      {"Französisch", "SENT"},
      {"Italienisch", "PON"},
      {"Niederländisch", "$."},
      {"Spanisch", "FS"},
      {"Polnisch", "interp"}
    };

    public override string InstallationPath { get { return "(NICHT WÄHLBAR - OPTIMIERTE VERSION)"; } set { } }

    public override IEnumerable<string> LanguagesAvailabel => _languageses;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (!_languageses.Contains(value))
          throw new NotSupportedException("LanguageSelected-value is not in List of LanguagesAvailabel");
        _languageSelected = value;
        _sentenceMark = _sentenceMarks[value];
      }
    }

    protected override bool IsEndOfSentence(string[] data) { return data.Length > 2 && data[1] == _sentenceMark; }

    // ReSharper disable once UnusedMember.Global
    public LayerRangeState NewRangeLayer(string displayname) { return AddRangeLayer(displayname); }
  }
}
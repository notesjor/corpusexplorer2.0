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

    private readonly Dictionary<string, HashSet<string>> _sentenceMarks = new Dictionary<string, HashSet<string>>
    {
      {"Deutsch", new HashSet<string> {"$."}},
      {"Englisch", new HashSet<string> {"."}},
      {"Französisch", new HashSet<string> {"SENT"}},
      {"Italienisch", new HashSet<string> {"PON"}},
      {"Niederländisch", new HashSet<string> {"$."}},
      {"Spanisch", new HashSet<string> {"FS"}},
      {"Polnisch", new HashSet<string> {"interp"}}
    };

    private string _languageSelected;

    protected HashSet<string> _sentenceMark =
      new HashSet<string> {"$.", "PUNCT", ".", "SENT", "PON", "FS", "interp", "S"};

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

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

    // ReSharper disable once UnusedMember.Global
    public LayerRangeState NewRangeLayer(string displayname)
    {
      return AddRangeLayer(displayname);
    }

    protected override bool IsEndOfSentence(string[] data)
    {
      return data.Length > 2 && _sentenceMark.Contains(data[1]);
    }
  }
}
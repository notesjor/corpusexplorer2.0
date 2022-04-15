using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.Abstract
{
  public abstract class AbstractTreeTagger : AbstractTaggerOneWordPerLine
  {
    protected abstract AbstractLocatorStrategy LocatorStrategy { get; }
    private string _languageSelected;
    protected HashSet<string> _sentenceMark =
      new HashSet<string> { "$.", "PUNCT", ".", "SENT", "PON", "FS", "interp", "S" };

    protected override string Foundry => "TreeTagger";
    protected override string FoundryLayerInfo => "pos lemma";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => LocatorStrategy.AvailableLanguages;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (LocatorStrategy != null && !LocatorStrategy.ValidateLanguageSelection(value))
          throw new NotSupportedException("LanguageSelected-value is not in List of LanguagesAvailabel");
        _languageSelected = value;
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
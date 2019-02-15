using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.UdPipe.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.ConllTagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.UdPipe.Tagger
{
  public class UdPipeDllTagger : AbstractConllStyleTagger
  {
    private string _languageSelected;
    private Model.Model _model;

    public UdPipeDllTagger()
    {
      AddValueLayer("Wort", 1);
      AddValueLayer("Lemma", 2);
      AddValueLayer("POS", 4);
    }

    public override string DisplayName => "UDPipe";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => _languagesAvailable.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (value == _languageSelected)
          return;

        _languageSelected = value;
        _model = Model.Model.load(
                                  Configuration
                                   .GetDependencyPath($"UDPipe/Models/{_languagesAvailable[_languageSelected]}.udpipe"));
      }
    }

    private Dictionary<string, string> _languagesAvailable => new Dictionary<string, string>
    {
      {"Deutsch", "German"},
      {"Altgriechisch (PROIEL)", "Ancient_greek-PROIEL"},
      {"Altgriechisch", "Ancient_greek"},
      {"Arabisch", "Arabic"},
      {"Baskisch", "Basque"},
      {"Bulgarisch", "Bulgarian"},
      {"Chinesisch", "Chinese"},
      {"Dänisch", "Danish"},
      {"Englisch (LINES)", "English-LINES"},
      {"Englisch (PARTUT)", "English-PARTUT"},
      {"Englisch", "English"},
      {"Estnisch", "Estonian"},
      {"Finnisch (FTB)", "Finnish-FTB"},
      {"Finnisch", "Finnish"},
      {"Französisch (PARTUT)", "French-PARTUT"},
      {"Französisch (SEQUOIA)", "French-SEQUOIA"},
      {"Französisch", "French"},
      {"Galicisch (TREEGAL)", "Galician-TREEGAL"},
      {"Galicisch", "Galician"},
      {"Gotisch", "Gothic"},
      {"Griechisch", "Greek"},
      {"Hebräisch", "Hebrew"},
      {"Hindi", "Hindi"},
      {"Indonesisch", "Indonesian"},
      {"Italienisch", "Italian"},
      {"Irisch", "Irish"},
      {"Japanisch", "Japanese"},
      {"Kasachisch", "Kazakh"},
      {"Katalanisch", "Catalan"},
      {"Koptisch", "Coptic"},
      {"Koreanisch", "Korean"},
      {"Kroatisch", "Croatian"},
      {"Latein (ITTB)", "Latin-ITTB"},
      {"Latein (PROIEL)", "Latin-PROIEL"},
      {"Latein", "Latin"},
      {"Lettisch", "Latvian"},
      {"Litauisch", "Lithuanian"},
      {"Niederländisch (LASSYSMALL)", "Dutch-LASSYSMALL"},
      {"Niederländisch", "Dutch"},
      {"Norwegisch (BOKMAAL)", "Norwegian-BOKMAAL"},
      {"Norwegisch (NYNORSK)", "Norwegian-NYNORSK"},
      {"Persisch", "Persian"},
      {"Polnisch", "Polish"},
      {"Portugiesisch (BR)", "Portuguese-BR"},
      {"Portugiesisch", "Portuguese"},
      {"Rumänisch", "Romanian"},
      {"Russisch (SYNTAGRUS)", "Russian-SYNTAGRUS"},
      {"Russisch", "Russian"},
      {"Sanskrit", "Sanskrit"},
      {"Slawisch", "Old_church_slavonic"},
      {"Slowakisch", "Slovak"},
      {"Slowenisch (SST)", "Slovenian-SST"},
      {"Slowenisch", "Slovenian"},
      {"Spanisch (ANCORA)", "Spanish-ANCORA"},
      {"Spanisch", "Spanish"},
      {"Schwedisch (LINES)", "Swedish-LINES"},
      {"Schwedisch", "Swedish"},
      {"Tamilisch", "Tamil"},
      {"Tschechisch (CAC)", "Czech-CAC"},
      {"Tschechisch (CLTT)", "Czech-CLTT"},
      {"Tschechisch", "Czech"},
      {"Türkisch", "Turkish"},
      {"Ukrainisch", "Ukrainian"},
      {"Ungarisch", "Hungarian"},
      {"Urdu", "Urdu"},
      {"Uighurisch", "Uyghur"},
      {"Vietnamesisch", "Vietnamese"},
      {"Weißrussisch", "Belarusian"}
    };

    protected override string ExecuteTagger(string text)
    {
      try
      {
        var pipeline = new Pipeline(_model, "tokenize", Pipeline.DEFAULT, Pipeline.NONE, "conllu");
        var error = new ProcessingError();
        var res = pipeline.process(text, error);

        if (error.occurred())
          throw new Exception(error.message);

        return res;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return string.Empty;
      }
    }
  }
}
#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText
{
  public sealed class RawTextTagger : AbstractTaggerOneWordPerLine
  {
    private readonly HashSet<string> _endOfSentence = new HashSet<string> {".", "!", "?", ":", ";"};

    public RawTextTagger()
    {
      AddValueLayer("Wort", 0, 0);
      Tokenizer = new HighSpeedSpaceTokenizer();
    }

    public override string DisplayName => "Keine Annotation - Nur Textimport";

    public override string InstallationPath
    {
      get => "(NICHT W�HLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => new[] {"Universal"};

    public override string LanguageSelected { get; set; } = "Universal";

    protected override string Foundry => "None";
    protected override string FoundryLayerInfo => "";

    /// <summary>
    ///   �berschreitet der Tagger diese L�nge, dann wird die Runde abgeschlossen.
    ///   Wird dynamisch bestimmt. Empfohlener Startwert: 200000
    /// </summary>
    protected override int TaggerContentLengthMax => 20000000;

    /// <summary>
    ///   Unterschreitet der Tagger diese L�nge, wird die Verarbeitung abgebrochen.
    ///   Empfohlener Wert: 10
    /// </summary>
    protected override int TaggerContentLengthMin => 5;

    protected override string TaggerFileSeparator => "<ENDOFCORPUSEXPLORERFILE>";

    protected override string[] TaggerValueSeparator => new[] {"\t"};

    protected override string ExecuteTagger(string text)
    {
      return text;
    }

    protected override bool IsEndOfSentence(string[] data)
    {
      return data != null && data.Length > 0 && _endOfSentence.Contains(data[0]);
    }

    /// <summary>
    /// Erg�nzt die bishierge Liste der Satzenden {".", "!", "?", ":", ";"} um weitere g�ltige Endungen.
    /// </summary>
    /// <param name="additionalEndings">Zus�tzliche Satzenden.</param>
    public void AddEndOfSentence(IEnumerable<string> additionalEndings)
    {
      foreach (var x in additionalEndings)
      {
        _endOfSentence.Add(x);
      }
    }

    /// <summary>
    /// Setzt die Liste der g�ltigen Satzenden komplett neu. Die Standardeintr�ge {".", "!", "?", ":", ";"} gehen dabei verloren.
    /// </summary>
    /// <param name="completeEndingsList">Satzenden</param>
    public void DefineEndOfSentence(IEnumerable<string> completeEndingsList)
    {
      _endOfSentence.Clear();
      AddEndOfSentence(completeEndingsList);
    }
  }
}
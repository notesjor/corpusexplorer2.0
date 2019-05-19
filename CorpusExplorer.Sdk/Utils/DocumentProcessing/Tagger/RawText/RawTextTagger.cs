#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

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
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => new[] {"Universal"};

    public override string LanguageSelected { get; set; } = "Universal";

    /// <summary>
    ///   Überschreitet der Tagger diese Länge, dann wird die Runde abgeschlossen.
    ///   Wird dynamisch bestimmt. Empfohlener Startwert: 200000
    /// </summary>
    protected override int TaggerContentLengthMax => 20000000;

    /// <summary>
    ///   Unterschreitet der Tagger diese Länge, wird die Verarbeitung abgebrochen.
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
    /// Ergänzt die bishierge Liste der Satzenden {".", "!", "?", ":", ";"} um weitere gültige Endungen.
    /// </summary>
    /// <param name="additionalEndings">Zusätzliche Satzenden.</param>
    public void AddEndOfSentence(IEnumerable<string> additionalEndings)
    {
      foreach (var x in additionalEndings)
      {
        _endOfSentence.Add(x);
      }
    }

    /// <summary>
    /// Setzt die Liste der gültigen Satzenden komplett neu. Die Standardeinträge {".", "!", "?", ":", ";"} gehen dabei verloren.
    /// </summary>
    /// <param name="completeEndingsList">Satzenden</param>
    public void DefineEndOfSentence(IEnumerable<string> completeEndingsList)
    {
      _endOfSentence.Clear();
      AddEndOfSentence(completeEndingsList);
    }
  }
}
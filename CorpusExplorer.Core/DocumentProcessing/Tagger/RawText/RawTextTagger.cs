#region

using System.Collections.Generic;
using CorpusExplorer.Core.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.RawText
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
  }
}
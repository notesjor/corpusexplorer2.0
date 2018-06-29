namespace CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes.Model
{
  public sealed class ClanChildesError
  {
    private string _lineAnnotationFixed;
    private string _lineUtteranceFixed;

    public ClanChildesError(
      string path,
      int lineNumberUtterance,
      string lineUtterance,
      int lineNumberAnnoation,
      string lineAnnoation,
      string lineUtteranceParsed)
    {
      Path = path;
      LineNumberUtterance = lineNumberUtterance;
      LineUtterance = lineUtterance;
      LineNumberAnnoation = lineNumberAnnoation;
      LineAnnotation = lineAnnoation;
      LineUtteranceParsed = lineUtteranceParsed;
    }

    public string LineAnnotation { get; }

    public string LineAnnotationFixed
    {
      get => string.IsNullOrEmpty(_lineAnnotationFixed) ? LineAnnotation : _lineAnnotationFixed;
      set => _lineAnnotationFixed = value;
    }

    public int LineNumberAnnoation { get; }

    public int LineNumberUtterance { get; }
    public string LineUtterance { get; }

    public string LineUtteranceFixed
    {
      get => string.IsNullOrEmpty(_lineUtteranceFixed) ? LineUtterance : _lineUtteranceFixed;
      set => _lineUtteranceFixed = value;
    }

    public string LineUtteranceParsed { get; set; }

    public string Path { get; }
  }
}
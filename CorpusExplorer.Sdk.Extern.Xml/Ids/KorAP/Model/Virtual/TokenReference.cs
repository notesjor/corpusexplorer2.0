namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Virtual
{
  public struct TokenReference
  {
    private readonly int _form;
    private readonly int _to;
    private readonly int _sentence;
    private readonly int _token;

    public TokenReference(int form, int to, int sentence, int token)
    {
      _form = form;
      _to = to;
      _sentence = sentence;
      _token = token;
    }

    public int From => _form;
    public int To => _to;
    public int Sentence => _sentence;
    public int Token => _token;
  }
}

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Virtual
{
  public struct TokenReference
  {
    public TokenReference(int form, int to, int sentence, int token)
    {
      From = form;
      To = to;
      Sentence = sentence;
      Token = token;
    }

    public int From { get; }

    public int To { get; }

    public int Sentence { get; }

    public int Token { get; }
  }
}

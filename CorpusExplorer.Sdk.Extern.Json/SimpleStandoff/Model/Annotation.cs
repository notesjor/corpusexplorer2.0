namespace CorpusExplorer.Sdk.Extern.Json.SimpleStandoff.Model
{
  public class Annotation
  {
    public string Layer { get; set; }
    public string LayerValue { get; set; }
    public int From { get; set; }
    public int To { get; set; }
    public int FromSentence { get; set; }
    public int ToSentence { get; set; }

    public void Move()
    {
      From++;
      To++;
    }
  }
}

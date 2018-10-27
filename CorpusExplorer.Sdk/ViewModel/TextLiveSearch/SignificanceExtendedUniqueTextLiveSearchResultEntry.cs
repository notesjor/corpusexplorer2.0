namespace CorpusExplorer.Sdk.ViewModel.TextLiveSearch
{
  public class SignificanceExtendedUniqueTextLiveSearchResultEntry : UniqueTextLiveSearchResultEntry
  {
    public double Token { get; set; }
    public double SignificantToken { get; set; }
    public double SignificanceMax { get; set; }
    public double SignificanceSum { get; set; }
    public double SignificanceRank { get; set; }
    public double SignificanceMed { get; set; }
  }
}
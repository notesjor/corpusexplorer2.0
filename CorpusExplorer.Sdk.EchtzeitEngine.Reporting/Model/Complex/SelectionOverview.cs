using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Model.Simple;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Model.Complex
{
  public class SelectionOverview
  {
    public Simple2Label2Value[] Cooccurrences { get; set; }
    public Simple2Label3Value[] CorpusDistributions { get; set; }
    public string Displayname { get; set; }
    public double Documents { get; set; }
    public Simple3Label1Value[] Frequencies { get; set; }
    public QueryOverview[] Queries { get; set; }

    public double RelativeFrequencyFactor { get; set; }
    public double Sentences { get; set; }

    public double Token { get; set; }
  }
}
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Model.Simple;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Model.Complex
{
  public class QueryOverview
  {
    public Simple1Label2Value[] Cooccurrences { get; set; }
    public double Frequency { get; set; }
    public SimpleKwicResult[] KwicResults { get; set; }
    public string Query { get; set; }
  }
}
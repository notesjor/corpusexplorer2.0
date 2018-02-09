using System;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Model.Simple
{
  public class SimpleKwicResult
  {
    public Guid DocumentGuid { get; set; }
    public string Left { get; set; }
    public string Match { get; set; }
    public string Right { get; set; }
  }
}
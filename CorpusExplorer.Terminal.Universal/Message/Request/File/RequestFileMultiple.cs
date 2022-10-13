using System.Collections.Generic;

namespace CorpusExplorer.Terminal.Universal.Message.Request.File
{
  public class RequestFileMultiple
  {
    public IEnumerable<string> Paths { get;set;}
  }
}
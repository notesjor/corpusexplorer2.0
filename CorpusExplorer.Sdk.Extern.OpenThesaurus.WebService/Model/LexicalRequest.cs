using Diskursmonitor.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService.Model
{
  public class LexicalRequest : AbstractArgumentProxyEndpoint
  {
    public string Query => Mapper("query");
  }
}

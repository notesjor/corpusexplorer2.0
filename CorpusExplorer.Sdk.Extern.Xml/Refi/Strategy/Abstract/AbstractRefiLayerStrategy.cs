using CorpusExplorer.Sdk.Extern.Xml.Refi.Model;
using System.Collections.Generic;
using System.Web;

namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Strategy.Abstract
{
  public abstract class AbstractRefiLayerStrategy
  {
    public abstract Dictionary<string, KeyValuePair<string, string>> GetLayerInfo(Code[] codes);

    protected string EnsureHtmlAttributes(string value) => string.IsNullOrEmpty(value) ? value : HttpUtility.HtmlAttributeEncode(value).Replace("\"", "&quot;").Replace("'", "&apos;");
  }
}

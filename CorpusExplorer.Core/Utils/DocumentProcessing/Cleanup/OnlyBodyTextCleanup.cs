using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Cleanup
{
  public class OnlyBodyTextCleanup : AbstractCleanup
  {
    public override string DisplayName => "OnlyBodyText";

    protected override string Execute(string key, string input)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(input);

      var node = doc.DocumentNode.SelectNodes("//body").FirstOrDefault();
      return node == null ? input : node.InnerText;
    }
  }
}

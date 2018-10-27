#region

using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;

#endregion

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Html
{
  public sealed class SimpleHtmlDocumentScraper : AbstractSimpleDocumentScraper<HtmlFormatProvider>
  {
    public override string DisplayName => "Sehr einfacher Html-Dokument-Scraper";
  }
}
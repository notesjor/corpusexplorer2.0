#region

using CorpusExplorer.Core.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Html
{
  public sealed class SimpleHtmlDocumentScraper : AbstractSimpleDocumentScraper<HtmlFormatProvider>
  {
    public override string DisplayName => "Sehr einfacher Html-Dokument-Scraper";
  }
}
#region

using CorpusExplorer.Core.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Rtf
{
  public sealed class SimpleRtfDocumentScraper : AbstractSimpleDocumentScraper<RtfFormatProvider>
  {
    public override string DisplayName => "Sehr einfacher Rtf-Dokument-Scraper";
  }
}
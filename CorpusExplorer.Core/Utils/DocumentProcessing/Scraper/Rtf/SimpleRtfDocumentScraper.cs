#region

using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;

#endregion

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Rtf
{
  public sealed class SimpleRtfDocumentScraper : AbstractSimpleDocumentScraper<RtfFormatProvider>
  {
    public override string DisplayName => "Sehr einfacher Rtf-Dokument-Scraper";
  }
}
#region

using CorpusExplorer.Core.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Docx
{
  public sealed class SimpleDocxDocumentScraper : AbstractSimpleDocumentScraper<DocxFormatProvider>
  {
    public override string DisplayName => "Sehr einfacher Word-Dokument-Scraper";
  }
}
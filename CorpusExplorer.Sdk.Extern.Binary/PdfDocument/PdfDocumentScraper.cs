using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Text;
using Telerik.Windows.Documents.Fixed.Model;

namespace CorpusExplorer.Sdk.Extern.Binary.PdfDocument
{
  public class PdfDocumentScraper : AbstractScraper
  {
    private PdfFormatProvider _providerPdf;
    private TextFormatProvider _providerTxt;

    public override string DisplayName => "PDF-Dokument";

    public PdfDocumentScraper()
    {
      _providerPdf = new PdfFormatProvider();
      _providerTxt = new TextFormatProvider();
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      RadFixedDocument document = new RadFixedDocument();

      using (var input = new FileStream(file, FileMode.Open, FileAccess.Read))
        document = _providerPdf.Import(input);

      string documentContent = _providerTxt.Export(document);

      return new[] { new Dictionary<string, object> {
        { "Text", documentContent },
        { "Pfad", file },
        { "Autor", document.DocumentInfo?.Author },
        { "Titel", document.DocumentInfo?.Title },
        { "Kommentar", document.DocumentInfo?.Description },
        { "Seiten", document.Pages.Count },
        }
      };
    }
  }
}

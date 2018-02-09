using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Text;
using Telerik.Windows.Documents.Fixed.Model;

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Pdf
{
  public class SimplePdfDocumentScraper : AbstractScraper
  {
    private object _lock = new object();

    public override string DisplayName => "PDF";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      lock (_lock)
      {
        RadFixedDocument doc;

        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
          var importer = new PdfFormatProvider();
          doc = importer.Import(fs);
        }

        if (doc == null)
          return new Dictionary<string, object>[] { };

        var exporter = new TextFormatProvider();
        return new[]
        {
          new Dictionary<string, object>
          {
            {"Text", exporter.Export(doc, new TextFormatProviderSettings("\r\n","\r\n"))},
            {"Pfad", file},
            {"Dateiname", Path.GetFileNameWithoutExtension(file)}
          }
        };
      }
    }
  }
}

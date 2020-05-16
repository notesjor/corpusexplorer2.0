using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace CorpusExplorer.Sdk.Extern.TextSharp.PDF
{
  public class TextSharpPdfSinglePageScraper : AbstractScraper
  {
    public enum TextSharpPdfScraperStrategy
    {
      Location,
      Simple
    }

    public override string DisplayName => "iTextSharp (single page)";

    public TextSharpPdfScraperStrategy Strategy { get; set; } = TextSharpPdfScraperStrategy.Location;

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        var reader = new PdfReader(bs);
        for (var i = 1; i <= reader.NumberOfPages; i++)
        {
          var asDict = reader.GetPageN(i).GetAsDict(PdfName.RESOURCES);
          var strategy = Strategy == TextSharpPdfScraperStrategy.Simple
                           ? (ITextExtractionStrategy)
                           new SimpleTextExtractionStrategy()
                           : new LocationTextExtractionStrategy();

          var contentStreamProcessor = new PdfContentStreamProcessor(strategy);
          contentStreamProcessor.ProcessContent(ContentByteUtils.GetContentBytesForPage(reader, i), asDict);
          var text = strategy.GetResultantText();

          if (!string.IsNullOrWhiteSpace(text))
            res.Add(new Dictionary<string, object>
            {
              {"Text", text}, 
              {"Datei", file},
              {"Seite", i }
            });
        }

        return res;
      }
    }
  }
}
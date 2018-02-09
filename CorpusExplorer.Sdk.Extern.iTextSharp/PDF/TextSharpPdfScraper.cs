using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace CorpusExplorer.Sdk.Extern.TextSharp.PDF
{
  public class TextSharpPdfScraper : AbstractScraper
  {
    public override string DisplayName => "iTextSharp";

    public TextSharpPdfScraperStrategy Strategy { get; set; } = TextSharpPdfScraperStrategy.Simple;

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      {
        var reader = new PdfReader(fs);
        var strategy = Strategy == TextSharpPdfScraperStrategy.Simple
                         ? (ITextExtractionStrategy)
                           new SimpleTextExtractionStrategy()
                         : new LocationTextExtractionStrategy();

        var output = new StringBuilder();
        for (var i = 1; i <= reader.NumberOfPages; i++)
        {
          var asDict = reader.GetPageN(i).GetAsDict(PdfName.RESOURCES);
          var contentStreamProcessor = new PdfContentStreamProcessor(strategy);
          contentStreamProcessor.ProcessContent(ContentByteUtils.GetContentBytesForPage(reader, i), asDict);
        }
        output.AppendLine(strategy.GetResultantText());

        var res = new Dictionary<string, object> { { "Text", output.ToString() }, { "Datei", file } };
        foreach (var info in reader.Info.Where(info => !res.ContainsKey(info.Key)))
          res.Add(info.Key, info.Value);

        return new[] { res };
      }
    }

    public enum TextSharpPdfScraperStrategy
    {
      Location,
      Simple
    }
  }
}
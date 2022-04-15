using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Editing;
using Telerik.Windows.Zip;

namespace CorpusExplorer.Sdk.Extern.Binary.NexisNew
{
  public class NexisNewScraper : AbstractScraper
  {
    public override string DisplayName => "nexis.com - Nachrichten (ab 2020)";

    private HashSet<string> _keysRemove = new HashSet<string>
    {
      "Length",
      "Highlight",
      "Guests"
    };

    private Dictionary<string, string> _keysReplacements = new Dictionary<string, string>
    {
      { "Section", "Rubrik" },
      { "Byline", "Autor*innen" },
    };

    private HashSet<string> _bodyEnds = new HashSet<string>
    {
      "Graphic",
      "Classification",
      "End of Document"
    };

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var archive = new ZipArchive(stream))
        foreach (var entry in archive.Entries)
        {
          if (entry.Name.Contains("doclist"))
            continue;

          var doc = OpenDocx(entry);
          if (doc == null)
            continue;

          res.Add(ExtractDocument(doc));
        }

      return res;
    }

    private Dictionary<string, object> ExtractDocument(RadFlowDocument doc)
    {
      var res = new Dictionary<string, object>();

      foreach (var sec in doc.Sections)
      {
        var paragraphs = sec.Blocks.OfType<Paragraph>().ToArray();
        if (paragraphs.Length < 5)
          continue;

        res.Add("Titel", GetText(paragraphs[1]));
        res.Add("Zeitung", GetText(paragraphs[2]));
        var date = GetText(paragraphs[3]);
        res.Add("Datum (RAW)", date);
        res.Add("Datum", DateTimeHelper.Parse(date, true));

        var i = 4;
        for (; i < paragraphs.Length; i++)
        {
          if (IsBody(paragraphs[i]))
          {
            i++;
            break;
          }

          var lines = paragraphs[i].Inlines.OfType<Run>().Select(x => x.Text).ToList();
          if (lines.Count < 2)
            continue;

          var key = lines[0].Replace(":", "").Trim();
          if(_keysRemove.Contains(key))
            continue;
          if (_keysReplacements.ContainsKey(key))
            key = _keysReplacements[key];

          lines.RemoveAt(0);
          var value = string.Join(" ", lines).Replace("  ", " ").Trim();

          if (res.ContainsKey(key))
            res[key] = value;
          else
            res.Add(key, value);
        }

        var stb = new StringBuilder();
        for (; i < paragraphs.Length; i++)
        {
          if(IsBodyEnd(paragraphs[i]))
            break;
          stb.AppendLine(GetText(paragraphs[i]));
        }

        res.Add("Text", stb.ToString());
      }

      return res;
    }

    private bool IsBody(Paragraph p)
    {
      return string.Join(" ", p.Inlines.OfType<Run>()
                               .Select(x => x.Text))
                   .Trim() == "Body";
    }

    private bool IsBodyEnd(Paragraph p)
    {
      return _bodyEnds.Contains(string.Join(" ", p.Inlines.OfType<Run>()
                                                  .Select(x => x.Text))
                                      .Trim());
    }

    private string GetText(Paragraph p)
    {
      return string.Join(" ", p.Inlines.OfType<Run>()
                               .Where(x => !x.Text.StartsWith(" HYPERLINK"))
                               .Select(x => x.Text))
                   .Replace("  ", " ")
                   .Trim();
    }

    private static RadFlowDocument OpenDocx(ZipArchiveEntry entry)
    {
      RadFlowDocument doc = null;
      using (var ms = new MemoryStream())
      {
        using (var entryStream = entry.Open())
          entryStream.CopyTo(ms);

        ms.Seek(0, SeekOrigin.Begin);
        doc = (new DocxFormatProvider()).Import(ms);
      }

      return doc;
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Plaintext.KleineAnfrageDe
{
  public class KleineanfrageDeScraper : AbstractPlaintextScraper
  {
    private const string ValidSqlFormat =
      "COPY public.papers (id, body_id, legislative_term, reference, title, contents, page_count, url, published_at, downloaded_at, created_at, updated_at, slug, contains_table, pdf_last_modified, doctype, is_answer, frozen_at, source_url, deleted_at, contains_classified_information) FROM stdin;";

    public override string DisplayName => "Kleineanfrage.de SQL";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var run = false;

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      using (var reader = new StreamReader(bs, Configuration.Encoding))
      {
        while (!reader.EndOfStream)
          try
          {
            var line = reader.ReadLine();
            if (!run) // warte bis zu den relevanten Inforamtionen
            {
              if (line.StartsWith(ValidSqlFormat))
                run = true;
              continue;
            }

            if (line == @"\.") // wurden alle Daten gelesen, dann brich ab.
              break;

            var d = line.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);

            res.Add(new Dictionary<string, object>
            {
              {"ID", int.Parse(d[0])},
              {"Titel", CleanText(d[4])},
              {"Text", CleanText(d[5])},
              {"URL", d[6]},
              {"Typ", d[15]},
              {"Antwort?", d[16] == "t"},
              {"URL (Quelle)", d[18]},
              {"Vertraulich?", d[20] == "t"},
              {"Datum", DateTimeHelper.Parse(d[8], "yyyy-MM-dd")}
            });
          }
          catch (Exception ex)
          {
            // ignore
          }
      }

      return res;
    }

    private string CleanText(string text)
    {
      return text.Replace("\\t", " ").Replace("\\n", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
    }
  }
}
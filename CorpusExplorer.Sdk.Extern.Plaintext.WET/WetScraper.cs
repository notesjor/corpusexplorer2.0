using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.WET.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET
{
  public class WetScraper : AbstractScraper
  {
    private const string DocumentSeparator = "WARC/1.0";
    private const string BodySeparator = "Content-Length:";

    private const string HeaderTargetUri = "WARC-Target-URI:";
    private const string HeaderDate = "WARC-Date:";
    private const string HeaderRecordId = "WARC-Record-ID:";
    private const string HeaderRefersTo = "WARC-Refers-To:";
    private const string HeaderDigest = "WARC-Block-Digest:";

    public override string DisplayName => "http://commoncrawl.org - WET";

    private object _filterLock = new object();
    private LanguageFilter _filterLanguage;
    private bool _filterSet;
    private DomainFilter _filterDomain;

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      lock (_filterLock)
      {
        if (!_filterSet)
        {
          var form = new LanguageSelectionForm();
          form.ShowDialog();

          if (form.UseLanguageFilter)
            _filterLanguage = new LanguageFilter(form.SelectedLanguage);

          if (form.UseDomainFilter)
            _filterDomain = new DomainFilter(form.SelectedDomains);

          _filterSet = true;
        }
      }

      var res = new List<Dictionary<string, object>>();

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var reader = new StreamReader(fs, Configuration.Encoding))
      {
        // Skip WET Header
        reader.ReadLine();
        while (reader.ReadLine() != DocumentSeparator)
          reader.ReadLine();

        var current = new Dictionary<string, object>();
        var stb = new StringBuilder();
        var head = true;

        while (!reader.EndOfStream)
        {
          // HEAD
          if (head)
          {
            var line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
              continue;

            if (line.StartsWith(HeaderTargetUri))
              current.Add("Url", line.Replace(HeaderTargetUri, string.Empty).Trim());
            if (line.StartsWith(HeaderDate))
              current.Add("Datum (Original)", line.Replace(HeaderDate, string.Empty).Trim());
            if (line.StartsWith(HeaderDate))
              current.Add("Datum",
                DateTimeHelper.Parse(line.Replace(HeaderDate, string.Empty).Trim(), "yyyy-MM-ddTHH:mm:ssZ"));
            if (line.StartsWith(HeaderRecordId))
              current.Add("RecordURN", line.Replace(HeaderRecordId, string.Empty).Trim());
            if (line.StartsWith(HeaderRefersTo))
              current.Add("ReferURN", line.Replace(HeaderRefersTo, string.Empty).Trim());
            if (line.StartsWith(HeaderDigest))
              current.Add("Hash", line.Replace(HeaderDigest, string.Empty).Trim());
            if (line.StartsWith(BodySeparator))
              head = false;
          }
          // BODY
          else
          {
            var line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
              continue;

            // End of Document
            if (line == DocumentSeparator)
            {
              if (_filterDomain?.Match(current["Url"] as string) ?? true)
              {
                current.Add("Text", stb.ToString());
                res.Add(current);
              }

              current = new Dictionary<string, object>();
              stb.Clear();
              head = true;

              continue;
            }

            // Append body line
            stb.AppendLine(line);
          }
        }
      }
      
      if(_filterLanguage == null)
        return res;

      var bag = new ConcurrentBag<Dictionary<string, object>>();
      Parallel.ForEach(res, entry =>
      {
        if (_filterLanguage.Match(entry["Text"] as string)) 
          bag.Add(entry);
      });

      return bag;
    }
  }
}

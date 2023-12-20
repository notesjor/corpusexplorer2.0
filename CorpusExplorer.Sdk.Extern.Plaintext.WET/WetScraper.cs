using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.NTextCat;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET
{
  public class WetScraper : AbstractScraper
  {
    private const string BodySeparator = "Content-Length:";
    private const string DocumentSeparator = "WARC/1.0";
    private const string HeaderDate = "WARC-Date:";
    private const string HeaderDigest = "WARC-Block-Digest:";
    private const string HeaderRecordId = "WARC-Record-ID:";
    private const string HeaderRefersTo = "WARC-Refers-To:";

    private const string HeaderTargetUri = "WARC-Target-URI:";
    private DomainFilter _filterDomain;

    private readonly object _filterLock = new object();
    private bool _filterSet;
    private string _filterLanguage;

    public override string DisplayName => "http://commoncrawl.org - WET";

    public void InitializeFilter(DomainFilter filterDomain, string filterLanguage = null)
    {
      lock (_filterLock)
      {
        _filterLanguage = filterLanguage;
        _filterDomain = filterDomain;
        _filterSet = true;
      }
    }

    public IEnumerable<Dictionary<string, object>> ExecuteBypass(Stream stream, string filterLanguage, DomainFilter filterDomains)
    {
      lock (_filterLock)
      {
        if (!_filterSet)
        {
          _filterLanguage = filterLanguage;
          _filterDomain = filterDomains;

          _filterSet = true;
        }
      }

      var res = ExecuteExtraction(stream);

      if (_filterLanguage == null)
        return res;

      var cleaner = new NTextCatLanguageCleanup { Input = res };
      cleaner.Execute();

      return cleaner.Output;
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      lock (_filterLock)
      {
        if (!_filterSet)
        {
          var form = new CorpusExplorer.Sdk.Extern.Plaintext.WET.Forms.LanguageSelectionForm();
          form.ShowDialog();

          if (form.UseLanguageFilter)
            _filterLanguage = form.SelectedLanguage;

          if (form.UseDomainFilter)
            _filterDomain = new DomainFilter(form.SelectedDomains);

          _filterSet = true;
        }
      }

      ConcurrentQueue<Dictionary<string, object>> res;
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        res = ExecuteExtraction(bs);
      }

      if (_filterLanguage == null)
        return res;

      var cleaner = new NTextCatLanguageCleanup { Input = res };
      cleaner.Execute();

      return cleaner.Output;
    }

    private ConcurrentQueue<Dictionary<string, object>> ExecuteExtraction(Stream fs)
    {
      var lines = GetLines(fs);

      // SKIP WET HEADER
      var i = 1; // Wichtig, da sonst der WET Header als Dokument erkannt wird.
      for (; i < lines.Length; i++)
      {
        var line = lines[i];
        if (line == DocumentSeparator)
          break;
      }

      var res = new ConcurrentQueue<Dictionary<string, object>>();
      var current = new Dictionary<string, object>();
      var stb = new StringBuilder();
      var head = true;

      for (; i < lines.Length; i++)
      {
        var line = lines[i];

        // HEAD
        if (head)
        {
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
          if (string.IsNullOrWhiteSpace(line))
            continue;

          // End of Document
          if (line == DocumentSeparator)
          {
            if (_filterDomain == null)
            {
              current.Add("Text", stb.ToString());
              res.Enqueue(current);
            }
            else if (_filterDomain.Match(current["Url"] as string))
            {
              current.Add("Text", stb.ToString());
              res.Enqueue(current);
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

      return res;
    }

    private string[] GetLines(Stream fs)
    {
      var buffer = new byte[fs.Length];
      fs.Read(buffer, 0, buffer.Length);
      return Configuration.Encoding.GetString(buffer)
        .Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
    }
  }
}
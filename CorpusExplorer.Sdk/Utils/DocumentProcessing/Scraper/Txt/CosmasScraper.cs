#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Txt
{
  public sealed class CosmasScraper : AbstractScraper
  {
    /// <summary>
    ///   The _alter cleanup.
    /// </summary>
    private readonly Dictionary<string, string> _alterCleanup;

    /// <summary>
    ///   Initializes a new instance of the <see cref="CosmasScraper" /> class.
    /// </summary>
    public CosmasScraper()
    {
      _alterCleanup = new Dictionary<string, string>();
      for (var i = 0; i < 130; i++)
        _alterCleanup.Add("(" + i + ")", "[" + i + "]");
    }

    public override string DisplayName => "COSMAS-*.TXT";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new ConcurrentBag<Dictionary<string, object>>();
      var text = File.ReadAllText(file, Configuration.Encoding);

      var docs = text.Split(new[] {"\r\n\r\n"}, StringSplitOptions.RemoveEmptyEntries);

      Parallel.For(
                   0,
                   docs.Length,
                   Configuration.ParallelOptions,
                   i =>
                   {
                     var doc = docs[i];
                     doc = _alterCleanup.Aggregate(doc, (current, x) => current.Replace(x.Key, x.Value));

                     try
                     {
                       var entry = new Dictionary<string, object>();

                       var index = doc.LastIndexOf("(", StringComparison.Ordinal);
                       entry.Add(
                                 "Text",
                                 doc.Substring(0, index)
                                    .Trim()
                                    .Replace("\r", " ")
                                    .Replace("\n", " ")
                                    .Replace("  ", " ")
                                    .Replace("  ", " "));

                       var metaData =
                         doc.Substring(index)
                            .Replace("(", " ")
                            .Replace(")", " ")
                            .Trim()
                            .Replace("  ", " ")
                            .Replace("  ", " ")
                            .Replace(",", ";");

                       var metas = metaData.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                       if (metas.Length == 1)
                       {
                         entry.Add("Titel", metas[0]);
                         return;
                       }

                       var sign = metas[0].Substring(0, metas[0].IndexOf(" ", StringComparison.Ordinal));

                       entry.Add("Signatur", sign);
                       entry.Add("Zeitung", metas[0].Replace(sign, string.Empty).Trim());

                       try
                       {
                         entry.Add("Datum", DateTimeHelper.Parse(metas[1].Trim(), true));
                       }
                       catch
                       {
                         entry.Add("Datum", DateTime.MinValue);
                       }

                       if (metas.Length < 3)
                         return;

                       var page = metas[2].Trim();
                       // ReSharper disable once RedundantAssignment
                       var pageNr = -1;
                       var hasPageNr = false;

                       if (page.StartsWith("S. ") &&
                           int.TryParse(page.Replace("S. ", string.Empty), out pageNr))
                       {
                         entry.Add("Seite", pageNr);
                         hasPageNr = true;
                       }

                       var stb = new StringBuilder();
                       for (var j = hasPageNr ? 3 : 2; j < metas.Length; j++)
                       {
                         stb.Append(metas[j]);
                         if (j < metas.Length - 1)
                           stb.Append(" ");
                       }

                       entry.Add("Titel", stb.ToString());

                       res.Add(entry);
                     }
                     catch (Exception ex)
                     {
                       Console.WriteLine(ex.Message);
                       Console.WriteLine();
                       Console.WriteLine(ex.StackTrace);
                     }
                   });

      return res;
    }
  }
}
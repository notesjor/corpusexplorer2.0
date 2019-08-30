using System;
using System.Diagnostics;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia
{
  public class WikipediaCleanup : AbstractCleanup
  {
    public override string DisplayName => "Wikipedia Cleanup";

    public string ExecuteInline(string raw)
    {
      using (var fileOutput = new TemporaryFile(Configuration.TempPath))
      {
        using (var fileInput = new TemporaryFile(Configuration.TempPath))
        {
          FileIO.Write(fileInput.Path, raw.Substring(0, FirstIndex(ref raw)), Configuration.Encoding);
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath(@"pandoc\pandoc.exe"),
              Arguments = $"-s -f mediawiki -t html5 -o {fileOutput.Path} {fileInput.Path}",
              CreateNoWindow = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();
          process.WaitForExit();
        }

        var doc = new HtmlDocument();
        doc.Load(fileOutput.Path, Configuration.Encoding);

        return doc.DocumentNode.SelectNodes("//body").First().InnerText;
      }
    }

    protected override string Execute(string input)
    {
      return ExecuteInline(input);
    }

    private int FirstIndex(ref string raw)
    {
      var res = raw.Length;
      FirstIndexCheck(ref raw, ref res, "<references/>");
      FirstIndexCheck(ref raw, ref res, "== Einzelnachweise ==");
      FirstIndexCheck(ref raw, ref res, "== Weblinks ==");
      FirstIndexCheck(ref raw, ref res, "== Literatur ==");
      FirstIndexCheck(ref raw, ref res, "== Siehe auch ==");
      return res;
    }

    private static void FirstIndexCheck(ref string raw, ref int res, string check)
    {
      var tmp = raw.LastIndexOf(check, StringComparison.Ordinal);
      if (tmp > -1 && tmp < res)
        res = tmp;
    }
  }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.Model;

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Cosmas
{
  public class CosmasScraper : AbstractScraper
  {
    public override string DisplayName => "COSMAS 2 - C2API";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      RadFlowDocument doc;
      var provider = new RtfFormatProvider();
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        doc = provider.Import(fs);

      if (doc == null)
        return null;

      var root = doc.Sections.First();
      var version = ((root.Blocks[1] as Paragraph)?.Inlines.First() as Run)?.Text;
      if (!version.StartsWith("COSMAS II-Server, C2API-Version 4."))
        return new[]
        {
          new Dictionary<string, object>
          {
            {"Text", "Es können nur Texte aus COSMAS II der C2API ab Version 4 eingelesen werden."}
          }
        };

      var i = 0;
      for (; i < root.Blocks.Count; i++)
      {
        var text = GetText(root.Blocks[i]);
        if (text == null)
          continue;

        if (text.StartsWith("Belege (unsortiert)"))
          break;
      }
      for (; i < root.Blocks.Count; i++)
      {
        var text = GetText(root.Blocks[i]);
        if (text == null)
          continue;

        if (text.StartsWith("Kontext umschließt"))
        {
          i += 3;
          break;
        }
      }

      var res = new List<Dictionary<string, object>>();
      var list = new List<Run>();
      for (; i < root.Blocks.Count; i++)
      {
        try
        {
          var par = (root.Blocks[i] as Paragraph);
          if (par?.Inlines == null || par.Inlines.Count == 0)
          {
            if (list.Count == 0)
              continue;

            var last = list.Last();
            list.Remove(last);

            var text = string.Join(" ", list.Select(x => x.Text)).Replace("  ", " ");
            var meta = last?.Text;

            res.Add(new Dictionary<string, object>
            {
              {"Text", text},
              {"Meta", meta}
            });

            list.Clear();

            continue;
          }

          foreach (var inline in par.Inlines)
            if (inline is Run r)
              list.Add(r);
        }
        catch
        {
          // ignore
        }
      }

      return res;
    }

    private string GetText(BlockBase block)
    {
      try
      {
        return ((block as Paragraph)?.Inlines?.Last() as Run)?.Text;
      }
      catch
      {
        return null;
      }
    }
  }
}

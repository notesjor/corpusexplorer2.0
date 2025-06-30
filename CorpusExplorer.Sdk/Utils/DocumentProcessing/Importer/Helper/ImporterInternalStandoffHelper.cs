using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Tlv;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Tlv.Model;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Helper
{
  public sealed class ImporterInternalStandoffHelper
  {
    private List<string> _documents = new List<string>();

    public struct Annotation
    {
      public string Layer { get; set; }
      public string Value { get; set; }
      public int Start { get; set; }
      public int Stop { get; set; }
    }

    public void AddText(string text, Dictionary<string, object> meta, IEnumerable<Annotation> annotations)
      => AddText(text, meta, annotations.Select(a => new TlvEntry(a.Layer, a.Value, a.Start, a.Stop)));

    public void AddText(string text, Dictionary<string, object> meta, IEnumerable<TlvEntry> annotations)
    {
      var builder = new TlvBuilder(text)
      {
        Metadata = meta,
        ExternalUsage = false
      };

      foreach (var entry in annotations)
        if (entry.Length > 0)
          builder.Add(entry);

      var doc = new HtmlAgilityPack.HtmlDocument
      {
        OptionFixNestedTags = true,
        OptionAutoCloseOnEnd = true
      };
      doc.LoadHtml(builder.GetXmlOutput());

      // Cleanup
      var cleanCode = doc.DocumentNode
        .DescendantsAndSelf()
        .Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Text)
        .Aggregate(doc.DocumentNode.OuterHtml, (current, textNode) =>
          current.Replace(textNode.InnerHtml, System.Net.WebUtility.HtmlEncode(textNode.InnerHtml)));
      cleanCode = cleanCode.Replace("<body>","</meta><body>");

      _documents.Add(cleanCode);
    }

    public IEnumerable<AbstractCorpusAdapter> Execute()
    {
      var importer = new ImporterTlv();
      var merger = new CorpusMerger();

      merger.Input(importer.ExecuteInline(_documents));
      merger.Execute();

      return merger.Output;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using com.sun.codemodel.@internal;
using com.sun.org.apache.xalan.@internal.xsltc.trax;
using com.sun.org.glassfish.external.amx;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using TikaOnDotNet.TextExtraction;

namespace CorpusExplorer.Sdk.Extern.Tika
{
  public class TikaScraper : AbstractScraper
  {
    public TikaScraper()
    {
      var t = typeof(ClassType); // IKVM.OpenJDK.Tools
      Console.WriteLine(t.ToString());
      t = typeof(TransformerFactoryImpl); // IKVM.OpenJDK.XML.Transform
      Console.WriteLine(t.ToString());
      t = typeof(AMX); // IKVM.OpenJDK.XML.WebServices
      Console.WriteLine(t.ToString());
    }

    public override string DisplayName => "Auf gut Glück (Tika)";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var extractor = new TextExtractor();
      var text = extractor.Extract(file);

      if (string.IsNullOrEmpty(text?.Text))
        return null;

      var res = new Dictionary<string, object> {{"Text", text.Text}};
      if (text.Metadata == null)
        return new[] {res};

      foreach (var meta in text.Metadata.Where(meta => !res.ContainsKey(meta.Key)))
        res.Add(meta.Key, meta.Value);

      return new[] {res};
    }
  }
}
#region

using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;

#endregion

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Abstract
{
  public abstract class AbstractSimpleDocumentScraper<T> : AbstractScraper
    where T : FormatProviderBase<RadFlowDocument>, new()
  {
    private readonly object _lock = new object();
    private readonly TxtFormatProvider _provider = new TxtFormatProvider();

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      lock (_lock)
      {
        RadFlowDocument doc;

        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        using (var bs = new BufferedStream(fs))
        {
          var reader = Activator.CreateInstance(typeof(T)) as T;

          if (reader is HtmlFormatProvider)
            (reader as HtmlFormatProvider).ImportSettings = new HtmlImportSettings { ReplaceNonBreakingSpaces = true };

          if (reader == null)
            return null;

          doc = reader.Import(bs);
        }

        if (doc == null)
          return new Dictionary<string, object>[] { };

        string text;
        using (var ms = new MemoryStream())
        {
          _provider.Export(doc, ms);
          ms.Seek(0, SeekOrigin.Begin);
          var buffer = new byte[ms.Length];
          ms.Read(buffer, 0, buffer.Length);
          text = Configuration.Encoding.GetString(buffer);
        }

        return new[]
        {
          new Dictionary<string, object>
          {
            {"Text", text},
            {"Pfad", file},
            {"Dateiname", Path.GetFileNameWithoutExtension(file)}
          }
        };
      }
    }
  }
}
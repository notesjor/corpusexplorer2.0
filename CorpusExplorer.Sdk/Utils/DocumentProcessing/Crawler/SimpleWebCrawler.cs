#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler
{
  [Serializable]
  public class SimpleWebCrawler : AbstractCrawler
  {
    public SimpleWebCrawler() { Url = null; }

    public override string DisplayName => "Einfacher Download";

    public string Url { get; set; }

    public override void Execute()
    {
      var stb = new StringBuilder();
      using (var wc = new WebClient())
      {
        stb.Append(wc.DownloadString(Url));
      }
      Output.Enqueue(new Dictionary<string, object> {{"Text", stb.ToString()}});
    }
  }
}
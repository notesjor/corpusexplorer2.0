using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using CodeHollow.FeedReader;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Helper;
using Polenter.Serialization;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Rss
{
  public class RssFeedCrawlerService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath, int limit)
    {
      if (!(connection is Feed feed))
        return;
      
      var dir = Path.Combine(outputPath, Authentication.Settings["Name"]);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      var serializer = new SharpSerializer();
      foreach (var item in feed.Items)
      {
        using (var file = new FileStream(Path.Combine(dir, $"feed_{item.Id}-{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.xml").EnsureFileName(), FileMode.Create, FileAccess.Write))
          serializer.Serialize(item, file);

        if(!string.IsNullOrEmpty(item.Link))
          try
          {
            using (var wc = new WebClient())
            {
              wc.DownloadFile(item.Link,
                              Path.Combine(dir, $"html_{item.Id}-{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.html")
                                  .EnsureFileName());
            }
          }
          catch
          {
            // ignore
          }
      }
    }
  }
}
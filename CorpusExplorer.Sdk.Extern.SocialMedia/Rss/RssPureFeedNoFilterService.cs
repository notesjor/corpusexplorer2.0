using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Rss
{
  public class RssPureFeedNoFilterService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath, int limit)
    {
      if (!(connection is List<SyndicationItem> feedItems))
        return;

      var dir = Path.Combine(outputPath, Authentication.Settings["Name"]);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      var serializer = new NetDataContractSerializer();
      foreach (var item in feedItems)
      {
        using (var file = new FileStream(Path.Combine(dir, $"feed_{item.Id}-{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.xml").EnsureFileName(), FileMode.Create, FileAccess.Write))
          serializer.Serialize(file, item);
      }
    }
  }
}
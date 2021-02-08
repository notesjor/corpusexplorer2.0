using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YouTubeScraper : AbstractScraper
  {
    public override string DisplayName => "YouTube";

    private JsonSerializer serializer = new JsonSerializer();

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        using (var tr = new StreamReader(fs))
        using (var jr = new JsonTextReader(tr))
        {
          var obj = serializer.Deserialize<YouTubeSearchService.YouTubeSearchServiceCommentThread>(jr);
          if (obj == null)
            return null;

          return new[]
          {
            new Dictionary<string, object>
            {
              {"Id", obj.Id},
              {"Likes", obj.LikeCount},
              {"ParentId", obj.ParentId},
              {"Datum", obj.Published},
              {"Antworten", obj.ReplyCount},
              {"Text", obj.Text},
              {"Datum (aktualisiert)", obj.Updated},
              {"UserId", obj.UserId},
            }
          };
        }
      }
      catch
      {
        return null;
      }
    }
  }
}

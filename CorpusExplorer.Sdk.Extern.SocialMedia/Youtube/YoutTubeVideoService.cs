using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.YouTube.v3;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YoutTubeVideoService : AbstractService
  {
    public string VideoId { get; set; }

    protected override AbstractAuthentication Authentication { get; } = new YoutubeApiKeyAuthentication();

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as YouTubeService;
      var serializer = new Newtonsoft.Json.JsonSerializer();
      foreach (var query in queries)
      {
        var reqComments = context.CommentThreads.List(query);
        var comments = reqComments.Execute();
        if (comments == null)
          continue;

        foreach (var comment in comments.Items)
        {
          using (var file = new StreamWriter(Path.Combine(OutputPath, $"youtube_{query}_comment_{comment.Id}.json"), false, Encoding.UTF8))
            serializer.Serialize(file, new YouTubeSearchService.YouTubeSearchServiceCommentThread
            {
              Published = comment.Snippet.TopLevelComment.Snippet.PublishedAt,
              Id = comment.Id,
              ReplyCount = comment.Snippet.TotalReplyCount,
              UserId = comment.Snippet.TopLevelComment.Snippet.AuthorDisplayName,
              LikeCount = comment.Snippet.TopLevelComment.Snippet.LikeCount,
              Updated = comment.Snippet.TopLevelComment.Snippet.UpdatedAt,
              Text = comment.Snippet.TopLevelComment.Snippet.TextDisplay,
              Replies = comment.Replies?.Comments?.Select(c => new YouTubeSearchService.YouTubeSearchServiceComment
              {
                Id = c.Id,
                LikeCount = c.Snippet.LikeCount,
                Published = c.Snippet.PublishedAt,
                Text = c.Snippet.TextDisplay,
                Updated = c.Snippet.UpdatedAt,
                UserId = c.Snippet.AuthorDisplayName
              }).ToArray()
            });
        }
      }
    }
  }
}
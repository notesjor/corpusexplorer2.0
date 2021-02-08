using System;
using System.IO;
using System.Linq;
using System.Text;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public static class YouTubeTheadStorageHelper
  {
    public static void Store(YouTubeService context, JsonSerializer serializer, string outputPath, CommentThread comment)
    {
      try
      {
        var path = Path.Combine(outputPath, $"youtube_{comment.Id}.json");
        if (File.Exists(path))
          return;

        using (var file = new StreamWriter(path, false, Encoding.UTF8))
          serializer.Serialize(file, new YouTubeSearchService.YouTubeSearchServiceCommentThread
          {
            Published = comment.Snippet.TopLevelComment.Snippet.PublishedAt ?? DateTime.MinValue,
            Id = comment.Id,
            ParentId = comment.Id,
            ReplyCount = comment.Snippet.TotalReplyCount,
            UserId = comment.Snippet.TopLevelComment.Snippet.AuthorDisplayName,
            LikeCount = comment.Snippet.TopLevelComment.Snippet.LikeCount,
            Updated = comment.Snippet.TopLevelComment.Snippet.UpdatedAt ?? DateTime.MinValue,
            Text = comment.Snippet.TopLevelComment.Snippet.TextDisplay
          });

        try
        {
          string page = null;

          while (true)
          {
            var reqComments = context.Comments.List("snippet");
            reqComments.ParentId = comment.Id;
            reqComments.MaxResults = 100;
            reqComments.TextFormat = CommentsResource.ListRequest.TextFormatEnum.PlainText;
            if (page != null)
              reqComments.PageToken = page;
            var comments = reqComments.Execute();
            page = comments.NextPageToken;

            if (comments?.Items == null || comments.Items.Count == 0)
              break;

            foreach (var c in comments.Items)
              Store(context, serializer, outputPath, c);

            if(comments.Items.Count < 100)
              break;
          }
        }
        catch
        {
          // ignore
        }
      }
      catch
      {
        // ignore
      }
    }

    private static void Store(YouTubeService context, JsonSerializer serializer, string outputPath, Comment comment)
    {
      try
      {
        using (var file = new StreamWriter(Path.Combine(outputPath, $"youtube_{comment.Id}.json"), false,
                                           Encoding.UTF8))
          serializer.Serialize(file, new YouTubeSearchService.YouTubeSearchServiceCommentThread
          {
            Published = comment.Snippet.PublishedAt ?? DateTime.MinValue,
            Id = comment.Id,
            UserId = comment.Snippet.AuthorDisplayName,
            LikeCount = comment.Snippet.LikeCount,
            Updated = comment.Snippet.UpdatedAt ?? DateTime.MinValue,
            Text = comment.Snippet.TextDisplay,
            ParentId = comment.Snippet.ParentId
          });
      }
      catch
      {
        // ignore
      }
    }
  }
}

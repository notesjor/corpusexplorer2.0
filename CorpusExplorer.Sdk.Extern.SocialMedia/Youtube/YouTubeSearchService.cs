using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.YouTube.v3;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YouTubeSearchService : AbstractService
  {
    public enum YouTubeServiceSafeSearch
    {
      None,
      Moderate,
      Strict
    }

    public class YouTubeSearchServiceResult
    {
      public string Title { get; set; }
      public string Description { get; set; }
      public string Author { get; set; }
      public DateTime Published { get; set; }
    }

    public class YouTubeSearchServiceCommentThread : YouTubeSearchServiceComment
    {
      public string ParentId { get; set; }
      public long? ReplyCount { get; set; }
    }

    public class YouTubeSearchServiceComment
    {
      public string Id { get; set; }
      public string UserId { get; set; }
      public DateTime Published { get; set; }
      public long? LikeCount { get; set; }
      public DateTime Updated { get; set; }
      public string Text { get; set; }
    }

    public DateTime? PublishedBefore { get; set; }
    public DateTime? PublishedAfter { get; set; }
    public string ChannelId { get; set; }
    public YouTubeServiceSafeSearch SafeSearch { get; set; } = YouTubeServiceSafeSearch.Strict;
    public string UserId { get; set; }
    public string Language { get; set; }
    public string RegionCode { get; set; }
    public bool GetComments { get; set; } = true;

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath, int limit)
    {
      var context = connection as YouTubeService;
      var request = context.Search.List(string.Join(",", queries));
      request.ChannelId = ChannelId;
      request.PublishedAfter = PublishedAfter;
      request.PublishedBefore = PublishedBefore;
      request.RegionCode = RegionCode;
      request.RelevanceLanguage = Language;
      request.SafeSearch = SafeSearch == YouTubeServiceSafeSearch.None
                             ? SearchResource.ListRequest.SafeSearchEnum.None
                             : SafeSearch == YouTubeServiceSafeSearch.Moderate
                               ? SearchResource.ListRequest.SafeSearchEnum.Moderate
                               : SearchResource.ListRequest.SafeSearchEnum.Strict;
      request.QuotaUser = UserId;

      var resp = request.Execute();
      var serializer = new Newtonsoft.Json.JsonSerializer();
      foreach (var item in resp.Items)
      {
        using (var file = new StreamWriter(Path.Combine(outputPath, $"youtube_{item.Id}.json"), false, Encoding.UTF8))
          serializer.Serialize(file, new YouTubeSearchServiceResult
          {
            Title = item.Snippet.Title,
            Description = item.Snippet.Description,
            Author = item.Snippet.ChannelId,
            Published = item.Snippet.PublishedAt ?? DateTime.MinValue,
          });

        if (!GetComments)
          continue;

        var reqComments = context.CommentThreads.List(item.Id.VideoId);
        var comments = reqComments.Execute();
        if (comments == null)
          continue;

        foreach (var comment in comments.Items)
        {
          YouTubeTheadStorageHelper.Store(context, serializer, outputPath, comment);
        }
      }
    }
  }
}
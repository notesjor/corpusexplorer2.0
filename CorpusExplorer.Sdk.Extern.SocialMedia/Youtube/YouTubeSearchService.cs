﻿using System;
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
      public string Describtion { get; set; }
      public string Author { get; set; }
      public DateTime? Published { get; set; }
    }

    public class YouTubeSearchServiceCommentThread : YouTubeSearchServiceComment
    {
      public YouTubeSearchServiceComment[] Replies { get; set; }
      public long? ReplyCount { get; set; }
    }

    public class YouTubeSearchServiceComment
    {
      public string Id { get; set; }
      public string UserId { get; set; }
      public DateTime? Published { get; set; }
      public long? LikeCount { get; set; }
      public DateTime? Updated { get; set; }
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

    protected override AbstractAuthentication Authentication { get; } = new YoutubeApiKeyAuthentication();

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
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
        using (var file = new StreamWriter(Path.Combine(OutputPath, $"youtube_{item.Id}.json"), false, Encoding.UTF8))
          serializer.Serialize(file, new YouTubeSearchServiceResult
          {
            Title = item.Snippet.Title,
            Describtion = item.Snippet.Description,
            Author = item.Snippet.ChannelId,
            Published = item.Snippet.PublishedAt,
          });

        if (!GetComments)
          continue;

        var reqComments = context.CommentThreads.List(item.Id.VideoId);
        var comments = reqComments.Execute();
        if (comments == null)
          continue;

        foreach (var comment in comments.Items)
        {
          using (var file = new StreamWriter(Path.Combine(OutputPath, $"youtube_{item.Id}_comment_{comment.Id}.json"), false, Encoding.UTF8))
            serializer.Serialize(file, new YouTubeSearchServiceCommentThread
            {
              Published = item.Snippet.PublishedAt,
              Id = comment.Id,
              ReplyCount = comment.Snippet.TotalReplyCount,
              UserId = comment.Snippet.TopLevelComment.Snippet.AuthorDisplayName,
              LikeCount = comment.Snippet.TopLevelComment.Snippet.LikeCount,
              Updated = comment.Snippet.TopLevelComment.Snippet.UpdatedAt,
              Text = comment.Snippet.TopLevelComment.Snippet.TextDisplay,
              Replies = comment.Replies?.Comments?.Select(c => new YouTubeSearchServiceComment
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
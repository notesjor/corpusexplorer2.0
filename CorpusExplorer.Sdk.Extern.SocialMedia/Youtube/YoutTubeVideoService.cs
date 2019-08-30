using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.YouTube.v3;
using WordPressPCL.Models;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YoutTubeVideoService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as YouTubeService;
      var serializer = new Newtonsoft.Json.JsonSerializer();
      var max = 0;
      var cnt = 0;
      string page = null;

      foreach (var query in queries)
      {
        try
        {
          while (true)
          {
            var reqComments = context.CommentThreads.List("snippet");
            reqComments.VideoId = query;
            reqComments.Order = CommentThreadsResource.ListRequest.OrderEnum.Time;
            reqComments.MaxResults = 100;
            reqComments.TextFormat = CommentThreadsResource.ListRequest.TextFormatEnum.PlainText;
            if (page != null)
              reqComments.PageToken = page;

            var comments = reqComments.Execute();
            page = comments.NextPageToken;

            if (comments?.Items == null || comments.Items.Count == 0)
              break;

            max += comments.Items.Count;

            foreach (var comment in comments.Items)
            {
              try
              {
                PostStatusUpdate($"Suche Kommentare zu {query} -  {cnt + 1}/{max}...", cnt++, max);

                var dir = Path.Combine(outputPath, query);
                if (!Directory.Exists(dir))
                  Directory.CreateDirectory(dir);

                YouTubeTheadStorageHelper.Store(context, serializer, dir, comment);
              }
              catch
              {
                // ignore
              }
            }
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Helper;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Reddit
{
  public class RedditSubredditService : AbstractService
  {
    protected override AbstractAuthentication Authentication { get; } = new RedditAuthentication();
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var reddit = connection as RedditSharp.Reddit;

      foreach (var query in queries)
      {
        var url = !query.StartsWith("/r/") ? $"/r/{query}" : query;
        var subreddit = reddit.GetSubreddit(url);

        foreach (var post in subreddit.Posts)
          Serializer.SerializeJson(post, Path.Combine(OutputPath, $"post_{post.Id}.json"));
      }
    }
  }
}
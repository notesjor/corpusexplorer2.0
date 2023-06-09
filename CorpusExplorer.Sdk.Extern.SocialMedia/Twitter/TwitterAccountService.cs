using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Delegates;
using LinqToTwitter;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterAccountService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath, int limit)
    {
      foreach (var query in queries)
      {
        ExecuteQuery(connection, query, outputPath, limit);
      }
    }

    private void ExecuteQuery(object connection, string query, string outputPath, int queryLimit)
    {
      if (!(connection is TwitterContext context))
        return;

      PostStatusUpdate($"Suche Twitter-Account: {query}...", 0, 1);
      var tweets = (from tweet in context.Status
                    where tweet.Type       == StatusType.User
                       && tweet.ScreenName == query
                       && tweet.Count      == 200
                    select tweet).ToList();

      ulong maxId = 0;
      if (tweets.Count > 0)
        maxId = ulong.Parse(tweets.Last().StatusID.ToString()) - 1;

      do
      {
        var limit = context.RateLimitRemaining;
        if (limit == 0)
          break;

        var ntweets = (from tweet in context.Status
                       where tweet.Type       == StatusType.User
                          && tweet.ScreenName == query
                          && tweet.MaxID      == maxId
                          && tweet.Count      == 200
                       select tweet).ToArray();
        tweets.AddRange(ntweets);
        PostStatusUpdate($"{tweets.Count} Tweets für {query}...", 0, 1);

        if (ntweets.Length > 0)
          maxId = ulong.Parse(tweets.Last().StatusID.ToString()) - 1;
        else
          break;

        if (limit > 0 && tweets.Count >= limit)
          break;

      } while (true);

      var account = query.Replace("@", "");
      var dir = Path.Combine(outputPath, account);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      var cnt = 1;
      foreach (var tweet in tweets)
      {
        PostStatusUpdate($"Speichere Tweet {cnt++}/{tweets.Count}...", cnt, tweets.Count);
        File.WriteAllText(Path.Combine(dir, $"twitter_usr_{account}_{tweet.CreatedAt:yyyy-MM-dd_HH-mm-ss}.json"), JsonConvert.SerializeObject(tweet));
      }
    }
  }
}

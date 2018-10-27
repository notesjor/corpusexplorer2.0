using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using LinqToTwitter;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterAccountService : AbstractService
  {
    protected override AbstractAuthentication Authentication => new TwitterContextAuthentication();

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      foreach (var query in queries)
      {
        ExecuteQuery(connection, query, outputPath);
      }
    }

    private void ExecuteQuery(object connection, string query, string outputPath)
    {
      if (!(connection is TwitterContext context))
        return;

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

        if (ntweets.Length > 0)
          maxId = ulong.Parse(tweets.Last().StatusID.ToString()) - 1;
        else
          break;
      } while (true);

      var dir = Path.Combine(outputPath,
                             query.Replace("@", ""));

      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      foreach (var tweet in tweets)
        File.WriteAllText(Path.Combine(dir, $"{tweet.CreatedAt:yyyy-MM-dd_HH-mm-ss}.json"),
                          JsonConvert.SerializeObject(tweet));
    }
  }
}

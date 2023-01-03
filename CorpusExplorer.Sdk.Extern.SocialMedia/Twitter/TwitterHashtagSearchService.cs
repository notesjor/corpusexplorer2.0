using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using LinqToTwitter;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterHashtagSearchService : AbstractService
  {
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

      List<Status> searchResponse;
      ulong sinceID = 1;
      ulong maxID = ulong.MaxValue;
      var cnt = 1;
      var sum = 0;

      do
      {
        PostStatusUpdate($"Suche Tweets zu \"{query}\"...", 0, 1);
        var task = (from search in context.Search
                    where search.Type == SearchType.Search &&
                          search.Query == query &&
                          search.Count == 100 &&
                          search.MaxID == maxID &&
                          search.SinceID == sinceID &&
                          search.TweetMode == TweetMode.Extended &&
                          search.SearchLanguage == "de"
                    select search.Statuses)
         .SingleOrDefaultAsync();
        task.Wait();

        searchResponse = task.Result;
        if (searchResponse == null || searchResponse.Count == 0)
          break;

        sum += searchResponse.Count;
        maxID = searchResponse.Min(status => status.StatusID) - 1;

        var dir = Path.Combine(outputPath, query.Replace("@", ""));

        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);

        foreach (var tweet in searchResponse)
        {
          PostStatusUpdate($"Speichere Tweet {cnt++}/{sum} zu \"{query}\"...", cnt, sum);
          File.WriteAllText(Path.Combine(dir, $"twitter_query_{query}_{tweet.CreatedAt:yyyy-MM-dd_HH-mm-ss}.json"), JsonConvert.SerializeObject(tweet));
        }

      } while (searchResponse.Any());
    }
  }
}
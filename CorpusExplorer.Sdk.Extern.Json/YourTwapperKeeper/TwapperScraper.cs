#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Model;
using CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper
{
  public sealed class TwapperScraper : AbstractGenericJsonFormatScraper<TwapperCorpus>
  {
    public override string DisplayName => "TwapperCorpus";
    protected override AbstractGenericDataReader<TwapperCorpus> DataReader => new TwapperCorpusReader();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<TwapperCorpus> model)
    {
      return from tc in model from tweet in tc.Tweets select Map(tweet);
    }

    private static Dictionary<string, object> Map(Tweet tweet)
    {
      return new Dictionary<string, object>
      {
        {"Archivesource", tweet.Archivesource},
        {"Erstellt", tweet.CreatedAt},
        {"Autor", tweet.FromUser},
        {"Autor (ID)", tweet.FromUserId},
        {"GEO 1", tweet.GeoCoordinates0},
        {"GEO 2", tweet.GeoCoordinates1},
        {"GEO (Typ)", tweet.GeoType},
        {"ID", tweet.Id},
        {"LANG", tweet.IsoLanguageCode},
        {"Quelle", tweet.Source},
        {"Text", tweet.Text},
        {"Datum", tweet.Time},
        {"Empfänger (ID)", tweet.ToUserId}
      };
    }
  }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Reader;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream
{
  public class TwitterAnonymizeScraper : AbstractGenericJsonFormatScraper<StreamMessage>
  {
    private readonly Dictionary<ulong, ulong> _idTweet = new Dictionary<ulong, ulong>();
    private readonly object _idTweetLock = new object();
    private readonly Dictionary<ulong, ulong> _idUser = new Dictionary<ulong, ulong>();
    private readonly object _idUserLock = new object();

    protected override AbstractGenericDataReader<StreamMessage> DataReader { get { return new TwitterDataReader(); } }

    public override string DisplayName { get { return "Twitter JSON Anonymize Scraper"; } }

    private ulong AnonymizeTweetId(StreamMessage message)
    {
      if (message == null)
        return 01;

      var id = ulong.Parse(message.IdStr);

      lock (_idTweetLock)
      {
        if (_idTweet.ContainsKey(id))
          return _idTweet[id];

        var res = (ulong) _idTweet.Count + 1;
        _idTweet.Add(id, res);
        return res;
      }
    }

    private ulong AnonymizeUserId(User user)
    {
      if (user == null)
        return 0;

      var id = ulong.Parse(user.IdStr);

      lock (_idUserLock)
      {
        if (_idUser.ContainsKey(id))
          return _idUser[id];

        var res = (ulong) _idUser.Count + 1;
        _idUser.Add(id, res);
        return res;
      }
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<StreamMessage> model)
    {
      if (model == null)
        return null;

      var res = new List<Dictionary<string, object>>();

      foreach (var message in model)
      {
        var act = message;

        // Rekursives Durchlaufen des RetweetStatus
        while (act != null)
        {
          var scrap = StreamMessageToScrapDocument(act);
          if (scrap == null)
            break;
          res.Add(scrap);
          act = act.RetweetedStatus;
        }
      }

      return res;
    }

    // ReSharper disable FunctionComplexityOverflow
    private Dictionary<string, object> StreamMessageToScrapDocument(StreamMessage message)
      // ReSharper restore FunctionComplexityOverflow
    {
      try
      {
        var id = AnonymizeUserId(message.User);
        var name = $"USR{id:D9}";
        var rid = AnonymizeTweetId(message.RetweetedStatus);
        var rname = $"USR{rid:D9}";

        return
          new Dictionary<string, object>
          {
            {"Geo", message.Coordinates == null ? "" : GeoCoordinatesHelper.Serialize(message.Coordinates.Coordinates)},
            {
              "Datum",
              DateTime.ParseExact(message.CreatedAt, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture)
            },
            {"Favorisierungs-Rate", message.FavoriteCount},
            {"Retweet-Rate", message.RetweetCount},
            {"Sprache", message.Lang},
            {"Text", message.Text},
            {"Tweet (Id)", AnonymizeTweetId(message)},
            {"Jugendgefährdend?", message.PossiblySensitive},
            {"Land", message.Place == null ? "" : message.Place.Country},
            {"Ländercode", message.Place == null ? "" : message.Place.CountryCode},
            {"Absender (Id)", id},
            {"Absender (Name)", name},
            {"Referenz (Id)", rid},
            {"Referenz (Name)", rname},
            {
              "Medien-URL (|-separiert)",
              message.Entities?.Media == null
                ? ""
                : string.Join("|", message.Entities.Media.Select(media => media.ExpandedUrl))
            },
            {
              "Externe-URL (|-separiert)",
              message.Entities?.Urls == null
                ? ""
                : string.Join("|", message.Entities.Urls.Select(url => url.ExpandedUrl))
            }
          };
      }
      catch
      {
        return null;
      }
    }
  }
}
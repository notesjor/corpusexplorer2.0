#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Reader;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;

// ReSharper disable All

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream
{
  public class TwitterScraper : AbstractGenericJsonFormatScraper<StreamMessage>
  {
    public override string DisplayName
      => "Twitter JSON Scraper";

    protected override AbstractGenericDataReader<StreamMessage> DataReader
      => new TwitterDataReader();

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

    private IEnumerable<Dictionary<string, object>> PostProcessingMerge(
      Dictionary<ulong, List<Dictionary<string, object>>> dic)
    {
      const string Label1 = "Retweet-Rate";
      const string Label2 = "Favorisierungs-Rate";

      var res = new List<Dictionary<string, object>>();

      foreach (var message in dic)
      {
        var act = message.Value.FirstOrDefault();

        // Wenn mehr als eine Nachricht vorliegt dann aktualisiere auf den höchsten Retweet/Favorisirungs-Wert
        if (message.Value.Count > 1)
        {
          foreach (var version in message.Value.Where(version => version.Get(Label1, 0) > act.Get(Label1, 0)))
          {
            act.Set(Label1, version.Get(Label1, 0));
            act.Set(Label2, version.Get(Label2, 0));
          }
        }

        res.Add(act);
      }

      return res;
    }

    // ReSharper disable FunctionComplexityOverflow
    private Dictionary<string, object> StreamMessageToScrapDocument(StreamMessage message)
    // ReSharper restore FunctionComplexityOverflow
    {
      try
      {
        return
          new Dictionary<string, object>
          {
            {
              "Geo",
              message.Coordinates == null ? "" : GeoCoordinatesHelper.Serialize(message.Coordinates.Coordinates)
            },
            {
              "Datum",
              DateTime.ParseExact(message.CreatedAt, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture)
            },
            {"Favorisierungs-Rate", message.FavoriteCount},
            {"Retweet-Rate", message.RetweetCount},
            {"Sprache", message.Lang},
            {"Quelle", message.Source},
            {"Text", message.Text},
            {"Tweet (Id)", ulong.Parse(message.IdStr)},
            {"Jugendgefährdend?", message.PossiblySensitive},
            {"Land", message.Place == null ? "" : message.Place.Country},
            {"Ländercode", message.Place == null ? "" : message.Place.CountryCode},
            {"Absender (Id)", message.User == null ? (ulong) 0 : ulong.Parse(message.User.IdStr)},
            {"Absender (Sprache)", message.User == null ? "" : message.User.Lang},
            {"Absender (Name)", message.User == null ? "" : message.User.Name},
            {"Absender (Anzeigename)", message.User == null ? "" : message.User.ScreenName},
            {"Absender (Follower)", message.User == null ? (ulong) 0 : message.User.FollowersCount},
            {"Absender (Tweets)", message.User == null ? (ulong) 0 : message.User.StatusesCount},
            {
              "Referenz (Id)",
              message.RetweetedStatus == null ? (ulong) 0 : ulong.Parse(message.RetweetedStatus.IdStr)
            },
            {
              "Referenz (Absender (Id))",
              message.RetweetedStatus == null || message.RetweetedStatus.User == null
                ? (ulong) 0
                : ulong.Parse(message.RetweetedStatus.User.IdStr)
            },
            {
              "Referenz (Absender (Sprache))",
              message.RetweetedStatus == null || message.RetweetedStatus.User == null
                ? ""
                : message.RetweetedStatus.User.Lang
            },
            {
              "Referenz (Absender (Name))",
              message.RetweetedStatus == null || message.RetweetedStatus.User == null
                ? ""
                : message.RetweetedStatus.User.Name
            },
            {
              "Referenz (Absender (Anzeigename))",
              message.RetweetedStatus == null || message.RetweetedStatus.User == null
                ? ""
                : message.RetweetedStatus.User.ScreenName
            },
            {
              "Referenz (Absender (Follower))",
              message.RetweetedStatus == null || message.RetweetedStatus.User == null
                ? (ulong) 0
                : message.RetweetedStatus.User.FollowersCount
            },
            {
              "Medien-URL (|-separiert)",
              message.Entities == null || message.Entities.Media == null
                ? ""
                : string.Join("|",
                  message.Entities.Media.Select(m => string.IsNullOrEmpty(m.MediaUrl) ? m.MediaUrlHttps : m.MediaUrl))
            },
            {
              "Externe-URL (|-separiert)",
              message.Entities == null || message.Entities.Urls == null
                ? ""
                : string.Join("|", message.Entities.Urls.Select(url => url.ExpandedUrl))
            },
            {
              "URL",
              message.User == null
                ? ""
                : string.Format("https://twitter.com/{0}/status/{1}", message.User.ScreenName, message.IdStr)
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
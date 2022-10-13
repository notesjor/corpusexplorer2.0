#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model;
using CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Reader;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;

// ReSharper disable All

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus
{
  public class TwitterStatusScraper : AbstractGenericJsonFormatScraper<Tweet>
  {
    public override string DisplayName
    {
      get { return "Twitter-Status JSON Scraper"; }
    }

    protected override AbstractGenericDataReader<Tweet> DataReader
    {
      get { return new TwitterStatusReader(); }
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<Tweet> model)
    {
      if (model == null)
        return null;

      var res = new List<Dictionary<string, object>>();

      foreach (var message in model)
      {
        var act = message;

        var scrap = StreamMessageToScrapDocument(act);
        if (scrap == null)
          break;
        res.Add(scrap);
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
    private Dictionary<string, object> StreamMessageToScrapDocument(Tweet message)
    // ReSharper restore FunctionComplexityOverflow
    {
      try
      {
        return
          new Dictionary<string, object>
          {
            {
              "Geo",
              message.Coordinates == null
                ? ""
                : GeoCoordinatesHelper.Serialize(new[] {message.Coordinates.Longitude, message.Coordinates.Latitude})
            },
            {
              "Datum",
              DateTime.ParseExact(message.CreatedAt, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
            },
            {"Favorisierungs-Rate", message.FavoriteCount},
            {"Retweet-Rate", message.RetweetCount},
            {"Sprache", message.Lang},
            {"Quelle", message.Source},
            {"Text", message.Text},
            {"Tweet (Id)", message.ID == 0 ? message.StatusID : message.ID},
            {"Jugendgefährdend?", message.PossiblySensitive},
            {"Land", message.Place == null ? "" : message.Place.Country},
            {"Ländercode", message.Place == null ? "" : message.Place.CountryCode},
            {"Absender (Id)", GetUserId(message)},
            {"Absender (Sprache)", message.User == null ? "" : message.User.Lang},
            {"Absender (Name)", message.User == null ? "" : message.User.Name},
            {"Absender (Anzeigename)", message.User == null ? "" : message.User.ScreenName},
            {"Absender (Follower)", message.User == null ? 0 : message.User.FollowersCount},
            {
              "Medien-URL (|-separiert)",
              message.Entities == null || message.Entities.MediaEntities == null
                ? ""
                : string.Join("|", message.Entities.MediaEntities.Select(media => media.ExpandedUrl))
            },
            {
              "Externe-URL (|-separiert)",
              message.Entities == null || message.Entities.UrlEntities == null
                ? ""
                : string.Join("|", message.Entities.UrlEntities.Select(url => url.ExpandedUrl))
            },
            {
              "URL",
              message.User == null
                ? ""
                : string.Format("https://twitter.com/{0}/status/{1}", message.User.ScreenName, message.ID)
            }
          };
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    private ulong GetUserId(Tweet message)
    {
      if(message.UserID > 0)
        return message.UserID;
      if (message.User == null)
        return 0;
      if (message.User.UserID > 0)
        return message.User.UserID;
      return ulong.Parse(message.User.UserIDResponse);
    }
  }
}
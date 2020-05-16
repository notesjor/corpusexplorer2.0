using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CodeHollow.FeedReader;
using CorpusExplorer.Sdk.Extern.SocialMedia.Blogger;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Helper;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties;
using CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr;
using CorpusExplorer.Sdk.Extern.SocialMedia.Twitter;
using CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress;
using CorpusExplorer.Sdk.Extern.SocialMedia.Youtube;
using HtmlAgilityPack;
using Polenter.Serialization;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  public partial class MainControl : AbstractUserControl
  {
    public MainControl()
    {
      InitializeComponent();
      Load += (s, e) => pages_main.SelectedPage = page_main_main;

      pages_blogger.MakeHeaderInvisible();
      //pages_facebook.MakeHeaderInvisible();
      //pages_instagram.MakeHeaderInvisible();
      pages_tumblr.MakeHeaderInvisible();
      pages_twitter.MakeHeaderInvisible();
      pages_youtube.MakeHeaderInvisible();

      btn_main_blogger.OnClick += (s, e) => pages_main.SelectedPage = page_main_blogger;
      //btn_main_facebook.OnClick += (s, e) => pages_main.SelectedPage = page_main_facebook;
      //btn_main_forum.OnClick += (s, e) => pages_main.SelectedPage = page_main_forum;
      //btn_main_instagram.OnClick += (s, e) => pages_main.SelectedPage = page_main_instagram;
      //btn_main_reddit.OnClick += (s, e) => pages_main.SelectedPage = page_main_reddit;
      btn_main_tumblr.OnClick += (s, e) => pages_main.SelectedPage = page_main_tumblr;
      btn_main_twitter.OnClick += (s, e) => pages_main.SelectedPage = page_main_twitter;
      //btn_main_web.OnClick += (s, e) => pages_main.SelectedPage = page_main_web;
      //btn_main_wordpress.OnClick += (s, e) => pages_main.SelectedPage = page_main_wordpress;
      btn_main_youtube.OnClick += (s, e) => pages_main.SelectedPage = page_main_youtube;
      btn_main_feed.OnClick += (s, e) => pages_main.SelectedPage = page_main_feed;

      // BLOCK
      pages_main.SelectedPageChanging += (s, e) =>
      {
        if (e.Page == page_main_web) // e.Page == page_main_reddit   || 
          e.Cancel = true;
      };

      // (1) Nachdem ServiceName gesetzt wurde, kann das Mapping erfolgen.

      serviceHome_blogger.Authentication = new BloggerAuthentication();
      // ToDo: serviceHome_facebook.SetApiCredentials(_services[serviceHome_facebook.ServiceName].Settings);
      // ToDo: serviceHome_instagram.SetApiCredentials(_services[serviceHome_instagram.ServiceName].Settings);
      // ToDo: serviceHome_reddit.SetApiCredentials(_services[serviceHome_reddit.ServiceName].Settings);
      serviceHome_tumblr.Authentication = new TumblrAuthentication();
      serviceHome_twitter.Authentication = new TwitterAuthentication();
      // ToDo: serviceHome_wordpress.Authentication = new WordPressAuthentication();
      serviceHome_youtube.Authentication = new YouTubeAuthentication();

      // (2) Endpoints müssen manuell (über diesen Code) eigefügt werden.
      serviceHome_blogger
       .AddEndpoint(Resources.blogger_128px,
                    "<html><strong>Blogger</strong><br/>Erstellt ein Korpus aus Blog-Posts.</html>",
                    1,
                    new EndpointRequestSimple(),
                    new BloggerService());
      /* ToDo: implementieren
      serviceHome_blogger
       .AddEndpoint(Resources.blogger_128px,
                    "<html><strong>Blogger</strong><br/>Nutzen Sie Blog-Posts und Kommentare als Korpusquelle.</html>",
                    2,
                    new EndpointRequestSimple(),
                    new BloggerService());
      */
      // ToDo: Weitere Service hinzufügen
      serviceHome_tumblr
       .AddEndpoint(Resources.tumblr_128px,
                    "<html><strong>Tumblr</strong><br/>Geben Sie eine Liste von Blognamen ein, um diese komplett zu erfassen.</html>",
                    1,
                    new EndpointRequestSimple(),
                    new TumblrService()
                   );
      serviceHome_twitter
       .AddEndpoint(Resources.twitter_128px,
                    "<html><strong>Twitter</strong><br/>Die letzten 3200 Tweets eines Accounts abrufen.</html>",
                    1,
                    new EndpointRequestSimple(),
                    new TwitterAccountService());
      serviceHome_twitter
       .AddEndpoint(Resources.twitter_128px,
                    "<html><strong>Twitter</strong><br/>Die letzten 10000 Tweets zu einem Thema abrufen.</html>",
                    2,
                    new EndpointRequestSimple(),
                    new TwitterHashtagSearchService());
      serviceHome_twitter
       .AddEndpoint(Resources.twitter_128px,
                    "<html><strong>Twitter</strong><br/>Themen/Hashtags im Twitter-Stream aufzeichnen.</html>",
                    3,
                    new EndpointRequestSimple(),
                    new TwitterStreamService());
      serviceHome_youtube
       .AddEndpoint(Resources.youtube_128px,
                    "<html><strong>YouTube</strong><br/>Erfassen Sie alle Kommentare zu bestimmten Videos.</html>",
                    2,
                    new EndpointRequestSimple(),
                    new YoutTubeVideoService());
      serviceHome_youtube
       .AddEndpoint(Resources.youtube_128px,
                    "<html><strong>YouTube</strong><br/>Suchen Sie nach Videos und laden Sie die Kommentare herunter.</html>",
                    2,
                    new EndpointRequestSimple(),
                    new YouTubeSearchService());
      page_main_feed_request.Execute += page_main_feed_request_Execute;
      // ToDo: Weitere Service hinzufügen
    }

    private void pages_main_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
    {
      if (e.Page == null || e.Page.Controls.Count != 1)
        return;
      if (!(e.Page.Controls[0] is RadPageView rpv))
        return;
      rpv.SelectedPage = rpv.Pages[0];
    }

    // TODO: Refactoring >>>>

    private void page_main_feed_request_Execute(SocialMedia.Abstract.AbstractAuthentication auth, System.Collections.Generic.Dictionary<string, object> parameters)
    {
      var urls = parameters["queries"] as string[];
      if(urls == null)
        return;

      foreach (var url in urls)
      {
        try
        {
          var html = new HtmlDocument();
          using (var wc = new WebClient())
            html.LoadHtml(wc.DownloadString(url));

          var nodes = new List<HtmlNode>();
          nodes.AddRange(html.DocumentNode.SelectNodes("//a"));
          nodes.AddRange(html.DocumentNode.SelectNodes("//link"));

          foreach (var node in nodes)
          {
            var href = node.GetAttributeValue("href", "").ToLower();
            var points = 0;

            if (node.GetAttributeValue("rel", "") == "alternate")
              points++;

            if (node.GetAttributeValue("type", "") == "application/rss+xml")
              points++;

            if (href.Contains("rss") || href.Contains("rdf") || href.Contains("atom") || href.Contains("feed"))
              points++;

            if (points >= 2)
            {
              if (href.StartsWith("/"))
                href = url.Substring(0, url.Length - 1) + href;

              if (!href.StartsWith("http:") && !href.StartsWith("https:"))
                continue;

              ProcessFeed(url);
            }
          }
        }
        catch
        {
          // ignore
        }
      }
    }

    private static void ProcessFeed(string url)
    {
      try
      {
        var task = FeedReader.ReadAsync(url);
        task.Wait();
        var feed = task.Result;
        if (feed == null)
          return;

        var valid = feed.Items.Where(x => x.PublishingDate.HasValue).ToArray(); // ToArray() wichtig, um die Analyse durchzuführen
        if (valid.Length == 0)
          return;

        foreach (var item in valid)
          ProcessItem(item);

      }
      catch
      {
        // ignore
      }
    }

    private static void ProcessItem(FeedItem item)
    {
      var fn = Guid.NewGuid().ToString("N");

      try
      {
        var serializer = new SharpSerializer();
        serializer.Serialize(item, GenerateFilePath(fileName: fn));
      }
      catch
      {
        // ignore
      }

      try
      {
        using (var wc = new WebClient())
        {
          var stream = wc.OpenRead(item.Link);
          var size = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);
          stream?.Close();
          if (size < 500000)
            wc.DownloadFile(item.Link, GenerateFilePath(fileName: fn, extension: ".html"));
        }
      }
      catch
      {
        // ignore
      }
    }

    private static string GenerateFilePath(string fileName, string extension = ".xml")
    {
      throw new NotImplementedException();
    }

    // <<<<< TODO: Refactoring ENDE
  }
}
using CorpusExplorer.Sdk.Extern.SocialMedia.Blogger;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties;
using CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr;
using CorpusExplorer.Sdk.Extern.SocialMedia.Twitter;
using CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress;
using CorpusExplorer.Sdk.Extern.SocialMedia.Youtube;
using CorpusExplorer.Terminal.WinForm.Helper;
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
      pages_facebook.MakeHeaderInvisible();
      pages_instagram.MakeHeaderInvisible();
      pages_reddit.MakeHeaderInvisible();
      pages_tumblr.MakeHeaderInvisible();
      pages_twitter.MakeHeaderInvisible();
      pages_wordpress.MakeHeaderInvisible();

      btn_main_blogger.OnClick += (s, e) => pages_main.SelectedPage = page_main_blogger;
      //btn_main_facebook.OnClick += (s, e) => pages_main.SelectedPage = page_main_facebook;
      //btn_main_forum.OnClick += (s, e) => pages_main.SelectedPage = page_main_forum;
      //btn_main_instagram.OnClick += (s, e) => pages_main.SelectedPage = page_main_instagram;
      //btn_main_reddit.OnClick += (s, e) => pages_main.SelectedPage = page_main_reddit;
      btn_main_tumblr.OnClick += (s, e) => pages_main.SelectedPage = page_main_tumblr;
      btn_main_twitter.OnClick += (s, e) => pages_main.SelectedPage = page_main_twitter;
      //btn_main_web.OnClick += (s, e) => pages_main.SelectedPage = page_main_web;
      //btn_main_wordpress.OnClick += (s, e) => pages_main.SelectedPage = page_main_wordpress;
      //btn_main_youtube.OnClick += (s, e) => pages_main.SelectedPage = page_main_youtube;

      // BLOCK
      pages_main.SelectedPageChanging += (s, e) =>
      {
        if (e.Page == page_main_facebook || e.Page == page_main_forum || e.Page == page_main_instagram ||
            e.Page == page_main_reddit   || e.Page == page_main_web   || e.Page == page_main_youtube   ||
            e.Page == page_main_wordpress)
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
      serviceHome_youtube.Authentication = new YoutubeAuthentication();

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
      serviceHome_wordpress
       .AddEndpoint(Resources.wordpress_128px,
                    "<html><strong>WordPress</strong><br/>Blogposts suchen und speichern.</html>",
                    1,
                    new EndpointRequestSimple(),
                    new WordPressService {GetComments = false});
      serviceHome_wordpress
       .AddEndpoint(Resources.wordpress_128px,
                    "<html><strong>WordPress</strong><br/>Blogposts inkl. Kommentare suchen und speichern.</html>",
                    2,
                    new EndpointRequestSimple(),
                    new WordPressService {GetComments = true});
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
  }
}
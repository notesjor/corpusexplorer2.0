using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Tfres;
using System.Net;
using System.Security.Claims;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Web;
using RestSharp;
using System.Text;
using Newtonsoft.Json;

namespace CorpusExplorer.Api.KorapOauth2
{
  internal class Program
  {
    static RestClient _client;

    static string _clientId = "FJH4mfppbHG7PbmNpr4JH6";
    static string _clientSecret;
    static string _clientRedirect = "https://api.corpusexplorer.de/oauth2/korap";
    static string _basicAuth;

    static string[] _scopes;
    static string _baseUrl = null;
    static string _sessionPrefix = "CorpusExplorer-";
    static int _sessionPrefixLength = _sessionPrefix.Length;

    static Dictionary<string, Session> _openSessions = new Dictionary<string, Session>();
    static object _sessionLock = new object();
    static TimeSpan _sessionTimeout = new TimeSpan(0, 10, 0);
    static DateTime _nextCleanup;

    static string _korapResponse = "<html><head></head><body><script>window.close();</script></body></html>";
    static string _korapResponseType = "text/html";

    static void Main(string[] args)
    {
      _scopes = File.ReadAllLines("scopes.lst").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
      _baseUrl = $"https://korap.ids-mannheim.de/settings/oauth/authorize?client_id={_clientId}&redirect_uri={HttpUtility.UrlEncode(_clientRedirect)}&response_type=code&scope={string.Join("%20", _scopes)}&state=CorpusExplorer-";

      var server = new Server("*", 55023, (obj) => obj.Response.Send(200));
      server.AddEndpoint(HttpMethod.Get, "/new", NewSession);
      server.AddEndpoint(HttpMethod.Get, "/korap", KorapInterface);
      server.AddEndpoint(HttpMethod.Get, "/fetch", FetchToken);

      _clientSecret = File.ReadAllText("credential.key");
      _basicAuth = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(_clientId + ":" + _clientSecret))}";

      var options = new RestClientOptions()
      {
        Timeout = new TimeSpan(0, 0, 30)
      };
      _client = new RestClient(options);

      _nextCleanup = DateTime.Now.Add(_sessionTimeout);

      while (true)
        Thread.Sleep(25000);
    }

    public class Session
    {
      public DateTime Expires { get; set; }
      public string Token { get; set; }
      public string RefreshToken { get; set; }
    }

    private static void NewSession(HttpContext ctx)
    {
      var guid = Guid.NewGuid().ToString("N");

      lock (_sessionLock)
        _openSessions.Add(guid, new Session()
        {
          Expires = DateTime.Now + _sessionTimeout,
          Token = ""
        });

      ctx.Response.Send(_baseUrl + guid, "text/plain");

      SessionCleanup();
    }

    private static void KorapInterface(HttpContext ctx)
    {
      // Hinweis: Diesen Endpunkt nutzt nur KorAP - es wird immer OK zurück gegeben auch im Fehlerfall.

      var data = ctx.Request.GetData();
      if (data == null)
      {
        ctx.Response.Send(_korapResponse, _korapResponseType);
        return;
      }

      if (!data.ContainsKey("state") || !data.ContainsKey("code"))
      {
        ctx.Response.Send(_korapResponse, _korapResponseType);
        return;
      }

      var guid = data["state"];
      if (guid.StartsWith(_sessionPrefix))
        guid = guid.Substring(_sessionPrefixLength);
      else
      {
        ctx.Response.Send(_korapResponse, _korapResponseType);
        return;
      }

      lock (_sessionLock)
      {
        if (!_openSessions.ContainsKey(guid))
        {
          ctx.Response.Send(_korapResponse, _korapResponseType);
          return;
        }

        ctx.Response.Send(_korapResponse, _korapResponseType); // Sage hier schon KorAP Ok

        var code = data["code"];

        var request = new RestRequest("https://korap.ids-mannheim.de/api/v1.0/oauth2/token", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("Authorization", _basicAuth);
        request.AddParameter("grant_type", "authorization_code");
        request.AddParameter("client_id", _clientId);
        request.AddParameter("redirect_uri", _clientRedirect);
        request.AddParameter("code", code);
        RestResponse response = _client.Execute(request);

        var korap = JsonConvert.DeserializeObject<KorapResponse>(response.Content);
        if (korap == null)
          return;

        _openSessions[guid].Token = korap.AccessToken;
        _openSessions[guid].RefreshToken = korap.RefreshToken;
      }
    }

    public class KorapResponse
    {
      [JsonProperty("access_token")]
      public string AccessToken { get; set; }
      [JsonProperty("refresh_token")]
      public string RefreshToken { get; set; }
      [JsonProperty("scope")]
      public string Scope { get; set; }
      [JsonProperty("token_type")]
      public string TokenType { get; set; }
      [JsonProperty("expires_in")]
      public int ExpiresIn { get; set; }
    }

    private static void FetchToken(HttpContext ctx)
    {
      var data = ctx.Request.GetData();
      if (data == null)
      {
        ctx.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      if (!data.ContainsKey("state"))
      {
        ctx.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      var guid = data["state"];
      if (guid.StartsWith(_sessionPrefix))
        guid = guid.Substring(_sessionPrefixLength);
      else
      {
        ctx.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      lock (_sessionLock)
      {
        if (!_openSessions.ContainsKey(guid))
        {
          ctx.Response.Send(HttpStatusCode.NotFound);
          return;
        }

        var session = _openSessions[guid];
        _openSessions.Remove(guid);

        ctx.Response.Headers.Add("RefreshToken", session.RefreshToken);
        ctx.Response.Send(session.Token, "text/plain");
      }
    }

    private static void SessionCleanup()
    {
      lock (_sessionLock)
      {
        if (DateTime.Now < _nextCleanup)
          return;

        // Flood Protection
        var date = _openSessions.Count > 10000
          ? DateTime.Now.AddMinutes(8)
          : _openSessions.Count > 1000
            ? DateTime.Now.AddMinutes(5)
            : DateTime.Now;

        var kill = new List<string>();
        foreach (var session in _openSessions)
          if (date > session.Value.Expires)
            kill.Add(session.Key);

        foreach (var x in kill)
          _openSessions.Remove(x);

        _nextCleanup = DateTime.Now.Add(_sessionTimeout);
      }
    }
  }
}
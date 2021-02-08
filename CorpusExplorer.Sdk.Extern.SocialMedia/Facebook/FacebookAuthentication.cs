using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Facebook;
using Newtonsoft.Json;
using RestSharp;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Facebook
{
  public class FacebookAuthentication : AbstractAuthentication
  {
    public override string ProviderName => "Facebook";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"App-ID", ""},
        {"App-Geheimcode", ""},
      };

    public override object OpenConnection()
    {
      try
      {
        var client = new RestClient($"https://graph.facebook.com/oauth/access_token?client_id={Settings["App-ID"]}&client_secret={Settings["App-Geheimcode"]}&grant_type=client_credentials");
        var request = new RestRequest(Method.GET);

        return new FacebookClient(JsonConvert.DeserializeObject<FacebookOAuthResponse>(client.Execute(request).Content).access_token)
        {
          AppId = Settings["App-ID"],
          AppSecret = Settings["App-Geheimcode"]
        };
      }
      catch
      {
        return null;
      }
    }
  }
}
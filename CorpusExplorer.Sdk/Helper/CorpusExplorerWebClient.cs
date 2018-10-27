using System;
using System.Net;

namespace CorpusExplorer.Sdk.Helper
{
  public class CorpusExplorerWebClient : WebClient
  {
    protected override WebRequest GetWebRequest(Uri uri)
    {
      var res = base.GetWebRequest(uri);
      if (res != null)
        res.Timeout = 30 * 60 * 1000;
      return res;
    }
  }
}
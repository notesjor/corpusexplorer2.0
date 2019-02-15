using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bcs.Network
{
  public static class WebRequestHelper
  {
    public static string SendPostData(string url, string jsonData, string contentType = "application/json", string method = "POST")
    {
      try
      {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
        httpWebRequest.ContentType = contentType;
        httpWebRequest.Method = method;

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
          streamWriter.Write(jsonData);

        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
          return streamReader.ReadToEnd();
      }
      catch
      {
        return null;
      }
    }
  }
}

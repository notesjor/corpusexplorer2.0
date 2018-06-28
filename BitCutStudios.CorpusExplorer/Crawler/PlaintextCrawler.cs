#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Bcs.Crawler.Interface;

#endregion

namespace Bcs.Crawler
{
  // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
  /// <summary>
  ///   Class HtmlCrawler
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class PlaintextCrawler : ICrawler
  {
    /// <summary>
    ///   Crawle die Url
    /// </summary>
    /// <returns>Gemappte Daten</returns>
    public Dictionary<string, object>[] Crawl()
    {
      if (string.IsNullOrEmpty(Url))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Url");

      using (var wc = new WebClient {Encoding = Encoding.UTF8})
      {
        return new[] {new Dictionary<string, object> {{"Text", wc.DownloadString(Url)}}};
      }
    }

    /// <summary>
    ///   Die zu crawlende URL
    /// </summary>
    /// <value>The URL.</value>
    [XmlAttribute("url")]
    public string Url { get; set; }
  }
}
#region

using System.Collections.Generic;

#endregion

namespace Bcs.Crawler.Interface
{
  public interface ICrawler
  {
    #region Public Properties

    string Url { get; set; }

    #endregion

    #region Public Methods and Operators

    Dictionary<string, object>[] Crawl();

    #endregion
  }
}
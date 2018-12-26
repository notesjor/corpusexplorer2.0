using System.Collections.Generic;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Links
  {

    [JsonProperty("about")]
    public IList<About> About { get; set; }

    [JsonProperty("author")]
    public IList<Author> Author { get; set; }

    [JsonProperty("collection")]
    public IList<Collection> Collection { get; set; }

    [JsonProperty("curies")]
    public IList<Cury> Curies { get; set; }

    [JsonProperty("replies")]
    public IList<Reply> Replies { get; set; }

    [JsonProperty("self")]
    public IList<Self> Self { get; set; }

    [JsonProperty("version-history")]
    public IList<VersionHistory> VersionHistory { get; set; }

    [JsonProperty("wp:attachment")]
    public IList<WpAttachment> WpAttachment { get; set; }

    [JsonProperty("wp:featuredmedia")]
    public object WpFeaturedmedia { get; set; }

    [JsonProperty("wp:post_type")]
    public object WpPostType { get; set; }

    [JsonProperty("wp:term")]
    public IList<WpTerm> WpTerm { get; set; }
  }
}
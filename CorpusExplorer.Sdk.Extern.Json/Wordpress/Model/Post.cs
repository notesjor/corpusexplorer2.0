using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Post
  {

    [JsonProperty("_links")]
    public Links Links { get; set; }

    [JsonProperty("author")]
    public int Author { get; set; }

    [JsonProperty("categories")]
    public IList<int> Categories { get; set; }

    [JsonProperty("comment_status")]
    public string CommentStatus { get; set; }

    [JsonProperty("content")]
    public Content Content { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("date_gmt")]
    public DateTime DateGmt { get; set; }

    [JsonProperty("excerpt")]
    public Excerpt Excerpt { get; set; }

    [JsonProperty("featured_media")]
    public int FeaturedMedia { get; set; }

    [JsonProperty("format")]
    public string Format { get; set; }

    [JsonProperty("guid")]
    public Guid Guid { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("liveblog_likes")]
    public int LiveblogLikes { get; set; }

    [JsonProperty("meta")]
    public IList<object> Meta { get; set; }

    [JsonProperty("modified")]
    public DateTime Modified { get; set; }

    [JsonProperty("modified_gmt")]
    public DateTime ModifiedGmt { get; set; }

    [JsonProperty("password")]
    public object Password { get; set; }

    [JsonProperty("ping_status")]
    public string PingStatus { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("sticky")]
    public bool Sticky { get; set; }

    [JsonProperty("tags")]
    public IList<int> Tags { get; set; }

    [JsonProperty("template")]
    public string Template { get; set; }

    [JsonProperty("title")]
    public Title Title { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
  }
}

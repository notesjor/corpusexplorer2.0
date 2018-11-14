using System.Collections.Generic;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Blogger
{
  public class BloggerService : AbstractService
  {
    protected override AbstractAuthentication Authentication { get; }
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as Google.Apis.Blogger.v3.BloggerService;
      if (context == null)
        return;

      var reqBlog = context.Blogs.Get(BlogId);
      var resBlog = reqBlog.Execute();

      var serializer = new Newtonsoft.Json.JsonSerializer();

      foreach (var item in resBlog.Posts.Items)
      {
        using (var file = new StreamWriter(Path.Combine(OutputPath, $"blogger_{item.Id}.json"), false, Encoding.UTF8))
          serializer.Serialize(file, item);

        foreach (var comment in item.Replies.Items)
          using (var file = new StreamWriter(Path.Combine(OutputPath, $"blogger_{item.Id}_comment_{comment.Id}.json"), false, Encoding.UTF8))
            serializer.Serialize(file, comment);
      }
    }

    public string BlogId { get; set; }
  }
}
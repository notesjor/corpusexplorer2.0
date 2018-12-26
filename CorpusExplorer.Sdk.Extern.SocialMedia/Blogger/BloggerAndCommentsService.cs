using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Blogger
{
  public class BloggerAndCommentsService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as Google.Apis.Blogger.v3.BloggerService;
      if (context == null)
        return;

      PostStatusUpdate("Inhalte werden abgerufen...", 0, 1);

      var cnt = 1;
      var sum = 0;
      var date = DateTime.Now;
      var serializer = new NetDataContractSerializer();
      foreach (var blogId in queries)
      {
        while (true)
        {
          var reqBlog = context.Posts.List(blogId);
          reqBlog.EndDate = date;
          var resBlog = reqBlog.Execute();
          if (resBlog.Items == null || resBlog.Items.Count == 0)
            break;

          var array = resBlog.Items.ToArray();
          sum += array.Length;

          var dir = Path.Combine(outputPath, blogId);
          if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

          foreach (var item in array)
          {
            PostStatusUpdate($"Speichere Post {cnt}/{sum}...", cnt, sum);
            using (var file = new FileStream(Path.Combine(dir, $"blogger_{item.Id}.xml"), FileMode.Create,
                                             FileAccess.Write))
              serializer.Serialize(file, item);
            cnt++;

            var reqCom = context.Comments.List(blogId, item.Id);
            // ToDo

            if (item.Published.HasValue && item.Published.Value < date)
              date = item.Published.Value;
          }
        }
      }
    }
  }
}
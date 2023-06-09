using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Delegates;
using CorpusExplorer.Sdk.Extern.SocialMedia.Helper;
using CorpusExplorer.Sdk.Helper;
using DontPanic.TumblrSharp;
using DontPanic.TumblrSharp.Client;
using LinqToTwitter;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr
{
  public class TumblrService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath, int limit)
    {
      foreach (var blogName in queries)
        Query(connection, blogName, outputPath, limit);
    }

    protected void Query(object connection, string blogName, string outputPath, int limit)
    {
      var context = connection as TumblrClient;
      if (context == null)
        return;

      var path = Path.Combine(outputPath, blogName).EnsureFileName();
      if(!Directory.Exists(path))
        Directory.CreateDirectory(path);

      PostStatusUpdate("Inhalte werden abgerufen...", 0, 1);
      
      var serializer = new NetDataContractSerializer();
      for (var i = 0; i < int.MaxValue; i += 20)
      {
        var cnt = 1;
        var sum = 0;
        try
        {          
          var request = context.GetPostsAsync(blogName, i, 20, PostType.All, true, true);
          if (request == null)
            break;
          request.Wait();

          if (request.Exception != null)
            break;
          if (request.Result?.Result == null || request.Result.Result.Length == 0)
            break;

          var array = request.Result.Result;
          sum += array.Length;

          foreach (var post in request.Result.Result)
          {
            PostStatusUpdate($"Speichere Post {cnt}/{sum}...", cnt, array.Length);
            using (var file = new FileStream(Path.Combine(path, $"{post.Id}.xml"), FileMode.Create, FileAccess.Write))
              serializer.Serialize(file, post);
            cnt++;
          }

          if (limit > 0 && sum >= limit)
            break;
        }
        catch
        {
          // ignore
        }
      }
    }
  }
}
using System.Collections.Generic;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using DontPanic.TumblrSharp;
using DontPanic.TumblrSharp.Client;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr
{
  public class TumblrService : AbstractService
  {
    public string BlogName { get; set; }

    protected override AbstractAuthentication Authentication { get; } = new TumblrAuthentication();

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as TumblrClient;
      if (context == null)
        return;

      var serializer = new Newtonsoft.Json.JsonSerializer();
      for (var i = 0; i < int.MaxValue; i += 20)
      {
        var request = context.GetPostsAsync(BlogName, i, 20, PostType.All, true, true);
        if (request == null)
          break;
        request.Wait();

        if (request.Exception != null)
          break;
        if (request.Result?.Result == null || request.Result.Result.Length == 0)
          break;

        foreach (var post in request.Result.Result)
        {
          using (var file = new StreamWriter(Path.Combine(OutputPath, $"tumblr_{post.Id}.json"), false, Encoding.UTF8))
            serializer.Serialize(file, post);
        }
      }

    }
  }
}
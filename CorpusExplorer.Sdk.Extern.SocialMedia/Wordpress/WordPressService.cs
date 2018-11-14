using System.Collections.Generic;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using WordPressPCL;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress
{
  public class WordPressService : AbstractService
  {
    public bool Embed { get; set; } = true;
    private bool Authenticate => Authentication is WordPressUserAuthentication;
    public bool GetComments { get; set; } = true;

    protected override AbstractAuthentication Authentication { get; } = new WordPressNoAuthentication();
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var client = connection as WordPressClient;
      if (client == null)
        return;

      var posts = queries == null
                    ? client.Posts.GetAll(Embed, Authenticate)
                    : client.Posts.GetPostsBySearch(string.Join(" ", queries), Embed, Authenticate);
      posts.Wait();

      var serializer = new Newtonsoft.Json.JsonSerializer();

      foreach (var post in posts.Result)
      {

        using (var file = new StreamWriter(Path.Combine(OutputPath, $"wordpress_{post.Id}.json"), false, Encoding.UTF8))
          serializer.Serialize(file, post);

        if(!GetComments)
          continue;

        var comments = client.Comments.GetAllCommentsForPost(post.Id, Embed, Authenticate);
        comments.Wait();

        foreach (var comment in comments.Result)
        {
          using (var file = new StreamWriter(Path.Combine(OutputPath, $"wordpress_{post.Id}_comment_{comment.Id}.json"), false, Encoding.UTF8))
            serializer.Serialize(file, comment);
        }
      }
    }
  }
}
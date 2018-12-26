using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Helper;
using WordPressPCL;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress
{
  public class WordPressService : AbstractService
  {
    public bool GetComments { get; set; } = true;

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var client = connection as WordPressClient;
      if (client == null)
        return;

      PostStatusUpdate("Verbindung zum Blog wird aufgebaut...", 0, 1);
      var posts = queries == null || !queries.Any()
                    ? client.Posts.GetAll(false, true)
                    : client.Posts.GetPostsBySearch(string.Join(" ", queries), false, true);
      posts.Wait();

      var serializer = new Newtonsoft.Json.JsonSerializer();
      var cntP = 1;
      var arrP = posts.Result.ToArray();

      foreach (var post in arrP)
      {
        PostStatusUpdate($"Speichere Post {cntP++}/{arrP.Length}...", cntP,arrP.Length);

        var raw = post.Content.Raw;
        var ren = post.Content.Rendered;

        using (var file = new StreamWriter(Path.Combine(outputPath, $"{post.Id}.json").EnsureFileName(), false, Encoding.UTF8))          
          serializer.Serialize(file, post);

        if (!GetComments)
          continue;

        PostStatusUpdate($"Rufe Kommentare zu PostID:{post.Id} ab...", cntP, arrP.Length);
        var comments = client.Comments.GetAllCommentsForPost(post.Id, false, true);
        comments.Wait();

        var cntC = 1;
        var arrC = comments.Result.ToArray();

        foreach (var comment in arrC)
        {
          PostStatusUpdate($"Speichere Kommentar {cntC++}/{arrC.Length} zu PostID:{post.Id} ab...", cntC, arrC.Length);
          using (var file = new StreamWriter(Path.Combine(outputPath, $"{post.Id}_comment_{comment.Id}.json").EnsureFileName(), false, Encoding.UTF8))
            serializer.Serialize(file, comment);
        }
      }
    }
  }
}
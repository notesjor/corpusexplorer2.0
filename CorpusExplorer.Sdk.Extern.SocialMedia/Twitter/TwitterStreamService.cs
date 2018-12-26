using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using LinqToTwitter;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterStreamService : AbstractService
  {
    private static TwitterContext _context;
    private static string _query;
    private static string _outputpath;

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      _context = connection as TwitterContext;
      if(_context == null)
        return;
      _query = string.Join(",", queries);

      var dir = Path.Combine(outputPath, queries.First());
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      _outputpath = dir;

      var task = StreamTwitterContent();
      Console.WriteLine("ok!");

      while (true)
      {
        Thread.Sleep(15000);
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }

      task.Wait();
    }

    private Task<List<Streaming>> StreamTwitterContent()
    {
      var cnt = 0;
      var clo = new object();
      PostStatusUpdate("AUFZEICHNUNG LÄUFT: 0 Tweets aufgezeichnet", 1, 1);

      return (from strm in _context.Streaming
              where strm.Type == StreamingType.Filter && strm.Track == _query
              select strm).StartAsync(
                                      async strm =>
                                      {
                                        try
                                        {
                                          if (strm == null)
                                            return;

                                          var content = strm.Content;
                                          if (!string.IsNullOrEmpty(content))
                                            try
                                            {                                              
                                              var stamp = DateTime.Now.ToString("O").Replace(":", "-");

                                              using (var fs = new FileStream(Path.Combine(_outputpath, $"twitter_stream_{stamp}.json"),
                                                                             FileMode.Create,
                                                                             FileAccess.Write))
                                              using (var bs = new BufferedStream(fs))
                                              {
                                                var buffer = Ecosystem.Model.Configuration.Encoding.GetBytes(content);
                                                bs.Write(buffer, 0, buffer.Length);
                                              }
                                              lock(clo)
                                              PostStatusUpdate($"AUFZEICHNUNG LÄUFT: {cnt++} Tweets aufgezeichnet", 1, 1);
                                            }
                                            catch
                                            {
                                              // ignore
                                            }
                                        }
                                        catch
                                        {
                                          // ignore
                                        }
                                      });
    }
  }
}
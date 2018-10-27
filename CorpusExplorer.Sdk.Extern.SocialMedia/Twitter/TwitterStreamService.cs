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
    protected override AbstractAuthentication Authentication => new TwitterContextAuthentication();

    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      _context = connection as TwitterContext;
      if(_context == null)
        return;
      _query = string.Join(",", queries);

      if (!Directory.Exists(outputPath))
        Directory.CreateDirectory(outputPath);

      _outputpath = outputPath;

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

    private static Task<List<Streaming>> StreamTwitterContent()
    {
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

                                              using (var fs = new FileStream(Path.Combine(_outputpath, stamp + ".json"),
                                                                             FileMode.Create,
                                                                             FileAccess.Write))
                                              using (var bs = new BufferedStream(fs))
                                              {
                                                var buffer = Ecosystem.Model.Configuration.Encoding.GetBytes(content);
                                                bs.Write(buffer, 0, buffer.Length);
                                              }
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
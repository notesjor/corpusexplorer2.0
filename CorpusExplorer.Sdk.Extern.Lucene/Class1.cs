using System;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace CorpusExplorer.Sdk.Extern.LuceneNet
{
  public class Class1
  {
    public void test()
    {
      var version = Version.LUCENE_30;
      var directory = FSDirectory.Open("LuceneIndex");
      var analyzer = new StandardAnalyzer(version);
      var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

      // foreach document
      var doc = new Document();
      doc.Add(new Field("id", Guid.NewGuid().ToString("N"), Field.Store.YES, Field.Index.NO));
      doc.Add(new Field("text", "hello world", Field.Store.YES, Field.Index.ANALYZED));
      writer.AddDocument(doc);

      // After all
      writer.Optimize();
      //Close the writer
      writer.Flush(true, true, true);
      writer.Close();

      // <->

      // build query
      var parser = new QueryParser(version, "text", analyzer);
      var query = parser.Parse("world");

      // search
      var searcher = new IndexSearcher(directory);
      var hits = searcher.Search(query, int.MaxValue);

      var results = hits.TotalHits;
      Console.WriteLine("Found {0} results", results);
      for (var i = 0; i < results; i++)
      {
        var entry = hits.ScoreDocs[i];
        var document = searcher.Doc(entry.Doc);
        Console.WriteLine("Result num {0}, score {1}", i + 1, entry.Score);
        Console.WriteLine("ID: {0}", document.Get("id"));
        Console.WriteLine("Text found: {0}" + Environment.NewLine, document.Get("postBody"));
      }

      // exit
      searcher.Close();
      directory.Close();
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using Lucene.Net.Search;
using Lucene.Net.Store;

namespace CorpusExplorer.Sdk.Extern.LuceneNet
{
  public class LuceneIndexSearch : IDisposable
  {
    private readonly Directory _dir;
    private readonly IndexSearcher _index;

    public LuceneIndexSearch(AbstractCorpusAdapter corpus, bool inMemoryIndex = true)
    {
      var dir = LuceneConfiguration.GetCorpusIndexDirectory(corpus);
      if (!System.IO.Directory.Exists(dir))
        LuceneIndexBuilder.BuildIndex(corpus);

      if (inMemoryIndex)
      {
        var tmp = FSDirectory.Open(dir);
        _dir = new RAMDirectory();
        Directory.Copy(tmp, _dir, true);
      }
      else
      {
        _dir = FSDirectory.Open(dir);
      }

      _index = new IndexSearcher(_dir);
    }

    public void Dispose()
    {
      _index?.Dispose();
      _dir?.Dispose();
    }

    public IEnumerable<KeyValuePair<Guid, float>> Search(string query)
    {
      return _index.Search(LuceneConfiguration.QueryParser.Parse(query), int.MaxValue)
                   .ScoreDocs.Select(entry =>
                                       new
                                         KeyValuePair<Guid, float
                                         >(new Guid(_index.Doc(entry.Doc).GetBinaryValue("guid")),
                                           entry.Score));
    }
  }
}
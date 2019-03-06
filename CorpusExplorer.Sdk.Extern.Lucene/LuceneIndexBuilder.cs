using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Directory = System.IO.Directory;

namespace CorpusExplorer.Sdk.Extern.LuceneNet
{
  public static class LuceneIndexBuilder
  {
    public static void BuildIndex(AbstractCorpusAdapter corpus)
    {
      var dir = LuceneConfiguration.GetCorpusIndexDirectory(corpus);
      if (Directory.Exists(dir))
        return;

      var directory = FSDirectory.Open(dir);
      var writer = new IndexWriter(directory, LuceneConfiguration.Analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
      var wlock = new object();

      Parallel.ForEach(corpus.Layers, layer =>
      {
        Parallel.ForEach(layer.DocumentGuids, dsel =>
        {
          var doc = new Document();
          doc.Add(new Field("guid", dsel.ToByteArray(), Field.Store.YES));
          doc.Add(new Field("layer", layer.Displayname, Field.Store.YES, Field.Index.NOT_ANALYZED));
          doc.Add(new Field("text", layer.GetReadableDocumentByGuid(dsel).ReduceDocumentToText(), Field.Store.YES,
                            Field.Index.ANALYZED));

          lock (wlock)
          {
            writer.AddDocument(doc);
          }
        });
      });

      /* Vorerst deaktiviert
      Parallel.ForEach(corpus.DocumentMetadata, meta =>
      {
        var doc = new Document();
        doc.Add(new Field("guid", meta.Key.ToByteArray(), Field.Store.YES));
        foreach (var v in meta.Value)
          doc.Add(new Field(v.Key, v.Value.ToString(), Field.Store.YES, Field.Index.ANALYZED));

        lock (wlock)
          writer.AddDocument(doc);
      });
      */

      writer.Optimize();
      writer.Flush(true, true, true);
      writer.Dispose();
    }
  }
}
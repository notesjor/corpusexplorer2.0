using System.IO;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Util;

namespace CorpusExplorer.Sdk.Extern.LuceneNet
{
  public static class LuceneConfiguration
  {
    public static Version Version { get; } = Version.LUCENE_30;

    public static Analyzer Analyzer { get; } = new StandardAnalyzer(Version);

    public static QueryParser QueryParser { get; } = new QueryParser(Version, "text", Analyzer);

    public static string GetCorpusIndexDirectory(AbstractCorpusAdapter corpus)
    {
      return Path.Combine(Path.GetDirectoryName(corpus.CorpusPath),
                          $"{Path.GetFileNameWithoutExtension(corpus.CorpusPath)}.index");
    }
  }
}
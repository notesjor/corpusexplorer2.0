using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FolderBased.QueryToSentence
{
  public class QueryToSentenceIndexFactory
  {
    private const string CEEXT = ".ceidx";
    private int _docCount = 0;
    private string _layerDisplayname;
    private string _outputDirectory;

    /// <summary>
    /// De/Aktiviert die Optimierung
    /// </summary>
    public bool EnableAutoOptimize { get; set; } = true;
    /// <summary>
    /// Minimale Anzahl an Dokumenten, in denen ein Wort vorkommen muss.
    /// </summary>
    public double AutoOptimizeMinDocument { get; set; } = 10;
    /// <summary>
    /// Gibt an über wieviel Dokumente sich ein Begriff erstrecken darf (in Prozent).
    /// </summary>
    public double AutoOptimizeMaxDocumentPercentage { get; set; } = 0.95;

    public QueryToSentenceIndexFactory(string layerDisplayname, string outputDirectory)
    {
      _layerDisplayname = layerDisplayname;
      _outputDirectory = outputDirectory;

      if (!Directory.Exists(_outputDirectory))
        Directory.CreateDirectory(_outputDirectory);
    }

    public void Add(AbstractCorpusAdapter corpus)
    {
      _docCount += corpus.CountDocuments;
      var checkMax = (int)(_docCount * AutoOptimizeMaxDocumentPercentage);

      foreach (var x in QueryToSentenceIndex.Create(corpus, _layerDisplayname))
      {
        var data = x.Value;
        var path = Path.Combine(_outputDirectory, x.Key + CEEXT);
        if (File.Exists(path))
          foreach (var y in Serializer.Deserialize<Dictionary<Guid, int[]>>(path))
            if (!data.ContainsKey(y.Key))
              data.Add(y.Key, y.Value);

        if (!EnableAutoOptimize || data.Count >= AutoOptimizeMinDocument && data.Count <= checkMax)
          Serializer.Serialize(data, path, false);
        else if (File.Exists(path))
          File.Delete(path);
      }
    }
  }
}

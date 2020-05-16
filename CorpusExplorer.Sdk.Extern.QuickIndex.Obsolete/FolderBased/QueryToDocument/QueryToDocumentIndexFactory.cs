using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FolderBased.QueryToDocument
{
  public class QueryToDocumentIndexFactory
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

    public QueryToDocumentIndexFactory(string layerDisplayname, string outputDirectory)
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

      foreach (var x in QueryToDocumentIndex.Create(corpus, _layerDisplayname))
      {
        var data = new HashSet<Guid>(x.Value);
        var path = Path.Combine(_outputDirectory, x.Key + CEEXT);
        if (File.Exists(path))
          foreach (var guid in Serializer.Deserialize<Guid[]>(path))
            data.Add(guid);

        if (!EnableAutoOptimize || data.Count >= AutoOptimizeMinDocument && data.Count <= checkMax)
          Serializer.Serialize(data.ToArray(), path, false);
        else if (File.Exists(path))
          File.Delete(path);
      }
    }
  }
}

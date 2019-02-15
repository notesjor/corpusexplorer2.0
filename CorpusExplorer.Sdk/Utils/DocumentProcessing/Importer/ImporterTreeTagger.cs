using System;
using System.Collections.Generic;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer
{
  public class ImporterTreeTagger : AbstractImporter
  {
    private readonly Dictionary<Guid, Dictionary<string, object>> _docMeta = new Dictionary<Guid, Dictionary<string, object>>();
    private readonly LayerValueState _layerL = new LayerValueState("Lemma", 2);    
    private readonly LayerValueState _layerP = new LayerValueState("POS", 1);
    private readonly LayerValueState _layerW = new LayerValueState("Wort", 0);
    private readonly object _layerLock = new object();

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var sentenceMarks = new HashSet<string> {"$.", ".", "SENT", "PON", "FS", "interp"};
      var lines = FileIO.ReadLines(importFilePath, Configuration.Encoding);

      var docW = new List<string[]>();
      var docP = new List<string[]>();
      var docL = new List<string[]>();

      var senW = new List<string>();
      var senP = new List<string>();
      var senL = new List<string>();

      foreach (var line in lines)
        try
        {
          var split = line.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
          if (split.Length != 3)
            continue;

          senW.Add(split[0]);
          senP.Add(split[1]);
          senL.Add(split[2]);

          if (!sentenceMarks.Contains(split[1]))
            continue;

          // Bei Satzende

          docW.Add(senW.ToArray());
          docP.Add(senP.ToArray());
          docL.Add(senL.ToArray());

          senW.Clear();
          senP.Clear();
          senL.Clear();
        }
        catch
        {
          //ignore
        }

      if (senW.Count > 0)
      {
        docW.Add(senW.ToArray());
        docP.Add(senP.ToArray());
        docL.Add(senL.ToArray());
      }

      lock (_layerLock)
      {
        var guid = Guid.NewGuid();
        _layerW.AddCompleteDocument(guid, docW.ToArray());
        _layerP.AddCompleteDocument(guid, docP.ToArray());
        _layerL.AddCompleteDocument(guid, docL.ToArray());
        _docMeta.Add(guid, new Dictionary<string, object>
        {
          {"Pfad", importFilePath},
          {"Dateiname", Path.GetFileNameWithoutExtension(importFilePath)}
        });
      }

      return null; // notwendig, um doppelte Datenhaltung zu vermeiden. Rückgabewert wird in PostProcessing erzeugt.
    }

    protected override IEnumerable<AbstractCorpusAdapter> PostProcessing(IEnumerable<AbstractCorpusAdapter> corpora)
    {
      var builder = new CorpusBuilderWriteDirect();
      return builder.Create(new[] {_layerW, _layerP, _layerL}, _docMeta, new Dictionary<string, object>(), null);
    }
  }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract
{
  public abstract class AbstractImporterBase : AbstractImporter
  {
    private readonly object _metaLock = new object();
    private readonly object _layerLock = new object();
    public AbstractCorpusBuilder CorpusBuilder { get; set; } = new CorpusBuilderWriteDirect();
    private List<Concept> Concepts { get; set; }
    private string CorpusDisplayname { get; set; }
    private Dictionary<string, object> CorpusMetadata { get; set; }
    private Dictionary<Guid, Dictionary<string, object>> DocumentMetadata { get; set; }
    private Dictionary<string, LayerValueState> Layers { get; set; }

    protected void AddCorpusMetadata(string key, object value)
    {
      lock (_metaLock)
      {
        if (CorpusMetadata.ContainsKey(key))
          CorpusMetadata[key] = value;
        else
          CorpusMetadata.Add(key, value);
      }
    }

    protected void AddDocumentMetadata(Guid documentGuid, Dictionary<string, object> documentMetadata)
    {
      lock (_metaLock)
      {
        DocumentMetadata.Add(documentGuid, documentMetadata);
      }
    }

    protected void AddDocumentMetadata(Guid documentGuid, string key, object value)
    {
      lock (_metaLock)
      {
        if (!DocumentMetadata.ContainsKey(documentGuid))
          AddDocumentMetadata(documentGuid, new Dictionary<string, object>());
        if (DocumentMetadata[documentGuid].ContainsKey(key))
          DocumentMetadata[documentGuid][key] = value;
        else
          DocumentMetadata[documentGuid].Add(key, value);
      }
    }

    protected void AddDocumet(string layerName, Guid documentGuid, string[][] document)
    {
      lock (_layerLock)
      {
        EnsureLayer(layerName);
        Layers[layerName].AddCompleteDocument(documentGuid, document);
      }
    }

    protected void AddDocumet(string layerName, Guid documentGuid, int[][] document)
    {
      lock (_layerLock)
      {
        EnsureLayer(layerName);
        Layers[layerName].Documents.Add(documentGuid, document);
      }
    }

    protected int[][] ConvertToLayer(string layerName, string[][] layerValues)
    {
      lock (_layerLock)
      {
        EnsureLayer(layerName);
        return Layers[layerName].ConvertToLayer(layerValues);
      }
    }

    protected int ConvertToLayer(string layerName, string layerValue)
    {
      lock (_layerLock)
      {
        EnsureLayer(layerName);
        return Layers[layerName].ConvertToLayer(layerValue);
      }
    }

    /// <summary>
    ///   Converts to layer.
    /// </summary>
    /// <param name="layerName">Name of the layer.</param>
    /// <param name="layerValues">The layer values.</param>
    /// <returns>System.Int32[].</returns>
    protected int[] ConvertToLayer(string layerName, string[] layerValues)
    {
      lock (_layerLock)
      {
        EnsureLayer(layerName);
        return Layers[layerName].ConvertToLayer(layerValues);
      }
    }

    protected string ConvertToSingleLineOfText(IEnumerable<string> lines) 
      => lines == null ? string.Empty : string.Join("\r\n", lines).Trim();

    private void EnsureLayer(string layerName)
    {
      if (!Layers.ContainsKey(layerName))
        Layers.Add(layerName, new LayerValueState(layerName, Layers.Count));
    }

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string inputPath)
    {
      CorpusDisplayname = Path.GetFileNameWithoutExtension(inputPath);

      Reset(false);
      ExecuteCall(inputPath);

      return BuildCorpus(false);
    }

    protected abstract void ExecuteCall(string path);

    private IEnumerable<AbstractCorpusAdapter> BuildCorpus(bool dontFlushHeads)
    {
      var res = CorpusBuilder.Create(
                                     Layers.Select(x => x.Value),
                                     DocumentMetadata,
                                     CorpusMetadata,
                                     Concepts).ToArray();

      if (res.Length == 1)
        res[0].CorpusDisplayname = CorpusDisplayname;
      else
        for (var i = 0; i < res.Length; i++)
          res[i].CorpusDisplayname = $"{CorpusDisplayname} ({i + 1:D5})";

      Reset(dontFlushHeads);
      return res;
    }

    private void Reset(bool dontFlushHeads)
    {
      // Flush nur wenn null oder explizit angefragt
      lock (_layerLock)
      {
        if (Layers == null)
          dontFlushHeads = false;
        if (dontFlushHeads)
        {
          if (Layers != null)
            foreach (var layer in Layers)
              layer.Value.Documents.Clear();
          GC.Collect();
          return;
        }

        CorpusMetadata = new Dictionary<string, object>();
        DocumentMetadata = new Dictionary<Guid, Dictionary<string, object>>();
        Concepts = new List<Concept>();

        Layers = new Dictionary<string, LayerValueState>();

        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }
  }
}
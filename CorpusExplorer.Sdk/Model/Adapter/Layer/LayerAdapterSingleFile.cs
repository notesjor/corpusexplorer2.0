using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Model.Adapter.Layer
{
  public sealed class LayerAdapterSingleFile : AbstractLayerAdapter
  {
    private Model.Layer _layer;

    private LayerAdapterSingleFile()
    {
    }

    /// <summary>
    ///   Anzahl der enthaltenen Dokumente
    /// </summary>
    public override int CountDocuments => _layer.CountDocuments;

    /// <summary>
    ///   Anzahl der enthaltenen Werte
    /// </summary>
    public override int CountValues => _layer.CountValues;

    /// <summary>
    ///   Auflistung aller Dokument-GUIDs
    /// </summary>
    public override IEnumerable<Guid> DocumentGuids => _layer.DocumentGuids;

    /// <summary>
    ///   Gibt die entsprechende Wertbeschreibung zurück
    /// </summary>
    /// <param name="index">
    ///   Index
    /// </param>
    /// <returns>
    ///   Wertbeschreibung
    /// </returns>
    public override string this[int index] => _layer[index];

    /// <summary>
    ///   Gibt den Index zur Wertbeschreibung zurück
    /// </summary>
    /// <param name="index">
    ///   Wertbeschreibung
    /// </param>
    /// <returns>
    ///   Index
    /// </returns>
    public override int this[string index] => _layer[index];

    /// <summary>
    ///   Gibt die Layerrohdaten des Dokuments zurück
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Rohdaten (Indexbasiert)
    /// </returns>
    public override int[][] this[Guid guid]
    {
      get => _layer[guid];
      set => _layer[guid] = value;
    }

    /// <summary>
    ///   Auflistung aller Werte des Layers
    /// </summary>
    public override IEnumerable<string> Values => _layer.Values;

    /// <summary>
    ///   Enthält der Layer informationen zum gesuchten Dokument
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Ja/Nein?
    /// </returns>
    public override bool ContainsDocument(Guid guid)
    {
      return _layer.ContainsDocument(guid);
    }

    /// <summary>
    ///   Erstellt eine Kopie dieses Layers. Der neue Layer enthält exakt die gleichen Werte, wie der Ursprungslayer.
    ///   Lediglich der GUID und die Metadaten werden verworfen.
    /// </summary>
    /// <returns>Kopie des Layers</returns>
    public override AbstractLayerAdapter Copy()
    {
      return Create(_layer.Copy());
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      return ContainsDocument(documentGuid) ? Create(_layer.Copy(documentGuid)) : null;
    }

    public static LayerAdapterSingleFile Create(Model.Layer layer)
    {
      return new LayerAdapterSingleFile
      {
        _layer = layer,
        _guid = layer.Guid,
        Displayname = layer.Displayname,
        Metadata = layer.Metadata
      };
    }

    public static LayerAdapterSingleFile Create(
      Dictionary<Guid, int[][]> documents,
      Dictionary<string, int> dictionary,
      Dictionary<string, object> layerMetadata,
      string layerDisplayname)
    {
      return Create(new Model.Layer(documents, dictionary, layerMetadata) { Displayname = layerDisplayname });
    }

    public static LayerAdapterSingleFile Create(
      Dictionary<Guid, int[][]> documents,
      ListOptimized<string> dictionary,
      Dictionary<string, object> layerMetadata,
      string layerDisplayname)
    {
      return Create(new Model.Layer(documents, dictionary, layerMetadata) { Displayname = layerDisplayname });
    }

    public static LayerAdapterSingleFile Create(AbstractLayerState layerState)
    {
      return Create(new Model.Layer(layerState.GetDocuments().ToDictionary(x => x.Key, x => x.Value), layerState.GetCache().ToDictionary(x => x.Key, x => x.Value), null)
      {
        Displayname = layerState.Displayname
      });
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      var dictionary = new Dictionary<Guid, int[][]>();
      foreach (var pair in _layer)
      {
        if (dictionary.ContainsKey(pair.Key))
          continue;
        dictionary.Add(pair.Key, pair.Value);
      }

      return dictionary;
    }

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      return _layer.GetDocumentLayervalueMask(documentGuid, layerValue);
    }

    /// <summary>
    ///   The get readable document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      return _layer.GetReadableDocumentByGuid(documentGuid);
    }

    /// <summary>
    ///   The get readable document snippet by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="start">
    ///   The start.
    /// </param>
    /// <param name="stop">
    ///   The stop.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(
      Guid documentGuid,
      int start,
      int stop)
    {
      return _layer.GetReadableDocumentSnippetByGuid(documentGuid, start, stop);
    }

    public Model.Layer ReciveRawLayer()
    {
      return _layer;
    }

    public override Dictionary<string, int> ReciveRawLayerDictionary()
    {
      return _layer.ReciveRawLayerDictionary();
    }

    public override Dictionary<int, string> ReciveRawReverseLayerDictionary()
    {
      return _layer.ReciveRawLayerDictionary().ToDictionary(x => x.Value, x => x.Key);
    }

    public override void ResetRawLayerDictionary(Dictionary<string, int> dictionary)
    {
      throw new NotImplementedException();
    }

    public override void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse)
    {
      throw new NotImplementedException();
    }

    public override void RefreshDictionaries()
    {
      _layer.RefreshDictionaries();
    }

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    {
      return _layer.SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, value);
    }

    /// <summary>
    ///   Ändert sehr schnell alle annotierten Daten eines bestimmten Dokuments mithilfe eines StreamDokuments.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="streamDocument">
    ///   Stream-Dokument muss exakt den Ausmaßen des mittels GUID referenziertem Dokuments
    ///   entsprechen.
    /// </param>
    /// <returns>Erfolgreich?</returns>
    public override bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
    {
      return _layer.SetQuickStreamDocumentAnnotation(documentGuid, streamDocument);
    }

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null)
    {
      return _layer.ToConcept();
    }

    /// <summary>
    ///   Fügt dem Layer einen neuen Wert hinzu
    /// </summary>
    /// <param name="value">
    ///   neuer Wert
    /// </param>
    public override void ValueAdd(string value)
    {
      _layer.ValueAdd(value);
    }

    /// <summary>
    ///   Ändert den die Wertbezeichnung von Layerdaten.
    /// </summary>
    /// <param name="oldValue">
    ///   Alter Wert
    /// </param>
    /// <param name="newValue">
    ///   Neuer Wert
    /// </param>
    public override void ValueChange(string oldValue, string newValue)
    {
      _layer.ValueChange(oldValue, newValue);
    }

    /// <summary>
    ///   Entfernt einen Layerwert
    /// </summary>
    /// <param name="removeValue">
    ///   Zu entfernender Wert
    /// </param>
    public override void ValueRemove(string removeValue)
    {
      _layer.ValueRemove(removeValue);
    }

    protected override CeDictionary GetValueDictionary()
    {
      return _layer.GetValueDictionary();
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      return _layer.ValuesByRegex(regEx);
    }
  }
}
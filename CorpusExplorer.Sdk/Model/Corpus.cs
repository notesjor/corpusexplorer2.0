#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model.Adapter.Layer;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Sdk.Model
{
  /// <summary>
  ///   The corpus.
  /// </summary>
  [Serializable]
  public class Corpus : CeObject
  {
    [OptionalField] private List<Concept> _concepts = new List<Concept>();

    /// <summary>
    ///   The _document metadata.
    /// </summary>
    [NonSerialized] private Dictionary<Guid, Dictionary<string, object>> _documentMetadata =
      new Dictionary<Guid, Dictionary<string, object>>();

    private KeyValuePair<Guid, KeyValuePair<string, object>[]>[] _documentMetadataSerialized;

    /// <summary>
    ///   The _layers.
    /// </summary>
    [NonSerialized] private Dictionary<Guid, AbstractLayerAdapter> _layers =
      new Dictionary<Guid, AbstractLayerAdapter>();

    private KeyValuePair<Guid, Layer>[] _layersSerialized;

    public IEnumerable<Concept> Concepts => _concepts;

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    public IEnumerable<Guid> DocumentGuids => _documentMetadata.Select(meta => meta.Key);

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata => _documentMetadata;

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    public Guid FirstDocument => DocumentGuids.FirstOrDefault();

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    public IEnumerable<string> LayerDisplaynames => _layers.Select(layer => layer.Value.Displayname);

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _layers.ToDictionary(layer => layer.Key, layer => layer.Value.Displayname);

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    public IEnumerable<Guid> LayerGuids => _layers.Select(layer => layer.Value.Guid);

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    public IEnumerable<AbstractLayerAdapter> Layers => from x in _layers select x.Value;

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    public IEnumerable<string> LayerUniqueDisplaynames
    {
      get
      {
        var hash = new HashSet<string>();
        foreach (var layer in _layers.Where(layer => !hash.Contains(layer.Value.Displayname)))
          hash.Add(layer.Value.Displayname);

        return hash;
      }
    }

    public void AddConcept(Concept concept)
    {
      _concepts.Add(concept);
    }

    /// <summary>
    ///   The add layer.
    /// </summary>
    /// <param name="layer">
    ///   The layer.
    /// </param>
    public void AddLayer(AbstractLayerAdapter layer)
    {
      if (_layers.ContainsKey(layer.Guid))
        return;

      _layers.Add(layer.Guid, layer);
    }

    /// <summary>
    ///   The contains document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public bool ContainsDocument(Guid documentGuid)
    {
      return _layers.Any(layer => layer.Value.ContainsDocument(documentGuid));
    }

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    public bool ContainsLayer(string layerDisplayname)
    {
      return _layers.Any(layer => layer.Value.Displayname == layerDisplayname);
    }

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    public bool ContainsLayer(Guid layerGuid)
    {
      return _layers.Any(layer => layer.Key == layerGuid);
    }

    /// <summary>
    ///   The find document by metadata.
    /// </summary>
    /// <param name="example">
    ///   The example.
    /// </param>
    /// <returns>
    ///   Document Guid
    /// </returns>
    public IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      var res = new List<Guid>();
      foreach (var dsel in _documentMetadata.Where(dsel => dsel.Value != null))
        try
        {
          var all = true;
          foreach (var t in example)
          {
            if (dsel.Value.ContainsKey(t.Key))
            {
              if (dsel.Value[t.Key] == null &&
                  t.Value           == null)
                continue;

              if (dsel.Value[t.Key] != null &&
                  t.Value           != null &&
                  dsel.Value[t.Key].Equals(t.Value))
                continue;
            }

            all = false;
            break;
          }

          if (all)
            res.Add(dsel.Key);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      return res;
    }

    /// <summary>
    ///   Gets the corpus unique identifier of document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <returns>Guid.</returns>
    public Guid GetCorpusGuidOfDocument(Guid documentGuid)
    {
      return ContainsDocument(documentGuid) ? Guid : Guid.Empty;
    }

    /// <summary>
    ///   The get document title.
    /// </summary>
    /// <param name="guid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public string GetDocumentDisplayname(Guid guid)
    {
      var meta = GetDocumentMetadata(guid);
      return meta != null && meta.TryGetValue(Resources.Title, out var value)
               ? value.ToString()
               : string.Format(Resources.NoTitle, guid.ToString(Resources.N));
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      string layerValue)
    {
      return (from layer in _layers where layer.Value.Displayname == layerDisplayname select layer.Value)
            .FirstOrDefault()?
            .GetDocumentLayervalueMask(
                                       documentGuid,
                                       layerValue);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      string layerValue)
    {
      return _layers.ContainsKey(layerGuid)
               ? _layers[layerGuid].GetDocumentLayervalueMask(documentGuid, layerValue)
               : null;
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid documentGuid)
    {
      if (!ContainsDocument(documentGuid))
        return -1;

      var layer = _layers.FirstOrDefault(x => x.Value.ContainsDocument(documentGuid)).Value;

      var doc = layer?[documentGuid];
      if (doc == null)
        return -1;

      return doc.Length < 1 ? -1 : doc.Length;
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid corpusGuid, Guid documentGuid)
    {
      return corpusGuid != Guid ? -1 : GetDocumentLengthInSentences(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInWords(Guid documentGuid)
    {
      if (!ContainsDocument(documentGuid))
        return -1;

      var layer = _layers.FirstOrDefault(x => x.Value.ContainsDocument(documentGuid)).Value;

      var doc = layer?[documentGuid];
      if (doc == null)
        return -1;

      var res = doc.SelectMany(s => s).Count();

      return res < 1 ? -1 : res;
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInWords(Guid corpusGuid, Guid documentGuid)
    {
      return corpusGuid != Guid ? -1 : GetDocumentLengthInWords(documentGuid);
    }

    /// <summary>
    ///   The get document metadata.
    /// </summary>
    /// <param name="documentGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   Document-Metadata
    /// </returns>
    public Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return _documentMetadata.ContainsKey(documentGuid) ? _documentMetadata[documentGuid] : null;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    public Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var res = new Dictionary<string, HashSet<object>>();

      foreach (var meta in _documentMetadata.SelectMany(doc => doc.Value))
      {
        if (!res.TryGetValue(meta.Key, out var value))
        {
          res.Add(meta.Key, new HashSet<object> {meta.Value});
        }
        else
        {
          if (!value.Contains(meta.Value))
            value.Add(meta.Value);
        }
      }

      return res;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen</returns>
    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      var res = new HashSet<string>();

      foreach (var meta in _documentMetadata.SelectMany(doc => doc.Value))
        res.Add(meta.Key);

      return res;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metawerte einer bestimmten
    ///   Metabezeichnung zurück.
    /// </summary>
    /// <param name="property">Metabezeichnung die durchsucht werden soll</param>
    /// <returns>Metawerte - im Grunde alle Values zu einer bestimmten Metabezeichnung von GetDocumentMetadataPrototype()</returns>
    public IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      return
        new HashSet<object>(from x in _documentMetadata where x.Value.ContainsKey(property) select x.Value[property]);
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metawerte einer bestimmten
    ///   Metabezeichnung zurück.
    /// </summary>
    /// <param name="property">Metabezeichnung die durchsucht werden soll</param>
    /// <returns>
    ///   Metawerte (gecastet als string) - im Grunde alle Values zu einer bestimmten Metabezeichnung von
    ///   GetDocumentMetadataPrototype()
    /// </returns>
    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(string property)
    {
      return new HashSet<string>(
                                 from x in _documentMetadata
                                 where x.Value.ContainsKey(property)
                                 select x.Value[property] == null ? "" : x.Value[property].ToString());
    }

    /// <summary>
    ///   The get layer.
    /// </summary>
    /// <param name="layerGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractLayerAdapter" />.
    /// </returns>
    public AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return _layers.ContainsKey(layerGuid) ? _layers[layerGuid] : null;
    }

    /// <summary>
    ///   Gibt eine Auflistung aller Layer zurück die dieses Dokument enthalten. Im Format LayerGUID / LayerDisplayname
    /// </summary>
    /// <param name="documentGuid">Guid des Dokuments</param>
    /// <returns>Auflistung</returns>
    public IEnumerable<KeyValuePair<Guid, string>> GetLayerGuidAndDisplaynamesOfDocument(Guid documentGuid)
    {
      return Layers.Where(layer => layer.ContainsDocument(documentGuid))
                   .ToDictionary(layer => layer.Guid, layer => layer.Displayname);
    }

    /// <summary>
    ///   The get layer of document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="layerDisplayname">
    ///   The layer displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractLayerAdapter" />.
    /// </returns>
    public AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      return (from layer in _layers
              where
                layer.Value
                     .Displayname ==
                layerDisplayname &&
                layer.Value
                     .ContainsDocument
                        (documentGuid)
              select layer.Value)
       .FirstOrDefault();
    }

    /// <summary>
    ///   The get layers.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   Layers
    /// </returns>
    public IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      return from x in _layers where x.Value.Displayname == displayname select x.Value;
    }

    /// <summary>
    ///   The get layers of document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      return from layer in _layers where layer.Value.ContainsDocument(documentGuid) select layer.Value;
    }

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    public IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var res = new HashSet<string>();
      foreach (
        var value in Layers.Where(layer => layer.Displayname == layerDisplayname).SelectMany(layer => layer.Values)
      )
        res.Add(value);
      return res;
    }

    /// <summary>
    ///   Gibt die Layerwerte eines bestimmten Layers zurück.
    /// </summary>
    /// <param name="layerGuid">Guid des Layers</param>
    /// <returns>Layerwerte</returns>
    public IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      return _layers.ContainsKey(layerGuid) ? _layers[layerGuid].Values : null;
    }

    /// <summary>
    ///   The get readable document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="layerDisplayname">
    ///   The layer displayname.
    /// </param>
    /// <returns>
    ///   Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return (from layer in _layers where layer.Value.Displayname == layerDisplayname select layer.Value)
            .FirstOrDefault()?
            .GetReadableDocumentByGuid
               (documentGuid);
    }

    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return _layers.ContainsKey(layerGuid) ? _layers[layerGuid].GetReadableDocumentByGuid(documentGuid) : null;
    }

    /// <summary>
    ///   The get readable document snippet.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="layerDisplayname">
    ///   The layer displayname.
    /// </param>
    /// <param name="start">
    ///   The start.
    /// </param>
    /// <param name="stop">
    ///   The stop.
    /// </param>
    /// <returns>
    ///   Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return (from layer in _layers where layer.Value.Displayname == layerDisplayname select layer.Value)
            .FirstOrDefault()?
            .GetReadableDocumentSnippetByGuid(
                                              documentGuid,
                                              start,
                                              stop);
    }

    /// <summary>
    ///   The get readable multilayer document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   Key = Layer / Value => Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    public Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid)
    {
      return _layers.Where(layer => layer.Value.ContainsDocument(documentGuid))
                    .ToDictionary(
                                  layer => layer.Value.Displayname,
                                  layer => layer.Value.GetReadableDocumentByGuid(documentGuid));
    }

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    public void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      var layer = GetLayers(layerDisplaynameOriginal).FirstOrDefault()?.Copy();
      if (layer == null)
        return;

      layer.Displayname = layerDisplaynameCopy;

      _layers.Add(layer.Guid, layer);
    }

    /// <summary>
    ///   Löscht alle Layer mit diesem Displayname
    /// </summary>
    /// <param name="layerDisplayname">Name der zu löschenden Layer</param>
    public void LayerDelete(string layerDisplayname)
    {
      try
      {
        var del = _layers.Where(x => x.Value.Displayname == layerDisplayname).Select(x => x.Key).ToArray();

        foreach (var x in del)
          _layers.Remove(x);
      }
      catch
      {
        // ignore
      }
    }

    /// <summary>
    ///   Erzeugt einen neuen Layer mit diesem Namen
    /// </summary>
    /// <param name="layerDisplayname">Name des neuen Layers</param>
    public void LayerNew(string layerDisplayname)
    {
      if (ContainsLayer(layerDisplayname))
        return;

      var layer = (from x in _layers where x.Value.Displayname == "Wort" select x.Value).FirstOrDefault()
               ?? (from x in _layers select x.Value).FirstOrDefault();
      if (layer == null)
        return;

      var nlayer = LayerAdapterSingleFile.Create(
                                                 layer.GetDocumentDictionary(),
                                                 new Dictionary<string, int>(),
                                                 new Dictionary<string, object>(),
                                                 Displayname = layerDisplayname);
      _layers.Add(nlayer.Guid, nlayer);
    }

    /// <summary>
    ///   Benennt alle Layer mit diesem Namen um.
    /// </summary>
    /// <param name="layerDisplaynameOld">Alter Displayname</param>
    /// <param name="layerDisplaynameNew">Neuer Displayname</param>
    public void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      if (string.IsNullOrEmpty(layerDisplaynameOld) ||
          string.IsNullOrEmpty(layerDisplaynameNew)
        ||
          layerDisplaynameOld == "Wort")
        return;

      foreach (var l in _layers.Where(l => l.Value.Displayname == layerDisplaynameOld))
        l.Value.Displayname = layerDisplaynameNew;
    }

    /// <summary>
    ///   Löscht einen bestehenden Layerwert
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <param name="layerValue">Layerwert-Bezeichnung</param>
    public void LayerValueDelete(string layerDisplayname, string layerValue)
    {
      foreach (var l in _layers.Where(l => l.Value.Displayname == layerDisplayname))
        l.Value.ValueRemove(layerValue);
    }

    /// <summary>
    ///   Erzeugt einen neuen Layerwert
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <param name="layerValue">Layerwert-Bezeichnung</param>
    public void LayerValueNew(string layerDisplayname, string layerValue)
    {
      foreach (var l in _layers.Where(l => l.Value.Displayname == layerDisplayname))
        l.Value.ValueAdd(layerValue);
    }

    /// <summary>
    ///   Benennt einen Layerwert um. Wenn der neue Layerwert bereits exisitiert wird ein merge durchgeführt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <param name="layerValueOld">Alter Layerwert-Bezeichnung</param>
    /// <param name="layerValueNew">Neue Layerwert-Bezeichnung</param>
    public void LayerValueRename(string layerDisplayname, string layerValueOld, string layerValueNew)
    {
      foreach (var l in _layers.Where(l => l.Value.Displayname == layerDisplayname))
        l.Value.ValueChange(layerValueOld, layerValueNew);
    }

    public bool RemoveConcept(Concept concept)
    {
      return _concepts.Remove(concept);
    }

    /// <summary>
    ///   The reset all document metadata.
    /// </summary>
    /// <param name="newMetadata">
    ///   The new metadata.
    /// </param>
    public void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      foreach (var meta in newMetadata.Where(meta => _documentMetadata.ContainsKey(meta.Key)))
        _documentMetadata[meta.Key] = meta.Value;
    }

    /// <summary>
    ///   Switch für die angegebene Position im Text für einen bestimmten Layerwert.
    /// </summary>
    /// <param name="documentGuid">Document GUID</param>
    /// <param name="layerGuid">Layer GUID</param>
    /// <param name="sentenceIndex">Satz Index</param>
    /// <param name="layerValue">
    ///   Layer-Wert (ist der Wert identisch mit der an der spezifizierten Stelle
    ///   [documentGuid/sentenceIndex/wordIndex] vorgefunden Wert dann wird der Wert gelöscht ansonsten wird er gesetzt.)
    /// </param>
    /// <param name="wordIndex">Wort Index</param>
    /// <returns>Erfolgreich?</returns>
    public bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return _layers.ContainsKey(layerGuid)
          && _layers[layerGuid].SetDocumentLayerValueMaskBySwitch(
                                                                  documentGuid,
                                                                  sentenceIndex,
                                                                  wordIndex,
                                                                  layerValue);
    }

    /// <summary>
    ///   Switch für die angegebene Position im Text für einen bestimmten Layerwert.
    /// </summary>
    /// <param name="documentGuid">Document GUID</param>
    /// <param name="layerDisplayname">Layername</param>
    /// <param name="sentenceIndex">Satz Index</param>
    /// <param name="wordIndex">Wort Index</param>
    /// <param name="layerValue">
    ///   Layer-Wert (ist der Wert identisch mit der an der spezifizierten Stelle
    ///   [documentGuid/sentenceIndex/wordIndex] vorgefunden Wert dann wird der Wert gelöscht ansonsten wird er gesetzt.)
    /// </param>
    /// <returns>Erfolgreich?</returns>
    public bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      var l =
        (from layer in _layers where layer.Value.Displayname == layerDisplayname select layer.Value).FirstOrDefault();
      return l != null && l.SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue);
    }

    /// <summary>
    ///   The set document metadata.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="metadata">
    ///   The metadata.
    /// </param>
    public void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      if (documentGuid == Guid.Empty ||
          metadata     == null)
        return;

      foreach (var m in metadata)
        try
        {
          if (!m.Value.GetType().IsSerializable)
            throw new SerializationException(string.Format(Resources.SetDocumentMetadata_SerializerException, m.Key));
        }
        catch (SerializationException ex)
        {
          // ReSharper disable once PossibleIntendedRethrow
          throw ex;
        }
        catch
        {
          // ignore
        }

      _documentMetadata[documentGuid] = metadata;
    }

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    public void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      if (!type.IsSerializable)
        throw new SerializationException(
                                         Resources.SetDocumentMetadata_SerializerException);

      foreach (var doc in _documentMetadata.Where(doc => !doc.Value.ContainsKey(metadataKey)))
        doc.Value.Add(metadataKey, type == typeof(string) ? "" : Activator.CreateInstance(type));
    }

    internal static Corpus Create(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var res = new Corpus
      {
        Metadata = corpusMetadata,
        _concepts = concepts == null ? new List<Concept>() : new List<Concept>(concepts),
        _documentMetadata = documentMetadata
      };

      return res;
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      OnDeserializedLayers();

      OnDeserializedMetadata();

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    private void OnDeserializedLayers()
    {
      try
      {
        _layers =
          _layersSerialized?.ToDictionary(
                                          x => x.Key,
                                          x => (AbstractLayerAdapter) LayerAdapterSingleFile.Create(x.Value)) ??
          new Dictionary<Guid, AbstractLayerAdapter>();
      }
      catch // Fallback
      {
        _layers = new Dictionary<Guid, AbstractLayerAdapter>();
        if (_layersSerialized != null)
          foreach (var entry in _layersSerialized.Where(entry => !_layers.ContainsKey(entry.Key)))
            _layers.Add(entry.Key, LayerAdapterSingleFile.Create(entry.Value));
      }

      _layersSerialized = null;
    }

    private void OnDeserializedMetadata()
    {
      try
      {
        _documentMetadata = _documentMetadataSerialized?.ToDictionary(
                                                                      x => x.Key,
                                                                      x =>
                                                                        x.Value.ToDictionary(y => y.Key, y => y.Value))
                         ?? new Dictionary<Guid, Dictionary<string, object>>();
      }
      catch
      {
        _documentMetadata = new Dictionary<Guid, Dictionary<string, object>>();

        if (_documentMetadataSerialized != null)
          foreach (var entry in _documentMetadataSerialized)
          {
            if (_documentMetadata.ContainsKey(entry.Key))
              continue;

            var dic = new Dictionary<string, object>();
            foreach (var value in entry.Value.Where(value => !dic.ContainsKey(value.Key)))
              dic.Add(value.Key, value.Value);
            _documentMetadata.Add(entry.Key, dic);
          }
      }

      _documentMetadataSerialized = null;
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _layersSerialized = null;
      _documentMetadataSerialized = null;

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      var temp = from layer in _layers
                 where layer.Value is LayerAdapterSingleFile
                 select ((LayerAdapterSingleFile) layer.Value).ReciveRawLayer();

      _layersSerialized = temp.Select(x => new KeyValuePair<Guid, Layer>(x.Guid, x)).ToArray();
      _documentMetadataSerialized =
        _documentMetadata?.Select(
                                  meta =>
                                    new KeyValuePair<Guid, KeyValuePair<string, object>[]>(meta.Key,
                                                                                           meta.Value.ToArray()))
                          .ToArray();
    }
  }
}
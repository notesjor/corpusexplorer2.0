using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Model.Adapter.Corpus
{
  /// <summary>
  ///   The corpus.
  /// </summary>
  public sealed class CorpusAdapterSingleFile : AbstractCorpusAdapter
  {
    private Model.Corpus _corpus;

    private CorpusAdapterSingleFile()
    {
    }

    public override IEnumerable<Concept> Concepts => _corpus.Concepts;

    public override string CorpusDisplayname
    {
      get => _corpus.Displayname;
      set => _corpus.Displayname = value;
    }

    public override Guid CorpusGuid => _corpus.Guid;

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    public override IEnumerable<Guid> DocumentGuids => _corpus.DocumentGuids;

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
      => _corpus.DocumentMetadata;

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    public override Guid FirstDocument => _corpus.FirstDocument;

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    public override IEnumerable<string> LayerDisplaynames => _corpus.LayerDisplaynames;

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames =>
      _corpus.LayerGuidAndDisplaynames;

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    public override IEnumerable<Guid> LayerGuids => _corpus.LayerGuids;

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    public override IEnumerable<AbstractLayerAdapter> Layers => _corpus.Layers;

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    public override IEnumerable<string> LayerUniqueDisplaynames => _corpus.LayerUniqueDisplaynames;

    public override bool UseCompression => true;

    public override void AddConcept(Concept concept)
    {
      _corpus.AddConcept(concept);
    }

    /// <summary>
    ///   The add layer.
    /// </summary>
    /// <param name="layer">
    ///   The layer.
    /// </param>
    public override void AddLayer(AbstractLayerAdapter layer)
    {
      _corpus.AddLayer(layer);
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
    public override bool ContainsDocument(Guid documentGuid)
    {
      return _corpus.ContainsDocument(documentGuid);
    }

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    public override bool ContainsLayer(string layerDisplayname)
    {
      return _corpus.ContainsLayer(layerDisplayname);
    }

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    public override bool ContainsLayer(Guid layerGuid)
    {
      return _corpus.ContainsLayer(layerGuid);
    }

    /// <summary>
    ///   The create.
    /// </summary>
    /// <param name="documentMetadata">
    ///   The document metadata.
    /// </param>
    /// <param name="corpusMetadata">The corpus metadata.</param>
    /// <param name="concepts">The concept.</param>
    /// <returns>
    ///   The <see cref="Corpus" />.
    /// </returns>
    public static CorpusAdapterSingleFile Create(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      IEnumerable<Concept> concepts)
    {
      var res = new CorpusAdapterSingleFile
      {
        _corpus =
          Model.Corpus.Create(
            documentMetadata,
            corpusMetadata ?? new Dictionary<string, object>(),
            concepts == null ? new List<Concept>() : new List<Concept>(concepts))
      };
      return res;
    }

    public static CorpusAdapterSingleFile Create(string path)
    {
      var res = new CorpusAdapterSingleFile
      {
        CorpusPath = path,
        _corpus = Serializer.Deserialize<Model.Corpus>(path)
      };

      if (res._corpus == null)
        throw new SerializationException(path);

      if (string.IsNullOrEmpty(res._corpus.Displayname))
        res._corpus.Displayname = Path.GetFileNameWithoutExtension(path);

      foreach (var layer in res._corpus.Layers)
        layer.RefreshDictionaries();

      return res;
    }

    /// <summary>
    ///   The find document by metadata.
    /// </summary>
    /// <param name="example">
    ///   The example.
    /// </param>
    /// <returns>
    ///   Document Guids
    /// </returns>
    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return _corpus.FindDocumentByMetadata(example);
    }

    public override AbstractCorpusBuilder GetCorpusBuilder()
    {
      return new CorpusBuilderSingleFile();
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
    {
      return _corpus.Metadata;
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public override int GetDocumentLengthInSentences(Guid documentGuid)
    {
      return _corpus.GetDocumentLengthInSentences(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public override int GetDocumentLengthInWords(Guid documentGuid)
    {
      return _corpus.GetDocumentLengthInWords(documentGuid);
    }

    /// <summary>
    ///   The get document metadata.
    /// </summary>
    /// <param name="documentGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   Document Metadata
    /// </returns>
    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return _corpus.GetDocumentMetadata(documentGuid);
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      return _corpus.GetDocumentMetadataPrototype();
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen</returns>
    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      return _corpus.GetDocumentMetadataPrototypeOnlyProperties();
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      return _corpus.GetDocumentMetadataPrototypeOnlyPropertieValues(property);
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
    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return _corpus.GetLayer(layerGuid);
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
    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      return _corpus.GetLayerOfDocument(documentGuid, layerDisplayname);
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
    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      return _corpus.GetLayers(displayname);
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
    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      return _corpus.GetLayersOfDocument(documentGuid);
    }

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      return _corpus.GetLayerValues(layerDisplayname);
    }

    /// <summary>
    ///   Gibt die Layerwerte eines bestimmten Layers zurück.
    /// </summary>
    /// <param name="layerGuid">Guid des Layers</param>
    /// <returns>Layerwerte</returns>
    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      return _corpus.GetLayerValues(layerGuid);
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
    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return _corpus.GetReadableDocument(documentGuid, layerDisplayname);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return _corpus.GetReadableDocument(documentGuid, layerGuid);
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
    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return _corpus.GetReadableDocumentSnippet(documentGuid, layerDisplayname, start, stop);
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
    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      return _corpus.GetReadableMultilayerDocument(documentGuid);
    }

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      _corpus.LayerCopy(layerDisplaynameOriginal, layerDisplaynameCopy);
    }

    /// <summary>
    ///   Löscht alle Layer mit diesem Displayname
    /// </summary>
    /// <param name="layerDisplayname">Name der zu löschenden Layer</param>
    public override void LayerDelete(string layerDisplayname)
    {
      _corpus.LayerDelete(layerDisplayname);
    }

    /// <summary>
    ///   Erzeugt einen neuen Layer mit diesem Namen
    /// </summary>
    /// <param name="layerDisplayname">Name des neuen Layers</param>
    public override void LayerNew(string layerDisplayname)
    {
      _corpus.LayerNew(layerDisplayname);
    }

    /// <summary>
    ///   Benennt alle Layer mit diesem Namen um.
    /// </summary>
    /// <param name="layerDisplaynameOld">Alter Displayname</param>
    /// <param name="layerDisplaynameNew">Neuer Displayname</param>
    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      _corpus.LayerRename(layerDisplaynameOld, layerDisplaynameNew);
    }

    public override bool RemoveConcept(Concept concept)
    {
      return _corpus.RemoveConcept(concept);
    }

    /// <summary>
    ///   The reset all document metadata.
    /// </summary>
    /// <param name="newMetadata">
    ///   The new metadata.
    /// </param>
    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      _corpus.ResetAllDocumentMetadata(newMetadata);
    }

    /// <summary>
    ///   Speichert das Korpus unter dem angegebenen Pfad
    /// </summary>
    /// <param name="path">Pfad</param>
    /// <param name="useCompression">if set to <c>true</c> [use compression].</param>
    public override void Save(string path = null, bool useCompression = true)
    {
      Serializer.Serialize(
        _corpus,
        (string.IsNullOrEmpty(path)
          ? string.IsNullOrEmpty(CorpusPath)
            ? Path.Combine(Configuration.MyCorpora, CorpusDisplayname)
            : CorpusPath
          : path).ForceFileExtension(".cec5"),
        useCompression);
    }

    public override void SetCorpusMetadata(string key, object value)
    {
      if (_corpus.Metadata.ContainsKey(key))
        _corpus.Metadata[key] = value;
      else
        _corpus.Metadata.Add(key, value);
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
    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return _corpus.SetDocumentLayerValueMask(documentGuid, layerGuid, sentenceIndex, wordIndex, layerValue);
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
    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return _corpus.SetDocumentLayerValueMask(documentGuid, layerDisplayname, sentenceIndex, wordIndex, layerValue);
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
    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      _corpus.SetDocumentMetadata(documentGuid, metadata);
    }

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      _corpus.SetNewDocumentMetadata(metadataKey, type);
    }
  }
}
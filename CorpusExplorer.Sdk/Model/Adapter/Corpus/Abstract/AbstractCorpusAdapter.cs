#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract
{
  public abstract class AbstractCorpusAdapter : IHydra
  {
    public abstract IEnumerable<Concept> Concepts { get; }

    /// <summary>
    ///   Anzeigename dieses Korpus
    /// </summary>
    public abstract string CorpusDisplayname { get; set; }

    /// <summary>
    ///   Korpus-GUID
    /// </summary>
    public abstract Guid CorpusGuid { get; }

    /// <summary>
    ///   Ort an dem die Informationen zum herstellen mit diesem Korpus hinterlegt sind
    /// </summary>
    public string CorpusPath { get; set; }

    public abstract bool UseCompression { get; }

    /// <summary>
    ///   The contains corpus.
    /// </summary>
    /// <param name="corpusGuid">
    ///   The corpus guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public bool ContainsCorpus(Guid corpusGuid)
    {
      return CorpusGuid == corpusGuid;
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
    public abstract bool ContainsDocument(Guid documentGuid);

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    public abstract bool ContainsLayer(string layerDisplayname);

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    public abstract bool ContainsLayer(Guid layerGuid);

    /// <summary>
    ///   Auflistung - CorpusGuid / DocumentGuids des Korpus
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, IEnumerable<Guid>>> CorporaAndDocumentGuids
      => new Dictionary<Guid, IEnumerable<Guid>> {{CorpusGuid, DocumentGuids}};

    /// <summary>
    ///   Gets the selected corpora displaynames.
    /// </summary>
    public IEnumerable<string> CorporaDisplaynames => new[] {CorpusDisplayname};

    /// <summary>
    ///   Auflistung aller Corpora per GUID
    /// </summary>
    public IEnumerable<Guid> CorporaGuids => new[] {CorpusGuid};

    /// <summary>
    ///   Gets the corpora guids and displaynames.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> CorporaGuidsAndDisplaynames
      => new Dictionary<Guid, string> {{CorpusGuid, CorpusDisplayname}};

    /// <summary>
    ///   Gets the count corpora.
    /// </summary>
    public int CountCorpora => 1;

    /// <summary>
    ///   Gets the count documents.
    /// </summary>
    public int CountDocuments => DocumentGuids.Count();

    /// <summary>
    ///   Gets the count sentences.
    /// </summary>
    /// <value>The count sentences.</value>
    public long CountSentences => DocumentGuids.Sum(GetDocumentLengthInSentences);

    /// <summary>
    ///   Gets the count token.
    /// </summary>
    /// <value>The count token.</value>
    public long CountToken
    {
      get
      {
        var layer = Layers.FirstOrDefault();
        if (layer == null)
          return -1;

        var count = 0;
        foreach (var guid in DocumentGuids)
          try
          {
            count += layer[guid].SelectMany(s => s).Count();
          }
          catch
          {
            // ignore
          }

        return count;
      }
    }

    /// <summary>
    ///   Gets the document titles.
    /// </summary>
    public IEnumerable<string> DocumentDisplaynames => DocumentGuids.Select(GetDocumentDisplayname);

    /// <summary>
    ///   Gets the document guids and titles.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> DocumentGuidAndDisplaynames
    {
      get { return DocumentGuids.ToDictionary(guid => guid, GetDocumentDisplayname); }
    }

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    public abstract IEnumerable<Guid> DocumentGuids { get; }

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    public abstract IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata { get; }

    public AbstractLayerAdapter ExportDocumentLayer(Guid documentGuid, string layerDisplayname)
    {
      return ContainsDocument(documentGuid)
               ? GetLayerOfDocument(documentGuid, layerDisplayname).Copy(documentGuid)
               : null;
    }

    /// <summary>
    ///   The find document by metadata.
    /// </summary>
    /// <param name="exampleKey">
    ///   The example key.
    /// </param>
    /// <param name="exampleValue">
    ///   The example documentGuids.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<Guid> FindDocumentByMetadata(string exampleKey, object exampleValue)
    {
      return FindDocumentByMetadata(new Dictionary<string, object> {{exampleKey, exampleValue}});
    }

    /// <summary>
    ///   The find document by metadata.
    /// </summary>
    /// <param name="example">
    ///   The example.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public abstract IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example);

    /// <summary>
    ///   Gets the first corpus.
    /// </summary>
    public Guid FirstCorpus => CorpusGuid;

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    public abstract Guid FirstDocument { get; }

    /// <summary>
    ///   The get corpora by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<AbstractCorpusAdapter> GetCorpora(string displayname)
    {
      return displayname == CorpusDisplayname ? new[] {this} : null;
    }

    /// <summary>
    ///   Gibt über eine interne Auflösung (Resolve) das bezeichnete Korpus zurück.
    ///   Diese Funktion kann dazu verwendet werden um das vollständige Corpus abzufragen.
    ///   Wenn Sie nur die Dokumente dieses Korpus benötigen, dann greifen Sie auf Selection[Guid] zurück.
    /// </summary>
    /// <param name="guid">
    ///   GUID des Korpus
    /// </param>
    /// <returns>
    ///   Korpus-Objekt
    /// </returns>
    public AbstractCorpusAdapter GetCorpus(Guid guid)
    {
      return guid == CorpusGuid ? this : null;
    }

    /// <summary>
    ///   Gets the corpus unique identifier of document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <returns>Guid.</returns>
    public Guid GetCorpusGuidOfDocument(Guid documentGuid)
    {
      return ContainsDocument(documentGuid) ? CorpusGuid : Guid.Empty;
    }

    /// <summary>
    ///   The get corpus which contains document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractCorpusAdapter" />.
    /// </returns>
    public AbstractCorpusAdapter GetCorpusOfDocument(Guid documentGuid)
    {
      return ContainsDocument(documentGuid) ? this : null;
    }

    public int[][] GetDocument(Guid documentGuid, Guid layerGuid)
    {
      return GetLayer(layerGuid)?[documentGuid];
    }

    public int[][] GetDocument(Guid documentGuid, string layerDisplayname)
    {
      return GetLayerOfDocument(documentGuid, layerDisplayname)?[documentGuid];
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
      try
      {
        if (guid == Guid.Empty)
          return guid.ToString(Resources.N);

        var meta = GetDocumentMetadata(guid);
        if (meta == null)
          return guid.ToString(Resources.N);

        if (!meta.ContainsKey(Resources.Title))
          return guid.ToString(Resources.N);

        var res = meta[Resources.Title] as string;
        return string.IsNullOrEmpty(res) ? guid.ToString(Resources.N) : res;
      }
      catch
      {
        return guid.ToString(Resources.N);
      }
    }

    /// <summary>
    ///   The get document title.
    /// </summary>
    /// <param name="documentGuids">
    ///   The documentGuids.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<string> GetDocumentDisplayname(IEnumerable<Guid> documentGuids)
    {
      return documentGuids.Select(GetDocumentDisplayname);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      string layerValue)
    {
      return GetLayerOfDocument(documentGuid, layerDisplayname).GetDocumentLayervalueMask(documentGuid, layerValue);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      string layerValue)
    {
      return GetLayer(layerGuid).GetDocumentLayervalueMask(documentGuid, layerValue);
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public abstract long GetDocumentLengthInSentences(Guid documentGuid);

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public long GetDocumentLengthInSentences(Guid corpusGuid, Guid documentGuid)
    {
      return corpusGuid != CorpusGuid ? -1 : GetDocumentLengthInSentences(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public abstract long GetDocumentLengthInWords(Guid documentGuid);

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public long GetDocumentLengthInWords(Guid corpusGuid, Guid documentGuid)
    {
      return corpusGuid != CorpusGuid ? -1 : GetDocumentLengthInWords(documentGuid);
    }

    /// <summary>
    ///   The get document metadata.
    /// </summary>
    /// <param name="documentGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   The <see cref="Dictionary{TKey,TValue}" />.
    /// </returns>
    public abstract Dictionary<string, object> GetDocumentMetadata(Guid documentGuid);

    public T GetDocumentMetadata<T>(Guid documentGuid, string metaKey, T defaultValue)
    {
      var meta = GetDocumentMetadata(documentGuid);
      if (meta == null || !meta.ContainsKey(metaKey))
        return defaultValue;
      var data = meta[metaKey];
      if (data is T obj)
        return obj;

      return defaultValue;
    }

    public string GetDocumentMetadata(Guid documentGuid, string metaKey, string defaultValue)
    {
      var meta = GetDocumentMetadata(documentGuid);
      if (meta == null || !meta.ContainsKey(metaKey))
        return defaultValue;
      var data = meta[metaKey];
      switch (data)
      {
        case null:
          return defaultValue;
        case string obj:
          return obj;
        default:
          return data.ToString();
      }
    }

    public Dictionary<Guid, T> GetDocumentMetadata<T>(string metaKey, T defaultValue)
    {
      return DocumentMetadata.Where(x => x.Value.ContainsKey(metaKey) && x.Value[metaKey] is T)
                             .ToDictionary(x => x.Key, x => (T) x.Value[metaKey]);
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    public abstract Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype();

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen - im Grunde alle Keys von GetDocumentMetadataPrototype()</returns>
    public abstract IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties();

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metawerte einer bestimmten
    ///   Metabezeichnung zurück.
    /// </summary>
    /// <param name="property">Metabezeichnung die durchsucht werden soll</param>
    /// <returns>Metawerte - im Grunde alle Values zu einer bestimmten Metabezeichnung von GetDocumentMetadataPrototype()</returns>
    public abstract IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property);

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
      return from x in GetDocumentMetadataPrototypeOnlyPropertieValues(property) where x != null select x.ToString();
    }

    /// <summary>
    ///   The get first corpus by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractCorpusAdapter" />.
    /// </returns>
    public AbstractCorpusAdapter GetFirstCorpusByDisplayname(string displayname)
    {
      return displayname == CorpusDisplayname ? this : null;
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
    public abstract AbstractLayerAdapter GetLayer(Guid layerGuid);

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
    public abstract AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname);

    /// <summary>
    ///   The get layers.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public abstract IEnumerable<AbstractLayerAdapter> GetLayers(string displayname);

    /// <summary>
    ///   The get layers of document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public abstract IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid);

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    public abstract IEnumerable<string> GetLayerValues(string layerDisplayname);

    /// <summary>
    ///   Gibt die Layerwerte eines bestimmten Layers zurück.
    /// </summary>
    /// <param name="layerGuid">Guid des Layers</param>
    /// <returns>Layerwerte</returns>
    public abstract IEnumerable<string> GetLayerValues(Guid layerGuid);

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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public abstract IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname);

    public abstract IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid);

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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public abstract IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop);

    /// <summary>
    ///   The get readable multilayer document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="Dictionary{TKey,TValue}" />.
    /// </returns>
    public abstract Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid);

    public Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid, int start, int stop)
    {
      var doc = GetReadableMultilayerDocument(documentGuid);
      if (doc == null) return null;
      if (start < 0)
        start = 0;

      var res = new Dictionary<string, IEnumerable<IEnumerable<string>>>();
      foreach (var d in doc)
        try
        {
          var arr = d.Value.ToArray();
          stop++;
          var max = stop > arr.Length ? arr.Length : stop;
          var cpy = new List<IEnumerable<string>>();
          for (var i = start; i < max; i++)
            cpy.Add(arr[i]);
          res.Add(d.Key, cpy);
        }
        catch
        {
          // ignore
        }

      return res;
    }

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    public abstract void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy);

    /// <summary>
    ///   Löscht alle Layer mit diesem Displayname
    /// </summary>
    /// <param name="layerDisplayname">Name der zu löschenden Layer</param>
    public abstract void LayerDelete(string layerDisplayname);

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    public abstract IEnumerable<string> LayerDisplaynames { get; }

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    public abstract IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames { get; }

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    public abstract IEnumerable<Guid> LayerGuids { get; }

    /// <summary>
    ///   Erzeugt einen neuen Layer mit diesem Namen
    /// </summary>
    /// <param name="layerDisplayname">Name des neuen Layers</param>
    public abstract void LayerNew(string layerDisplayname);

    /// <summary>
    ///   Benennt alle Layer mit diesem Namen um.
    /// </summary>
    /// <param name="layerDisplaynameOld">Alter Displayname</param>
    /// <param name="layerDisplaynameNew">Neuer Displayname</param>
    public abstract void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew);

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    public abstract IEnumerable<AbstractLayerAdapter> Layers { get; }

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    public abstract IEnumerable<string> LayerUniqueDisplaynames { get; }

    /// <summary>
    ///   The reset all document metadata.
    /// </summary>
    /// <param name="newMetadata">
    ///   The new metadata.
    /// </param>
    public abstract void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata);

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
    public abstract bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue);

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
    public abstract bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue);

    /// <summary>
    ///   The set document metadata.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="metadata">
    ///   The metadata.
    /// </param>
    public abstract void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata);

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    public abstract void SetNewDocumentMetadata(string metadataKey, Type type);

    public abstract void AddConcept(Concept concept);

    /// <summary>
    ///   The add layer.
    /// </summary>
    /// <param name="layer">
    ///   The layer.
    /// </param>
    public abstract void AddLayer(AbstractLayerAdapter layer);

    /// <summary>
    ///   Gibt den CorpusBuilder zurück, der dieses Korpus erstellt hat
    /// </summary>
    /// <returns></returns>
    public abstract AbstractCorpusBuilder GetCorpusBuilder();

    /// <summary>
    ///   Metadaten für dieses Korpus
    /// </summary>
    public abstract IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata();

    /// <summary>
    ///   Gibt einen bestimmten Metadatenwert für das Korpsu zurück.
    /// </summary>
    /// <param name="key">KEY des Wertes</param>
    /// <returns>Wert</returns>
    public object GetCorpusMetadata(string key)
    {
      return (from x in GetCorpusMetadata() where x.Key == key select x.Value).FirstOrDefault();
    }

    public Dictionary<Guid, int[][]> GetMultilayerDocument(Guid documentGuid)
    {
      return GetLayersOfDocument(documentGuid).ToDictionary(adapter => adapter.Guid, adapter => adapter[documentGuid]);
    }

    public Dictionary<Guid, int[][]> GetMultilayerDocument(Guid documentGuid, IEnumerable<Guid> layerGuids)
    {
      var valid = new HashSet<Guid>(layerGuids);
      return GetLayersOfDocument(documentGuid).Where(adapter => valid.Contains(adapter.Guid))
                                              .ToDictionary(adapter => adapter.Guid, adapter => adapter[documentGuid]);
    }


    public abstract bool RemoveConcept(Concept concept);

    /// <summary>
    ///   Speichert das Korpus unter dem angegebenen Pfad
    /// </summary>
    /// <param name="path">Pfad</param>
    /// <param name="useCompression">if set to <c>true</c> [use compression].</param>
    public abstract void Save(string path = null, bool useCompression = true);

    /// <summary>
    ///   Ändert bzw. fügt Metadaten in das Korpus ein.
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Daten</param>
    public abstract void SetCorpusMetadata(string key, object value);
  }
}
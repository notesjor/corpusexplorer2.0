#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Model.Interface
{
  /// <summary>
  ///   The Multiverse interface.
  /// </summary>
  public interface IHydra
  {
    /// <summary>
    ///   Auflistung - CorpusGuid / DocumentGuids des Korpus
    /// </summary>
    IEnumerable<KeyValuePair<Guid, IEnumerable<Guid>>> CorporaAndDocumentGuids { get; }

    /// <summary>
    ///   Gets the selected corpora displaynames.
    /// </summary>
    IEnumerable<string> CorporaDisplaynames { get; }

    /// <summary>
    ///   Auflistung aller Corpora per GUID
    /// </summary>
    IEnumerable<Guid> CorporaGuids { get; }

    /// <summary>
    ///   Gets the corpora guids and displaynames.
    /// </summary>
    IEnumerable<KeyValuePair<Guid, string>> CorporaGuidsAndDisplaynames { get; }

    /// <summary>
    ///   Gets the count corpora.
    /// </summary>
    int CountCorpora { get; }

    /// <summary>
    ///   Gets the count documents.
    /// </summary>
    int CountDocuments { get; }

    /// <summary>
    ///   Gets the count sentences.
    /// </summary>
    /// <value>The count sentences.</value>
    long CountSentences { get; }

    /// <summary>
    ///   Gets the count token.
    /// </summary>
    /// <value>The count token.</value>
    long CountToken { get; }

    /// <summary>
    ///   Gets the document titles.
    /// </summary>
    IEnumerable<string> DocumentDisplaynames { get; }

    /// <summary>
    ///   Gets the document guids and titles.
    /// </summary>
    IEnumerable<KeyValuePair<Guid, string>> DocumentGuidAndDisplaynames { get; }

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    IEnumerable<Guid> DocumentGuids { get; }

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata { get; }

    /// <summary>
    ///   Gets the first corpus.
    /// </summary>
    Guid FirstCorpus { get; }

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    Guid FirstDocument { get; }

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    IEnumerable<string> LayerDisplaynames { get; }

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames { get; }

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    IEnumerable<Guid> LayerGuids { get; }

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    IEnumerable<AbstractLayerAdapter> Layers { get; }

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    IEnumerable<string> LayerUniqueDisplaynames { get; }

    /// <summary>
    ///   The contains corpus.
    /// </summary>
    /// <param name="corpusGuid">
    ///   The corpus guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    bool ContainsCorpus(Guid corpusGuid);

    /// <summary>
    ///   The contains document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    bool ContainsDocument(Guid documentGuid);

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    bool ContainsLayer(Guid layerGuid);

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    bool ContainsLayer(string layerDisplayname);

    /// <summary>
    ///   Exportiert einen Layer mit einem Dokument. Diese Funktion ist NUR für die manuelle
    ///   Annotation vorgesehen.
    /// </summary>
    /// <param name="documentGuid">DocumentGuid</param>
    /// <param name="layerDisplayname">Name des Layers</param>
    /// <returns>AbstractLayerAdapter</returns>
    AbstractLayerAdapter ExportDocumentLayer(Guid documentGuid, string layerDisplayname);

    /// <summary>
    ///   The find document guid.
    /// </summary>
    /// <param name="exampleKey">
    ///   The example key.
    /// </param>
    /// <param name="exampleValue">
    ///   The example documentGuids.
    /// </param>
    /// <returns>
    ///   Document Guids
    /// </returns>
    IEnumerable<Guid> FindDocumentByMetadata(string exampleKey, object exampleValue);

    /// <summary>
    ///   The find document guid.
    /// </summary>
    /// <param name="example">
    ///   The example.
    /// </param>
    /// <returns>
    ///   Document Guids
    /// </returns>
    IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example);

    /// <summary>
    ///   The get corpora by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   Corpora
    /// </returns>
    IEnumerable<AbstractCorpusAdapter> GetCorpora(string displayname);

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
    AbstractCorpusAdapter GetCorpus(Guid guid);

    /// <summary>
    ///   Gets the corpus unique identifier of document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <returns>Guid.</returns>
    Guid GetCorpusGuidOfDocument(Guid documentGuid);

    /// <summary>
    ///   The get corpus which contains document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractCorpusAdapter" />.
    /// </returns>
    AbstractCorpusAdapter GetCorpusOfDocument(Guid documentGuid);

    /// <summary>
    ///   Gets the document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns>System.Int32[][].</returns>
    int[][] GetDocument(Guid documentGuid, Guid layerGuid);

    /// <summary>
    ///   Gets the document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <param name="layerDisplayname">The layer displayname.</param>
    /// <returns>System.Int32[][].</returns>
    int[][] GetDocument(Guid documentGuid, string layerDisplayname);

    /// <summary>
    ///   The get document title.
    /// </summary>
    /// <param name="documentGuids">
    ///   The documentGuids.
    /// </param>
    /// <returns>
    ///   Documents Displayname
    /// </returns>
    IEnumerable<string> GetDocumentDisplayname(IEnumerable<Guid> documentGuids);

    /// <summary>
    ///   The get document title.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    string GetDocumentDisplayname(Guid documentGuid);

    /// <summary>
    ///   Gibt ein Maske zurück die angibt ob der Layerwerte für die entsprechende Textstelle gewählt wurde oder nicht.
    /// </summary>
    /// <param name="documentGuid">Document GUID</param>
    /// <param name="layerDisplayname">Name des Layers</param>
    /// <param name="layerValue">Wert für den die Maske erstellt werden soll</param>
    /// <returns>Boolesche-Maske</returns>
    IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      string layerValue);

    /// <summary>
    ///   Gibt ein Maske zurück die angibt ob der Layerwerte für die entsprechende Textstelle gewählt wurde oder nicht.
    /// </summary>
    /// <param name="documentGuid">Document GUID</param>
    /// <param name="layerGuid">GUID des Layers</param>
    /// <param name="layerValue">Wert für den die Maske erstellt werden soll</param>
    /// <returns>Boolesche-Maske</returns>
    IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(Guid documentGuid, Guid layerGuid, string layerValue);

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    long GetDocumentLengthInSentences(Guid documentGuid);

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    long GetDocumentLengthInSentences(Guid corpusGuid, Guid documentGuid);

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    long GetDocumentLengthInWords(Guid documentGuid);

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    long GetDocumentLengthInWords(Guid corpusGuid, Guid documentGuid);

    /// <summary>
    ///   Gibt die Metadaten aller Dokumente zurück, die dem metaKey entsprechen
    /// </summary>
    /// <param name="metaKey">
    ///   metaKey
    /// </param>
    /// <param name="defaultValue">
    ///   Standardwert falls nicht vorhanden.
    /// </param>
    /// <returns>
    ///   Key = DocumentGuid / Value = Wert
    /// </returns>
    Dictionary<Guid, T> GetDocumentMetadata<T>(string metaKey, T defaultValue);

    /// <summary>
    ///   Gibt die Metadaten eines bestimmten Dokuments zurück
    /// </summary>
    /// <param name="documentGuid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Key = MetaKey / Value = Wert
    /// </returns>
    Dictionary<string, object> GetDocumentMetadata(Guid documentGuid);

    /// <summary>
    ///   Fragt eine bestimmte Meta-Eigenschaft (metaKey) eines bestimmten Dokuments (documentGuid) ab.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="documentGuid">documentGUID</param>
    /// <param name="metaKey">Eigenschaft</param>
    /// <param name="defaultValue">Standardrückgabewert</param>
    /// <returns></returns>
    T GetDocumentMetadata<T>(Guid documentGuid, string metaKey, T defaultValue);

    /// <summary>
    ///   Fragt eine bestimmte Meta-Eigenschaft (metaKey) eines bestimmten Dokuments (documentGuid) ab.
    ///   Die Rückgabe wird im Gegensatz zu Generic-Version (siehe Überladung) immer in string konvertiert.
    /// </summary>
    /// <param name="documentGuid">documentGUID</param>
    /// <param name="metaKey">Eigenschaft</param>
    /// <param name="defaultValue">Standardrückgabewert</param>
    string GetDocumentMetadata(Guid documentGuid, string metaKey, string defaultValue);

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch gibt alle verfügbaren Metabezeichnungen sowie die dazugehörigen
    ///   einmaligen Werte zurück.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype();

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen - im Grunde alle Keys von GetDocumentMetadataPrototype()</returns>
    IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties();

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metawerte einer bestimmten
    ///   Metabezeichnung zurück.
    /// </summary>
    /// <param name="property">Metabezeichnung die durchsucht werden soll</param>
    /// <returns>Metawerte - im Grunde alle Values zu einer bestimmten Metabezeichnung von GetDocumentMetadataPrototype()</returns>
    IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property);

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metawerte einer bestimmten
    ///   Metabezeichnung zurück.
    /// </summary>
    /// <param name="property">Metabezeichnung die durchsucht werden soll</param>
    /// <returns>
    ///   Metawerte (gecastet als string) - im Grunde alle Values zu einer bestimmten Metabezeichnung von
    ///   GetDocumentMetadataPrototype()
    /// </returns>
    IEnumerable<string> GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(string property);

    /// <summary>
    ///   The get first corpus by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractCorpusAdapter" />.
    /// </returns>
    AbstractCorpusAdapter GetFirstCorpusByDisplayname(string displayname);

    /// <summary>
    ///   The get layer by guid.
    /// </summary>
    /// <param name="layerGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractLayerAdapter" />.
    /// </returns>
    AbstractLayerAdapter GetLayer(Guid layerGuid);

    /// <summary>
    ///   Gibt eine Auflistung aller Layer zurück die dieses Dokument enthalten. Im Format LayerGUID / LayerDisplayname
    /// </summary>
    /// <param name="documentGuid">Guid des Dokuments</param>
    /// <returns>Auflistung</returns>
    IEnumerable<KeyValuePair<Guid, string>> GetLayerGuidAndDisplaynamesOfDocument(Guid documentGuid);

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
    AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname);

    /// <summary>
    ///   The get layers by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   Layers
    /// </returns>
    IEnumerable<AbstractLayerAdapter> GetLayers(string displayname);

    /// <summary>
    ///   The get layers of document.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   Layers
    /// </returns>
    IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid);

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    IEnumerable<string> GetLayerValues(string layerDisplayname);

    /// <summary>
    ///   Gibt die Layerwerte eines bestimmten Layers zurück.
    /// </summary>
    /// <param name="layerGuid">Guid des Layers</param>
    /// <returns>Layerwerte</returns>
    IEnumerable<string> GetLayerValues(Guid layerGuid);

    /// <summary>
    ///   The get readable document by guid.
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
    IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname);

    /// <summary>
    ///   The get readable document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="layerGuid">
    ///   The layer guid.
    /// </param>
    /// <returns>
    ///   Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid);

    /// <summary>
    ///   The get readable document snippet by guid.
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
    IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop);

    /// <summary>
    ///   The get readable multilayer document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   Key = Layername / Value => Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid);

    /// <summary>
    ///   The get readable multilayer document by guid.
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
    ///   Key = Layername / Value => Text 0-Dim = Sentence / 1-Dim = Word
    /// </returns>
    Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid,
                                                                                       int start,
                                                                                       int stop);

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy);

    /// <summary>
    ///   Löscht alle Layer mit diesem Displayname
    /// </summary>
    /// <param name="layerDisplayname">Name der zu löschenden Layer</param>
    void LayerDelete(string layerDisplayname);

    /// <summary>
    ///   Erzeugt einen neuen Layer mit diesem Namen
    /// </summary>
    /// <param name="layerDisplayname">Name des neuen Layers</param>
    void LayerNew(string layerDisplayname);

    /// <summary>
    ///   Benennt alle Layer mit diesem Namen um.
    /// </summary>
    /// <param name="layerDisplaynameOld">Alter Displayname</param>
    /// <param name="layerDisplaynameNew">Neuer Displayname</param>
    void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew);

    /// <summary>
    ///   The reset all document metadata.
    /// </summary>
    /// <param name="newMetadata">
    ///   The new metadata.
    /// </param>
    void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata);

    /// <summary>
    ///   Switch für die angegebene Position im Text für einen bestimmten Layerwert.
    /// </summary>
    /// <param name="documentGuid">Document GUID</param>
    /// <param name="layerGuid">Layer GUID</param>
    /// <param name="sentenceIndex">Satz Index</param>
    /// <param name="wordIndex">Wort Index</param>
    /// <param name="layerValue">
    ///   Layer-Wert (ist der Wert identisch mit der an der spezifizierten Stelle
    ///   [documentGuid/sentenceIndex/wordIndex] vorgefunden Wert dann wird der Wert gelöscht ansonsten wird er gesetzt.)
    /// </param>
    /// <returns>Erfolgreich?</returns>
    bool SetDocumentLayerValueMask(
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
    bool SetDocumentLayerValueMask(
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
    void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata);

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    void SetNewDocumentMetadata(string metadataKey, Type type);
  }
}
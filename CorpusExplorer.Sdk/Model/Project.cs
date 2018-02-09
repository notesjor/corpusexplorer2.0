using System.Globalization;
using System.Reflection;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Abstract;
using CorpusExplorer.Sdk.Model.Export;
using CorpusExplorer.Sdk.Properties;

#region

using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Model.Delegates;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

#endregion

namespace CorpusExplorer.Sdk.Model
{
  /// <summary>
  ///   The project.
  /// </summary>
  [Serializable]
  public sealed class Project : CeObject, IHydra
  {
    /// <summary>
    ///   The _selections.
    /// </summary>
    private readonly List<Selection> _selections = new List<Selection>();

    /// <summary>
    ///   The _corpora.
    /// </summary>
    [NonSerialized]
    private List<AbstractCorpusAdapter> _corpora = new List<AbstractCorpusAdapter>();

    /// <summary>
    ///   The _current selection.
    /// </summary>
    private Selection _currentSelection;

    /// <summary>
    ///   The _selection all.
    /// </summary>
    [NonSerialized]
    private Selection _selectionAll;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Project" /> class.
    ///   Prevents a default instance of the <see cref="Project" /> class from being created.
    /// </summary>
    private Project() { }

    /// <summary>
    ///   Gets or sets the current selection.
    /// </summary>
    public Selection CurrentSelection
    {
      get => _currentSelection ?? SelectAll;
      set
      {
        _currentSelection = value;
        Configuration.Cache.CurrentSelectionChanged();
        OnSelectionChanged();
      }
    }

    /// <summary>
    ///   Gibt eine Auflistung zurück, die alle Selections aufführt, außer der aktuellen.
    ///   Relevant für alle Funktionen, die kontrastiv arbeiten.
    /// </summary>
    /// <value>Key = Selection / Value = Selection.Displayname</value>
    public IEnumerable<KeyValuePair<Selection, string>> OtherSelections
      =>
        Selections.Where(x => x.Guid != CurrentSelection.Guid)
                  .ToDictionary(
                    x => x,
                    x =>
                      x.Displayname.Replace("<html>", "")
                       .Replace("</html>", "")
                       .Replace("<strong>", "")
                       .Replace("</strong>", "")
                       .Replace("&nbsp;", ""));

    /// <summary>
    ///   Gets the select all.
    /// </summary>
    public Selection SelectAll
    {
      get
      {
        if (_selectionAll != null)
          return _selectionAll;

        if (_corpora == null || _corpora.Count == 0)
          return null;

        var dic = _corpora.ToDictionary(c => c.CorpusGuid, c => new HashSet<Guid>(c.DocumentGuids));

        const string label = "<html>Alle Korpora & Dokumente &nbsp;<strong>(dynamisch)</strong></html>";
        _selectionAll = Selection.Create(this, dic, label);
        var sels = _selections.ToArray();
        foreach (var s in sels.Where(s => s.Displayname == label))
          _selections.Remove(s);

        _selections.Add(_selectionAll);
        CurrentSelection = SelectAll;

        return _selectionAll;
      }
    }

    /// <summary>
    ///   Gets the selections.
    /// </summary>
    public IEnumerable<Selection> Selections => _selections;

    public IEnumerable<Selection> SelectionsRecursive
    {
      get
      {
        var res = new List<Selection>();

        var queue = new Queue<Selection>(_selections);
        while (queue.Count > 0)
        {
          var selection = queue.Dequeue();
          res.Add(selection);
          if (selection.SubSelections == null)
            continue;

          foreach (var subSelection in selection.SubSelections)
            queue.Enqueue(subSelection);
        }

        return res;
      }
    }

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
      return SelectAll != null && SelectAll.ContainsCorpus(corpusGuid);
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
      return SelectAll != null && SelectAll.ContainsDocument(documentGuid);
    }

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    public bool ContainsLayer(Guid layerGuid)
    {
      return SelectAll.ContainsLayer(layerGuid);
    }

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    public bool ContainsLayer(string layerDisplayname)
    {
      return SelectAll.ContainsLayer(layerDisplayname);
    }

    /// <summary>
    ///   Auflistung - CorpusGuid / DocumentGuids des Korpus
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, IEnumerable<Guid>>> CorporaAndDocumentGuids
      => SelectAll.CorporaAndDocumentGuids;

    /// <summary>
    ///   Gets the selected corpora displaynames.
    /// </summary>
    public IEnumerable<string> CorporaDisplaynames => SelectAll.CorporaDisplaynames;

    /// <summary>
    ///   Auflistung aller Corpora per GUID
    /// </summary>
    public IEnumerable<Guid> CorporaGuids => SelectAll.CorporaGuids;

    /// <summary>
    ///   Gets the corpora guids and displaynames.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> CorporaGuidsAndDisplaynames => SelectAll.CorporaGuidsAndDisplaynames;

    /// <summary>
    ///   Gets the count corpora.
    /// </summary>
    public int CountCorpora => SelectAll.CountCorpora;

    /// <summary>
    ///   Gets the count documents.
    /// </summary>
    public int CountDocuments => SelectAll.CountDocuments;

    /// <summary>
    ///   Gets the count sentences.
    /// </summary>
    /// <value>The count sentences.</value>
    public int CountSentences => SelectAll.CountSentences;

    /// <summary>
    ///   Gets the count token.
    /// </summary>
    /// <value>The count token.</value>
    public int CountToken => SelectAll.CountToken;

    /// <summary>
    ///   Gets the document titles.
    /// </summary>
    public IEnumerable<string> DocumentDisplaynames => SelectAll.DocumentDisplaynames;

    /// <summary>
    ///   Gets the document guids and titles.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> DocumentGuidAndDisplaynames =>
      SelectAll.DocumentGuidsAndDisplaynames;

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    public IEnumerable<Guid> DocumentGuids => SelectAll.DocumentGuids;

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata => SelectAll.DocumentMetadata;

    public AbstractLayerAdapter ExportDocumentLayer(Guid documentGuid, string layerDisplayname)
    {
      return GetCorpusOfDocument(documentGuid)?.GetLayerOfDocument(documentGuid, layerDisplayname)?.Copy(documentGuid);
    }

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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<Guid> FindDocumentByMetadata(string exampleKey, object exampleValue)
    {
      return FindDocumentByMetadata(new Dictionary<string, object> { { exampleKey, exampleValue } });
    }

    /// <summary>
    ///   The find document guid.
    /// </summary>
    /// <param name="example">
    ///   The example.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return _corpora.SelectMany(c => c.FindDocumentByMetadata(example));
    }

    /// <summary>
    ///   Gets the first corpus.
    /// </summary>
    public Guid FirstCorpus => CurrentSelection.FirstCorpus;

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    public Guid FirstDocument => CurrentSelection.FirstDocument;

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
      return _corpora.Where(x => x.CorpusDisplayname == displayname);
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
      return _corpora.FirstOrDefault(x => x.CorpusGuid == guid);
    }

    /// <summary>
    ///   Gets the corpus unique identifier of document.
    /// </summary>
    /// <param name="documentGuid">The document unique identifier.</param>
    /// <returns>Guid.</returns>
    public Guid GetCorpusGuidOfDocument(Guid documentGuid)
    {
      return SelectAll.GetCorpusGuidOfDocument(documentGuid);
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
      return SelectAll.GetCorpusOfDocument(documentGuid);
    }

    public int[][] GetDocument(Guid documentGuid, Guid layerGuid)
    {
      return GetCorpusOfDocument(documentGuid)?.GetDocument(documentGuid, layerGuid);
    }

    public int[][] GetDocument(Guid documentGuid, string layerDisplayname)
    {
      return GetCorpusOfDocument(documentGuid)?.GetDocument(documentGuid, layerDisplayname);
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
      return SelectAll.GetDocumentDisplayname(documentGuids);
    }

    /// <summary>
    ///   The get document title.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public string GetDocumentDisplayname(Guid documentGuid)
    {
      var corpus = ProxyRequestCorpus(c => c.ContainsDocument(documentGuid));
      return corpus == null
               ? $"Kein Titel (GUID: {documentGuid:N}"
               : corpus.GetDocumentDisplayname(documentGuid);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      string layerValue)
    {
      var corpus = ProxyRequestCorpus(c => c.ContainsDocument(documentGuid));
      return corpus?.GetDocumentLayerValueMask(documentGuid, layerDisplayname, layerValue);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      string layerValue)
    {
      var corpus = ProxyRequestCorpus(c => c.ContainsDocument(documentGuid));
      return corpus?.GetDocumentLayerValueMask(documentGuid, layerGuid, layerValue);
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid documentGuid)
    {
      var corpus = GetCorpusOfDocument(documentGuid);
      return corpus.GetDocumentLengthInSentences(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid corpusGuid, Guid documentGuid)
    {
      var corpus = GetCorpus(corpusGuid);
      return corpus?.GetDocumentLengthInSentences(documentGuid) ?? -1;
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInWords(Guid documentGuid)
    {
      var corpus = GetCorpusOfDocument(documentGuid);
      return corpus.GetDocumentLengthInWords(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInWords(Guid corpusGuid, Guid documentGuid)
    {
      var corpus = GetCorpus(corpusGuid);
      return corpus?.GetDocumentLengthInWords(documentGuid) ?? -1;
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
    public Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))?.GetDocumentMetadata(documentGuid);
    }

    public T GetDocumentMetadata<T>(Guid documentGuid, string metaKey, T defaultValue)
    {
      var corpus = ProxyRequestCorpus(c => c.ContainsDocument(documentGuid));
      return corpus == null ? defaultValue : corpus.GetDocumentMetadata(documentGuid, metaKey, defaultValue);
    }

    public Dictionary<Guid, T> GetDocumentMetadata<T>(string metaKey, T defaultValue)
    {
      var l = new object();
      var res = new Dictionary<Guid, T>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          var temp = c.GetDocumentMetadata(metaKey, defaultValue);
          lock (l)
          {
            foreach (var x in temp)
              res.Add(x.Key, x.Value);
          }
        });
      return res;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    public Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var l = new object();
      var res = new Dictionary<string, HashSet<object>>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c => GetDocumentMetadataPrototypeCall(c, l, res));
      return res;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen</returns>
    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      var @lock = new object();
      var res = new HashSet<string>();
      Parallel.ForEach(
        _corpora,
        c =>
        {
          var items = c.GetDocumentMetadataPrototype();
          lock (@lock)
          {
            foreach (var item in items.Where(item => !res.Contains(item.Key)))
              res.Add(item.Key);
          }
        });
      return res;
    }

    public IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      var @lock = new object();
      var res = new HashSet<object>();
      Parallel.ForEach(
        _corpora,
        c =>
        {
          var items = c.GetDocumentMetadataPrototypeOnlyPropertieValues(property);
          lock (@lock)
          {
            foreach (var item in items.Where(item => !res.Contains(item)))
              res.Add(item);
          }
        });
      return res;
    }

    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(string property)
    {
      var @lock = new object();
      var res = new HashSet<string>();
      Parallel.ForEach(
        _corpora,
        c =>
        {
          var items = c.GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(property);
          lock (@lock)
          {
            foreach (var item in items.Where(item => !res.Contains(item)))
              res.Add(item);
          }
        });
      return res;
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
      return _corpora.FirstOrDefault(x => x.CorpusDisplayname == displayname);
    }

    /// <summary>
    ///   The get layer by guid.
    /// </summary>
    /// <param name="layerGuid">
    ///   The guid.
    /// </param>
    /// <returns>
    ///   The <see cref="AbstractLayerAdapter" />.
    /// </returns>
    public AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return ProxyRequestCorpus(c => c.ContainsLayer(layerGuid))?.GetLayer(layerGuid);
    }

    /// <summary>
    ///   Gibt eine Auflistung aller Layer zurück die dieses Dokument enthalten. Im Format LayerGUID / LayerDisplayname
    /// </summary>
    /// <param name="documentGuid">Guid des Dokuments</param>
    /// <returns>Auflistung</returns>
    public IEnumerable<KeyValuePair<Guid, string>> GetLayerGuidAndDisplaynamesOfDocument(Guid documentGuid)
    {
      return GetCorpusOfDocument(documentGuid)?.GetLayerGuidAndDisplaynamesOfDocument(documentGuid);
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
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))
        ?.GetLayerOfDocument(documentGuid, layerDisplayname);
    }

    /// <summary>
    ///   The get layers by displayname.
    /// </summary>
    /// <param name="displayname">
    ///   The displayname.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      var res = new ConcurrentBag<AbstractLayerAdapter>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          foreach (var layer in c.GetLayers(displayname))
            res.Add(layer);
        });
      return res;
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
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))?.GetLayersOfDocument(documentGuid);
    }

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    public IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      return ProxyRequestHashSet(
        c =>
        {
          var h = new HashSet<string>();
          foreach (var v in
            from layer in c.Layers
            where layer.Displayname == layerDisplayname
            from v in layer.Values
            select v)
            h.Add(v);
          return h;
        });
    }

    /// <summary>
    ///   Gibt die Layerwerte eines bestimmten Layers zurück.
    /// </summary>
    /// <param name="layerGuid">Guid des Layers</param>
    /// <returns>Layerwerte</returns>
    public IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      return ProxyRequestHashSet(
        c =>
        {
          var h = new HashSet<string>();
          foreach (var v in
            from layer in c.Layers
            where layer.Guid == layerGuid
            from v in layer.Values
            select v)
            h.Add(v);
          return h;
        });
    }

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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))
        ?.GetReadableDocument(documentGuid, layerDisplayname);
    }

    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))?.GetReadableDocument(documentGuid, layerGuid);
    }

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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))?
        .GetReadableDocumentSnippet(documentGuid, layerDisplayname, start, stop);
    }

    /// <summary>
    ///   The get readable multilayer document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="Dictionary{TKey,TValue}" />.
    /// </returns>
    public Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid)
    {
      return ProxyRequestCorpus(c => c.ContainsDocument(documentGuid))?.GetReadableMultilayerDocument(documentGuid);
    }

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    public void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      foreach (var corpus in _corpora)
        corpus.LayerCopy(layerDisplaynameOriginal, layerDisplaynameCopy);
    }

    /// <summary>
    ///   Löscht alle Layer mit diesem Displayname
    /// </summary>
    /// <param name="layerDisplayname">Name der zu löschenden Layer</param>
    public void LayerDelete(string layerDisplayname)
    {
      foreach (var corpus in _corpora)
        corpus.LayerDelete(layerDisplayname);
    }

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    public IEnumerable<string> LayerDisplaynames => ProxyRequestList(x => x.LayerDisplaynames);

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => ProxyRequestDictionary(x => x.LayerGuidAndDisplaynames);

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    public IEnumerable<Guid> LayerGuids => ProxyRequestList(x => x.LayerGuids);

    /// <summary>
    ///   Erzeugt einen neuen Layer mit diesem Namen
    /// </summary>
    /// <param name="layerDisplayname">Name des neuen Layers</param>
    /// <returns>GUID des neuen Layers</returns>
    public void LayerNew(string layerDisplayname)
    {
      foreach (var corpus in _corpora)
        corpus.LayerNew(layerDisplayname);
    }

    /// <summary>
    ///   Benennt alle Layer mit diesem Namen um.
    /// </summary>
    /// <param name="layerDisplaynameOld">Alter Displayname</param>
    /// <param name="layerDisplaynameNew">Neuer Displayname</param>
    public void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      foreach (var corpus in _corpora)
        corpus.LayerRename(layerDisplaynameOld, layerDisplaynameNew);
    }

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    public IEnumerable<AbstractLayerAdapter> Layers => ProxyRequestList(x => x.Layers);

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    public IEnumerable<string> LayerUniqueDisplaynames
    {
      get
      {
        var res = new HashSet<string>();
        var names = LayerDisplaynames;
        foreach (var name in names.Where(name => !res.Contains(name)))
          res.Add(name);

        return res;
      }
    }
    
    /// <summary>
    ///   The reset all document metadata.
    /// </summary>
    /// <param name="newMetadata">
    ///   The new metadata.
    /// </param>
    public void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          var guids = new HashSet<Guid>(c.DocumentGuids);
          c.ResetAllDocumentMetadata(
            newMetadata.Where(guid => guids.Contains(guid.Key))
                       .ToDictionary(guid => guid.Key, guid => guid.Value));
        });
    }

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
    public bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      foreach (var corpus in _corpora.Where(corpus => corpus.ContainsDocument(documentGuid)))
        corpus.SetDocumentLayerValueMask(documentGuid, layerGuid, sentenceIndex, wordIndex, layerValue);
      return true;
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
      foreach (var corpus in _corpora.Where(corpus => corpus.ContainsDocument(documentGuid)))
        corpus.SetDocumentLayerValueMask(documentGuid, layerDisplayname, sentenceIndex, wordIndex, layerValue);
      return true;
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
      foreach (var corpus in _corpora.Where(corpus => corpus.ContainsDocument(documentGuid)))
        corpus.SetDocumentMetadata(documentGuid, metadata);
    }

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    public void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      foreach (var corpus in _corpora)
        corpus.SetNewDocumentMetadata(metadataKey, type);
    }

    /// <summary>
    ///   Fügt dem Projekt ein neues Korpus hinzu.
    ///   Läd ein Korpus direkt in den Speicher.
    /// </summary>
    /// <param name="corpus">
    ///   Neues Korpus.
    /// </param>
    public void Add(AbstractCorpusAdapter corpus)
    {
      if (ContainsCorpus(corpus.CorpusGuid))
        return;

      _corpora.Add(corpus);

      SelectCompleteCorpus(corpus);
    }

    /// <summary>
    ///   Fügt dem Projekt eine bestehende Auswahl hinzu.
    ///   ACHTUNG: Sollte nur verwendet werden um Selection die durch BLOCKs erzeugt wurden dem Projekt hinzuzufügen.
    ///   Für die manuelle Selection-Erzeugung benutzen Sie bitte CreateSelection !!!
    /// </summary>
    /// <param name="selection">Die Selection</param>
    /// <param name="parentSelection">Übergeordnete Selection</param>
    private void AddSelection(Selection selection, Selection parentSelection = null)
    {
      if (parentSelection == null)
        _selections.Add(selection);
      else
        parentSelection.AddSubSelection(selection);
    }

    /// <summary>
    ///   The create.
    /// </summary>
    /// <param name="displayName">
    ///   The display name.
    /// </param>
    /// <returns>
    ///   The <see cref="Project" />.
    /// </returns>
    public static Project Create(string displayName = null)
    {
      return new Project
      {
        Displayname = displayName ?? Resources.Project + DateTime.Now.ToString(Resources.DateTimeFormat_Long)
      };
    }

    /// <summary>
    ///   Erzeugt eine neue Auswahl
    /// </summary>
    /// <param name="queries">Queries</param>
    /// <param name="overrideSelectionDisplayname">Überschreibt den automatisch generierten Anzeigenamen</param>
    /// <param name="parentSelection">
    ///   Selection von der die neue Selection abgeleitet werden soll. Wenn null, dann wird
    ///   SelectAll des Projekts verwendet.
    /// </param>
    /// <returns></returns>
    public Selection CreateSelection(
      IEnumerable<AbstractFilterQuery> queries,
      string overrideSelectionDisplayname,
      Selection parentSelection = null)
    {
      var res = (parentSelection ?? SelectAll).Create(queries, overrideSelectionDisplayname);

      AddSelection(res, parentSelection);
      OnSelectionCreated();

      return res;
    }

    public Selection CreateSelection(
      IEnumerable<Guid> documentGuids,
      string overrideSelectionDisplayname,
      Selection parentSelection = null)
    {
      var dic = new Dictionary<Guid, HashSet<Guid>>();

      foreach (var guid in documentGuids)
      {
        if (guid == Guid.Empty)
          continue;
        var corpus = GetCorpusGuidOfDocument(guid);
        if (corpus == Guid.Empty)
          continue;

        if (dic.ContainsKey(corpus))
          dic[corpus].Add(guid);
        else
          dic.Add(corpus, new HashSet<Guid> { guid });
      }

      return CreateSelection(dic, overrideSelectionDisplayname, parentSelection);
    }

    public Selection CreateSelection(
      Dictionary<Guid, HashSet<Guid>> corpusAndDocumentGuids,
      string overrideSelectionDisplayname,
      Selection parentSelection = null)
    {
      var res = (parentSelection ?? SelectAll).Create(
        corpusAndDocumentGuids,
        overrideSelectionDisplayname);

      AddSelection(res, parentSelection);
      OnSelectionCreated();

      return res;
    }

    public Selection CreateSelectionTemporary(
      IEnumerable<AbstractFilterQuery> queries,
      Selection parentSelection = null)
    {
      return (parentSelection ?? SelectAll).CreateTemporary(queries);
    }

    public Selection CreateSelectionTemporary(
      Dictionary<Guid, HashSet<Guid>> corpusAndDocumentGuids,
      Selection parentSelection = null)
    {
      return (parentSelection ?? SelectAll).CreateTemporary(corpusAndDocumentGuids);
    }

    internal int GetDocumentLengthInSentences(Dictionary<Guid, HashSet<Guid>> selectionDefinition)
    {
      return (from csel in selectionDefinition
              let corpus = GetCorpus(csel.Key)
              where corpus != null
              from dsel in csel.Value
              select corpus.GetDocumentLengthInSentences(dsel)).Sum();
    }

    private static void GetDocumentMetadataPrototypeCall(
      AbstractCorpusAdapter c,
      object l,
      Dictionary<string, HashSet<object>> res)
    {
      var proto = c.GetDocumentMetadataPrototype();
      foreach (var entry in proto)
        lock (l)
        {
          if (res.ContainsKey(entry.Key))
            foreach (var v in entry.Value)
              res[entry.Key].Add(v);
          else
            res.Add(entry.Key, new HashSet<object>(entry.Value));
        }
    }

    /// <summary>
    ///   The load.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <returns>
    ///   The <see cref="Project" />.
    /// </returns>
    public static Project Load(string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding, stringSplitOptions: StringSplitOptions.RemoveEmptyEntries);
      if (lines[0] != "----=----")
        return null;

      var res = new Project();

      var i = 1;
      for (; i < lines.Length; i++)
      {
        if (lines[i] == "---->----")
          break;

        try
        {
          var entry = lines[i].Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
          if (entry.Length != 2)
            continue;

          switch (entry[0])
          {
            case "NAME":
              res.Displayname = entry[1];
              break;
            case "GUID":
              res._guid = Guid.Parse(entry[1]);
              break;
            case "ENCO":
              Configuration.Encoding = Encoding.GetEncoding(int.Parse(entry[1]));
              break;
            case "CACH":
              Configuration.Cache = Activator.CreateInstance(Type.GetType(entry[1])) as AbstractCacheStrategy;
              break;
            case "MEAS":
              Configuration.Measure = Activator.CreateInstance(Type.GetType(entry[1])) as IMeasure;
              break;
            case "PROT":
              Configuration.ProtectMemoryOverflow = bool.Parse(entry[1]);
              break;
            case "SIGN":
              Configuration.Significance = Activator.CreateInstance(Type.GetType(entry[1])) as ISignificance;
              break;
            case "MINF":
              Configuration.MinimumFrequency = int.Parse(entry[1]);
              break;
            case "MINS":
              Configuration.MinimumSignificance = double.Parse(entry[1], CultureInfo.InvariantCulture);
              break;
          }
        }
        catch { }
      }

      for (; i < lines.Length; i++)
      {
        if (lines[i] == "----?----")
          break;

        var entry = lines[i].Split(new[] { ">" }, StringSplitOptions.RemoveEmptyEntries);
        if (entry.Length != 3)
          continue;

        var tguid = Guid.Parse(entry[0]);
        var type = Type.GetType(entry[1]);

        var corpus = type.GetMethods().First(x => x.IsStatic && x.IsPublic && x.Name == "Create" && x.GetParameters().Length == 1).Invoke(null, new object[] { entry[2] }) as AbstractCorpusAdapter;
        if (corpus == null || corpus.CorpusGuid != tguid)
          continue;
        res.Add(corpus);
      }

      i++;
      for (; i < lines.Length; i++)
        SelectionListConverterHelper.FromListStream(res, lines[i]);

      return res;
    }

    private void OnSelectionChanged() { SelectionChanged?.Invoke(); }

    private void OnSelectionCreated() { SelectionCreated?.Invoke(); }

    private AbstractCorpusAdapter ProxyRequestCorpus(ProxyRequestDelegate func)
    {
      AbstractCorpusAdapter res = null;

      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        (c, state) =>
        {
          if (!func(c))
            return;
          res = c;
          state.Break();
        });

      return res;
    }

    private Dictionary<TK, TV> ProxyRequestDictionary<TK, TV>(ProxyRequestDictionaryDelegate<TK, TV> func)
    {
      var res = new ConcurrentDictionary<TK, TV>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          var items = func(c);
          foreach (var item in items)
            res.TryAdd(item.Key, item.Value);
        });

      return res.ToDictionary(x => x.Key, x => x.Value);
    }

    private HashSet<T> ProxyRequestHashSet<T>(ProxyRequestListDelegate<T> func)
    {
      var l = new object();
      var res = new HashSet<T>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          var items = func(c);
          lock (l)
          {
            foreach (var item in items)
              res.Add(item);
          }
        });

      return res;
    }

    private List<T> ProxyRequestList<T>(ProxyRequestListDelegate<T> func)
    {
      var l = new object();
      var res = new List<T>();
      Parallel.ForEach(
        _corpora,
        Configuration.ParallelOptions,
        c =>
        {
          var items = func(c);
          lock (l)
          {
            res.AddRange(items);
          }
        });

      return res;
    }

    /// <summary>
    ///   The corpus remove.
    /// </summary>
    /// <param name="corpusGuid">
    ///   The corpus guid.
    /// </param>
    public void Remove(Guid corpusGuid)
    {
      var c = (from x in _corpora where x.CorpusGuid == corpusGuid select x).FirstOrDefault();
      if (c != null)
        _corpora.Remove(c);

      _selectionAll = null;
    }

    public void RemoveSelection(Selection selection) { _selections.Remove(selection); }

    /// <summary>
    ///   The save.
    /// </summary>
    /// <param name="path">
    ///   Pfad unter dem das Projekt gespeichert wird.
    /// </param>
    public void Save(string path)
    {
      var stb = new StringBuilder();

      stb.AppendLine("----=----");

      stb.AppendLine($"NAME={Displayname}");
      stb.AppendLine($"GUID={Guid}");
      stb.AppendLine($"ENCO={Configuration.Encoding.CodePage}");
      stb.AppendLine($"CACH={Configuration.Cache.GetType().FullName}");
      stb.AppendLine($"MEAS={Configuration.Measure.GetType().FullName}");
      stb.AppendLine($"PROT={Configuration.ProtectMemoryOverflow}");
      stb.AppendLine($"SIGN={Configuration.Significance.GetType().FullName}");
      stb.AppendLine($"MINF={Configuration.MinimumFrequency}");
      stb.AppendLine($"MINS={Configuration.MinimumSignificance.ToString(CultureInfo.InvariantCulture)}");

      stb.AppendLine("---->----");

      foreach (var corpus in _corpora)
        stb.AppendLine($"{corpus.CorpusGuid}>{corpus.GetType()}>{corpus.CorpusPath}");

      stb.AppendLine("----?----");

      foreach (var selection in _selections)
        stb.AppendLine(SelectionListConverterHelper.ToListStream(selection));

      FileIO.Write(path.ForceFileExtension("proj5"), stb.ToString(), Configuration.Encoding);
    }

    /// <summary>
    ///   The create selection all.
    /// </summary>
    public void SelectAllNew()
    {
      _selectionAll = null;
    }

    private void SelectCompleteCorpus(AbstractCorpusAdapter corpus)
    {
      var corpusSelection = new Dictionary<Guid, HashSet<Guid>>
      {
        {
          corpus.CorpusGuid, new HashSet<Guid>(corpus.DocumentGuids)
        }
      };
      CurrentSelection = Selection.Create(
        this,
        corpusSelection,
        $"{Resources.AllDocumentsFrom} {corpus.CorpusDisplayname}");
      _selections.Add(CurrentSelection);
      SelectAllNew();
    }

    public event HydraDelegate SelectionChanged;

    /// <summary>
    ///   Gets or sets the on model changes.
    /// </summary>
    /// <value>The on model changes.</value>
    public event HydraDelegate SelectionCreated;

    private delegate bool ProxyRequestDelegate(AbstractCorpusAdapter c);

    /// <summary>
    ///   The proxy request dictionary delegate.
    /// </summary>
    /// <param name="c">
    ///   The c.
    /// </param>
    /// <typeparam name="TK">
    /// </typeparam>
    /// <typeparam name="TV">
    /// </typeparam>
    private delegate IEnumerable<KeyValuePair<TK, TV>> ProxyRequestDictionaryDelegate<TK, TV>(AbstractCorpusAdapter c);

    /// <summary>
    ///   The proxy request list delegate.
    /// </summary>
    /// <param name="c">
    ///   The c.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    private delegate IEnumerable<T> ProxyRequestListDelegate<out T>(AbstractCorpusAdapter c);
  }
}
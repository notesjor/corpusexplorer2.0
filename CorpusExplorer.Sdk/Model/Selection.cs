using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Properties;

#region

using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

#endregion

namespace CorpusExplorer.Sdk.Model
{
  /// <summary>
  ///   The selection.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class Selection : CeObject, IHydra, IEnumerable<KeyValuePair<Guid, HashSet<Guid>>>, ICloneable
  {
    /// <summary>
    ///   The _sub selections.
    /// </summary>
    [XmlArray] private readonly List<Selection> _subSelections = new List<Selection>();

    [XmlIgnore] [NonSerialized] private int _countSentences = -1;

    [XmlIgnore] [NonSerialized] private int _countToken = -1;

    [XmlIgnore] [NonSerialized] private int _countTokenMatches = -1;

    [XmlIgnore] [NonSerialized] private int _countSentenceMatches = -1;

    [XmlIgnore] [NonSerialized] private Dictionary<Guid, Dictionary<string, object>> _documentMetadata;

    [XmlIgnore] [NonSerialized] private Project _project;

    /// <summary>
    ///   Selected Corpora and Documents
    /// </summary>
    [XmlIgnore] [NonSerialized] private Dictionary<Guid, HashSet<Guid>> _selection;

    [XmlArray] private KeyValuePair<Guid, HashSet<Guid>>[] _selectionSerialized;

    /// <summary>
    ///   Prevents a default instance of the <see cref="Selection" /> class from being created.
    /// </summary>
    private Selection()
    {
    }

    /// <summary>
    ///   Gets the document guids and displaynames.
    /// </summary>
    public IEnumerable<KeyValuePair<Guid, string>> DocumentGuidsAndDisplaynames
    {
      get
      {
        var res = new Dictionary<Guid, string>();
        foreach (var csel in _selection)
        {
          var corpus = Project.GetCorpus(csel.Key);
          if (corpus == null)
            continue;

          var valid = new HashSet<Guid>(csel.Value);
          var temp = corpus.DocumentGuidAndDisplaynames;

          foreach (KeyValuePair<Guid, string> pair in temp.Where(entry => valid.Contains(entry.Key)))
            try
            {
              res.Add(pair.Key, pair.Value);
            }
            catch
            {
              // ignore
            }
        }

        return res;
      }
    }

    [XmlIgnore] public AbstractFilterQuery[] Queries { get; internal set; }

    /// <summary>
    ///   Unterauswahlen die auf dieser Auswahl basieren.
    ///   Eine Unterauswahl wird durch Clone() erzeugt.
    ///   Diesen Vorgang übernimmt der FilterBlick vollautomatisch.
    /// </summary>
    [XmlArray]
    public IEnumerable<Selection> SubSelections => _subSelections;

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    [XmlElement]
    public string Verbal => Displayname;

    /// <summary>
    ///   Gets or sets the project.
    /// </summary>
    [XmlIgnore]
    internal Project Project
    {
      get => _project;
      set => _project = value;
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public object Clone()
    {
      var date = DateTime.Now;
      var res = new Selection
      {
        _selection = _selection.Clone(),
        Project = Project,
        Displayname =
          Displayname + $" (MOD: {date.ToString(Resources.DateTimeFormat_Long)})"
      };

      res.Metadata.Add(Resources.Created, date);
      res.Metadata.Add(Resources.Label, res.Displayname);
      return res;
    }

    /// <summary>
    ///   Gibt einen Enumerator zurück, der eine Auflistung durchläuft.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="T:System.Collections.IEnumerator" />-Objekt, das zum Durchlaufen der Auflistung verwendet werden kann.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    ///   Gibt einen Enumerator zurück, der die Auflistung durchläuft.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="T:System.Collections.Generic.IEnumerator`1" />, der zum Durchlaufen der Auflistung verwendet werden
    ///   kann.
    /// </returns>
    public IEnumerator<KeyValuePair<Guid, HashSet<Guid>>> GetEnumerator()
    {
      return _selection.GetEnumerator();
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
      return _selection.ContainsKey(corpusGuid);
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
      return _selection.SelectMany(csel => csel.Value).Any(guid => guid == documentGuid);
    }

    /// <summary>
    ///   Determines whether the specified layer unique identifier contains layer.
    /// </summary>
    /// <param name="layerGuid">The layer unique identifier.</param>
    /// <returns><c>true</c> if the specified layer unique identifier contains layer; otherwise, <c>false</c>.</returns>
    public bool ContainsLayer(Guid layerGuid)
    {
      return _selection.Any(csel => Project.GetCorpus(csel.Key).ContainsLayer(layerGuid));
    }

    /// <summary>
    ///   Gibt zurück ob es einen Layer mit diesem Namen gibt.
    /// </summary>
    /// <param name="layerDisplayname">Displayname des Layers</param>
    /// <returns><c>true</c> wenn mindestens ein Layer diesen Displaynamen trägt; ansonsten <c>false</c>.</returns>
    public bool ContainsLayer(string layerDisplayname)
    {
      return _selection.Select(x => x.Key).Any(cguid => Project.GetCorpus(cguid).ContainsLayer(layerDisplayname));
    }

    /// <summary>
    ///   Auflistung - CorpusGuid / DocumentGuids des Korpus
    /// </summary>
    [XmlIgnore]
    public IEnumerable<KeyValuePair<Guid, IEnumerable<Guid>>> CorporaAndDocumentGuids
      => _selection.ToDictionary<KeyValuePair<Guid, HashSet<Guid>>, Guid, IEnumerable<Guid>>(c => c.Key, c => c.Value);

    /// <summary>
    ///   Gets the corpora displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<string> CorporaDisplaynames
      => _selection.Select(c => GetCorpus(c.Key).CorpusDisplayname).ToList();

    /// <summary>
    ///   Auflistung aller Corpora per GUID
    /// </summary>
    [XmlIgnore]
    public IEnumerable<Guid> CorporaGuids => _selection.Select(x => x.Key);

    /// <summary>
    ///   Gets the corpora guids and displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<KeyValuePair<Guid, string>> CorporaGuidsAndDisplaynames
      => ProxyRequestDictionary(x => x.CorporaGuidsAndDisplaynames);

    /// <summary>
    ///   Gets the count corpora.
    /// </summary>
    [XmlIgnore]
    public int CountCorpora => _selection.Count;

    /// <summary>
    ///   Gets the count documents.
    /// </summary>
    [XmlIgnore]
    public int CountDocuments => _selection.Sum(pair => pair.Value.Count);

    [XmlIgnore]
    public bool IsEmpty => _selection == null || _selection.Count == 0 || _selection.Sum(pair => pair.Value.Count) == 0;

    [XmlIgnore]
    public int CountSentences
    {
      get
      {
        if (_countSentences > -1)
          return _countSentences;

        _countSentences = 0;
        foreach (var csel in _selection)
        {
          var corpus = GetCorpus(csel.Key);
          if (corpus == null)
            continue;
          foreach (var dsel in csel.Value)
            _countSentences += corpus.GetDocumentLengthInSentences(dsel);
        }

        Project.GetDocumentLengthInSentences(_selection);
        return _countSentences;
      }
    }

    [XmlIgnore]
    public int CountToken
    {
      get
      {
        if (_countToken > -1)
          return _countToken;

        _countToken = 0;
        foreach (var csel in _selection)
        {
          var corpus = GetCorpus(csel.Key);
          if (corpus == null)
            continue;
          foreach (var dsel in csel.Value)
            _countToken += corpus.GetDocumentLengthInWords(dsel);
        }

        return _countToken;
      }
    }

    [XmlIgnore]
    public int CountTokenMatches
    {
      get
      {
        if (_countTokenMatches > -1)
          return _countTokenMatches;

        if (Queries == null || Queries.Length == 0)
          _countTokenMatches = CountToken; // Falls keine Queries gesetzt, selektiere alles
        else
        {
          _countTokenMatches = 0;

          foreach (var q in Queries)
          {
            var matches = q.GetSentenceAndWordIndices(this);
            _countTokenMatches += matches.SelectMany(x => x.Value).SelectMany(x => x.Value).SelectMany(x => x.Value).Count();
          }
        }

        return _countTokenMatches;
      }
    }

    [XmlIgnore]
    public int CountSentenceMatches
    {
      get
      {
        if (_countSentenceMatches > -1)
          return _countSentenceMatches;

        if (Queries == null || Queries.Length == 0)
          _countSentenceMatches = CountSentences; // Falls keine Queries gesetzt, selektiere alles
        else
        {
          _countSentenceMatches = 0;

          foreach (var q in Queries)
          {
            var matches = q.GetSentenceAndWordIndices(this);
            _countSentenceMatches += matches.SelectMany(x => x.Value).SelectMany(x => x.Value).Count();
          }
        }

        return _countSentenceMatches;
      }
    }

    /// <summary>
    ///   Gets the document displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<string> DocumentDisplaynames
    {
      get
      {
        return ProxyRequestList(
          x =>
          {
            var valid = new HashSet<Guid>(_selection[x.CorpusGuid]);
            var tests = x.DocumentGuidAndDisplaynames;

            return from test in tests where valid.Contains(test.Key) select test.Value;
          });
      }
    }

    /// <summary>
    ///   Gets the document guids and titles.
    /// </summary>
    IEnumerable<KeyValuePair<Guid, string>> IHydra.DocumentGuidAndDisplaynames => DocumentGuidsAndDisplaynames;

    /// <summary>
    ///   Gets the document guids.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<Guid> DocumentGuids => _selection.SelectMany(c => c.Value);

    /// <summary>
    ///   Gets the document metadata.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
    {
      get
      {
        if (_documentMetadata != null)
          return _documentMetadata;
        var tmp = new ConcurrentDictionary<Guid, Dictionary<string, object>>();

        Parallel.ForEach(
          _selection,
          Configuration.ParallelOptions,
          csel =>
          {
            var corpus = GetCorpus(csel.Key);
            var metas = corpus.DocumentMetadata.ToDictionary(x => x.Key, x => x.Value);

            foreach (var guid in csel.Value.Where(metas.ContainsKey))
              tmp.TryAdd(guid, metas[guid]);
          });

        _documentMetadata = tmp.ToDictionary(x => x.Key, x => x.Value);
        return _documentMetadata;
      }
    }

    public AbstractLayerAdapter ExportDocumentLayer(Guid documentGuid, string layerDisplayname)
    {
      return ContainsDocument(documentGuid) ? Project.ExportDocumentLayer(documentGuid, layerDisplayname) : null;
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
      var temp = Project.FindDocumentByMetadata(example);
      var valid = new HashSet<Guid>(DocumentGuids);
      return temp.Where(valid.Contains);
    }

    /// <summary>
    ///   Gets the first corpus.
    /// </summary>
    [XmlIgnore]
    public Guid FirstCorpus => _selection.FirstOrDefault().Key;

    /// <summary>
    ///   Gets the first document.
    /// </summary>
    [XmlIgnore]
    public Guid FirstDocument => _selection.FirstOrDefault().Value.FirstOrDefault();

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
      return Project.GetCorpora(displayname).Where(corpus => corpus.CorpusDisplayname == displayname);
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
      return Project.GetCorpus(guid);
    }

    public Guid GetCorpusGuidOfDocument(Guid documentGuid)
    {
      foreach (var csel in _selection)
        if (csel.Value.Contains(documentGuid))
          return csel.Key;
      return Guid.Empty;
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
      var key = GetCorpusGuidOfDocument(documentGuid);
      return key == Guid.Empty ? null : Project.GetCorpus(key);
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
      return documentGuids.Select(GetDocumentDisplayname);
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
      return Project.GetDocumentDisplayname(documentGuid);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      string layerValue)
    {
      return Project.GetDocumentLayerValueMask(documentGuid, layerDisplayname, layerValue);
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      string layerValue)
    {
      return Project.GetDocumentLayerValueMask(documentGuid, layerGuid, layerValue);
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid documentGuid)
    {
      return Project.GetDocumentLengthInSentences(documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Sätze in einem Dokument zurück.
    /// </summary>
    /// <param name="corpusGuid">Korpus GUID in dem das Dokument enthalten sein muss</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInSentences(Guid corpusGuid, Guid documentGuid)
    {
      return Project.GetDocumentLengthInSentences(corpusGuid, documentGuid);
    }

    /// <summary>
    ///   Gibt die Anzahl der Worte in einem Dokument zurück.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>System.Int32.</returns>
    public int GetDocumentLengthInWords(Guid documentGuid)
    {
      return Project.GetDocumentLengthInWords(documentGuid);
    }

    public int GetDocumentLengthInWords(Guid corpusGuid, Guid documentGuid)
    {
      return Project.GetDocumentLengthInWords(corpusGuid, documentGuid);
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
      return Project.GetDocumentMetadata(documentGuid);
    }

    public T GetDocumentMetadata<T>(Guid documentGuid, string metaKey, T defaultValue)
    {
      return Project.GetDocumentMetadata(documentGuid, metaKey, defaultValue);
    }

    public Dictionary<Guid, T> GetDocumentMetadata<T>(string metaKey, T defaultValue)
    {
      return Project.GetDocumentMetadata(metaKey, defaultValue);
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch.
    /// </summary>
    /// <returns>Key = Metabezeichnung / Value = Metawert</returns>
    public Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var meta = DocumentMetadata;
      var res = new Dictionary<string, HashSet<object>>();

      foreach (var x in meta)
        foreach (var y in x.Value)
        {
          if (!res.ContainsKey(y.Key))
            res.Add(y.Key, new HashSet<object>());
          res[y.Key].Add(y.Value);
        }

      return res;
    }

    /// <summary>
    ///   Führt eine tiefe Analyse der Dokumentmetadaten durch und gibt alle verfügbaren Metabezeichnungen zurück.
    /// </summary>
    /// <returns>Metabezeichnungen</returns>
    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      var meta = DocumentMetadata;
      return new HashSet<string>(from x in meta from y in x.Value select y.Key);
    }

    public IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      var meta = DocumentMetadata;
      return new HashSet<object>(from x in meta where x.Value.ContainsKey(property) select x.Value[property]);
    }

    public IEnumerable<string> GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(string property)
    {
      var meta = DocumentMetadata;
      return
        new HashSet<string>(
          from x in meta where x.Value.ContainsKey(property) select x.Value[property]?.ToString() ?? "");
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
      return _selection.Count == 0 ? null : Project.GetCorpus(_selection.FirstOrDefault().Key);
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
      return Project.GetLayer(layerGuid);
    }

    /// <summary>
    ///   Gibt eine Auflistung aller Layer zurück die dieses Dokument enthalten
    /// </summary>
    /// <param name="documentGuid">Guid des Dokuments</param>
    /// <returns>Auflistung</returns>
    public IEnumerable<KeyValuePair<Guid, string>> GetLayerGuidAndDisplaynamesOfDocument(Guid documentGuid)
    {
      return Project.GetLayerGuidAndDisplaynamesOfDocument(documentGuid);
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
      return (from csel in _selection
              select Project.GetCorpus(csel.Key)
        into corpus
              where corpus != null && corpus.ContainsDocument(documentGuid)
              select corpus.GetLayerOfDocument(documentGuid, layerDisplayname)).FirstOrDefault();
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
      return
        _selection.Select(csel => Project.GetCorpus(csel.Key))
          .Where(corpus => corpus != null)
          .SelectMany(corpus => corpus.Layers)
          .Where(layer => layer.Displayname == displayname);
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
      return (from csel in _selection
              select Project.GetCorpus(csel.Key)
        into corpus
              where corpus != null && corpus.ContainsDocument(documentGuid)
              select corpus.GetLayersOfDocument(documentGuid)).FirstOrDefault();
    }

    /// <summary>
    ///   Gibt die Layerwerte aller Layer zurück die mit dem angegebenen LayerDisplayname bezeichnet sind.
    /// </summary>
    /// <param name="layerDisplayname">Name der Layer</param>
    /// <returns>Layerwerte</returns>
    public IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var res = new HashSet<string>();

      foreach (var value in from csel in Project.CorporaGuids
                            select Project.GetCorpus(csel)
        into corpus
                            from layer in corpus.GetLayers(layerDisplayname)
                            from value in layer.Values
                            select value)
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
      return Project.GetLayerValues(layerGuid);
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
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return Project.GetReadableDocument(documentGuid, layerDisplayname);
    }

    public IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return Project.GetReadableDocument(documentGuid, layerGuid);
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
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return Project.GetReadableDocumentSnippet(documentGuid, layerDisplayname, start, stop);
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
      return Project.GetReadableMultilayerDocument(documentGuid);
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
    public Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(Guid documentGuid, int start, int stop)
    {
      return Project.GetReadableMultilayerDocument(documentGuid, start, stop);
    }

    /// <summary>
    ///   Layers the copy.
    /// </summary>
    /// <param name="layerDisplaynameOriginal">The layer displayname original.</param>
    /// <param name="layerDisplaynameCopy">The layer displayname copy.</param>
    public void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      Project.LayerCopy(layerDisplaynameOriginal, layerDisplaynameCopy);
    }

    public void LayerDelete(string layerDisplayname)
    {
      Project.LayerDelete(layerDisplayname);
    }

    /// <summary>
    ///   Gets the layer displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<string> LayerDisplaynames => ProxyRequestList(x => x.LayerDisplaynames);

    /// <summary>
    ///   Gets the layer guid and displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => ProxyRequestDictionary(x => x.LayerGuidAndDisplaynames);

    /// <summary>
    ///   Gets the layer guids.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<Guid> LayerGuids => ProxyRequestList(x => x.LayerGuids);

    public void LayerNew(string layerDisplayname)
    {
      Project.LayerNew(layerDisplayname);
    }

    public void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      Project.LayerRename(layerDisplaynameOld, layerDisplaynameNew);
    }

    /// <summary>
    ///   Gets the layers.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<AbstractLayerAdapter> Layers => ProxyRequestList(x => x.Layers);

    /// <summary>
    ///   Gets the layer unique displaynames.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<string> LayerUniqueDisplaynames
    {
      get
      {
        var l = new object();
        var res = new HashSet<string>();
        Parallel.ForEach(
          _selection,
          Configuration.ParallelOptions,
          csel =>
          {
            var corpus = GetCorpus(csel.Key);
            if (corpus == null)
              return;

            var items = corpus.LayerUniqueDisplaynames;
            lock (l)
            {
              foreach (var item in items.Where(item => !res.Contains(item)))
                res.Add(item);
            }
          });
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
      Project.ResetAllDocumentMetadata(newMetadata);
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
      return Project.SetDocumentLayerValueMask(documentGuid, layerGuid, sentenceIndex, wordIndex, layerValue);
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
      return Project.SetDocumentLayerValueMask(documentGuid, layerDisplayname, sentenceIndex, wordIndex, layerValue);
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
      Project.SetDocumentMetadata(documentGuid, metadata);
    }

    /// <summary>
    ///   Erstellt eine neue Dokument-Metadaten-Angabe die für alle Dokumente im Korpus gilt
    /// </summary>
    /// <param name="metadataKey">Schlüssel unter dem die Metadaten abegespichert sind</param>
    /// <param name="type">Typ für die neue Metaangabe</param>
    public void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      Project.SetNewDocumentMetadata(metadataKey, type);
    }

    /// <summary>
    ///   Interne Spezialfunktion die eine bereits definierte Auswahl in eine Selection umwandelt.
    /// </summary>
    /// <param name="project">Projekt</param>
    /// <param name="definition">Definierte Auswahl</param>
    /// <param name="displayname">Anzeigename der anstelle des automatisch generierten verwendet wird</param>
    /// <param name="queriesForReproduction">Abfragen, die zur Generierung der Selection notwendig sind.</param>
    /// <returns>Seletion.</returns>
    public static Selection Create(
      Project project,
      Dictionary<Guid, HashSet<Guid>> definition,
      string displayname,
      Selection parent,
      IEnumerable<AbstractFilterQuery> queriesForReproduction = null)
    {
      var date = DateTime.Now;
      var res = new Selection
      {
        _guid = Guid.NewGuid(),
        _selection = definition,
        Project = project,
        Displayname = displayname ?? $"Auswahl ({date.ToString(Resources.DateTimeFormat_Long)})",
        Queries = queriesForReproduction?.ToArray()
      };

      res.Metadata.Add(Resources.Created, date);
      res.Metadata.Add(Resources.Label, res.Displayname);

      parent?._subSelections.Add(res);

      return res;
    }

    public Selection Create(IEnumerable<Guid> guids, string displayname)
      => Create(Project, DocumentGuidsToSelectionDictionary(guids), displayname, this);

    private Dictionary<Guid, HashSet<Guid>> DocumentGuidsToSelectionDictionary(IEnumerable<Guid> guids)
    {
      var dic = new Dictionary<Guid, HashSet<Guid>>();
      foreach (var guid in guids)
      {
        var csel = GetCorpusGuidOfDocument(guid);
        if (csel == Guid.Empty)
          continue;

        if (dic.ContainsKey(csel))
          dic[csel].Add(guid);
        else
          dic.Add(csel, new HashSet<Guid> { guid });
      }

      return dic;
    }

    public Selection Create(Dictionary<Guid, HashSet<Guid>> definition, string displayName)
    {
      return Create(Project, definition, displayName, this);
    }

    /// <summary>
    ///   Erzeugt eine neue Unterauswahl.
    /// </summary>
    /// <param name="queries">Queries</param>
    /// <param name="displayName">Überschreibt den automatisch generierten Anzeigenamen</param>
    /// <returns></returns>
    public Selection Create(IEnumerable<AbstractFilterQuery> queries, string displayName)
    {
      if (queries == null)
        return null;

      var q = queries.ToArray();
      return Create(Project, QueryFilter.SearchOnDocumentLevel(this, q), displayName, this, q);
    }

    /// <summary>
    ///   The create block.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="T" />.
    /// </returns>
    public T CreateBlock<T>()
      where T : AbstractBlock
    {
      return Configuration.Cache.CreateBlock(this, typeof(T)) as T;
    }

    public Selection CreateTemporary(Dictionary<Guid, HashSet<Guid>> definition)
    {
      return new Selection
      {
        _guid = Guid.NewGuid(),
        _selection = definition,
        Displayname = Resources.TemporarySelection,
        Project = Project
      };
    }

    public Selection CreateTemporary(IEnumerable<Guid> definition)
      => CreateTemporary(DocumentGuidsToSelectionDictionary(definition));

    public Selection CreateTemporary(IEnumerable<AbstractFilterQuery> queries)
    {
      if (queries == null)
        return null;

      var q = queries.ToArray();
      var res = CreateTemporary(QueryFilter.SearchOnDocumentLevel(this, q));
      res.Queries = q;

      return res;
    }

    public Dictionary<Guid, int[]> GetSelectedSentences()
    {
      if (Queries == null)
        return null;

      var loc = new object();
      var res = new Dictionary<Guid, int[]>();
      Parallel.ForEach(this, csel =>
      {
        var corpus = GetCorpus(csel.Key);
        if (corpus == null)
          return;

        Parallel.ForEach(csel.Value, dsel =>
        {
          var sentences = Queries.SelectMany(query => query.GetSentenceIndices(corpus, dsel)).ToArray();
          if (sentences.Length == 0)
            return;

          lock (loc)
            if (res.ContainsKey(dsel))
            {
              var hs = new HashSet<int>(res[dsel]);
              foreach (var sentence in sentences)
                hs.Add(sentence);

              res[dsel] = hs.ToArray();
            }
            else
              res.Add(dsel, sentences);
        });
      });

      return res;
    }

    public Dictionary<Guid, object> GetCorporaMetaData(string metadataKey)
    {
      return _selection.ToDictionary(c => c.Key, c => GetCorpus(c.Key).GetCorpusMetadata(metadataKey));
    }

    public Dictionary<Guid, T> GetCorporaMetaData<T>(string metadataKey)
    {
      var dictionary = new Dictionary<Guid, T>();
      foreach (var pair in _selection)
      {
        var data = GetCorpus(pair.Key).GetCorpusMetadata(metadataKey);
        T value;
        try
        {
          value = (T)data;
        }
        catch
        {
          value = default(T);
        }

        dictionary.Add(pair.Key, value);
      }

      return dictionary;
    }

    public Dictionary<Guid, IEnumerable<KeyValuePair<string, object>>> GetCorporaMetaData()
    {
      return _selection.ToDictionary(c => c.Key, c => GetCorpus(c.Key).GetCorpusMetadata());
    }

    public IEnumerable<KeyValuePair<string, object>> GetCorpusMetaData(Guid corpusGuid)
    {
      return _selection.ContainsKey(corpusGuid) ? GetCorpus(corpusGuid).GetCorpusMetadata() : null;
    }

    public Guid GetDocumentGuid(int index)
    {
      return _selection.SelectMany(c => c.Value).ToArray()[index];
    }

    public Dictionary<string, Type> GetDocumentMetadataPrototypeOnlyPropertiesAndTypes()
    {
      var input = GetDocumentMetadataPrototype();
      var res = new Dictionary<string, Type>();

      foreach (var p in input)
      {
        var temp = new Dictionary<Type, int>();

        foreach (var o in p.Value)
        {
          var t = o.GetType();
          if (temp.ContainsKey(t))
            temp[t]++;
          else
            temp.Add(t, 1);
        }

        res.Add(p.Key, temp.OrderByDescending(x => x.Value).First().Key);
      }

      return res;
    }

    public Project GetParentProject()
    {
      return _project;
    }

    /// <summary>
    ///   Virtualisiert
    /// </summary>
    /// <param name="corpus"></param>
    /// <param name="documentGuid"></param>
    /// <param name="sentences"></param>
    /// <returns></returns>
    public int[][] HydraOptimization(AbstractCorpusAdapter corpus, Guid documentGuid, int[][] sentences)
    {
      if (Queries == null ||
          Queries.Length == 0)
        return sentences;

      var indices = new HashSet<int>();
      foreach (
        var i in Queries.Select(query => query.GetSentenceIndices(corpus, documentGuid)).SelectMany(temp => temp))
        indices.Add(i);

      return sentences.Where((t, i) => indices.Contains(i)).ToArray();
    }

    public void RemoveSelection(Selection selection)
    {
      _subSelections.Remove(selection);
    }

    /// <summary>
    ///   Verändert die Auswahl.
    ///   Achtung: Dabei werden alle Blöcke und Unterselektionen gelöscht.
    /// </summary>
    /// <param name="queries">Queries</param>
    public void Reselect(IEnumerable<AbstractFilterQuery> queries)
    {
      _subSelections.Clear();

      var temp = Create(queries, Displayname);
      _selection = temp._selection;
    }

    public Dictionary<Guid, HashSet<Guid>> ToDictionary()
    {
      var res = new Dictionary<Guid, HashSet<Guid>>();
      foreach (var csel in _selection)
      {
        var hs = new HashSet<Guid>();
        foreach (var dsel in csel.Value)
          hs.Add(dsel);
        res.Add(csel.Key, hs);
      }

      return res;
    }

    /// <summary>
    ///   The remove.
    /// </summary>
    /// <param name="corpusGuid">
    ///   The corpus guid.
    /// </param>
    internal void Remove(Guid corpusGuid)
    {
      _selection.Remove(corpusGuid);
    }

    /// <summary>
    ///   The remove.
    /// </summary>
    /// <param name="corpusGuid">
    ///   The corpus guid.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    internal void Remove(Guid corpusGuid, Guid documentGuid)
    {
      _selection[corpusGuid].Remove(documentGuid);
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      _selection = _selectionSerialized?.ToDictionary(x => x.Key, x => x.Value)
                   ?? new Dictionary<Guid, HashSet<Guid>>();
      _selectionSerialized = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _selectionSerialized = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      _selectionSerialized = _selection?.ToArray();
    }

    /// <summary>
    ///   The proxy request dictionary.
    /// </summary>
    /// <param name="func">
    ///   The func.
    /// </param>
    /// <typeparam name="TK">
    /// </typeparam>
    /// <typeparam name="TV">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    private IEnumerable<KeyValuePair<TK, TV>> ProxyRequestDictionary<TK, TV>(
      ProxyRequestDictionaryDelegate<TK, TV> func)
    {
      var res = new ConcurrentDictionary<TK, TV>();
      Parallel.ForEach(
        _selection,
        Configuration.ParallelOptions,
        csel =>
        {
          var corpus = GetCorpus(csel.Key);
          if (corpus == null)
            return;

          var items = func(corpus);
          foreach (var item in items)
            res.TryAdd(item.Key, item.Value);
        });
      return res;
    }

    /// <summary>
    ///   The proxy request list.
    /// </summary>
    /// <param name="func">
    ///   The func.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    private IEnumerable<T> ProxyRequestList<T>(ProxyRequestListDelegate<T> func)
    {
      var l = new object();
      var res = new List<T>();
      Parallel.ForEach(
        _selection,
        Configuration.ParallelOptions,
        csel =>
        {
          var corpus = GetCorpus(csel.Key);
          if (corpus == null)
            return;

          var items = func(corpus);
          lock (l)
          {
            res.AddRange(items);
          }
        });
      return res;
    }

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
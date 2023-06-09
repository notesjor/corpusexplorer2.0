using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;

namespace CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract
{
  public abstract class AbstractLayerAdapter : CeObject
  {
    /// <summary>
    ///   Anzahl der enthaltenen Dokumente
    /// </summary>
    public abstract int CountDocuments { get; }

    /// <summary>
    ///   Anzahl der enthaltenen Werte
    /// </summary>
    public abstract int CountValues { get; }

    /// <summary>
    ///   Auflistung aller Dokument-GUIDs
    /// </summary>
    public abstract IEnumerable<Guid> DocumentGuids { get; }

    /// <summary>
    ///   Gibt die entsprechende Wertbeschreibung zur�ck
    /// </summary>
    /// <param name="index">
    ///   Index
    /// </param>
    /// <returns>
    ///   Wertbeschreibung
    /// </returns>
    public abstract string this[int index] { get; }

    /// <summary>
    ///   Gibt den Index zur Wertbeschreibung zur�ck
    /// </summary>
    /// <param name="index">
    ///   Wertbeschreibung
    /// </param>
    /// <returns>
    ///   Index
    /// </returns>
    public abstract int this[string index] { get; }

    /// <summary>
    ///   Gibt die Layerrohdaten des Dokuments zur�ck
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Rohdaten (Indexbasiert)
    /// </returns>
    public abstract int[][] this[Guid guid] { get; set; }

    /// <summary>
    ///   Auflistung aller Werte des Layers
    /// </summary>
    public abstract IEnumerable<string> Values { get; }

    /// <summary>
    ///   Enth�lt der Layer informationen zum gesuchten Dokument
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Ja/Nein?
    /// </returns>
    public abstract bool ContainsDocument(Guid guid);

    /// <summary>
    ///   Konvertiert ein Dokument in ein ReadableDocument.
    ///   ACHTUNG: Stellen Sie sicher, dass doc aus diesem Layer stammt.
    /// </summary>
    /// <param name="doc">Dokument</param>
    /// <returns></returns>
    public IEnumerable<IEnumerable<string>> ConvertToReadableDocument(int[][] doc)
    {
      return doc.Select(s => s.Select(w => this[w]));
    }

    /// <summary>
    ///   Erstellt eine Kopie dieses Layers. Der neue Layer enth�lt exakt die gleichen Werte, wie der Ursprungslayer.
    ///   Lediglich der GUID und die Metadaten werden verworfen.
    /// </summary>
    /// <returns>Kopie des Layers</returns>
    public abstract AbstractLayerAdapter Copy();

    /// <summary>
    ///   Erstellt eine Kopie dieses Layers.
    ///   Der neue Layer enth�lt nur das angebene Dokument.
    ///   Der neue Layer enth�lt exakt die gleichen Werte, wie der Ursprungslayer.
    ///   Lediglich der GUID und die Metadaten werden verworfen.
    ///   HINWEIS: Diese Funktion sollte NUR zu manuellen Annotation verwendet werden.
    /// </summary>
    /// <returns>Kopie des Layers</returns>
    public abstract AbstractLayerAdapter Copy(Guid documentGuid);

    public abstract Dictionary<Guid, int[][]> GetDocumentDictionary();

    public abstract IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue);

    /// <summary>
    ///   The get readable document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public abstract IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid);

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
    public abstract IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(
      Guid documentGuid,
      int start,
      int stop);

    /// <summary>
    ///   Gibt alle Indizes zur�ck, die auf den RegEx-Ausdruck passen
    /// </summary>
    /// <param name="regEx">RegEx-Ausdruck</param>
    /// <returns></returns>
    public IEnumerable<int> IndicesByRegex(string regEx)
    {
      return ValuesToIndices(ValuesByRegex(regEx));
    }

    /// <summary>
    ///   Gibt alle Indizes zur�ck, die auf die RegEx-Ausdr�cke passen
    /// </summary>
    /// <param name="regExs">RegEx-Ausdruck</param>
    /// <returns></returns>
    public IEnumerable<int> IndicesByRegex(IEnumerable<string> regExs)
    {
      return ValuesToIndices(ValuesByRegex(regExs));
    }

    public abstract Dictionary<string, int> ReciveRawLayerDictionary();

    public abstract Dictionary<int, string> ReciveRawReverseLayerDictionary();

    public abstract void ResetRawLayerDictionary(Dictionary<string, int> dictionary);

    public abstract void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse);

    public abstract void RefreshDictionaries();

    /// <summary>
    ///   Gibt die Frequenz eines Token im gew�hlten Dokument zur�ck.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments - muss im Layer enthalten sein.</param>
    /// <param name="token">Token nach dem gesucht werden soll.</param>
    /// <returns>Frequenz des Token im Dokument</returns>
    public int RequestDocumentSingleFrequency(Guid documentGuid, string token)
    {
      var index = this[token];
      if (index == -1)
        return 0;

      var doc = this[documentGuid];

      return doc.SelectMany(s => s).Count(w => w == index);
    }

    public abstract bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value);

    /// <summary>
    ///   �ndert sehr schnell alle annotierten Daten eines bestimmten Dokuments mithilfe eines StreamDokuments.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="streamDocument">
    ///   Stream-Dokument muss exakt den Ausma�en des mittels GUID referenziertem Dokuments
    ///   entsprechen.
    /// </param>
    /// <returns>Erfolgreich?</returns>
    public abstract bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument);

    public abstract Concept ToConcept(IEnumerable<string> ignoreValues = null);

    /// <summary>
    ///   Erlaubt es, einen bestehenden Layer in einen LayerState zur�ck zu verwandeln.
    /// </summary>
    /// <param name="newDisplayname">Displayname des neuen LayerStates</param>
    /// <param name="valueIndex">Index des Layers</param>
    /// <param name="clearDictionary">Wenn true, wird das Dictionary des Layers nicht kopiert.</param>
    /// <param name="clearDocument">Wenn true, wird das Dokument mit S�tzen/Token angelegt, die Token werden aber auf 0 gesetzt</param>
    /// <param name="noDocuments">Noch restriktiver als clearDocument - wird dieser Wert auf <see langword="true"/>gesetzt, werden alle Dokumente verworfen.</param>
    /// <returns></returns>
    public LayerValueState ToLayerState(string newDisplayname = null, int valueIndex = 0, bool clearDictionary = false, bool clearDocument = false, bool noDocuments = false)
    {
      return new LayerValueState(newDisplayname ?? Displayname, valueIndex)
      {
        Documents = noDocuments   ? new Dictionary<Guid, int[][]>() :
                    clearDocument ? GetDocumentDictionary()
                                     .ToDictionary(x => x.Key,
                                                   x => x.Value.Select(y => y.Select(z => 0).ToArray()).ToArray()) :
                                    GetDocumentDictionary(),
        Cache = clearDictionary
                  ? new Dictionary<string, int>()
                  : GetValueDictionary()
                   .ReciveRawIndexToValue()
                   .ToDictionary(x => x.Value, x => x.Key)
      };
    }

    /// <summary>
    ///   F�gt dem Layer einen neuen Wert hinzu
    /// </summary>
    /// <param name="value">
    ///   neuer Wert
    /// </param>
    public abstract void ValueAdd(string value);

    /// <summary>
    ///   F�gt dem Layer eine ganze Auflistung von Werten hinzu
    /// </summary>
    /// <param name="values">
    ///   Auflistung von Werten
    /// </param>
    public void ValueAddRange(IEnumerable<string> values)
    {
      foreach (var value in values)
        ValueAdd(value);
    }

    /// <summary>
    ///   �ndert den die Wertbezeichnung von Layerdaten.
    /// </summary>
    /// <param name="oldValue">
    ///   Alter Wert
    /// </param>
    /// <param name="newValue">
    ///   Neuer Wert
    /// </param>
    public abstract void ValueChange(string oldValue, string newValue);

    /// <summary>
    ///   Entfernt einen Layerwert
    /// </summary>
    /// <param name="removeValue">
    ///   Zu entfernender Wert
    /// </param>
    public abstract void ValueRemove(string removeValue);

    /// <summary>
    ///   Gibt alle Werte zur�ck, die auf die RegEx-Ausdr�cke passen
    /// </summary>
    /// <param name="regExs">RegEx-Ausdruck</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    public IEnumerable<string> ValuesByRegex(IEnumerable<string> regExs)
    {
      var res = new HashSet<string>();
      var @lock = new object();

      Parallel.ForEach(
                       regExs,
                       Configuration.ParallelOptions,
                       x =>
                       {
                         var values = ValuesByRegex(x);
                         lock (@lock)
                         {
                           foreach (var v in values)
                             res.Add(v);
                         }
                       });

      return res;
    }

    /// <summary>
    ///   Filtert die Werte (Layer.Values) und zeigt nur diejenigen an, die im gew�hlten Dokument vorhanden sind.
    /// </summary>
    /// <param name="documentGuid">Dokument GUID des Werte angezeigt werden sollen.</param>
    /// <returns>Werte die f�r das Dokument relevant sind.</returns>
    public HashSet<string> ValuesOfDocument(Guid documentGuid)
    {
      return ValuesOfDocument(this[documentGuid]);
    }

    /// <summary>
    /// Gibt die Anzahl der Token pro Satz f�r ein Dokument zur�ck
    /// </summary>
    /// <param name="documentGuid">Dokument GUID</param>
    /// <returns>Anzahl S�tze / Anzahl Token</returns>
    public IEnumerable<int> DocumentSize(Guid documentGuid)
    {
      return this[documentGuid].Select(x => x.Length);
    }

    /// <summary>
    ///   Filtert die Werte (Layer.Values) und zeigt nur diejenigen an, die im gew�hlten Dokument vorhanden sind.
    /// </summary>
    /// <param name="document">Dokument des Werte angezeigt werden sollen.</param>
    /// <returns>Werte die f�r das Dokument relevant sind.</returns>
    public HashSet<string> ValuesOfDocument(int[][] document)
    {
      var res = new HashSet<string>();
      foreach (var s in document)
        foreach (var w in s)
          res.Add(this[w]);
      return res;
    }

    /// <summary>
    ///   Wandelt eine Auflistung von Werten in die entsprechenden Indices um.
    ///   Enth�lt KEINE -1-Indices
    /// </summary>
    /// <param name="values">
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<int> ValuesToIndices(IEnumerable<string> values)
    {
      var res = new List<int>();
      if (values == null)
        return res;

      foreach (var value in values)
        try
        {
          var v = this[value];
          if (v > -1)
            res.Add(v);
        }
        catch
        {
          // ignore
        }

      return res;
    }

    protected abstract CeDictionary GetValueDictionary();

    /// <summary>
    ///   Gibt alle Werte zur�ck, die auf den RegEx-Ausdruck passen
    /// </summary>
    /// <param name="regEx">RegEx-Ausdruck</param>
    /// <returns>IEnumerable&lt;System.String&gt;.</returns>
    protected abstract IEnumerable<string> ValuesByRegex(string regEx);
  }
}
#region usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

#endregion

namespace CorpusExplorer.Sdk.Data.Model
{
  /// <summary>
  ///   Class <see cref="Layer" />
  /// </summary>
  [Serializable]
  public sealed class Layer : IEnumerable<KeyValuePair<string, int[][]>>, ICloneable
  {
    /// <summary>
    ///   The <see cref="CorpusExplorer.Sdk.Data.Model.Layer._daten" />
    /// </summary>
    internal List<string> _daten = new List<string>();

    /// <summary>
    ///   The <see cref="CorpusExplorer.Sdk.Data.Model.Layer._dokumente" />
    /// </summary>
    internal Dictionary<string, int[][]> _dokumente = new Dictionary<string, int[][]>();

    [OptionalField] private string _password;

    /// <summary>
    ///   Gets the daten.
    /// </summary>
    /// <value>
    ///   The daten.
    /// </value>
    public string[] Daten
    {
      get { return _daten.AsParallel().ToArray(); }
    }

    /// <summary>
    ///   <para>
    ///     Gibt die Anzahl der
    ///     <see cref="CorpusExplorer.Sdk.Data.Model.Layer.Daten" /> in diesem
    ///     <see cref="Layer" />
    ///   </para>
    ///   <para>zurück</para>
    /// </summary>
    /// <value>
    ///   The daten anzahl.
    /// </value>
    public int DatenAnzahl
    {
      get { return _daten.Count; }
    }

    /// <summary>
    ///   Gibt die Anazhl der Verfügbaren Dokumente in diesem layer zurück.
    /// </summary>
    /// <value>
    ///   The dokumenten anzahl.
    /// </value>
    public int DokumentenAnzahl
    {
      get { return _dokumente.Count(); }
    }

    /// <summary>
    ///   Name des Layers
    /// </summary>
    /// <value>
    ///   The name of the layer.
    /// </value>
    public string LayerName { get; set; }

    /// <summary>
    ///   Gibt die Anzahl der Sätze zurück
    /// </summary>
    /// <value>
    ///   The satz anazahl.
    /// </value>
    public int SatzAnazahl
    {
      get { return _dokumente.SelectMany(doc => doc.Value).Count(); }
    }

    /// <summary>
    ///   Gibt die Gesamtzahl der Wörter zurück. Um das einmalige Vorkommen eines
    ///   Wortes zu ermitteln rufen Sie bitte
    ///   <see cref="CorpusExplorer.Sdk.Data.Model.Layer.DatenAnzahl" /> ab.
    /// </summary>
    /// <value>
    ///   The wörter gesamtzahl.
    /// </value>
    public int WörterGesamtzahl
    {
      get { return _dokumente.SelectMany(doc => doc.Value).Sum(satz => satz.Length); }
    }

    /// <summary>
    ///   Passwort mit dem der Layer geschützt ist.
    /// </summary>
    public string Password
    {
      get { return _password; }
      set { _password = value; }
    }

    /// <summary>
    ///   with the specified dokumentName.
    /// </summary>
    /// <param name="dokumentName">Name of the dokument.</param>
    /// <returns>
    ///   System.Nullable{KeyValuePair{System.StringSystem.Int32[][]}}.
    /// </returns>
    public int[][] this[string dokumentName]
    {
      get
      {
        return string.IsNullOrEmpty(dokumentName) || (!_dokumente.ContainsKey(dokumentName))
          ? null
          : _dokumente[dokumentName];
      }
    }

    /// <summary>
    ///   Gibt die <see cref="CorpusExplorer.Sdk.Data.Model.Layer.Daten" /> des
    ///   layers zurück
    /// </summary>
    /// <param name="wort">The wort.</param>
    /// <returns>
    ///   Datenwort
    /// </returns>
    public string this[int wort]
    {
      get { return wort > -1 && wort < _daten.Count ? _daten[wort] : null; }
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz
    ///   darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public object Clone()
    {
      return Create(LayerName, _daten.AsParallel().ToArray().ToList(),
        _dokumente.AsParallel().ToList().ToDictionary(x => x.Key, x => x.Value));
    }

    /// <summary>
    ///   Gets the enumerator.
    /// </summary>
    /// <returns>
    ///   IEnumerator{KeyValuePair{System.StringSystem.Int32[][]}}.
    /// </returns>
    public IEnumerator<KeyValuePair<string, int[][]>> GetEnumerator()
    {
      return _dokumente.GetEnumerator();
    }

    /// <summary>
    ///   Gibt einen Enumerator zurück, der eine Auflistung durchläuft.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="IEnumerator" /> -Objekt, das zum Durchlaufen der
    ///   Auflistung verwendet werden kann.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return _dokumente.GetEnumerator();
    }

    /// <summary>
    ///   Erstellt einen neuen <see cref="Layer" /> und speichert diesen in den
    ///   entsprechenden Dateien.
    /// </summary>
    /// <param name="layerName">Name des Layers</param>
    /// <param name="daten">
    ///   <see cref="CorpusExplorer.Sdk.Data.Model.Layer.Daten" />
    /// </param>
    /// <param name="dokumente">Dokumente</param>
    /// <returns>
    ///   Neuer <see cref="Layer" />
    /// </returns>
    public static Layer Create(string layerName, List<string> daten, Dictionary<string, int[][]> dokumente)
    {
      if (string.IsNullOrEmpty(layerName) || dokumente == null || daten == null)
        return null;

      return new Layer {_daten = daten, _dokumente = dokumente, LayerName = layerName};
    }

    /// <summary>
    ///   Hängt neue <see cref="CorpusExplorer.Sdk.Data.Model.Layer.Daten" /> an
    ///   einen alten <see cref="Layer" /> an.
    /// </summary>
    /// <param name="a">A.</param>
    /// <param name="b">The b.</param>
    /// <returns>
    ///   Neue <see cref="Layer" />
    /// </returns>
    public static Layer Merge(Layer a, Layer b)
    {
      if (a == null || b == null)
        return null;

      // Daten Merge
      var daten = a._daten.ToList();
      var alteDatenIndex = new List<string>(daten.ToArray());

      foreach (var x in b._daten.Where(x => !daten.Contains(x)))
        daten.Add(x);

      daten.Sort();

      // Dokumente Merge
      var dokumente = a._dokumente.AsParallel().ToDictionary(pair => pair.Key, pair => pair.Value);
      var alteDokuemteIndex = a._dokumente.Select(pair => pair.Key).ToList();

      foreach (var x in b._dokumente.Where(x => !dokumente.ContainsKey(x.Key)))
        dokumente.Add(x.Key, x.Value);

      var tdok = dokumente.AsParallel().ToArray();

      // Defragmentierung
      foreach (var doc in tdok)
        dokumente[doc.Key] = Refactor(doc.Value, ref daten,
          alteDokuemteIndex.Contains(doc.Key) ? alteDatenIndex : b._daten);

      return new Layer {_daten = daten, _dokumente = dokumente, LayerName = a.LayerName};
    }

    /// <summary>
    ///   Gibt die Anzahl aller Sätze in diesem <see cref="Layer" /> zurück
    /// </summary>
    /// <param name="documentName">
    ///   Wenn übergeben, dann wird die Anzahl aller Sätze in diesem Dokument
    ///   zurückgebene.
    /// </param>
    /// <returns>
    ///   System.Int32.
    /// </returns>
    public int AnzahlSätze(string documentName = null)
    {
      return string.IsNullOrEmpty(documentName)
        ? _dokumente.SelectMany(doc => doc.Value).Count()
        : _dokumente.Where(doc => doc.Key == documentName).SelectMany(pair => pair.Value).Count();
    }

    /// <summary>
    ///   Enthält dieser <see cref="Layer" /> Informationen zum angegebenen
    ///   Dokument?
    /// </summary>
    /// <param name="dokumentName">Name of the dokument.</param>
    /// <returns>
    ///   Antwort
    /// </returns>
    public bool Contains(string dokumentName)
    {
      return _dokumente.ContainsKey(dokumentName);
    }

    /// <summary>
    ///   Gibt ein lesbares Dokument zurück
    /// </summary>
    /// <param name="dokumentName">
    ///   Name des Dokuments welches ausgegeben wird
    /// </param>
    /// <returns>
    ///   Dokumentenlayer
    /// </returns>
    public string[][] DokumentAusgabenWort(string dokumentName)
    {
      var doc = _dokumente[dokumentName];
      return doc == null
        ? null
        : doc.AsParallel()
          .ToArray()
          .Select(satz => satz.Select(wort => this[wort]).ToArray())
          .ToArray();
    }

    /// <summary>
    ///   Gibt ein lesbares Dokument zurück
    /// </summary>
    /// <param name="dokumentName">
    ///   Name des Dokuments welches ausgegeben wird
    /// </param>
    /// <returns>
    ///   Dokumentenlayer
    /// </returns>
    public IEnumerable<string> DokumentAusgabenSatz(string dokumentName)
    {
      var doc = _dokumente[dokumentName];
      if (doc == null)
        return null;

      var res = new List<string>();
      foreach (var satz in doc)
      {
        var stb = new StringBuilder();
        foreach (var x in satz.Select(w => this[w]))
        {
          stb.Append(x);
          if (x.Length > 1)
            stb.Append(" ");
        }
        res.Add(stb.ToString());
      }

      return res;
    }

    /// <summary>
    ///   Gibt die Größe eines spezifischen Dokuments zurück
    /// </summary>
    /// <param name="dokumentName">Name des Dokuments</param>
    /// <returns>
    ///   Größe (inkl. Satzzeichen [ohne Leerzeichen])
    /// </returns>
    public int DokumentGröße(string dokumentName)
    {
      var doc = this[dokumentName];
      return doc == null ? 0 : doc.Sum(satz => satz.Length);
    }

    /// <summary>
    ///   Gibt den Index der <paramref name="daten" /> zurück
    /// </summary>
    /// <param name="daten">Beispieldaten</param>
    /// <returns>
    ///   Index der Exaple-Daten
    /// </returns>
    public int IndexOf(string daten)
    {
      return _daten.IndexOf(daten);
    }

    /// <summary>
    ///   Lösche das Dokument aus dem Layer. Diese Aktion ist nur Temporär
    /// </summary>
    /// <param name="dokumentName">Name des zu löschenden Dokuments</param>
    public void TemporaryDeleteDokument(string dokumentName)
    {
      if (_dokumente.ContainsKey(dokumentName))
        _dokumente.Remove(dokumentName);
    }

    /// <summary>
    ///   Returns a <see cref="String" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///   A <see cref="String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return "Layer: " + LayerName;
    }

    /// <summary>
    ///   Refactors the specified doc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="doc">The doc.</param>
    /// <param name="daten">The daten.</param>
    /// <param name="indexTabelle">The index tabelle.</param>
    /// <returns>
    ///   System.Int32[][][].
    /// </returns>
    private static int[][] Refactor<T>(int[][] doc, ref List<T> daten, IList<T> indexTabelle)
    {
      foreach (var satz in doc)
        for (var i = 0; i < satz.Length; i++)
          satz[i] = daten.IndexOf(indexTabelle[satz[i]]);
      return doc;
    }
  }
}
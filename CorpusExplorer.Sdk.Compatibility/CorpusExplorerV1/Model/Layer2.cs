#region usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CorpusExplorer.Sdk.Data.Helper;

#endregion

namespace CorpusExplorer.Sdk.Data.Model
{
  /// <summary>
  ///   Class <see cref="Layer" />
  /// </summary>
  [Serializable]
  public sealed class Layer2 : IEnumerable<KeyValuePair<string, int[][]>>, ICloneable
  {
    /// <summary>
    ///   The <see cref="CorpusExplorer.Sdk.Data.Model.Layer._daten" />
    /// </summary>
    internal ListOptimized<string> _daten = new ListOptimized<string>();

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
    ///   <para>zur�ck</para>
    /// </summary>
    /// <value>
    ///   The daten anzahl.
    /// </value>
    public int DatenAnzahl
    {
      get { return _daten.Count; }
    }

    /// <summary>
    ///   Gibt die Anazhl der Verf�gbaren Dokumente in diesem layer zur�ck.
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
    ///   Gibt die Anzahl der S�tze zur�ck
    /// </summary>
    /// <value>
    ///   The satz anazahl.
    /// </value>
    public int SatzAnazahl
    {
      get { return _dokumente.SelectMany(doc => doc.Value).Count(); }
    }

    /// <summary>
    ///   Gibt die Gesamtzahl der W�rter zur�ck. Um das einmalige Vorkommen eines
    ///   Wortes zu ermitteln rufen Sie bitte
    ///   <see cref="CorpusExplorer.Sdk.Data.Model.Layer.DatenAnzahl" /> ab.
    /// </summary>
    /// <value>
    ///   The w�rter gesamtzahl.
    /// </value>
    public int W�rterGesamtzahl
    {
      get { return _dokumente.SelectMany(doc => doc.Value).Sum(satz => satz.Length); }
    }

    /// <summary>
    ///   Passwort mit dem der Layer gesch�tzt ist.
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
    ///   layers zur�ck
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
      return Create(LayerName, _daten.AsParallel().ToArray().ToListOptimized(),
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
    ///   Gibt einen Enumerator zur�ck, der eine Auflistung durchl�uft.
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
    public static Layer2 Create(string layerName, ListOptimized<string> daten, Dictionary<string, int[][]> dokumente)
    {
      if (string.IsNullOrEmpty(layerName) || dokumente == null || daten == null)
        return null;

      return new Layer2 { _daten = daten, _dokumente = dokumente, LayerName = layerName };
    }

    /// <summary>
    ///   H�ngt neue <see cref="CorpusExplorer.Sdk.Data.Model.Layer.Daten" /> an
    ///   einen alten <see cref="Layer" /> an.
    /// </summary>
    /// <param name="a">A.</param>
    /// <param name="b">The b.</param>
    /// <returns>
    ///   Neue <see cref="Layer" />
    /// </returns>
    public static Layer2 Merge(Layer2 a, Layer2 b)
    {
      if (a == null || b == null)
        return null;
      if (a.LayerName != b.LayerName)
        throw new Exception("Es k�nnen nur Layer mit identischen Namen vermischt werden!");

      var listA = a._daten;
      var listB = b._daten;

      var listR = new ListOptimized<string>(listA, listB);

      var transA = listR.GetTranslationMatrix(listA);
      var transB = listR.GetTranslationMatrix(listB);

      var dicR = new Dictionary<string, int[][]>();

      Merga_FixIndex(a, transA, dicR);
      Merga_FixIndex(b, transB, dicR);

      return Create(a.LayerName, listR, dicR);
    }

    private static void Merga_FixIndex(Layer2 a, Dictionary<int, int> transA, Dictionary<string, int[][]> dicR)
    {
      foreach (var doc in a._dokumente)
      {
        var array = doc.Value.Clone() as int[][];
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < array.Length; i++)
          for (var j = 0; j < array[i].Length; j++)
            array[i][j] = transA[array[i][j]];

        dicR.Add(doc.Key, array);
      }
    }

    /// <summary>
    ///   Gibt die Anzahl aller S�tze in diesem <see cref="Layer" /> zur�ck
    /// </summary>
    /// <param name="documentName">
    ///   Wenn �bergeben, dann wird die Anzahl aller S�tze in diesem Dokument
    ///   zur�ckgebene.
    /// </param>
    /// <returns>
    ///   System.Int32.
    /// </returns>
    public int AnzahlS�tze(string documentName = null)
    {
      if (string.IsNullOrEmpty(documentName))
      {
        var res = 0;
        foreach (var doc in _dokumente)
        {
          try
          {
            res += doc.Value.Length;
          }
          catch { }
        }

        return res;
      }
      else
      {
        return this._dokumente.Where(doc => doc.Key == documentName).SelectMany(pair => pair.Value).Count();
      }
    }

    /// <summary>
    ///   Enth�lt dieser <see cref="Layer" /> Informationen zum angegebenen
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
    ///   Gibt ein lesbares Dokument zur�ck
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
    ///   Gibt ein lesbares Dokument zur�ck
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

      var res = new ListOptimized<string>();
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
    ///   Gibt die Gr��e eines spezifischen Dokuments zur�ck
    /// </summary>
    /// <param name="dokumentName">Name des Dokuments</param>
    /// <returns>
    ///   Gr��e (inkl. Satzzeichen [ohne Leerzeichen])
    /// </returns>
    public int DokumentGr��e(string dokumentName)
    {
      var doc = this[dokumentName];
      return doc == null ? 0 : doc.Sum(satz => satz.Length);
    }

    /// <summary>
    ///   Gibt den Index der <paramref name="daten" /> zur�ck
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
    ///   L�sche das Dokument aus dem Layer. Diese Aktion ist nur Tempor�r
    /// </summary>
    /// <param name="dokumentName">Name des zu l�schenden Dokuments</param>
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
  }
}
#region usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Data.Helper;
using CorpusExplorer.Sdk.Data.Model.MetaInformationen;

#endregion

namespace CorpusExplorer.Sdk.Data.Model
{
  using CorpusExplorer.Sdk.Data.Model.Extensions.Layer;

  /// <summary>
  ///   Class <see cref="MultiLayer" />
  /// </summary>
  public class MultiLayer : IEnumerable<Layer2>, ICloneable
  {
    /// <summary>
    ///   Extension die für alle aktuellen Layer gilt.
    ///   Muss per Suchen&Ersetzen im ganzen Projekt ersetzen werden,
    ///   wenn sich diese Endung ändert.
    /// </summary>
    private const string _layerExt = ".layer2";

    /// <summary>
    ///   The _dokument namens liste
    /// </summary>
    protected string[] _dokumentNamensListe;

    [NonSerialized] private string _enteredPassword;

    private List<string> _isSelecedDocument = new List<string>();
    private bool _isSelected;

    /// <summary>
    ///   The <see cref="CorpusExplorer.Sdk.Data.Model.MultiLayer._layers" />
    /// </summary>
    protected List<Layer2> _layers = new List<Layer2>();

    /// <summary>
    ///   The _merged layer
    /// </summary>
    private Dictionary<string, int[][]> _mergedLayer;

    /// <summary>
    ///   The <see cref="CorpusExplorer.Sdk.Data.Model.MultiLayer._path" />
    /// </summary>
    protected internal string _path;

    /// <summary>
    ///   Läd einen neuen Multilayer
    /// </summary>
    /// <param name="korpusName">
    ///   Name des Korpus der als Multilayer verfügbar gemacht werden soll
    /// </param>
    public MultiLayer(string korpusName)
    {
      var tmp = Load(CeEnviroment.GetKorpus(korpusName), korpusName);

      KorpusName = korpusName;
      _path = tmp._path;
      _layers = tmp._layers;

      MetadatenDokumente = tmp.MetadatenDokumente;
      MetadatenKorpus = tmp.MetadatenKorpus;

      LayerUpdate();
    }

    /// <summary>
    ///   Konstruktor für einen leeren Multilayer
    /// </summary>
    internal MultiLayer()
    {
      MetadatenKorpus = new List<AbstrakterMetaEintrag>();
      MetadatenDokumente = new Dictionary<string, List<AbstrakterMetaEintrag>>();
    }

    /// <summary>
    ///   Ist dieser Korpus vollständig/teilweise gewählt?
    /// </summary>
    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        _isSelected = value;

        IsSelecedDocument.Clear();
        if (value)
          IsSelecedDocument.AddRange(DokumentNamensListe);
      }
    }

    public string EnteredPassword
    {
      get { return _enteredPassword; }
      set { _enteredPassword = HashPassword(value); }
    }

    public string Password
    {
      get
      {
        try
        {
          return this["Wort"].Password;
        }
        catch
        {
          return null;
        }
      }
      set
      {
        if (!IsPasswordProtected)
        {
          this["Wort"].Password = HashPassword(value);
          return;
        }
        if (EnteredPassword == Password)
          this["Wort"].Password = HashPassword(value);
      }
    }

    public bool IsPasswordProtected
    {
      get
      {
        if (string.IsNullOrEmpty(Password))
          return false;

        return Password != EnteredPassword;
      }
    }

    /// <summary>
    ///   Liste aller gewählten Dokumente des Korpus
    /// </summary>
    public List<string> IsSelecedDocument
    {
      get { return _isSelecedDocument; }
      set { _isSelecedDocument = value; }
    }

    /// <summary>
    ///   <para>
    ///     Der <see cref="CorpusExplorer.Sdk.Data.Model.MultiLayer.AnalyseLayer" />
    ///   </para>
    ///   <para>
    ///     fasst alle <see cref="Layer" /> des Multilayers zusammen. Key =
    ///     Layername / Value = Alle Dokumente des Layers werden zu einem Dokument
    ///     zusammengefügt.
    ///   </para>
    /// </summary>
    /// <value>
    ///   The analyse layer.
    /// </value>
    public Dictionary<string, int[][]> AnalyseLayer
    {
      get
      {
        if (_mergedLayer != null)
          return _mergedLayer;

        var res = new Dictionary<string, int[][]>();
        var docs = DokumentNamensListe;
        var empty = new int[0];
        empty.Initialize();

        foreach (var layer in _layers)
        {
          var temp = new List<int[]>();

          foreach (var dn in docs)
          {
            var len = MergedLayerDocumentLength(dn);
            if (len == -1)
              continue;

            var doc = layer[dn];
            if (doc == null)
              for (var i = 0; i < len; i++)
                temp.Add(empty);
            else
              temp.AddRange(doc);
          }

          res.Add(layer.LayerName, temp.ToArray());
        }

        _mergedLayer = res;
        return res;
      }
    }

    /// <summary>
    ///   Liste aller verfügbaren Dokumente in allen Layern
    /// </summary>
    /// <value>
    ///   The dokument namens liste.
    /// </value>
    public string[] DokumentNamensListe
    {
      get
      {
        if (_dokumentNamensListe != null && _dokumentNamensListe.Length != 0)
          return _dokumentNamensListe;

        var res = new List<string>();
        foreach (var layer in _layers)
          res.AddRange(from x in layer._dokumente where !res.Contains(x.Key) select x.Key);

        _dokumentNamensListe = res.ToArray();
        return _dokumentNamensListe;
      }
    }

    /// <summary>
    ///   Gets or sets the name of the korpus.
    /// </summary>
    /// <value>
    ///   The name of the korpus.
    /// </value>
    public string KorpusName { get; protected set; }

    /// <summary>
    ///   Metadaten des Korpus
    /// </summary>
    public List<AbstrakterMetaEintrag> MetadatenKorpus { get; set; }

    /// <summary>
    ///   Gibt den Prototyp für alle Dokumentmetadaten zurück
    /// </summary>
    public IEnumerable<AbstrakterMetaEintrag> MetadatenDokumentPrototyp
    {
      get { return MetadatenDokumente.ToArray()[0].Value; }
    }

    /// <summary>
    ///   Metadaten der einzelnen Dokumente
    /// </summary>
    public Dictionary<string, List<AbstrakterMetaEintrag>> MetadatenDokumente { get; set; }

    /// <summary>
    ///   Gets the <see cref="Layer" /> with the specified layer name.
    /// </summary>
    /// <param name="layerName">Name of the layer.</param>
    /// <returns>
    ///   Layer.
    /// </returns>
    public Layer2 this[string layerName]
    {
      get { return _layers.Find(x => x.LayerName == layerName); }
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
      return new MultiLayer {_layers = _layers, _path = _path, KorpusName = KorpusName};
    }

    public object CloneLimmited(IEnumerable<string> documents)
    {
      return new MultiLayer
                  {
                    _layers = _layers.CloneLimmited(documents),
                    _path = _path,
                    KorpusName = KorpusName,
                    _dokumentNamensListe = documents.ToArray()
                  };
    }

    /// <summary>
    ///   Gets the enumerator.
    /// </summary>
    /// <returns>
    ///   IEnumerator{Layer}.
    /// </returns>
    public IEnumerator<Layer2> GetEnumerator()
    {
      return _layers.GetEnumerator();
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
      return _layers.GetEnumerator();
    }

    private string HashPassword(string original)
    {
      return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(original)));
    }

    /// <summary>
    ///   Loads the specified path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="korpusName">Name of the korpus.</param>
    /// <returns>
    ///   MultiLayer.
    /// </returns>
    public static MultiLayer Load(string path, string korpusName)
    {
      var res = new MultiLayer {_path = path, KorpusName = korpusName};
      if (string.IsNullOrEmpty(res.KorpusName)) res.KorpusName = Path.GetFileNameWithoutExtension(res._path);

      var layers = Directory.GetFiles(res._path, "*.layer", SearchOption.TopDirectoryOnly);

      // Konvertiere alte Layer (v1)
      foreach (var file in layers)
      {
        var layer = Serializer.DeserializeCompressed<Layer>(file);
        var newLayer = Layer2.Create(layer.LayerName, new ListOptimized<string>(layer.Daten), layer._dokumente);
        Serializer.SerializeCompressed(newLayer, file + "2");
        File.Delete(file);
      }

      layers = Directory.GetFiles(res._path, "*" + _layerExt, SearchOption.TopDirectoryOnly);
      // Lade neue Layer
      foreach (var layer in layers)
      {
        res._layers.Add(Serializer.DeserializeCompressed<Layer2>(layer));
      }

      var p = Path.Combine(res._path, "metaK.data");
      res.MetadatenKorpus = CleanMetadatenKorpus(File.Exists(p)
        ? Serializer.DeserializeCompressed<List<AbstrakterMetaEintrag>>(p)
        : new List<AbstrakterMetaEintrag>());

      p = Path.Combine(res._path, "metaD.data");
      res.MetadatenDokumente = CleanMetadatenDokumente(File.Exists(p)
        ? Serializer.DeserializeCompressed<Dictionary<string, List<AbstrakterMetaEintrag>>>(p)
        : new Dictionary<string, List<AbstrakterMetaEintrag>>());

      res.LayerUpdate();

      return res;
    }

    private static Dictionary<string, List<AbstrakterMetaEintrag>> CleanMetadatenDokumente(
      Dictionary<string, List<AbstrakterMetaEintrag>> metadaten)
    {
      // ToDo: Sollte nicht beim Programmstart sondern beim anlegen des Korpus ausgeführt werden.
      foreach (var pair in metadaten)
      {
        foreach (var m in pair.Value)
        {
          if (m is MetaEintragText)
            ((MetaEintragText) m).Value =
              ((MetaEintragText) m).Value.Replace("\r", "").Replace("\n", "");
        }
      }
      return metadaten;
    }

    private static List<AbstrakterMetaEintrag> CleanMetadatenKorpus(List<AbstrakterMetaEintrag> metadaten)
    {
      // ToDo: Sollte nicht beim Programmstart sondern beim anlegen des Korpus ausgeführt werden.
      foreach (var m in metadaten)
      {
        if (m is MetaEintragText)
          ((MetaEintragText) m).Value =
            ((MetaEintragText) m).Value.Replace("\r", "").Replace("\n", "");
      }
      return metadaten;
    }

    /// <summary>
    ///   Fügt dem Korpus einen neuen <see cref="Layer" /> hinzu.
    /// </summary>
    /// <param name="layer">
    ///   <see cref="Layer" />
    /// </param>
    /// <param name="saveLayer">Soll das Ergebnis gespeichert werden?</param>
    /// <param name="layerMerge">
    ///   Führt ein Layer-Merge aus, wenn <see langword="true" /> und der
    ///   <see cref="Layer" /> bereits im MulitLayer exsisitert
    /// </param>
    public void Add(Layer2 layer, bool saveLayer = false, bool layerMerge = true)
    {
      var alterLayer = this[layer.LayerName];

      // Wenn ein gleichnamiger Layer exsisitiert, dann:
      // Merge der Layer
      // Lösche alten Layer
      if (alterLayer != null)
      {
        if (layerMerge)
          layer = Layer2.Merge(alterLayer, layer);
        _layers.Remove(alterLayer);
      }

      // Füge neuen Layer ein
      _layers.Add(layer);
      if (saveLayer)
        SaveLayer(layer);
      LayerUpdate();
    }

    /// <summary>
    ///   Fügt einen bestehenden MultiLayer diesem MultiLayer hinzu. Dies kann
    ///   auch ein Dokument sein, das per MultiLayer.DokumentLayer() abgerufen
    ///   wurde.
    /// </summary>
    /// <param name="multiLayer">MultiLayer</param>
    /// <param name="saveLayer">Soll das Ergebnis gespeichert werden?</param>
    public void Add(IEnumerable<Layer2> multiLayer, bool saveLayer = false)
    {
      Parallel.ForEach(multiLayer, layer => Add(layer, saveLayer));
      LayerUpdate();
    }

    /// <summary>
    ///   Importiert einen externen <see cref="Layer" /> in den Korpus
    /// </summary>
    /// <param name="pathToLayerFile">Pfad zum externen *.layer-File</param>
    public void Add(string pathToLayerFile)
    {
      if (string.IsNullOrEmpty(pathToLayerFile) || !pathToLayerFile.EndsWith(_layerExt))
        return;

      var layer = Serializer.DeserializeCompressed<Layer2>(pathToLayerFile);
      if (layer == null)
        return;
      SaveLayer(layer);
    }

    /// <summary>
    ///   Löscht den <see cref="Layer" /> aus dem MultiLayer
    /// </summary>
    /// <param name="layerName">Name des zu löschenden Layers</param>
    public void Remove(string layerName)
    {
      var layer = this[layerName];
      if (layer == null)
        return;

      _layers.Remove(layer);

      var path = Path.Combine(_path, layerName + _layerExt);
      File.Delete(path);

      LayerUpdate();
    }

    /// <summary>
    ///   Speichert den MultiLayer
    /// </summary>
    public void Save()
    {
      foreach (var layer in _layers)
      {
        SaveLayer(layer);
      }

      SaveOnlyMetadata();
    }

    /// <summary>
    ///   Speichert nur die Metadaten des Multilayers
    /// </summary>
    public void SaveOnlyMetadata()
    {
      Serializer.SerializeCompressed(MetadatenKorpus, Path.Combine(_path, "metaK.data"));
      Serializer.SerializeCompressed(MetadatenDokumente, Path.Combine(_path, "metaD.data"));
    }

    /// <summary>
    ///   Speichert einen bestimmten <see cref="Layer" />
    /// </summary>
    /// <param name="layerName">
    ///   Name des <see cref="Layer" />
    /// </param>
    public void SaveOnlyLayer(string layerName)
    {
      var layer = _layers.Find(x => x.LayerName == layerName);
      if (layer == null) return;
      SaveLayer(layer);
    }

    /// <summary>
    ///   Speichert einen bestimmten <see cref="Layer" /> in einer neuen Datei
    /// </summary>
    /// <param name="layerName">Name des Layers</param>
    /// <param name="path">Pfad</param>
    /// <param name="newLayerName">Erstezt den bisherigen Layernamen</param>
    public void SaveOnlyLayerAs(string layerName, string path, string newLayerName = null)
    {
      var layer = _layers.Find(x => x.LayerName == layerName);
      if (layer == null) return;

      layer = (Layer2) layer.Clone();

      if (!string.IsNullOrEmpty(newLayerName))
        layer.LayerName = newLayerName;

      SaveLayer(layer, path);
    }

    /// <summary>
    ///   Returns a <see cref="String" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///   A <see cref="String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return "MultiLayer: " + KorpusName;
    }

    /// <summary>
    ///   Saves the layer.
    /// </summary>
    /// <param name="layer">The layer.</param>
    private void SaveLayer(Layer2 layer)
    {
      SaveLayer(layer, Path.Combine(_path, layer.LayerName + _layerExt));
    }

    /// <summary>
    ///   Saves the layer.
    /// </summary>
    /// <param name="layer">The layer.</param>
    /// <param name="path">The path.</param>
    private void SaveLayer(Layer2 layer, string path)
    {
      Serializer.SerializeCompressed(layer, path);
    }

    /// <summary>
    ///   Layers the update.
    /// </summary>
    private void LayerUpdate()
    {
      _mergedLayer = null;
      _dokumentNamensListe = null;
    }

    /// <summary>
    ///   Mergeds the length of the layer document.
    /// </summary>
    /// <param name="doc">The doc.</param>
    /// <returns>
    ///   System.Int32.
    /// </returns>
    private int MergedLayerDocumentLength(string doc)
    {
      return this["Wort"][doc].Length;
    }
  }
}
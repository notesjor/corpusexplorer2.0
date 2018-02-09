using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer
{
  public class LayerAdapterEchtzeitEngine : AbstractLayerAdapter
  {
    internal EchtzeitLayer _layer;

    private LayerAdapterEchtzeitEngine() { }
    public override string this[int index] => _layer.Dictionary[index];

    public override int this[string index] => _layer.Dictionary[index];

    public override int[][] this[Guid guid]
    {
      get { return guid == _layer.DocumentGuid ? _layer.Document : null; }
      set
      {
        if (guid == _layer.DocumentGuid)
          _layer.Document = value;
      }
    }

    public override int CountDocuments => 1;
    public override int CountValues => _layer.Dictionary.Count;
    public override IEnumerable<Guid> DocumentGuids { get { yield return _layer.Guid; } }

    public override IEnumerable<string> Values => _layer.Dictionary.Values;
    public override bool ContainsDocument(Guid guid) => guid == _layer.DocumentGuid;

    public override AbstractLayerAdapter Copy() => new LayerAdapterEchtzeitEngine
    {
      _layer = new EchtzeitLayer
      {
        Guid = Guid.NewGuid(),
        DocumentGuid = _layer.DocumentGuid,
        Document = (int[][]) _layer.Document.Clone(),
        Displayname = _layer.Displayname,
        Dictionary = _layer.Dictionary.Clone()
      }
    };

    public override AbstractLayerAdapter Copy(Guid documentGuid) => _layer.DocumentGuid == documentGuid ? Copy() : null;

    public static LayerAdapterEchtzeitEngine Create(EchtzeitLayer echtzeitLayer) => new LayerAdapterEchtzeitEngine
    {
      _layer = echtzeitLayer,
      Displayname = echtzeitLayer.Displayname,
      _guid = echtzeitLayer.Guid
    };

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
      => new Dictionary<Guid, int[][]> {{_layer.DocumentGuid, _layer.Document}};

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      if (documentGuid != _layer.DocumentGuid)
        return null;

      var val = _layer.Dictionary[layerValue];

      return _layer.Document.Select(s => s.Select(w => w == val));
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
      =>
      documentGuid != _layer.DocumentGuid
        ? null
        : (from s in _layer.Document where s != null select s.Select(w => this[w]));

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(
      Guid documentGuid,
      int start,
      int stop)
    {
      if (_layer.DocumentGuid != documentGuid)
        return null;

      start = start < 0 ? 0 : start;
      stop = stop >= _layer.Document.Length ? _layer.Document.Length - 1 : stop;
      stop = stop <= start ? start + 1 : stop;

      var res = new List<IEnumerable<string>>();
      for (var i = start; i < stop; i++)
        res.Add(_layer.Document[i].Select(w => this[w]));

      return res;
    }

    protected override CeDictionary GetValueDictionary() => _layer.Dictionary;

    public override Dictionary<string, int> ReciveRawLayerDictionary()
      => _layer.Dictionary.ReciveRawValueToIndex().ToDictionary(x => x.Key, x => x.Value);

    public override void RefreshDictionaries() => _layer.Dictionary.RefreshDictionaries();

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    {
      if (_layer.DocumentGuid != documentGuid)
        return false;

      // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
      if (!_layer.Dictionary.Contains(value))
        _layer.Dictionary.Add(value);

      // Rufe value/idx sowie das Dokument ab
      var idx = _layer.Dictionary[value];

      // Überprüfe Überlauf der Indices sentenceIndex und wordIndex
      if (sentenceIndex >= _layer.Document.Length)
        return false;
      if (wordIndex >= _layer.Document[sentenceIndex].Length)
        return false;

      // Setze Layerwert auf -1 wenn alter == neuer Wert ansonst setzte neuen Wert
      if (_layer.Document[sentenceIndex][wordIndex] == idx)
        _layer.Document[sentenceIndex][wordIndex] = -1;
      else
        _layer.Document[sentenceIndex][wordIndex] = idx;

      return true;
    }

    public override bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
    {
      var stream = streamDocument.ToArray();

      if ((documentGuid != _layer.DocumentGuid) || (stream.Length != _layer.Document.Sum(s => s.Length)))
        return false;

      var idx = 0;
      foreach (var t in _layer.Document)
        for (var j = 0; j < t.Length; j++)
        {
          if (!_layer.Dictionary.Contains(stream[idx]))
            _layer.Dictionary.Add(stream[idx]);
          t[j] = _layer.Dictionary[stream[idx]];
          idx++;
        }

      return true;
    }

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null) => null;
    public override void ValueAdd(string value) => _layer.Dictionary.Add(value);
    
    public override void ValueChange(string oldValue, string newValue)
      => _layer.Dictionary.RenameValue(oldValue, newValue);

    public override void ValueRemove(string removeValue)
    {
      var idx = _layer.Dictionary[removeValue];
      _layer.Dictionary.Remove(removeValue);

      foreach (var d in _layer.Document)
        for (var j = 0; j < d.Length; j++)
          if (idx == d[j])
            d[j] = -1;
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var regex = new Regex(regEx);
      return from x in _layer.Dictionary where regex.Match(x.Value).Success select x.Value;
    }
  }
}
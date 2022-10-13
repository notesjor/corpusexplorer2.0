using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQueryMultiLayerPhrase : AbstractFilterQuery
  {
    private readonly Dictionary<Guid, KeyValuePair<Guid, int>[]> _cache =
      new Dictionary<Guid, KeyValuePair<Guid, int>[]>();

    private readonly object _cacheLock = new object();

    private readonly Dictionary<Guid, HashSet<Guid>> _layers =
      new Dictionary<Guid, HashSet<Guid>>();

    [XmlAttribute] private IEnumerable<string> _multiLayerQueries;

    [XmlAttribute] private string _multiLayerValueSeparator = ":";

    [XmlIgnore][NonSerialized] private List<KeyValuePair<string, string>> _query;

    public IEnumerable<string> MultiLayerQueries
    {
      get => _multiLayerQueries;
      set
      {
        _multiLayerQueries = value;
        PrepareQuery();
      }
    }

    public string MultiLayerValueSeparator
    {
      get => _multiLayerValueSeparator;
      set
      {
        _multiLayerValueSeparator = value;
        PrepareQuery();
      }
    }

    public override string Verbal => $"Multilayer-Abfrage der Layer: {string.Join(", ", _multiLayerQueries)}";

    public override object Clone()
    {
      return new FilterQueryMultiLayerPhrase { _multiLayerQueries = _multiLayerQueries.ToArray() };
    }

    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (!GetSpecificQuery(corpus, out var query, out var layers)) // ist null, wenn das Korpus nicht alle Layer enthält
        return -1;

      var mult = corpus.GetMultilayerDocument(documentGuid, layers);
      var first = mult.First();

      if (Configuration.RightToLeftSupport)
      {
        for (var j = first.Value[sentence].Length - query.Length; j >= 0; j--)
        {
          var match = true;
          for (var k = query.Length - 1; k >= 0; k--)
          {
            if (query[k].Value == mult[query[k].Key][sentence][j - k])
              continue;
            match = false;
            break;
          }

          if (!match)
            continue;
          return j;
        }

        return -1;
      }
      else
      {
        for (var j = 0; j < first.Value[sentence].Length - query.Length; j++)
        {
          if (query.Where((t, k) => t.Value != mult[t.Key][sentence][j + k]).Any())
            continue;
          return j;
        }

        return -1;
      }
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (!GetSpecificQuery(corpus, out var query, out var layers)) // ist null, wenn das Korpus nicht alle Layer enthält
        return null;

      var mult = corpus.GetMultilayerDocument(documentGuid, layers);
      var first = mult.First();

      if (Configuration.RightToLeftSupport)
      {
        var res = new List<int>();
        for (var i = 0; i < first.Value.Length; i++)
          for (var j = first.Value[i].Length - query.Length; j >= 0; j--)
          {
            var match = true;
            for (var k = query.Length - 1; k >= 0; k--)
            {
              if (query[k].Value == mult[query[k].Key][i][j - k])
                continue;
              match = false;
              break;
            }

            if (match)
            {
              res.Add(i);
              break;
            }
          }

        return res;
      }
      else
      {
        var res = new List<int>();
        for (var i = 0; i < first.Value.Length; i++)
          for (var j = 0; j < first.Value[i].Length - query.Length; j++)
          {
            if (query.Where((t, k) => t.Value != mult[t.Key][i][j + k]).Any())
              continue;
            res.Add(i);
            break;
          }

        return res;
      }
    }

    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (!GetSpecificQuery(corpus, out var query, out var layers)) // ist null, wenn das Korpus nicht alle Layer enthält
        return null;

      var mult = corpus.GetMultilayerDocument(documentGuid, layers);
      var first = mult.First();

      if (Configuration.RightToLeftSupport)
      {
        var res = new List<int>();
        for (var j = first.Value[sentence].Length - query.Length; j >= 0; j--)
        {
          var match = true;
          for (var k = query.Length - 1; k >= 0; k--)
          {
            if (query[k].Value == mult[query[k].Key][sentence][j - k])
              continue;
            match = false;
            break;
          }

          if (!match)
            continue;
          res.Add(j);
          break;
        }

        return res;
      }
      else
      {
        var res = new List<int>();
        for (var j = 0; j < first.Value[sentence].Length - query.Length; j++)
        {
          if (query.Where((t, k) => t.Value != mult[t.Key][sentence][j + k]).Any())
            continue;
          res.Add(j);
          break;
        }

        return res;
      }
    }

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (!GetSpecificQuery(corpus, out var query, out var layers)) // ist null, wenn das Korpus nicht alle Layer enthält
        return false;

      var mult = corpus.GetMultilayerDocument(documentGuid, layers);
      var first = mult.First();

      if (Configuration.RightToLeftSupport)
        for (var i = 0; i < first.Value.Length; i++)
          for (var j = first.Value[i].Length - query.Length; j >= 0; j--)
          {
            var match = true;
            for (var k = query.Length - 1; k >= 0; k--)
            {
              if (query[k].Value == mult[query[k].Key][i][j - k])
                continue;
              match = false;
              break;
            }

            if (match)
              return true;
          }
      else
        for (var i = 0; i < first.Value.Length; i++)
          for (var j = 0; j < first.Value[i].Length - query.Length; j++)
            if (!query.Where((t, k) => t.Value != mult[t.Key][i][j + k]).Any())
              return true;

      return false;
    }

    private bool GetSpecificQuery(AbstractCorpusAdapter corpus, out KeyValuePair<Guid, int>[] query,
                                  out HashSet<Guid> layers)
    {
      lock (_cacheLock)
      {
        if (_cache.ContainsKey(corpus.CorpusGuid))
        {
          query = _cache[corpus.CorpusGuid];
          layers = _layers[corpus.CorpusGuid];
          return true;
        }

        var qL = new List<KeyValuePair<Guid, int>>();
        var lL = new HashSet<Guid>();

        foreach (var q in _query)
        {
          var layer = corpus.GetLayers(q.Key).FirstOrDefault();
          if (layer == null)
          {
            _cache.Add(corpus.CorpusGuid, null);
            query = null;
            layers = null;
            return false;
          }

          qL.Add(new KeyValuePair<Guid, int>(layer.Guid, layer[q.Value]));
          lL.Add(layer.Guid);
        }

        query = qL.ToArray();
        layers = lL;

        _cache.Add(corpus.CorpusGuid, query);
        _layers.Add(corpus.CorpusGuid, layers);

        return true;
      }
    }

    private void PrepareQuery()
    {
      if (string.IsNullOrEmpty(_multiLayerValueSeparator) || _multiLayerQueries == null)
        return;

      _query = new List<KeyValuePair<string, string>>();
      var separator = new[] { _multiLayerValueSeparator };

      foreach (var x in _multiLayerQueries)
      {
        var split = x.Split(separator, StringSplitOptions.None);
        if (split.Length != 2)
          throw new IndexOutOfRangeException(
                                             $"FilterQueryMultiLayerPhrase erfordert die Kombination aus Layer + Wert. Scheinbar wurden mehrere Werte übergeben. Dies ist nicht zulässig. Überprüfen Sie den Wert-Trenner - dieser lautet: \"{_multiLayerValueSeparator}\"");

        _query.Add(new KeyValuePair<string, string>(split[0], split[1]));
      }
    }
  }
}
#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The dictionary extension.
  /// </summary>
  public static class DictionaryExtension
  {
    /// <summary>
    ///   Berechnet die Keyness einer Auflistung von dictionaries
    /// </summary>
    /// <param name="dictionaries">dictionaries</param>
    /// <returns>Keyness</returns>
    public static Dictionary<string, Dictionary<string, double>> CalculateKeyness(
      this IEnumerable<Dictionary<string, Dictionary<string, double>>> dictionaries)
    {
      var temp = new Dictionary<string, Dictionary<string, Tuple<double, double, double>>>();

      foreach (var dic in dictionaries)
      foreach (var e1 in dic)
      foreach (var e2 in e1.Value)
      {
        if (!temp.ContainsKey(e1.Key))
          temp.Add(e1.Key, new Dictionary<string, Tuple<double, double, double>>());
        if (!temp[e1.Key].ContainsKey(e2.Key))
          temp[e1.Key].Add(e2.Key, new Tuple<double, double, double>(e2.Value, 1, e2.Value));
        else
          temp[e1.Key][e2.Key] =
            new Tuple<double, double, double>(
              e2.Value < temp[e1.Key][e2.Key].Item1 ? e2.Value : temp[e1.Key][e2.Key].Item1,
              temp[e1.Key][e2.Key].Item2 + 1,
              e2.Value > temp[e1.Key][e2.Key].Item3 ? e2.Value : temp[e1.Key][e2.Key].Item3);
      }

      return temp.ToDictionary(
        k => k.Key,
        k => k.Value.ToDictionary(v => v.Key, v => (v.Value.Item3 - v.Value.Item1) / v.Value.Item2));
    }

    /// <summary>
    ///   Berechnet die Keyness einer Auflistung von dictionaries
    /// </summary>
    /// <param name="dictionaries">dictionaries</param>
    /// <returns>Keyness</returns>
    public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> CalculateKeyness(
      this IEnumerable<Dictionary<string, Dictionary<string, Dictionary<string, double>>>> dictionaries)
    {
      var temp = new Dictionary<string, Dictionary<string, Dictionary<string, Tuple<double, double, double>>>>();

      foreach (var e1 in dictionaries.SelectMany(dic => dic))
      {
        if (!temp.ContainsKey(e1.Key))
          temp.Add(e1.Key, new Dictionary<string, Dictionary<string, Tuple<double, double, double>>>());

        foreach (var e2 in e1.Value)
        {
          if (!temp[e1.Key].ContainsKey(e2.Key))
            temp[e1.Key].Add(e2.Key, new Dictionary<string, Tuple<double, double, double>>());

          foreach (var e3 in e2.Value)
            if (!temp[e1.Key][e2.Key].ContainsKey(e3.Key))
              temp[e1.Key][e2.Key].Add(e3.Key, new Tuple<double, double, double>(e3.Value, 1, e3.Value));
            else
              temp[e1.Key][e2.Key][e3.Key] =
                new Tuple<double, double, double>(
                  e3.Value < temp[e1.Key][e2.Key][e3.Key].Item1 ? e3.Value : temp[e1.Key][e2.Key][e3.Key].Item1,
                  temp[e1.Key][e2.Key][e3.Key].Item2 + 1,
                  e3.Value > temp[e1.Key][e2.Key][e3.Key].Item3 ? e3.Value : temp[e1.Key][e2.Key][e3.Key].Item3);
        }
      }

      return temp.ToDictionary(
        e1 => e1.Key,
        e1 =>
          e1.Value.ToDictionary(
            e2 => e2.Key,
            e2 =>
              e2.Value.ToDictionary(
                e3 => e3.Key,
                e3 =>
                  (e3.Value.Item3 - e3.Value.Item1) /
                  e3.Value.Item2)));
    }

    /// <summary>
    ///   Berechnet die Keyness einer Auflistung von dictionaries
    /// </summary>
    /// <param name="dictionaries">dictionaries</param>
    /// <returns>Keyness</returns>
    public static Dictionary<string, double> CalculateKeyness(this IEnumerable<Dictionary<string, double>> dictionaries)
    {
      var temp = new Dictionary<string, Tuple<double, double, double>>();

      foreach (var dic in dictionaries)
      foreach (var k in dic)
        if (!temp.ContainsKey(k.Key))
          temp.Add(k.Key, new Tuple<double, double, double>(k.Value, 1, k.Value));
        else
          temp[k.Key] = new Tuple<double, double, double>(
            k.Value < temp[k.Key].Item1 ? k.Value : temp[k.Key].Item1,
            temp[k.Key].Item2 + 1,
            k.Value > temp[k.Key].Item3 ? k.Value : temp[k.Key].Item3);

      return temp.ToDictionary(k => k.Key, v => (v.Value.Item3 - v.Value.Item1) / v.Value.Item2);
    }

    /// <summary>
    ///   Berechnet die Keyness einer Auflistung von dictionaries
    /// </summary>
    /// <param name="dictionaries">dictionaries</param>
    /// <returns>Keyness</returns>
    public static Dictionary<Guid, double> CalculateKeyness(this IEnumerable<Dictionary<Guid, double>> dictionaries)
    {
      var temp = new Dictionary<Guid, Tuple<double, double, double>>();

      foreach (var k in dictionaries.SelectMany(dic => dic))
        if (!temp.ContainsKey(k.Key))
          temp.Add(k.Key, new Tuple<double, double, double>(k.Value, 1, k.Value));
        else
          temp[k.Key] = new Tuple<double, double, double>(
            k.Value < temp[k.Key].Item1 ? k.Value : temp[k.Key].Item1,
            temp[k.Key].Item2 + 1,
            k.Value > temp[k.Key].Item3 ? k.Value : temp[k.Key].Item3);

      return temp.ToDictionary(k => k.Key, v => (v.Value.Item3 - v.Value.Item1) / v.Value.Item2);
    }

    /// <summary>
    ///   The clone.
    /// </summary>
    /// <param name="origin">
    ///   The origin.
    /// </param>
    /// <returns>
    ///   Dictionary
    /// </returns>
    public static Dictionary<Guid, HashSet<Guid>> Clone(this Dictionary<Guid, HashSet<Guid>> origin)
    {
      return origin.ToDictionary(c => c.Key, c => new HashSet<Guid>(c.Value));
    }

    public static Dictionary<TK, TV> Clone<TK, TV>(this Dictionary<TK, TV> dict)
    {
      return dict.ToDictionary(x => x.Key, x => x.Value);
    }

    public static Dictionary<TK, Dictionary<TK, TV>> Clone<TK, TV>(this Dictionary<TK, Dictionary<TK, TV>> dict)
    {
      return dict.ToDictionary(x => x.Key, x => x.Value.ToDictionary(y => y.Key, y => y.Value));
    }

    public static Dictionary<TK, Dictionary<TK, Dictionary<TK, TV>>> Clone<TK, TV>(
      this Dictionary<TK, Dictionary<TK, Dictionary<TK, TV>>> dict)
    {
      return dict.ToDictionary(
        x => x.Key,
        x => x.Value.ToDictionary(y => y.Key, y => y.Value.ToDictionary(z => z.Key, z => z.Value)));
    }

    public static Dictionary<string, Dictionary<string, double>> CompleteDictionaryToFullDictionary(
      this Dictionary<string, Dictionary<string, double>> fragmentDictionary)
    {
      var res = new Dictionary<string, Dictionary<string, double>>();

      foreach (var x in fragmentDictionary)
      {
        if (!res.ContainsKey(x.Key))
          res.Add(x.Key, new Dictionary<string, double>());

        foreach (var y in x.Value)
        {
          if (!res.ContainsKey(y.Key))
            res.Add(y.Key, new Dictionary<string, double>());

          if (!res[x.Key].ContainsKey(y.Key))
            res[x.Key].Add(y.Key, y.Value);
          else if (y.Value > res[x.Key][y.Key])
            res[x.Key][y.Key] = y.Value;

          if (!res[y.Key].ContainsKey(x.Key))
            res[y.Key].Add(x.Key, y.Value);
          else if (y.Value > res[y.Key][x.Key])
            res[y.Key][x.Key] = y.Value;
        }
      }

      return res;
    }

    public static Dictionary<string, Dictionary<string, double>> CompleteDictionaryViaJoinToFullDictionary(
      this Dictionary<string, Dictionary<string, double>> fragmentDictionary)
    {
      var res = new Dictionary<string, Dictionary<string, double>>();

      foreach (var x in fragmentDictionary)
      {
        if (!res.ContainsKey(x.Key))
          res.Add(x.Key, new Dictionary<string, double>());

        foreach (var y in x.Value)
        {
          if (!res.ContainsKey(y.Key))
            res.Add(y.Key, new Dictionary<string, double>());

          if (!res[x.Key].ContainsKey(y.Key))
            res[x.Key].Add(y.Key, y.Value);
          else
            res[x.Key][y.Key] += y.Value;

          if (!res[y.Key].ContainsKey(x.Key))
            res[y.Key].Add(x.Key, y.Value);
          else
            res[y.Key][x.Key] += y.Value;
        }
      }

      return res;
    }

    public static DataTable ConvertToDataTableNormalized(this Dictionary<string, double> dictionary)
    {
      var res = CreateDataTable();

      if (dictionary == null)
        return res;
      var list = dictionary.ToList();
      list.Sort((x, y) => y.Value.CompareTo(x.Value));

      res.BeginLoadData();
      foreach (var entry in list)
        res.Rows.Add(entry.Key, entry.Value);
      res.EndLoadData();

      return res;
    }

    /// <summary>
    ///   Baut eine Standardtabelle die von ALLEN ConvertToDataTable-Extensions genutzt wird.
    ///   Entweder als Basis für die Ausgabetabelle, oder aber als Default Return Value
    /// </summary>
    /// <returns></returns>
    private static DataTable CreateDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Key", typeof(string));
      res.Columns.Add("Value", typeof(double));
      return res;
    }

    /// <summary>
    ///   Drilldown a 3Level-Dictionary
    /// </summary>
    /// <returns>
    ///   The <see cref="DataTable" />.
    /// </returns>
    public static DataTable DrilldownToDataTable(
      this Dictionary<string, Dictionary<string, Dictionary<string, double>>> dictionary)
    {
      return dictionary == null
               ? CreateDataTable()
               : dictionary.ToDictionary(p1 => p1.Key, p1 => p1.Value.SelectMany(p2 => p2.Value).Sum(p3 => p3.Value))
                           .ConvertToDataTableNormalized();
    }

    /// <summary>
    ///   Drilldown a 2Level-Dictionary
    /// </summary>
    /// <returns>
    ///   The <see cref="DataTable" />.
    /// </returns>
    public static DataTable DrilldownToDataTable(this Dictionary<string, Dictionary<string, double>> dictionary)
    {
      return dictionary == null
               ? CreateDataTable()
               : dictionary.ToDictionary(p1 => p1.Key, p1 => p1.Value.Sum(p2 => p2.Value))
                           .ConvertToDataTableNormalized();
    }

    /// <summary>
    ///   Drilldown a 3Level-Dictionary
    /// </summary>
    /// <param name="dictionary">3-Layer-Dictionary</param>
    /// <param name="key">
    ///   The key
    /// </param>
    /// <returns>
    ///   The <see cref="DataTable" />.
    /// </returns>
    public static DataTable DrilldownToDataTable(
      this Dictionary<string, Dictionary<string, Dictionary<string, double>>> dictionary,
      string key)
    {
      return dictionary == null || !dictionary.ContainsKey(key)
               ? CreateDataTable()
               : dictionary[key].ToDictionary(pair => pair.Key, pair => pair.Value.Sum(p2 => p2.Value))
                                .ConvertToDataTableNormalized();
    }

    /// <summary>
    ///   Drilldown a 2Level-Dictionary
    /// </summary>
    /// <param name="key">
    ///   The key
    /// </param>
    /// <param name="dictionary">2-Layer-Dictionary</param>
    /// <returns>
    ///   The <see cref="DataTable" />.
    /// </returns>
    public static DataTable DrilldownToDataTable(
      this Dictionary<string, Dictionary<string, double>> dictionary,
      string key)
    {
      return dictionary == null || !dictionary.ContainsKey(key)
               ? CreateDataTable()
               : dictionary[key].ConvertToDataTableNormalized();
    }

    /// <summary>
    ///   The get word frequency.
    /// </summary>
    /// <param name="key1">
    ///   The key1
    /// </param>
    /// <param name="dictionary">3-Layer-Dictionary</param>
    /// <param name="key2">
    ///   The key
    /// </param>
    /// <returns>
    ///   The <see cref="DataTable" />.
    /// </returns>
    public static DataTable DrilldownToDataTable(
      this Dictionary<string, Dictionary<string, Dictionary<string, double>>> dictionary,
      string key1,
      string key2)
    {
      return dictionary == null || !dictionary.ContainsKey(key1) || !dictionary.ContainsKey(key2)
               ? CreateDataTable()
               : dictionary[key1][key2].ConvertToDataTableNormalized();
    }

    /// <summary>
    ///   Bereinigt ein Dictionary in dem alle Werte entfernt werden,
    ///   deren Value unter dem minimum liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dictionary
    /// </param>
    /// <param name="minimum">
    ///   minimum
    /// </param>
    /// <returns>
    ///   Bereinigtes Dictionary
    /// </returns>
    public static Dictionary<TK, TV> GetCleanDictionary<TK, TV>(
      this Dictionary<TK, TV> dictionary,
      TV minimum)
      where TV : IComparable
    {
      var list = dictionary.ToList();
      foreach (var pair in list.Where(pair => pair.Value.CompareTo(minimum) < 0))
        dictionary.Remove(pair.Key);

      return dictionary;
    }

    /// <summary>
    ///   Bereinigt ein Dictionary in dem alle Werte entfernt werden,
    ///   deren Value unter dem minimum liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dictionary
    /// </param>
    /// <param name="minimum">
    ///   minimum
    /// </param>
    /// <returns>
    ///   Bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, T>> GetCleanDictionary<T>(
      this Dictionary<string, Dictionary<string, T>> dictionary,
      T minimum)
      where T : IComparable
    {
      var rem = new List<string>();

      foreach (var entry in dictionary)
      {
        var list = entry.Value.ToList();
        foreach (var pair in list.Where(pair => pair.Value.CompareTo(minimum) < 0))
          entry.Value.Remove(pair.Key);

        if (entry.Value.Count == 0)
          rem.Add(entry.Key);
      }

      foreach (var r in rem)
        dictionary.Remove(r);

      return dictionary;
    }

    /// <summary>
    ///   Bereinigt ein Dictionary in dem alle Werte entfernt werden,
    ///   deren Value unter dem minimum liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dictionary
    /// </param>
    /// <param name="minimum">
    ///   minimum
    /// </param>
    /// <returns>
    ///   Bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, Dictionary<string, T>>> GetCleanDictionary<T>(
      this Dictionary<string, Dictionary<string, Dictionary<string, T>>> dictionary,
      T minimum)
      where T : IComparable
    {
      var rem1 = new List<string>();

      foreach (var pos in dictionary)
      {
        var rem2 = new List<string>();

        foreach (var lemma in pos.Value)
        {
          var list = lemma.Value.ToList();
          foreach (var pair in list.Where(pair => pair.Value.CompareTo(minimum) < 0))
            lemma.Value.Remove(pair.Key);
          if (lemma.Value.Count == 0)
            rem2.Add(lemma.Key);
        }

        foreach (var r in rem2)
          pos.Value.Remove(r);

        if (pos.Value.Count == 0)
          rem1.Add(pos.Key);
      }

      foreach (var r in rem1)
        dictionary.Remove(r);

      return dictionary;
    }

    /// <summary>
    ///   Interpoliert ein Dictionary indem es die Gesamtmenge der Wort auf den denominator-Wert umrechnet.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <param name="minimum">Minimum das erreicht werden muss damit der Eintrag im Dictionary verbleibt</param>
    /// <param name="denominator">
    ///   Nenner
    /// </param>
    /// <returns>
    ///   Interpoliertes Dictionary
    /// </returns>
    public static Dictionary<string, double> GetCleanInterpolateDictionary(
      this Dictionary<string, double> dictionary,
      double minimum,
      double denominator = 1000000.0d)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, double>();

      var factor = denominator / dictionary.Select(x => x.Value).Sum();

      foreach (var x in dictionary)
      {
        var val = x.Value * factor;
        if (double.IsInfinity(val) ||
            double.IsNaN(val) ||
            val < minimum)
          continue;

        res.Add(x.Key, val);
      }

      return res;
    }

    /// <summary>
    ///   Interpoliert ein Dictionary indem es die Gesamtmenge der Wort auf den denominator-Wert umrechnet.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <param name="minimum">Minimum das erreicht werden muss damit der Eintrag im Dictionary verbleibt</param>
    /// <param name="denominator">
    ///   Nenner
    /// </param>
    /// <returns>
    ///   Interpoliertes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, double>> GetCleanInterpolateDictionary(
      this Dictionary<string, Dictionary<string, double>> dictionary,
      double minimum,
      double denominator = 1000000.0d)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, Dictionary<string, double>>();

      var factor = denominator / dictionary.SelectMany(x => x.Value).Sum(y => y.Value);

      foreach (var x in dictionary)
      {
        var value = new Dictionary<string, double>();

        foreach (var y in x.Value)
        {
          var val = y.Value * factor;
          if (double.IsInfinity(val) ||
              double.IsNaN(val) ||
              val < minimum)
            continue;
          value.Add(y.Key, val);
        }

        if (value.Count > 0)
          res.Add(x.Key, value);
      }

      return res;
    }

    /// <summary>
    ///   Interpoliert ein Dictionary indem es die Gesamtmenge der Wort auf den denominator-Wert umrechnet.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <param name="denominator">
    ///   Nenner
    /// </param>
    /// <returns>
    ///   Interpoliertes Dictionary
    /// </returns>
    public static Dictionary<string, double> GetInterpolateDictionary(
      this Dictionary<string, double> dictionary,
      double denominator = 1000000.0d)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, double>();

      var factor = denominator / dictionary.Select(x => x.Value).Sum();

      foreach (var x in dictionary)
      {
        var val = x.Value * factor;
        if (double.IsInfinity(val) ||
            double.IsNaN(val))
          continue;

        res.Add(x.Key, val);
      }

      return res;
    }

    /// <summary>
    ///   Interpoliert ein Dictionary indem es die Gesamtmenge der Wort auf den denominator-Wert umrechnet.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <param name="denominator">
    ///   Nenner
    /// </param>
    /// <returns>
    ///   Interpoliertes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, double>> GetInterpolateDictionary(
      this Dictionary<string, Dictionary<string, double>> dictionary,
      double denominator = 1000000.0d)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, Dictionary<string, double>>();

      var factor = denominator / dictionary.SelectMany(x => x.Value).Select(x => x.Value).Sum();

      foreach (var x in dictionary)
      {
        var value = new Dictionary<string, double>();

        foreach (var y in x.Value)
        {
          var val = y.Value * factor;
          if (double.IsInfinity(val) ||
              double.IsNaN(val))
            continue;

          value.Add(y.Key, val);
        }

        res.Add(x.Key, value);
      }

      return res;
    }

    /// <summary>
    ///   Interpoliert ein Dictionary indem es die Gesamtmenge der Wort auf den denominator-Wert umrechnet.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Interpoliertes Dictionary
    /// </returns>
    public static Dictionary<string, double> GetInterpolateDictionary(
      this Dictionary<string, int> dictionary)
    {
      return GetInterpolateDictionary(dictionary.ToDictionary(x => x.Key, x => (double) x.Value));
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, double> GetNormalizedDictionary(this Dictionary<string, double> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, double>();
      var max = dictionary.Sum(x => x.Value);

      foreach (var x in dictionary)
      {
        var val = x.Value / max;
        if (!double.IsInfinity(val) &&
            !double.IsNaN(val))
          res.Add(x.Key, val);
      }

      return res;
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<Guid, double> GetNormalizedDictionary(this Dictionary<Guid, double> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<Guid, double>();
      var max = dictionary.Sum(x => x.Value);

      foreach (var x in dictionary)
      {
        var val = x.Value / max;
        if (!double.IsInfinity(val) &&
            !double.IsNaN(val))
          res.Add(x.Key, val);
      }

      return res;
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, double> GetNormalizedDictionary(this Dictionary<string, int> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, double>();
      var max = (double) dictionary.Sum(x => x.Value);

      foreach (var x in dictionary)
      {
        var val = x.Value / max;
        if (!double.IsInfinity(val) &&
            !double.IsNaN(val))
          res.Add(x.Key, val);
      }

      return res;
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, double>> GetNormalizedDictionary(
      this Dictionary<string, Dictionary<string, double>> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, Dictionary<string, double>>();
      var max = dictionary.SelectMany(e1 => e1.Value).Sum(e2 => e2.Value);

      foreach (var e1 in dictionary)
      {
        var values = new Dictionary<string, double>();
        foreach (var e2 in e1.Value)
        {
          var val = e2.Value / max;
          if (!double.IsInfinity(val) &&
              !double.IsNaN(val))
            values.Add(e2.Key, val);
        }
        if (values.Count > 0)
          res.Add(e1.Key, values);
      }

      return res;
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, double>> GetNormalizedDictionary(
      this Dictionary<string, Dictionary<string, int>> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, Dictionary<string, double>>();
      var max = (double) dictionary.SelectMany(e1 => e1.Value).Sum(e2 => e2.Value);

      foreach (var e1 in dictionary)
      {
        var values = new Dictionary<string, double>();
        foreach (var e2 in e1.Value)
        {
          var val = e2.Value / max;
          if (!double.IsInfinity(val) &&
              !double.IsNaN(val))
            values.Add(e2.Key, val);
        }
        if (values.Count > 0)
          res.Add(e1.Key, values);
      }

      return res;
    }

    /// <summary>
    ///   Normalisiert ein Dictionary indem es die relative Häufigkeit berechnet und die Werte entfernt,
    ///   die unter der minimumPercentage liegen.
    /// </summary>
    /// <param name="dictionary">
    ///   Dicitionary
    /// </param>
    /// <returns>
    ///   Normalisiertes und bereinigtes Dictionary
    /// </returns>
    public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> GetNormalizedDictionary(
      this Dictionary<string, Dictionary<string, Dictionary<string, double>>> dictionary)
    {
      if (dictionary == null)
        return null;

      var res = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
      var max = (from pos in dictionary from lem in pos.Value from wor in lem.Value select wor.Value).Sum();

      foreach (var e1 in dictionary)
      {
        var dic1 = new Dictionary<string, Dictionary<string, double>>();
        foreach (var e2 in e1.Value)
        {
          var dic2 = new Dictionary<string, double>();
          foreach (var e3 in e2.Value)
          {
            var value = e3.Value / max;
            if (!double.IsInfinity(value) &&
                !double.IsNaN(value))
              dic2.Add(e3.Key, value);
          }
          if (dic2.Count > 0)
            dic1.Add(e2.Key, dic2);
        }
        if (dic1.Count > 0)
          res.Add(e1.Key, dic1);
      }

      return res;
    }
  }
}
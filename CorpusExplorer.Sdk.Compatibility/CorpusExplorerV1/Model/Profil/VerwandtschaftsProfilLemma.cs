#region usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Profil
{
  [Serializable]
  public class VerwandtschaftsProfilLemma : VerwandtschaftsProfilEinfach
  {
    protected VerwandtschaftsProfilLemma()
    {
      LemmaBigram = new Dictionary<string, double>();
      LemmaTrigram = new Dictionary<string, double>();
    }

    public Dictionary<string, double> LemmaBigram { get; set; }

    public Dictionary<string, double> LemmaTrigram { get; set; }

    public double CompareTo(VerwandtschaftsProfilLemma cmp)
    {
      if (cmp == null || Name == cmp.Name)
        return -1;

      var res = base.CompareTo((cmp));

      res += BerechneUnterschied(LemmaBigram, cmp.LemmaBigram);
      res += BerechneUnterschied(LemmaTrigram, cmp.LemmaTrigram);

      return res;
    }

    protected double BerechneUnterschied(Dictionary<string, double> xs, Dictionary<string, double> ys)
    {
      if (xs.Count == 0 || ys.Count == 0)
        return 0;

      var res = 0.0d;
      var rl = ys.Select(y => y.Key).AsParallel().ToList();

      foreach (var x in xs.Where(x => ys.ContainsKey(x.Key)))
      {
        res += BerechneUnterschied(x.Value, ys[x.Key]);
        rl.Remove(x.Key);
      }

      return rl.Aggregate(res, (current, r) => current + ys[r]);
    }
  }
}
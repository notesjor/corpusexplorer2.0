#region usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Profil
{
  /// <summary>
  ///   Class <see cref="VerwandtschaftsProfilLemmaPos" />
  /// </summary>
  [Serializable]
  public class VerwandtschaftsProfilLemmaPos : VerwandtschaftsProfilLemma
  {
    /// <summary>
    ///   Initializes a new instance of the
    ///   <see cref="VerwandtschaftsProfilLemmaPos" /> class.
    /// </summary>
    public VerwandtschaftsProfilLemmaPos()
    {
      POSBigram = new Dictionary<string, double>();
      POSTrigram = new Dictionary<string, double>();
    }

    /// <summary>
    ///   Gets or sets the POS bigram.
    /// </summary>
    /// <value>
    ///   The POS bigram.
    /// </value>
    public Dictionary<string, double> POSBigram { get; set; }

    /// <summary>
    ///   Gets or sets the POS trigram.
    /// </summary>
    /// <value>
    ///   The POS trigram.
    /// </value>
    public Dictionary<string, double> POSTrigram { get; set; }

    /// <summary>
    ///   Compares to.
    /// </summary>
    /// <param name="cmp">The CMP.</param>
    /// <returns>
    ///   System.Double.
    /// </returns>
    public double CompareTo(VerwandtschaftsProfilLemmaPos cmp)
    {
      if (cmp == null || Name == cmp.Name)
        return -1;

      var res = base.CompareTo((cmp));
      res += BerechneUnterschied(POSBigram, cmp.POSBigram);
      res += BerechneUnterschied(POSTrigram, cmp.POSTrigram);

      return res;
    }

    /// <summary>
    ///   Berechnes the unterschied.
    /// </summary>
    /// <param name="xs">The xs.</param>
    /// <param name="ys">The ys.</param>
    /// <returns>
    ///   System.Double.
    /// </returns>
    private new double BerechneUnterschied(Dictionary<string, double> xs, Dictionary<string, double> ys)
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

    /// <summary>
    ///   Berechnes the unterschied.
    /// </summary>
    /// <param name="a">A.</param>
    /// <param name="b">The b.</param>
    /// <returns>
    ///   System.Double.
    /// </returns>
    private new double BerechneUnterschied(double a, double b)
    {
      if (a <= 0.0d) return b;
      if (b <= 0.0d) return a;

      return a > b ? b/a : a/b;
    }
  }
}
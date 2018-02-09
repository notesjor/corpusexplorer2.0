using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity.CalculationHelper
{
  public static class VocabularyComplexityMCalculationHelper
  {
    public static double GetM(Dictionary<string, double> tabelle)
    {
      var res = 0.0d;
      var max = (int) tabelle.Select(x => x.Value).Concat(new double[] {0}).Max();

      for (var i = 0; i < max; i++)
        res += Math.Pow(i, 2) * VocabularyComplexityViCalculationHelper.GetVi(tabelle, i);

      return res;
    }
  }
}
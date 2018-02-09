using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity.CalculationHelper
{
  public static class VocabularyComplexityViCalculationHelper
  {
    public static double GetVi(Dictionary<string, double> tabelle, int i)
    {
      return tabelle.Count(x => (int) x.Value == i);
    }
  }
}
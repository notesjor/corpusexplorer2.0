#region usings

using System;
using System.Linq;
using CorpusExplorer.Sdk.Data.Helper;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Profil
{
  [Serializable]
  public class VerwandtschaftsProfilEinfach
  {
    protected VerwandtschaftsProfilEinfach()
    {
      Name = string.Empty;
      Dokumente = new ListOptimized<string>();
      AnzahlSätze = 0;
      AnzahlTeilsätze = 0;
      AnzahlWörter = 0;
      WortlängeGruppen = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    }

    public double AnzahlSätze { get; set; }

    public double AnzahlTeilsätze { get; set; }

    public double AnzahlWörter { get; set; }

    public ListOptimized<string> Dokumente { get; set; }

    public string Name { get; set; }

    public double SätzeProText
    {
      get { return AnzahlSätze/Dokumente.Count; }
    }

    public double TeilsätzeProSatz
    {
      get { return AnzahlTeilsätze/AnzahlSätze; }
    }

    public double WörterProSatz
    {
      get { return AnzahlWörter/AnzahlSätze; }
    }

    public int[] WortlängeGruppen { get; set; }

    public double CompareTo(VerwandtschaftsProfilEinfach cmp)
    {
      if (cmp == null || Name == cmp.Name)
        return -1;

      var res = BerechneUnterschied(SätzeProText, cmp.SätzeProText);
      res += BerechneUnterschied(TeilsätzeProSatz, cmp.TeilsätzeProSatz);
      res += BerechneUnterschied(WörterProSatz, cmp.WörterProSatz);

      res /= 3; // Minimierung der eher unrelevanten Daten (SätzeProSatz / TeilsätzeProSatz / WörterProSatz)

      var tmp = WortlängeGruppen.Select((t, i) => BerechneUnterschied(t, cmp.WortlängeGruppen[i])).Sum();
      res = (res + (tmp/WortlängeGruppen.Length))/2;

      return res;
    }

    protected double BerechneUnterschied(double a, double b)
    {
      if (a <= 0.0d) return b;
      if (b <= 0.0d) return a;

      return a > b ? b/a : a/b;
    }
  }
}
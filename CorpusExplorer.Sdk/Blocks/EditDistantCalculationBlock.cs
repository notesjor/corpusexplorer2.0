#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Diff;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  public class EditDistantCalculationBlock : AbstractBlock
  {
    public List<Tuple<Guid, Guid, int, int>> EditDistances { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var dsel = Selection.DocumentGuids.ToArray();
      var resLock = new object();

      EditDistances = new List<Tuple<Guid, Guid, int, int>>();

      Parallel.For(0, dsel.Length, i =>
      {
        var a = Selection.GetDocument(dsel[i], LayerDisplayname)?
                         .Reduce()
                         .ToArray();
        if (a == null)
          return;

        Parallel.For(i + 1, dsel.Length, j =>
        {
          var b = Selection.GetDocument(dsel[j], LayerDisplayname)?
                           .Reduce()
                           .ToArray();
          if (b == null)
            return;

          var delta = Diff.DiffInt(a, b);
          var sum = delta.Sum(d => d.EditDistance);

          lock (resLock)
            EditDistances.Add(new Tuple<Guid, Guid, int, int>(dsel[i], dsel[j], sum, a.Length + b.Length));
        });
      });
    }
  }
}
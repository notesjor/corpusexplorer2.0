using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperStandoff
  {
    /// <summary>
    /// Durchsucht einen text und ordnet der text-Position ein Token aus doc zu.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="doc">Token, die dem Text zugeordnet werden.</param>
    /// <param name="layer">Layer zum Auflösen der Token aus doc</param>
    /// <returns>0 = Satz (doc) / 1 = Token (doc) / 2 = start Index (text) / 3 = end Index </returns>
    public IEnumerable<Tuple<int, int, int, int>> ExtractAlignment(string text, int[][] doc, AbstractLayerAdapter layer)
    {
      var res = new List<Tuple<int, int, int, int>>();
      var idx = 0;

      for (var i = 0; i < doc.Length; i++)
      {
        for (var j = 0; j < doc[i].Length; j++)
        {
          var t = layer[doc[i][j]];

          idx = text.IndexOf(t, idx);
          if (idx == -1)
            throw new Exception("ReMapperStandoff - AlignmentException");

          res.Add(new Tuple<int, int, int, int>(i, j, idx, idx + t.Length - 1));
          idx += t.Length;
        }
      }

      return res;
    }
  }
}

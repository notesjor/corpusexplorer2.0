using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperStandoff
  {
    public int ThrowExceptionAfterAlignmentErrors { get; set; } = -1;

    /// <summary>
    /// Durchsucht einen text und ordnet der text-Position ein Token aus doc zu.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="doc">Token, die dem Text zugeordnet werden.</param>
    /// <param name="layer">Layer zum Auflösen der Token aus doc</param>
    /// <returns>0 = Satz (doc) / 1 = Token (doc) / 2 = start Index (text) / 3 = end Index </returns>
    public List<ReMapperEntry> ExtractAlignment(string text, int[][] doc, AbstractLayerAdapter layer)
    {
      var res = new List<ReMapperEntry>();
      var idx = 0;

      for (var i = 0; i < doc.Length; i++)
      {
        for (var j = 0; j < doc[i].Length; j++)
        {
          var t = layer[doc[i][j]];

          idx = text.IndexOf(t, idx);
          if (idx == -1)
            throw new Exception("ReMapperStandoff - AlignmentException");

          res.Add(new ReMapperEntry
          {
            SentenceIndex = i,
            TokenIndex = j,
            TextCharFrom = idx,
            TextCharTo = idx + t.Length - 1
          });
          idx += t.Length;
        }
      }

      return res;
    }

    /// <summary>
    /// Durchsucht einen text und ordnet der text-Position ein Token aus doc zu.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="doc">Token, die dem Text zugeordnet werden.</param>
    /// <returns>0 = Satz (doc) / 1 = Token (doc) / 2 = start Index (text) / 3 = end Index </returns>
    public List<ReMapperEntry> ExtractAlignment(string text, string[][] doc)
    {
      var res = new List<ReMapperEntry>();
      var last = 0;

      for (var i = 0; i < doc.Length; i++)
      {
        for (var j = 0; j < doc[i].Length; j++)
        {
          var t = doc[i][j];

          var idx = text.IndexOf(t, last);
          if (idx == -1)
          {
            if (ThrowExceptionAfterAlignmentErrors > 0)
              ThrowExceptionAfterAlignmentErrors--;
            else if (ThrowExceptionAfterAlignmentErrors == 0)
              throw new Exception("ReMapperStandoff - AlignmentException");
            else // == -1
              continue;
          }

          res.Add(new ReMapperEntry
          {
            SentenceIndex = i,
            TokenIndex = j,
            TextCharFrom = idx,
            TextCharTo = idx + t.Length - 1
          });
          last += t.Length;
        }
      }

      return res;
    }
  }
}

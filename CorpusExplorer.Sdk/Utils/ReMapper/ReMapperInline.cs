using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Abstract;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperInline : AbstractReMapper
  {
    protected override string ApplyAnnotation(Tuple<AbstractLayerAdapter, int[][]>[] layers, string originalText, Tuple<int, int, int, int>[] annotationPositions)
    {
      if (layers.Length == 0 || string.IsNullOrEmpty(originalText) || annotationPositions == null)
        return string.Empty;
      
      var stb = new StringBuilder(originalText);
      for (var i = annotationPositions.Length - 1; i > -1; i--)
      {
        var x = annotationPositions[i];
        stb.Insert(x.Item4, "</token></annotation>");

        var lv = new StringBuilder();
        foreach (var l in layers)
          lv.AppendLine($"<layer name=\"{l.Item1.Displayname}\">{l.Item1[l.Item2[x.Item1][x.Item2]]}</layer>");
        
        stb.Insert(x.Item3, $"<annotation>{lv}<token>");
      }
      return stb.ToString();
    }
  }
}

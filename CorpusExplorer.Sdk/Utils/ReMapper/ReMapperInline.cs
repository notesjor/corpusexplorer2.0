using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperInline : AbstractReMapper
  {
    protected override string ApplyAnnotation(IEnumerable<KeyValuePair<AbstractLayerAdapter, int[][]>> layers, string originalText,
                                              List<ReMapperEntry> annotationPositions)
    {
      if (layers == null || string.IsNullOrEmpty(originalText) || annotationPositions == null)
        return string.Empty;

      var stb = new StringBuilder(originalText);

      for (var i = annotationPositions.Count - 1; i > -1; i--)
      {
        var x = annotationPositions[i];
        stb.Insert(x.TextCharTo, "</token></annotation>");

        var lv = new StringBuilder();
        foreach (var l in layers)
          lv.AppendLine($"<layer name=\"{l.Key.Displayname}\">{l.Key[l.Value[x.SentenceIndex][x.TokenIndex]]}</layer>");

        stb.Insert(x.TextCharFrom, $"<annotation>{lv}<token>");
      }

      return stb.ToString();
    }
  }
}
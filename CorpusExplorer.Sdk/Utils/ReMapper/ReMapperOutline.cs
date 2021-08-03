using System;
using System.Collections.Generic;
using System.Text;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperOutline : AbstractReMapper
  {
    protected override string ApplyAnnotation(IEnumerable<KeyValuePair<AbstractLayerAdapter, int[][]>> layers, string originalText,
                                              List<ReMapperEntry> annotationPositions)
    {
      if (layers == null|| string.IsNullOrEmpty(originalText))
        return string.Empty;

      var stb = new StringBuilder();
      stb.AppendLine("<annotations>");
      foreach (var x in annotationPositions)
      {
        stb.AppendLine($"\t<annotation from=\"{x.TextCharFrom}\" to=\"{x.TextCharTo}\">");

        foreach (var l in layers)
          stb.AppendLine($"\t\t<layer name=\"{l.Key.Displayname}\">{l.Key[l.Value[x.SentenceIndex][x.TokenIndex]]}</layer>");

        stb.AppendLine("\t</annotation>");
      }

      stb.AppendLine("</annotations>");
      return stb.ToString();
    }
  }
}
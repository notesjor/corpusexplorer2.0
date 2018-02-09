using System;
using System.Text;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Abstract;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperOutline : AbstractReMapper
  {
    protected override string ApplyAnnotation(Tuple<AbstractLayerAdapter, int[][]>[] layers, string originalText, Tuple<int, int, int, int>[] annotationPositions)
    {
      if (layers.Length == 0 || string.IsNullOrEmpty(originalText))
        return string.Empty;

      var stb = new StringBuilder();
      stb.AppendLine("<annotations>");
      foreach (var x in annotationPositions)
      {
        stb.AppendLine($"\t<annotation start=\"{x.Item3}\" stop=\"{x.Item4}\">");

        foreach (var l in layers)
          stb.AppendLine($"\t\t<layer name=\"{l.Item1.Displayname}\">{l.Item1[l.Item2[x.Item1][x.Item2]]}</layer>");

        stb.AppendLine("\t</annotation>");
      }
      stb.AppendLine("</annotations>");
      return stb.ToString();
    }
  }
}
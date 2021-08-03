using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;

namespace CorpusExplorer.Sdk.Utils.ReMapper
{
  public class ReMapperInlineAttributes : AbstractReMapper
  {
    protected override string ApplyAnnotation(IEnumerable<KeyValuePair<AbstractLayerAdapter, int[][]>> layers, string originalText,
                                              List<ReMapperEntry> annotationPositions)
    {
      if (layers == null || string.IsNullOrEmpty(originalText) || annotationPositions == null)
        return string.Empty;

      var layerNames = layers.Select(x => x.Key.Displayname).ToArray();
      var multiDoc = new Dictionary<string, string[][]>();
      foreach (var l in layers)
      {
        var layer = l.Key;
        multiDoc.Add(l.Key.Displayname, l.Value.Select(s => s.Select(t => layer[t]).ToArray()).ToArray());
      }

      var leader = multiDoc.First().Value;

      var stb = new StringBuilder();
      for (var i = 0; i < leader.Length; i++)
      {
        for (var j = 0; j < leader[i].Length; j++)
        {
          var tmp = new StringBuilder();
          tmp.Append("<anno ");
          foreach (var layerName in layerNames)
            if (layerName != "Wort")
              tmp.Append($"{layerName.ToLower().Replace(" ", "_")}=\"{multiDoc[layerName][i][j]}\" ");
          tmp.Append($">{multiDoc["Wort"][i][j]}</anno>");
          stb.Append(tmp);
          tmp.Clear();
        }
      }

      return stb.ToString();
    }
  }
}
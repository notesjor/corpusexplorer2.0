using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model
{
  public class LayerValueState : AbstractLayerState
  {
    private readonly int _valueIndex;

    public LayerValueState(string displayname, int valueIndex) : base(displayname)
    {
      _valueIndex = valueIndex;
    }

    public int MinimumDataLength { get; set; } = 1;

    public void AddCompleteDocument(Guid documentGuid, string[][] documentTokens)
    {
      AddCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
    }

    public void AddCompleteDocument(Guid documentGuid, IEnumerable<IEnumerable<string>> documentTokens)
    {
      AddCompleteDocument(documentGuid, ConvertToLayer(documentTokens));
    }

    public override bool AllowAnnotation(string[] data)
    {
      return data.Length > MinimumDataLength;
    }

    public override bool AllowValueChange(string[] data)
    {
      return data.Length > MinimumDataLength;
    }

    public int[][] ConvertToLayer(IEnumerable<IEnumerable<string>> document)
    {
      return ConvertToLayer(document.Select(s => s.ToArray()).ToArray());
    }

    public int[][] ConvertToLayer(string[][] document)
    {
      lock (CacheLock)
      {
        var res = new int[document.Length][];

        for (var i = 0; i < document.Length; i++)
        {
          res[i] = new int[document[i].Length];
          for (var j = 0; j < document[i].Length; j++)
            if (Cache.ContainsKey(document[i][j]))
            {
              res[i][j] = Cache[document[i][j]];
            }
            else
            {
              res[i][j] = Cache.Count;
              Cache.Add(document[i][j], Cache.Count);
            }
        }

        return res;
      }
    }

    public int[] ConvertToLayer(string[] layerValues)
    {
      lock (CacheLock)
      {
        var res = new int[layerValues.Length];

        for (var i = 0; i < layerValues.Length; i++)
          if (Cache.ContainsKey(layerValues[i]))
          {
            res[i] = Cache[layerValues[i]];
          }
          else
          {
            res[i] = Cache.Count;
            Cache.Add(layerValues[i], Cache.Count);
          }

        return res;
      }
    }

    public int ConvertToLayer(string layerValue)
    {
      return base.RequestIndex(layerValue);
    }

    public override int RequestIndex(string[] data, int lastIndex)
    {
      return RequestIndex(data[_valueIndex]);
    }

    private void AddCompleteDocument(Guid documentGuid, int[][] documentTokens)
    {
      if (!Documents.ContainsKey(documentGuid))
        Documents.Add(documentGuid, documentTokens);
    }
  }
}
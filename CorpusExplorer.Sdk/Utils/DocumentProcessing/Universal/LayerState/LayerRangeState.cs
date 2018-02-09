using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState
{
  public class LayerRangeState : AbstractLayerState
  {
    private readonly List<TaggerLayerRangeStateItem> _ranges = new List<TaggerLayerRangeStateItem>();

    public LayerRangeState(string displayname)
      : base(displayname)
    {
      Documents = new Dictionary<Guid, int[][]>();
      Cache = new Dictionary<string, int>();
    }

    public void AddRange(Func<string, bool> start, Func<string, string> value, Func<string, bool> end) { _ranges.Add(new TaggerLayerRangeStateItem(start, value, end)); }

    public override bool AllowAnnotation(string[] data) { return data.Length != 1; }

    public override bool AllowValueChange(string[] data) { return data.Length == 1; }

    public override int RequestIndex(string[] data, int lastIndex)
    {
      foreach (var range in _ranges)
      {
        if (range.LocateStart(data[0]))
          return RequestIndex(range.LocateValue(data[0]));
        if (range.LocateEnd(data[0]))
          return RequestIndex(" ");
      }
      return lastIndex;
    }

    private class TaggerLayerRangeStateItem
    {
      public TaggerLayerRangeStateItem(Func<string, bool> start, Func<string, string> value, Func<string, bool> end)
      {
        LocateStart = start;
        LocateValue = value;
        LocateEnd = end;
      }

      public Func<string, bool> LocateEnd { get; }
      public Func<string, bool> LocateStart { get; }
      public Func<string, string> LocateValue { get; }
    }
  }
}
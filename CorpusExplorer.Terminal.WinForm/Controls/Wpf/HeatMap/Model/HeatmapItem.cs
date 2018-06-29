#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.HeatMap.Model
{
  public class HeatmapItem : IHeatmapItem
  {
    public HeatmapItem(string name, long size)
    {
      Name = name;
      Size = size;
    }

    public List<IHeatmapItem> Children => null;

    public string Name { get; }
    public long Size { get; }
  }
}
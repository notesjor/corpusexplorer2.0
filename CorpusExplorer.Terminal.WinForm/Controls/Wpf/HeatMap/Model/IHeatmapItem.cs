#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.HeatMap.Model
{
  public interface IHeatmapItem
  {
    List<IHeatmapItem> Children { get; }
    string Name { get; }
    long Size { get; }
  }
}
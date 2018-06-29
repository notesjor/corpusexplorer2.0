#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.HeatMap.Model
{
  public class HeatmapGroup : IHeatmapItem
  {
    public HeatmapGroup(string name, IEnumerable<IHeatmapItem> children)
    {
      Name = name;
      Children = children.ToList();
    }

    public List<IHeatmapItem> Children { get; }
    public string Name { get; }

    public long Size
    {
      get { return Children.Sum(child => child.Size); }
    }
  }
}
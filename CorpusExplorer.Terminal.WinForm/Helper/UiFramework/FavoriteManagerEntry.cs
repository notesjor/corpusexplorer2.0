using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  [Serializable]
  public class FavoriteManagerEntry
  {
    [NonSerialized] public RadPageViewPage Page;

    public string Title { get; set; }
    public Image Image { get; set; }
    public string ModulePage { get; set; }
    public bool IsPinned { get; set; }
    public int Count { get; set; }
  }
}
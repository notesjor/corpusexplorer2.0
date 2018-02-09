using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class RadPageViewHelper
  {
    public static void MakeHeaderInvisible(this RadPageView radPageView)
    {
      radPageView.GetChildAt(0).GetChildAt(0).Visibility = ElementVisibility.Collapsed;
      radPageView.GetChildAt(0).GetChildAt(1).Padding = new Padding(5);
      radPageView.GetChildAt(0).GetChildAt(1).BorderThickness = new Padding(0);
      ((RadPageViewContentAreaElement) radPageView.GetChildAt(0).GetChildAt(1)).BorderWidth = 0;
    }
  }
}
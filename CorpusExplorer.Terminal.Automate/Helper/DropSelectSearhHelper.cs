using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate.Helper
{
  public static class DropSelectSearhHelper
  {
    public static void SelectValue(this RadDropDownList list, string value)
    {
      var idx = -1;
      for (var i = 0; i < list.Items.Count; i++)
      {
        if (list.Items[i].Text != value) 
          continue;

        idx = i;
        break;
      }
      if(idx > -1)
        list.SelectedIndex = idx;
    }
  }
}

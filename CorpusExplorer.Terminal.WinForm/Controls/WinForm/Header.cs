using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public class Header : RadLabel
  {
    private string _head = "HeaderHead";
    private string _description = "HeaderSecribtion";

    public Header()
    {
      AutoSize = false;
    }

    public string HeaderDescription
    {
      get => _description;
      set
      {
        _description = value;
        RefreshText();
      }
    }

    public string HeaderHead
    {
      get => _head;
      set
      {
        _head = value;
        RefreshText();
      }
    }

    private void RefreshText()
    {
      Text = $"<html><span style=\"font-size:14.5pt\">{HeaderHead}</span><br/><span style=\"font-size:11pt\">{HeaderDescription}</span></html>";
    }
  }
}

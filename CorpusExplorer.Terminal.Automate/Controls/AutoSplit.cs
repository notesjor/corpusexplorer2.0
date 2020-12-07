using System;
using System.ComponentModel;
using CorpusExplorer.Terminal.Automate.Controls.Abstract;

namespace CorpusExplorer.Terminal.Automate.Controls
{
  [ToolboxItem(true)]
  public partial class AutoSplit : AbstractControl
  {
    public AutoSplit()
    {
      InitializeComponent();
      drop_type.SelectedIndex = 0;
    }

    private void drop_type_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      switch (drop_type.SelectedIndex)
      {
        case 0:
          panle_date.Visible = panel_size.Visible = false;
          break;
        case 1:
        case 2:
          panel_size.Visible = true;
          panle_date.Visible = false;
          break;
        case 3:
          drop_date.SelectedIndex = 4;
          panle_date.Visible = true;
          break;
      }
      DataChanged?.Invoke(null, null);
    }

    private void drop_date_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      panel_size.Visible = drop_date.SelectedIndex == 0;
      DataChanged?.Invoke(null, null);
    }

    public string Result
    {
      get
      {
        if (string.IsNullOrEmpty(txt_meta.Text))
          return null;

        try
        {
          var res = $"XS{txt_meta.Text.Trim()}::";
          switch (drop_type.SelectedIndex)
          {
            case 0:
              res += "TEXT";
              break;
            case 1:
              res += $"INT;{txt_size.Text}";
              break;
            case 2:
              res += $"FLOAT;{txt_size.Text}";
              break;
            case 3:
              res += $"{GetDateCommand()}{(drop_date.SelectedIndex == 0 ? $";{txt_size.Text}" : "")}";
              break;
          }

          return res;
        }
        catch
        {
          return null;
        }
      }
    }

    private string GetDateCommand()
    {
      if (drop_date.SelectedIndex == -1)
        return null;

      var txt = drop_date.SelectedItem.Text;
      var f = txt.IndexOf("=");
      return txt.Substring(0, f - 1).Trim();
    }

    public event EventHandler DataChanged;

    private void datachange_textbox(object sender, EventArgs e)
    {
      DataChanged?.Invoke(null, null);
    }
  }
}

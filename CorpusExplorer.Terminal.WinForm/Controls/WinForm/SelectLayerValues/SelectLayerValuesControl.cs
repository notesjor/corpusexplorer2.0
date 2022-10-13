using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.SelectLayerValues
{
  [ToolboxItem(true)]
  public partial class SelectLayerValuesControl : AbstractUserControl
  {
    private string _selectedLayerDisplayname;
    private string[] _values;

    public SelectLayerValuesControl()
    {
      InitializeComponent();
      Load += OnLoad;
    }

    public IEnumerable<string> ResultQueries
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(radAutoCompleteBox1.Text)
                   ? new string[0]
                   : radAutoCompleteBox1.Text.Split(Sdk.Helper.Splitter.Semicolon, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => x.Trim());
        }
        catch
        {
          return new string[0];
        }
      }
      set
      {
        if (value != null)
          radAutoCompleteBox1.Text = string.Join(";", value);
      }
    }

    public string SelectedLayerDisplayname
    {
      get => _selectedLayerDisplayname;
      set
      {
        if (string.IsNullOrEmpty(value))
          return;
        if (CorpusExplorerEcosystem.CurrentProject == null)
          return;
        if (!new HashSet<string>(CorpusExplorerEcosystem.CurrentProject.LayerDisplaynames).Contains(value))
          return;

        _selectedLayerDisplayname = value;
        _values = CorpusExplorerEcosystem.CurrentProject.GetLayerValues(value).ToArray();
        radAutoCompleteBox1.AutoCompleteDataSource = _values;
      }
    }

    public IEnumerable<string> AllLayerValues => _values;

    private void OnLoad(object sender, EventArgs e)
    {
      SelectedLayerDisplayname = "Wort";
    }
  }
}
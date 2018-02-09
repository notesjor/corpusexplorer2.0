using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.LayerSelection.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection
{
  public partial class _1LayerSelection : AbstractLayerSelection
  {
    public _1LayerSelection(IEnumerable<string> availableLayers, Dictionary<string, string> layerDictionary)
      : base(availableLayers, layerDictionary)
    {
      InitializeComponent();

      combo_layer1.DataSource = availableLayers;
      LayerDictionary = layerDictionary;

      var arr = layerDictionary.ToArray();
      combo_layer1.SelectedValue = arr[0].Key;
      txt_layer1.Text = arr[0].Value;
    }

    private void _1LayerSelection_ButtonOkClick(object sender, EventArgs e)
    {
      LayerDictionary = new Dictionary<string, string>
      {
        {combo_layer1.SelectedValue.ToString(), txt_layer1.Text}
      };
    }
  }
}
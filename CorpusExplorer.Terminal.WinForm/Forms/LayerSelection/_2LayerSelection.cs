using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.LayerSelection.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection
{
  public partial class _2LayerSelection : AbstractLayerSelection
  {
    public _2LayerSelection(IEnumerable<string> availableLayers, Dictionary<string, string> layerDictionary)
      : base(availableLayers, layerDictionary)
    {
      InitializeComponent();

      combo_layer1.DataSource = availableLayers;
      combo_layer2.DataSource = availableLayers;

      LayerDictionary = layerDictionary;

      var arr = layerDictionary.ToArray();
      combo_layer1.SelectedValue = arr[0].Key;
      combo_layer2.SelectedValue = arr[1].Key;

      txt_layer1.Text = arr[0].Value;
      txt_layer2.Text = arr[1].Value;
    }

    private void _2LayerSelection_ButtonOkClick(object sender, EventArgs e)
    {
      LayerDictionary = new Dictionary<string, string>
      {
        {combo_layer1.SelectedValue.ToString(), txt_layer1.Text},
        {combo_layer2.SelectedValue.ToString(), txt_layer2.Text}
      };
    }
  }
}
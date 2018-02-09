using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Forms.LayerSelection.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection
{
  public static class LayerSelectionHelper
  {
    public static Dictionary<string, string> AskForSelectedLayers(
      IEnumerable<string> availableLayers,
      Dictionary<string, string> definedLayers)
    {
      AbstractLayerSelection form;
      switch (definedLayers.Count)
      {
        case 1:
          form = new _1LayerSelection(availableLayers, definedLayers);
          break;
        case 2:
          form = new _2LayerSelection(availableLayers, definedLayers);
          break;
        case 3:
          form = new _3LayerSelection(availableLayers, definedLayers);
          break;
        default:
          throw new ArgumentException(Resources.DefinedLayersCountMussImBereich1Bis3Liegen);
      }
      return form.ShowDialog() == DialogResult.OK ? form.LayerDictionary : null;
    }
  }
}
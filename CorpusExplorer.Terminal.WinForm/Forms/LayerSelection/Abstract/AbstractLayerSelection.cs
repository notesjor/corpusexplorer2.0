using System.Collections.Generic;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection.Abstract
{
  public partial class AbstractLayerSelection : AbstractDialog
  {
    protected AbstractLayerSelection() { InitializeComponent(); }

    public AbstractLayerSelection(IEnumerable<string> availableLayers, Dictionary<string, string> layerDictionary)
    {
      AvailableLayers = availableLayers;
      LayerDictionary = layerDictionary;
      InitializeComponent();
    }

    protected IEnumerable<string> AvailableLayers { get; set; }

    public Dictionary<string, string> LayerDictionary { get; set; }
  }
}
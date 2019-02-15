using System;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  public partial class Select1Layer : AbstractSelectLayer
  {
    public Select1Layer(string[] initValues = null)
    {
      InitializeComponent();
      if (initValues == null)
        return;

      layerSettings1.SelectLayer(initValues[0]);
    }

    #region ALL

    private void Form_ButtonOkClick(object sender, EventArgs e)
    {
      Error = null;

      if (string.IsNullOrEmpty(ResultSelectedLayer1Displayname))
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer1Header}\" aus.";
    }

    #endregion

    #region Layer1

    public string Layer1Header
    {
      get => layerSettings1.Header;
      set => layerSettings1.Header = value;
    }

    public string ResultSelectedLayer1Displayname => layerSettings1.ResultSelectedLayer;
    public string[] ResultSelectedLayerDisplaynames => new[] {ResultSelectedLayer1Displayname};

    #endregion
  }
}
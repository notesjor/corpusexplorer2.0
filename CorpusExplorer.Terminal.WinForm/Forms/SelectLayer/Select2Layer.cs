using System;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  public partial class Select2Layer : AbstractSelectLayer
  {
    public Select2Layer(string[] initValues = null)
    {
      InitializeComponent();
      if (initValues == null)
        return;
      var values = initValues.ToArray();

      layerSettings1.SelectLayer(values[0]);
      layerSettings2.SelectLayer(values[1]);
    }

    #region Layer1

    public string Layer1Header
    {
      get => layerSettings1.Header;
      set => layerSettings1.Header = value;
    }

    public string ResultSelectedLayer1Displayname => layerSettings1.ResultSelectedLayer;
    public bool ResultUseLayer1 => true;

    #endregion

    #region Layer2

    public bool IsLayer2Optional
    {
      get => layerSettings2.IsLayerOptional;
      set => layerSettings2.IsLayerOptional = value;
    }

    public string Layer2Header
    {
      get => layerSettings2.Header;
      set => layerSettings2.Header = value;
    }

    public string ResultSelectedLayer2Displayname => layerSettings2.ResultSelectedLayer;
    public bool ResultUseLayer2 => layerSettings2.ResultUseLayer;

    #endregion

    #region ALL

    public string[] ResultSelectedLayerDisplaynames =>
      ResultUseLayer2
        ? new[] { ResultSelectedLayer1Displayname, ResultSelectedLayer2Displayname }
        : new[] { ResultSelectedLayer1Displayname };

    private void Form_ButtonOkClick(object sender, EventArgs e)
    {
      Error = null;

      if (string.IsNullOrEmpty(ResultSelectedLayer1Displayname))
      {
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer1Header}\" aus.";
        return;
      }

      if (ResultUseLayer2 && string.IsNullOrEmpty(ResultSelectedLayer2Displayname))
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer2Header}\" aus." + (IsLayer2Optional
                                                                                        ? " Alternativ können Sie auch den Haken entfernen, um diesen Layer nicht zu analysieren."
                                                                                        : "");
    }

    #endregion
  }
}
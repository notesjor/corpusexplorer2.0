using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  public partial class Select3Layer : AbstractSelectLayer
  {
    public Select3Layer(IEnumerable<string> initValues = null)
    {
      InitializeComponent();

      if (initValues == null)
        return;
      var values = initValues.ToArray();

      if (values.Length > 0)
        layerSettings1.SelectLayer(values[0]);
      if (values.Length > 1)
        layerSettings2.SelectLayer(values[1]);
      if (values.Length > 2)
        layerSettings3.SelectLayer(values[2]);
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

    #region Layer3

    public bool IsLayer3Optional
    {
      get => layerSettings3.IsLayerOptional;
      set => layerSettings3.IsLayerOptional = value;
    }

    public string Layer3Header
    {
      get => layerSettings3.Header;
      set => layerSettings3.Header = value;
    }

    public string ResultSelectedLayer3Displayname => layerSettings3.ResultSelectedLayer;
    public bool ResultUseLayer3 => layerSettings3.ResultUseLayer;

    #endregion

    #region ALL

    public string[] ResultSelectedLayerDisplaynames => ResultUseLayer2
      ? (ResultUseLayer3
        ? new[]
          {ResultSelectedLayer1Displayname, ResultSelectedLayer2Displayname, ResultSelectedLayer3Displayname}
        : new[] {ResultSelectedLayer1Displayname, ResultSelectedLayer2Displayname})
      : (ResultUseLayer3
        ? new[] {ResultSelectedLayer1Displayname, ResultSelectedLayer3Displayname}
        : new[] {ResultSelectedLayer1Displayname});

    private void Form_ButtonOkClick(object sender, EventArgs e)
    {
      Error = null;

      if (string.IsNullOrEmpty(ResultSelectedLayer1Displayname))
      {
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer1Header}\" aus.";
        return;
      }

      if (ResultUseLayer2 && string.IsNullOrEmpty(ResultSelectedLayer2Displayname))
      {
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer2Header}\" aus." + (IsLayer2Optional
                  ? " Alternativ können Sie auch den Haken entfernen, um diesen Layer nicht zu analysieren."
                  : "");
        return;
      }

      if (ResultUseLayer3 && string.IsNullOrEmpty(ResultSelectedLayer3Displayname))
      {
        Error = $"Bitte wählen Sie zuerst einen Layer für \"{Layer3Header}\" aus." + (IsLayer2Optional
                  ? " Alternativ können Sie auch den Haken entfernen, um diesen Layer nicht zu analysieren."
                  : "");
      }
    }

    #endregion
  }
}
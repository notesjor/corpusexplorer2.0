using System;
using System.Text.RegularExpressions;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.RegEx
{
  public partial class RegExForm : AbstractSelectLayer
  {
    public RegExForm(string[] initValues, string regEx = "")
    {
      InitializeComponent();
      if (initValues == null)
        return;

      layerSettings1.SelectLayer(initValues[0]);
      txt_regex.Text = regEx;
    }

    public string SelectColumn => layerSettings1.ResultSelectedLayer;

    public string RegularExpression
    {
      get => txt_regex.Text;
      set => txt_regex.Text = value;
    }

    private void Form_ButtonOkClick(object sender, EventArgs e)
    {
      Error = null;

      if (string.IsNullOrEmpty(SelectColumn))
        Error = "Bitte wählen Sie zuerst eine Spalte aus.";

      try
      {
        var regex = new Regex(txt_regex.Text);
        if (regex.IsMatch("CorpusExplorerV2.0-JOR-2018"))
          Error = "Easteregg: Haben Sie gefunden, wonach Sie gesucht haben?";
      }
      catch
      {
        Error = "Bitte überprüfen Sie den Regulären Ausdruck - dieser ist aktuell nicht valide.";
      }
    }
  }
}
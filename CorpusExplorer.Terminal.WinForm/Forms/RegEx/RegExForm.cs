using System;
using System.Text.RegularExpressions;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.RegEx
{
  public partial class RegExForm : AbstractSelectLayer
  {
    private readonly string[] _initValues;

    public RegExForm(string[] initValues, string regEx = "")
    {
      _initValues = initValues;
      InitializeComponent();
      if (initValues == null)
        return;

      radDropDownList1.DataSource = _initValues;
      radDropDownList1.SelectedIndex = 0;
      txt_regex.Text = regEx;
    }

    public string SelectColumn => _initValues[radDropDownList1.SelectedIndex];

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
        var regex = new Regex("CorpusExplorerV2.0-JOR-2018");
        if (regex.IsMatch(txt_regex.Text))
          Error = "Easteregg: Haben Sie gefunden, wonach Sie gesucht haben?";
      }
      catch
      {
        Error = "Bitte überprüfen Sie den Regulären Ausdruck - dieser ist aktuell nicht valide.";
      }
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  public partial class PosFilter : AbstractSelectLayer
  {
    private Dictionary<string, AbstractWordBagBuilderOperator> _operators;
    private Selection _selection;
    private readonly string _layer1Displayname;
    private string[] _tokens;

    public PosFilter(Selection selection, string layer1Displayname)
    {
      InitializeComponent();
      if (selection == null)
        return;

      _selection = selection;
      _layer1Displayname = layer1Displayname;
      layerSettings1.RemoveLayerFromSelection(layer1Displayname);

      _operators = new Dictionary<string, AbstractWordBagBuilderOperator>
      {
        {"Startet mit...", new WordBagBuilderOperatorStartsWith()},
        {"Startet mit (case-sensitive)...", new WordBagBuilderOperatorStartsWithCaseSensitive()},
        {"Endet mit...", new WordBagBuilderOperatorEndsWith()},
        {"Endet mit (case-sensitive)...", new WordBagBuilderOperatorEndsWithCaseSensitive()},
        {"Wildcard-Filter [*]", new WordBagBuilderOperatorContains()},
        {"Wildcard-Filter [*] (case-sensitive)", new WordBagBuilderOperatorContainsCaseSensitive()},
        {"Regulärer Ausdruck", new WordBagBuilderOperatorRegex()}
      };

      drop_operator.Items.AddRange(_operators.Keys);
    }

    private void layerSettings1_SlectedLayerChanged(object sender, System.EventArgs e)
    {
      _tokens = _selection.GetLayerValues(layerSettings1.ResultSelectedLayer).ToArray();
      txt_results.AutoCompleteDataSource = _tokens;
    }

    private void PosFilter_Load(object sender, System.EventArgs e)
    {
      drop_operator.SelectedIndex = 0;
      layerSettings1.SelectLayer("POS");
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      if (!_operators.ContainsKey(drop_operator.SelectedItem.Text))
        return;
      if (string.IsNullOrWhiteSpace(txt_query.Text))
        return;

      try
      {
        var opr = _operators[drop_operator.SelectedItem.Text];
        opr.Initialize(txt_query.Text);

        txt_results.Text += $"{string.Join(";", _tokens.Where(t => opr.IsMatch(t)))};";
      }
      catch
      {
        // ignore
      }
    }

    public CorrespondingLayerValueFilterViewModel Result
    {
      get
      {
        if (DialogResult != DialogResult.OK)
          return null;

        var res = new CorrespondingLayerValueFilterViewModel
        {
          Selection = _selection,
          Layer1Displayname = _layer1Displayname,
          Layer2Displayname = layerSettings1.ResultSelectedLayer,
          Layer2ValueFilters = new HashSet<string>(txt_results.Text.Split(new[] { ";", " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)),
          AnyMatch = !chk_all.Checked
        };
        res.Execute();

        return res;
      }
    }

    public bool ShowAllOption
    {
      get => radGroupBox4.Visible;
      set => radGroupBox4.Visible = value;
    }

    private void PosFilter_ButtonOkClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(txt_results.Text))
      {
        MessageBox.Show("Sie müssen mindestens einen korrespondierenden Wert festlegen.", "Keine Werte",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
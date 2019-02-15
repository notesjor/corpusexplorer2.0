using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;

#region

using System;
using System.Drawing;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  public partial class CooccurrenceDiversity : AbstractView
  {
    private CooccurrencePolarisationViewModel _vm;

    public CooccurrenceDiversity()
    {
      InitializeComponent();
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      _vm.LayerValueA = txt_queryA.Text;
      _vm.LayerValueB = txt_queryB.Text;

      if (!_vm.Execute())
        return;

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.SortDescriptors.Clear();
      radGridView1.SortDescriptors.Add(new GridSortField(Resources.Polarisation, RadSortOrder.Ascending));
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(radGridView1);
    }

    private void btn_snapshot_create_Click(object sender, EventArgs e)
    {
      var main = new[] {txt_queryA.Text, txt_queryB.Text};
      CreateSelection(
                      from m in main
                      from row in radGridView1.SelectedRows
                      select
                        new FilterQuerySingleLayerAllInOneSentence
                        {
                          LayerDisplayname = "Wort",
                          Inverse = false,
                          LayerQueries =
                            new[] {m, row.Cells[Resources.Kookkurrenz].Value.ToString()}
                        });
    }

    private void btn_startB_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.BerechneKookkurrenzen, Analyse);
    }

    private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
    {
      var val = (double) e.RowElement.RowInfo.Cells[Resources.Polarisation].Value;

      var cal = (int) Math.Round(Math.Abs(val) * 255.0, MidpointRounding.AwayFromZero);
      if (cal > 255)
        cal = 255;
      if (cal < 0)
        cal = 0;

      e.RowElement.DrawFill = true;
      e.RowElement.GradientStyle = GradientStyles.Solid;
      e.RowElement.BackColor = val > 0 ? Color.FromArgb(cal, 255, 0, 0) : Color.FromArgb(cal, 0, 255, 0);
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vm = GetViewModel<CooccurrencePolarisationViewModel>();
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }
  }
}
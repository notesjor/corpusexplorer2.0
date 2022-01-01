#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Simple.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleGrid : AbstractDialog
  {
    public SimpleGrid(DataTable table, string windowTitle = null)
    {
      InitializeComponent();

      if (!string.IsNullOrWhiteSpace(windowTitle))
        Text = windowTitle;

      radGridView1.DataSource = table;
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    private void btn_export_Click(object sender, System.EventArgs e)
    {
      DataTableExporter.Export(radGridView1);
    }
  }
}
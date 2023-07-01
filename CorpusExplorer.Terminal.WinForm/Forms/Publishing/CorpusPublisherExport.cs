using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public partial class CorpusPublisherExport : AbstractForm
  {
    public Dictionary<AbstractExporter, string> ResultFirstFileExtension = new Dictionary<AbstractExporter, string>();

    public CorpusPublisherExport()
    {
      InitializeComponent();

      var exporter = Configuration.AddonExporters.Where(x => !x.Key.Contains("CorpusExplorer v6") && !x.Key.Contains("Abfragen") && !x.Key.Contains("+ ZIP"));
      foreach (var x in exporter)
        list_formats.Items.Add(new ListViewDataItem(x.Key.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[0]) { Tag = x.Value });
    }

    public IEnumerable<AbstractExporter> Result
    {
      get
      {
        var res = new List<AbstractExporter>();
        res.Add(new ExporterCec6());

        ResultFirstFileExtension.Add(new ExporterCec6(), ".cec6");

        foreach (var item in list_formats.Items.Where(x => x.CheckState == ToggleState.On))
        {
          var exporter = item.Tag as AbstractExporter;
          res.Add(exporter);
          ResultFirstFileExtension.Add(exporter, FileExtensionHelper.GetPreferredExtension(exporter).First().Replace("*", ""));
        }
        return res;
      }
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Abort;
      Close();
    }
  }
}

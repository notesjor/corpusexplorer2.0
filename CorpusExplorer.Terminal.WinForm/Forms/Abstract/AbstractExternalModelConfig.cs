using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Blocks.NamedEntityRecognition;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace CorpusExplorer.Terminal.WinForm.Forms.NamedEntity
{
  public partial class AbstractExternalModelConfig : AbstractDialog
  {
    public AbstractExternalModelConfig()
    {
      InitializeComponent();
      if (!string.IsNullOrEmpty(ModelDefaultPath))
        LoadFile(ModelDefaultPath);
    }

    public string ModelDisplayname { get; set; }
    
    private void btn_open_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = Properties.Resources.FileExtension_TSV };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      LoadFile(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = Properties.Resources.FileExtension_TSV };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var csv = new ExportToCSV(radGridView1)
      {
        Encoding = Configuration.Encoding,
        ColumnDelimiter = "\t",
        EncloseDataWithQuotes = false,
        RowDelimiter = "\r\n", 
        FileExtension = "tsv"
      };
      csv.RunExport(sfd.FileName);
    }

    private void LoadFile(string fileName)
    {
      Processing.Invoke("Lade Daten..", () =>
      {
        ModelDisplayname = Path.GetFileNameWithoutExtension(fileName);

        var lines = FileIO.ReadLines(fileName, Configuration.Encoding);
        var delimiter = lines[0].Contains("\t") ? "\t" : ";";
        var dt = ConvertToDataTable(lines.Select(line => line.Split(new[] { delimiter }, StringSplitOptions.None)).ToArray());

        radGridView1.DataSource = null;
        radGridView1.Columns.Clear();
        radGridView1.DataSource = dt;

        LoadFilePostProcess(radGridView1);

        radGridView1.AllowAutoSizeColumns = true;
        radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
      });
    }

    protected DataTable ConvertToDataTable(string[][] data)
    {
      var dt = new System.Data.DataTable();
      for (var i = 0; i < data[0].Length; i++)
        dt.Columns.Add(data[0][i], typeof(string));

      dt.BeginLoadData();
      for (var i = 1; i < data.Length; i++)
        dt.Rows.Add(data[i].Select(x=>(object)x).ToArray());
      dt.EndLoadData();

      return dt;
    }

    public T GetModel<T>()
    {
      var res = ConvertToModel(radGridView1);
      if (res == null)
        return default(T);
      if (!(res is T t))
        return default(T);
      return t;
    }

    #region virtual
    protected virtual void LoadFilePostProcess(RadGridView radGridView) { }
    
    protected virtual string ModelDefaultPath { get; } = null;

    protected virtual object ConvertToModel(RadGridView radGridView) => null;
    #endregion
  }
}
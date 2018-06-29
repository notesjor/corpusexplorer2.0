using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Blocks.NamedEntityRecognition;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Rule = CorpusExplorer.Sdk.Blocks.NamedEntityRecognition.Rule;

namespace CorpusExplorer.Terminal.WinForm.Forms.NamedEntity
{
  public partial class NamedEntityConfiguration : AbstractDialog
  {
    public NamedEntityConfiguration()
    {
      InitializeComponent();
      LoadFile(Configuration.GetDependencyPath("NamedEntityRecognition/PredefinedModels/dbPedia_persondata_de_pol.ner"));
    }

    public string ModelDisplayname { get; set; }

    public Model Model
    {
      get
      {
        var res = new Model {Displayname = ModelDisplayname};
        var entities = new List<Entity>();
        var hashset = new HashSet<string>();
        foreach (var row in radGridView1.Rows)
        {
          var name = row.Cells[0].Value.ToString();
          if (string.IsNullOrEmpty(name))
            continue;
          if (hashset.Contains(name))
            continue;
          hashset.Add(name);
          
          var context = new List<string> {row.Cells[2].Value.ToString()};
          context.AddRange(row.Cells[3].Value.ToString().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
          entities.Add(new Entity
          {
            Name = name,
            Rules = new List<Rule>
            {
              new Rule
              {
                Rank = 1.0,
                Filter = new FilterQuerySingleLayerExactPhrase
                {
                  LayerDisplayname = "Wort",
                  LayerQueries = row.Cells[0].Value.ToString().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                }
              },
              /*
              new Rule
              {
                Rank = 0.8,
                Filter = new FilterQuerySingleLayerAnyMatch
                {
                  LayerDisplayname = "Wort",
                  LayerQueries = row.Cells[2].Value.ToString().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                }
              },
              new Rule
              {
                Rank = 1.0,
                Filter = new FilterQuerySingleLayerFirstAndAnyOtherMatch
                {
                  LayerDisplayname = "Wort",
                  LayerQueries = context.ToArray()
                }
              }
              */
            }.ToArray()
          });
        }

        res.Entities = entities.ToArray();
        return res;
      }
    }

    private const string Filter = "NER-Datei (*.ner)|*.ner";

    private void btn_open_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = Filter};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      LoadFile(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = Filter};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var csv = new ExportToCSV(radGridView1) {Encoding = Configuration.Encoding};
      csv.RunExport(sfd.FileName);
    }

    private void LoadFile(string fileName)
    {
      Processing.Invoke("Lade Liste mit bekannten Entitäten...", () =>
      {
        ModelDisplayname = Path.GetFileNameWithoutExtension(fileName);

        var lines = FileIO.ReadLines(fileName, Configuration.Encoding);
        IReadOnlyList<object[]> csv = lines.Select(line => line.Split(new[] {"\t"}, StringSplitOptions.None)).ToArray();

        var dt = new DataTable();
        dt.Columns.Add("entity", typeof(string));
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("surname", typeof(string));
        dt.Columns.Add("context", typeof(string));

        dt.BeginLoadData();
        for (var i = 1; i < csv.Count; i++)
          dt.Rows.Add(csv[i]);
        dt.EndLoadData();

        radGridView1.Columns.Clear();
        radGridView1.DataSource = dt;
        radGridView1.Columns["entity"].HeaderText = "Entität";
        radGridView1.Columns["name"].HeaderText = "Vorname";
        radGridView1.Columns["surname"].HeaderText = "Nachname";
        radGridView1.Columns["context"].HeaderText = "Kontext";
        radGridView1.Columns["entity"].Name = "Entität";
        radGridView1.Columns["name"].Name = "Vorname";
        radGridView1.Columns["surname"].Name = "Nachname";
        radGridView1.Columns["context"].Name = "Kontext";

        radGridView1.AllowAutoSizeColumns = true;
        radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
      });
    }
  }
}
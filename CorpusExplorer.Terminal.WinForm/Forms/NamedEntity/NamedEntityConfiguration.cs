using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.NamedEntityRecognition;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.NamedEntity
{
  public partial class NamedEntityConfiguration : AbstractExternalModelConfig
  {
    public NamedEntityConfiguration()
    {
      InitializeComponent();
    }

    protected override void LoadFilePostProcess(RadGridView radGridView)
    {
      if (radGridView.Columns.Contains("name"))
        radGridView.Columns["name"].HeaderText = "Vorname";
      if (radGridView.Columns.Contains("surname"))
        radGridView.Columns["surname"].HeaderText = "Nachname";
      if (radGridView.Columns.Contains("context"))
        radGridView.Columns["context"].HeaderText = "Kontext";
      if (radGridView.Columns.Contains("entity"))
        radGridView.Columns["entity"].Name = "Entität";
    }

    protected override string ModelDefaultPath { get; } = Configuration.GetDependencyPath("NamedEntityRecognition/PredefinedModels/dbPedia_persondata_de_pol.ner");

    protected override object ConvertToModel(RadGridView radGridView)
    {
      var res = new Sdk.Blocks.NamedEntityRecognition.NamedEntityRecognitionModel { Displayname = ModelDisplayname };
      var entities = new List<Entity>();
      var hashset = new HashSet<string>();
      foreach (var row in radGridView.Rows)
      {
        var name = row.Cells[0].Value.ToString();
        if (string.IsNullOrEmpty(name))
          continue;
        if (hashset.Contains(name))
          continue;
        hashset.Add(name);

        var context = new List<string> { row.Cells[2].Value.ToString() };
        context.AddRange(row.Cells[3].Value.ToString().Split(Sdk.Helper.Splitter.Space, StringSplitOptions.RemoveEmptyEntries));
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
                LayerQueries = row.Cells[0].Value.ToString().Split(Sdk.Helper.Splitter.Space, StringSplitOptions.RemoveEmptyEntries)
              }
            }
            /*
            new Rule
            {
              Rank = 0.8,
              Filter = new FilterQuerySingleLayerAnyMatch
              {
                LayerDisplayname = "Wort",
                LayerQueries = row.Cells[2].Value.ToString().Split(Sdk.Helper.Splitter.Space, StringSplitOptions.RemoveEmptyEntries)
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
}

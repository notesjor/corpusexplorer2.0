using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI.Data;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  [ToolboxItem(false)]
  public partial class FulltextSnapshotControl : AbstractSnapshotControl
  {
    private const string MultiLayer = "Multi-Layer";
    private Guid _guid;
    private List<string> _layers;
    private Dictionary<AbstractFilterQuery, string> _queries;

    public FulltextSnapshotControl(Selection selection, AbstractFilterQuery query)
      : base(selection)
    {
      InitializeComponent();
      SetComboBoxes();

      _guid = Guid.NewGuid();

      if (query != null)
        LoadQuery(query);
    }

    public override AbstractFilterQuery Query
    {
      get
      {
        if (combo_layer.Text == MultiLayer)
          return new FilterQueryMultiLayerPhrase
          {
            MultiLayerValueSeparator = ":",
            MultiLayerQueries = txt_values.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)
              .Select(x => x.Trim()),
            Guid = _guid
          };
        // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (combo_query.SelectedValue is AbstractFilterQuerySingleLayer)
        {
          var query = (AbstractFilterQuerySingleLayer) combo_query.SelectedValue;
          query.LayerDisplayname = combo_layer.SelectedItem.Text;
          query.LayerQueries = txt_values.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim());
          query.Guid = _guid;
          return query;
        }

        // ReSharper disable once InvertIf
        // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
        if (combo_query.SelectedValue is FilterQuerySingleLayerExactPhrase)
        {
          var query = (FilterQuerySingleLayerExactPhrase) combo_query.SelectedValue;
          query.LayerDisplayname = combo_layer.SelectedItem.Text;
          query.LayerQueries = txt_values.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim());
          query.Guid = _guid;
          return query;
        }

        return null;
      }
    }

    private void combo_layer_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (combo_layer.Text == MultiLayer)
      {
        combo_query.Enabled = false;
        txt_values.AutoCompleteDataSource = from layer in _layers
          where layer != MultiLayer
          from v in Selection.GetLayerValues(layer)
          select $"{layer}:{v}";
        combo_query.SelectedIndex = 3;
      }
      else
      {
        combo_query.Enabled = true;
        txt_values.AutoCompleteDataSource = Selection.GetLayerValues(combo_layer.Text);
      }
    }

    private void LoadQuery(AbstractFilterQuery query)
    {
      switch (query)
      {
        case AbstractFilterQuerySingleLayer layer:
          combo_layer.SelectedValue = layer.LayerDisplayname;

          switch (layer)
          {
            case FilterQuerySingleLayerAnyMatch _:
              combo_query.SelectedValue = layer.Inverse ? _queries.ToArray()[4].Key : _queries.ToArray()[0].Key;
              break;
            case FilterQuerySingleLayerAllInOnDocument _:
              combo_query.SelectedValue = _queries.ToArray()[1].Key;
              break;
            case FilterQuerySingleLayerAllInOneSentence _:
              combo_query.SelectedValue = _queries.ToArray()[2].Key;
              break;
          }

          txt_values.Text = string.Join(";", layer.LayerQueries) + ";";
          break;
        case FilterQuerySingleLayerExactPhrase phrase:
          combo_layer.SelectedValue = phrase.LayerDisplayname;
          combo_query.SelectedValue = _queries.ToArray()[3].Key;
          txt_values.Text = string.Join(";", phrase.LayerQueries) + ";";
          break;
      }

      _guid = query.Guid;
    }

    private void SetComboBoxes()
    {
      // combo_layer
      _layers = Selection.LayerUniqueDisplaynames.ToList();
      _layers.Add(MultiLayer);
      combo_layer.DataSource = _layers;

      // combo_query
      _queries = new Dictionary<AbstractFilterQuery, string>
      {
        {
          new FilterQuerySingleLayerAnyMatch
          {
            Inverse = false,
            LayerDisplayname = "Wort"
          },
          Resources.Snapshot_Condition_AnyValue
        },
        {
          new FilterQuerySingleLayerAllInOnDocument
          {
            Inverse = false,
            LayerDisplayname = "Wort"
          },
          Resources.Snapshot_Condition_AllValues
        },
        {
          new FilterQuerySingleLayerAllInOneSentence
          {
            Inverse = false,
            LayerDisplayname = "Wort"
          },
          Resources.Snapshot_Condition_AllValuesInSentence
        },
        {
          new FilterQuerySingleLayerExactPhrase
          {
            Inverse = false,
            LayerDisplayname = "Wort"
          },
          Resources.Snapshot_Condition_Phrase
        },
        {
          new FilterQuerySingleLayerAnyMatch
          {
            Inverse = true,
            LayerDisplayname = "Wort"
          },
          Resources.Snapshot_Condition_Exclude
        }
      };

      DictionaryBindingHelper.BindDictionary(_queries, combo_query);
    }
  }
}
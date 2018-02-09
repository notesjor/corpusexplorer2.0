using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls.UI.Data;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  [ToolboxItem(false)]
  public partial class FulltextSnapshotControl : AbstractSnapshotControl
  {
    private const string MultiLayer = "Multi-Layer";
    private Guid _guid;
    private Dictionary<AbstractFilterQuery, string> _queries;
    private List<string> _layers;

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
        {
          return new FilterQueryMultiLayerPhrase
          {
            MultiLayerValueSeparator = ":",
            MultiLayerQueries = txt_values.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)
              .Select(x => x.Trim()),
            Guid = _guid
          };
        }
        // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (combo_query.SelectedValue is AbstractFilterQuerySingleLayer)
        {
          var query = (AbstractFilterQuerySingleLayer)combo_query.SelectedValue;
          query.LayerDisplayname = combo_layer.SelectedItem.Text;
          query.LayerQueries = txt_values.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
          query.Guid = _guid;
          return query;
        }
        // ReSharper disable once InvertIf
        // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
        if (combo_query.SelectedValue is FilterQuerySingleLayerExactPhrase)
        {
          var query = (FilterQuerySingleLayerExactPhrase)combo_query.SelectedValue;
          query.LayerDisplayname = combo_layer.SelectedItem.Text;
          query.LayerQueries = txt_values.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
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
        txt_values.AutoCompleteDataSource = (from layer in _layers where layer != MultiLayer from v in Selection.GetLayerValues(layer) select $"{layer}:{v}");
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
      if (query is AbstractFilterQuerySingleLayer)
      {
        combo_layer.SelectedValue = ((AbstractFilterQuerySingleLayer)query).LayerDisplayname;

        if (query is FilterQuerySingleLayerAnyMatch)
          combo_query.SelectedValue = query.Inverse ? _queries.ToArray()[4].Key : _queries.ToArray()[0].Key;
        if (query is FilterQuerySingleLayerAllInOnDocument)
          combo_query.SelectedValue = _queries.ToArray()[1].Key;
        if (query is FilterQuerySingleLayerAllInOneSentence)
          combo_query.SelectedValue = _queries.ToArray()[2].Key;

        txt_values.Text = string.Join(";", ((AbstractFilterQuerySingleLayer)query).LayerQueries) + ";";
      }
      else if (query is FilterQuerySingleLayerExactPhrase)
      {
        combo_layer.SelectedValue = ((FilterQuerySingleLayerExactPhrase)query).LayerDisplayname;
        combo_query.SelectedValue = _queries.ToArray()[3].Key;
        txt_values.Text = string.Join(";", ((FilterQuerySingleLayerExactPhrase)query).LayerQueries) + ";";
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
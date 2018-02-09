#region

using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.WinControls.UI.Data;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  [ToolboxItem(false)]
  public partial class MetadataSnapshotControl : AbstractSnapshotControl
  {
    private Guid _guid;
    private Dictionary<AbstractFilterQueryMeta, string> _queries;

    public MetadataSnapshotControl(Selection selection, AbstractFilterQueryMeta query)
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
        var query = combo_query.SelectedValue as AbstractFilterQueryMeta;
        if (query == null)
          return null;
        query.MetaLabel = combo_label.SelectedItem.Text;
        query.MetaValues = new[] { txt_values.Text };
        query.Guid = _guid;
        return query;
      }
    }

    private void combo_query_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (combo_query.SelectedValue.GetType() == typeof(FilterQueryMetaIsEmpty))
      {
        txt_values.Text = "";
        txt_values.ReadOnly = true;
        txt_values.NullText = Resources.Snapshot_NoInputAvailable;
      }
      else
      {
        txt_values.ReadOnly = false;
        txt_values.NullText = Resources.Snapshot_InsertValues;
      }
    }

    private void LoadQuery(AbstractFilterQueryMeta query)
    {
      var array = _queries.ToArray();
      combo_label.SelectedText = query.MetaLabel;
      txt_values.Text = (query.MetaValues == null) || !query.MetaValues.Any() ? "" : query.MetaValues.FirstOrDefault()?.ToString();

      if (query.GetType() == typeof(FilterQueryMetaContains))
        combo_query.SelectedValue = query.Inverse ? array[1] : array[0];
      else if (query.GetType() == typeof(FilterQueryMetaContainsCaseSensitive))
        combo_query.SelectedValue = query.Inverse ? array[3] : array[2];
      else if (query.GetType() == typeof(FilterQueryMetaRegex))
        combo_query.SelectedValue = query.Inverse ? array[5] : array[4];
      else if (query.GetType() == typeof(FilterQueryMetaIsEmpty))
        combo_query.SelectedValue = query.Inverse ? array[7] : array[6];
      else
        throw new TypeLoadException();

      _guid = query.Guid;
    }

    private void SetComboBoxes()
    {
      // combo_label
      combo_label.DataSource = Selection.GetDocumentMetadataPrototypeOnlyProperties();

      // combo_query
      _queries = new Dictionary<AbstractFilterQueryMeta, string>
      {
        {
          new FilterQueryMetaContains
          {
            Inverse = false
          },
          Resources.Snapshot_Contains
        },
        {
          new FilterQueryMetaContains
          {
            Inverse = true
          },
          Resources.Snapshot_NotContains
        },
        {
          new FilterQueryMetaContainsCaseSensitive
          {
            Inverse = false
          },
          Resources.Snapshot_ContainsCaseSensitive
        },
        {
          new FilterQueryMetaContainsCaseSensitive
          {
            Inverse = true
          },
          Resources.Snapshot_NotContainsCaseSensitive
        },
        {
          new FilterQueryMetaExactMatch
          {
            Inverse = false
          },
          "Ist gleich"
        },
        {
          new FilterQueryMetaExactMatch
          {
            Inverse = true
          },
          "Ist nicht"
        },              
        {
          new FilterQueryMetaExactMatchCaseSensitive
          {
            Inverse = false
          },
          "Ist gleich (beachte Groß- und Kleinschreibung)"
        },
        {
          new FilterQueryMetaExactMatchCaseSensitive
          {
            Inverse = true
          },
          "Ist nicht (beachte Groß- und Kleinschreibung)"
        },
        {
          new FilterQueryMetaRegex
          {
            Inverse = false
          },
          Resources.Snapshot_RegExMatch
        },
        {
          new FilterQueryMetaRegex
          {
            Inverse = true
          },
          Resources.Snapshot_RegExNotMatch
        },
        {
          new FilterQueryMetaIsEmpty
          {
            Inverse = false
          },
          Resources.Snapshot_MetaEmpty
        },
        {
          new FilterQueryMetaIsEmpty
          {
            Inverse = true
          },
          Resources.Snapshot_MetaNotEmpty
        }
      };

      DictionaryBindingHelper.BindDictionary(_queries, combo_query);
    }
  }
}
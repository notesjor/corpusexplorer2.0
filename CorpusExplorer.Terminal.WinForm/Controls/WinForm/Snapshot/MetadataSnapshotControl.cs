#region

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
        query.MetaValues = new[] {txt_values.Text};
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
      txt_values.Text = query.MetaValues == null || !query.MetaValues.Any()
        ? ""
        : query.MetaValues.FirstOrDefault()?.ToString();

      switch (query)
      {
        case FilterQueryMetaContains _:
          combo_query.SelectedValue = query.Inverse ? array[1] : array[0];
          break;
        case FilterQueryMetaContainsCaseSensitive _:
          combo_query.SelectedValue = query.Inverse ? array[3] : array[2];
          break;
        case FilterQueryMetaRegex _:
          combo_query.SelectedValue = query.Inverse ? array[5] : array[4];
          break;
        case FilterQueryMetaIsEmpty _:
          combo_query.SelectedValue = query.Inverse ? array[7] : array[6];
          break;
        case FilterQueryMetaExactMatch _:
          combo_query.SelectedValue = query.Inverse ? array[9] : array[8];
          break;
        case FilterQueryMetaExactMatchCaseSensitive _:
          combo_query.SelectedValue = query.Inverse ? array[11] : array[10];
          break;
        case FilterQueryMetaStartsWith _:
          combo_query.SelectedValue = query.Inverse ? array[13] : array[12];
          break;
        case FilterQueryMetaEndsWith _:
          combo_query.SelectedValue = query.Inverse ? array[15] : array[14];
          break;
        default:
          throw new TypeLoadException();
      }

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
          // 0
          new FilterQueryMetaContains
          {
            Inverse = false
          },
          Resources.Snapshot_Contains
        },
        {
          // 1
          new FilterQueryMetaContains
          {
            Inverse = true
          },
          Resources.Snapshot_NotContains
        },
        {
          // 2
          new FilterQueryMetaContainsCaseSensitive
          {
            Inverse = false
          },
          Resources.Snapshot_ContainsCaseSensitive
        },
        {
          // 3
          new FilterQueryMetaContainsCaseSensitive
          {
            Inverse = true
          },
          Resources.Snapshot_NotContainsCaseSensitive
        },
        {
          // 4
          new FilterQueryMetaRegex
          {
            Inverse = false
          },
          Resources.Snapshot_RegExMatch
        },
        {
          // 5
          new FilterQueryMetaRegex
          {
            Inverse = true
          },
          Resources.Snapshot_RegExNotMatch
        },
        {
          // 6
          new FilterQueryMetaIsEmpty
          {
            Inverse = false
          },
          Resources.Snapshot_MetaEmpty
        },
        {
          // 7
          new FilterQueryMetaIsEmpty
          {
            Inverse = true
          },
          Resources.Snapshot_MetaNotEmpty
        },
        {
          // 8
          new FilterQueryMetaExactMatch
          {
            Inverse = false
          },
          "Ist gleich"
        },
        {
          // 9
          new FilterQueryMetaExactMatch
          {
            Inverse = true
          },
          "Ist nicht"
        },
        {
          // 10
          new FilterQueryMetaExactMatchCaseSensitive
          {
            Inverse = false
          },
          "Ist gleich (beachte Groß- und Kleinschreibung)"
        },
        {
          // 11
          new FilterQueryMetaExactMatchCaseSensitive
          {
            Inverse = true
          },
          "Ist nicht (beachte Groß- und Kleinschreibung)"
        },
        {
          // 12
          new FilterQueryMetaStartsWith
          {
            Inverse = false
          },
          "Beginnt mit"
        },
        {
          // 13
          new FilterQueryMetaStartsWith
          {
            Inverse = true
          },
          "Beginnt nicht mit"
        },
        {
          // 14
          new FilterQueryMetaEndsWith
          {
            Inverse = false
          },
          "Endet auf"
        },
        {
          // 15
          new FilterQueryMetaEndsWith
          {
            Inverse = true
          },
          "Endet nicht auf"
        }
      };

      DictionaryBindingHelper.BindDictionary(_queries, combo_query);
    }
  }
}
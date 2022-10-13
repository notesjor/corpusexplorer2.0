using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Helper;
using CorpusExplorer.Terminal.Automate.Properties;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class QueryBuilderForm : AbstractForm
  {
    private Validator _validatorBasic;
    private AbstractValidator _additionalValidator = null;
    private HashSet<string> _uniqueQueryNames;

    public QueryBuilderForm(string[] parentQueries, object query = null)
    {
      InitializeComponent();

      _validatorBasic = new Validator
      {
        Rules = new List<Validator.Rule>
        {
          new Validator.Rule
          {
            Control = query_txt_name,
            ErrorMessage = "Bitte vergeben Sie einen eindeutigen Namen für diese Abfrage",
            ValidationFunction = box => !string.IsNullOrWhiteSpace((box as RadTextBox)?.Text)
          },
          new Validator.Rule
          {
            Control = query_txt_name,
            ErrorMessage = "Sie haben bereits eine Abfrage mit diesem Namen definiert. Bitte vergeben Sie für diese Abfrage einen eindeutigen Namen.",
            ValidationFunction = box => (box as RadTextBox)?.Text == _originalQueryName || !_uniqueQueryNames.Contains((box as RadTextBox)?.Text)
          }
        }
      };

      _additionalValidator = new Validator
      {
        Rules = new List<Validator.Rule>
        {
          new Validator.Rule
          {
            Control = meta_txt_label,
            ErrorMessage = "Bitte geben Sie den Namen einer Metadaten-Angabe ein.",
            ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadTextBox) x).Text)
          },
          new Validator.Rule
          {
            Control = meta_txt_value,
            ErrorMessage = "Bitte geben Sie einen Wert für die Metadaten-Suche ein.",
            ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadTextBox) x).Text)
          },
          new Validator.Rule
          {
            Control = meta_drop_operator,
            ErrorMessage = "Bitte wählhen Sie einen Suchoperator aus.",
            ValidationFunction = x => ((RadDropDownList)x).SelectedIndex > -1
          },
        }
      };

      _uniqueQueryNames = new HashSet<string>(parentQueries ?? new string[0]);
      query_drop_parent.Items.AddRange(_uniqueQueryNames);
      query_drop_parent.SelectedIndex = -1;

      _liveQueryPreview = Preview_Meta;
      _resultBuild = Build_Meta;
      pages_options.SelectedPage = page_meta;
      panel_fullMode.Visible = true;

      LoadQuery(query);
    }

    private void LoadQuery(object query)
    {
      _originalQueryName = query_txt_name.Text = QueryNameHelper.GetName(query);

      switch (query)
      {
        case query q:
          query_drop_parent.SelectValue(q.parent);
          var txt = q.Text.First();
          string[] vals;

          if (txt.StartsWith("!"))
          {
            query_check_invert.Checked = true;
            txt = txt.Substring(1);
          }

          switch (txt[0])
          {
            case 'M':
              pages_options.SelectedPage = page_meta;
              meta_drop_operator.SelectStartsWithValue(txt[1].ToString());
              vals = txt.Substring(2).Split(Sdk.Helper.Splitter.ColonColon, StringSplitOptions.RemoveEmptyEntries);
              meta_txt_label.Text = vals[0];
              meta_txt_value.Text = vals[1];
              break;
            case 'T':
              pages_options.SelectedPage = page_fulltext;
              fulltext_drop_operator.SelectStartsWithValue(txt[1].ToString());
              vals = txt.Substring(2).Split(Sdk.Helper.Splitter.ColonColon, StringSplitOptions.RemoveEmptyEntries);
              fulltext_txt_layer.Text = vals[0];
              fulltext_txt_values.Text = vals[1];
              break;
            case 'X':
              switch (txt[1])
              {
                case 'R':
                  pages_options.SelectedPage = page_random;
                  vals = txt.Substring(2).Split(Sdk.Helper.Splitter.ColonColon, StringSplitOptions.RemoveEmptyEntries);
                  random_txt_value.Text = vals[1];
                  break;
              }
              break;
          }
          break;
        case queryGroup g:
          query_drop_parent.SelectValue(g.parent);
          group_txt_prefix.Text = g.prefix;
          group_drop_operator.SelectValue(g.@operator);
          group_grid_queries.Rows.Clear();
          foreach (var q in g.query)
            group_grid_queries.Rows.Add(q.Text.First());
          break;
        case queryBuilder b:
          query_drop_parent.SelectValue(b.parent);
          list_txt_prefix.Text = b.prefix;
          list_grid_values.Rows.Clear();
          foreach (var v in b.value)
            list_grid_values.Rows.Add(v);
          break;
      }
    }

    public object Result => _resultBuild();

    private delegate string LiveQueryPreviewDelegate();

    private LiveQueryPreviewDelegate _liveQueryPreview;

    private delegate object ResultBuildDelegate();

    private ResultBuildDelegate _resultBuild;
    private string _originalQueryName = "";
    
    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (_validatorBasic != null)
        if (!_validatorBasic.Validate(_additionalValidator))
        {
          MessageBox.Show(_validatorBasic.SimpleErrorMessage());
          return;
        }

      if (MessageBox.Show(Resources.DialogChangesAcceptedMessage, Resources.DialogChangesAcceptedMessageHead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAbortMessage, Resources.DialogChangesAbortMessageHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.Abort;
      Close();
    }

    private void pages_options_SelectedPageChanged(object sender, EventArgs e)
    {
      if (pages_options.SelectedPage == page_meta)
      {
        query_check_invert.Visible = true;
        _liveQueryPreview = Preview_Meta;
        _resultBuild = Build_Meta;
        _additionalValidator = new Validator
        {
          Rules = new List<Validator.Rule>
          {
            new Validator.Rule
            {
              Control = meta_txt_label,
              ErrorMessage = "Bitte geben Sie den Namen einer Metadaten-Angabe ein.",
              ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadTextBox) x).Text)
            },
            new Validator.Rule
            {
              Control = meta_txt_value,
              ErrorMessage = "Bitte geben Sie einen Wert für die Metadaten-Suche ein.",
              ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadTextBox) x).Text)
            },
            new Validator.Rule
            {
              Control = meta_drop_operator,
              ErrorMessage = "Bitte wählhen Sie einen Suchoperator aus.",
              ValidationFunction = x => ((RadDropDownList)x).SelectedIndex > -1
            },
          }
        };
      }
      else if (pages_options.SelectedPage == page_fulltext)
      {
        query_check_invert.Visible = true;
        _liveQueryPreview = Preview_Fulltext;
        _resultBuild = Build_Fulltext;
        _additionalValidator = new Validator
        {
          Rules = new List<Validator.Rule>
          {
            new Validator.Rule
            {
              Control = fulltext_txt_layer,
              ErrorMessage = "Bitte geben Sie einen Layer-Namen ein.",
              ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadTextBox) x).Text)
            },
            new Validator.Rule
            {
              Control = fulltext_txt_values,
              ErrorMessage = "Bitte geben Sie mindestens einen Wert für die Volltext-Suche ein.",
              ValidationFunction = x => !string.IsNullOrWhiteSpace(((RadAutoCompleteBox) x).Text)
            },
            new Validator.Rule
            {
              Control = fulltext_drop_operator,
              ErrorMessage = "Bitte wählhen Sie einen Suchoperator aus.",
              ValidationFunction = x => ((RadDropDownList)x).SelectedIndex > -1
            },
          }
        };
      }
      else if (pages_options.SelectedPage == page_random)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_Random;
        _resultBuild = Build_Random;
        _additionalValidator = new Validator
        {
          Rules = new List<Validator.Rule>()
        };
      }
      else if (pages_options.SelectedPage == page_listBuilder)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_ListBuilder;
        _resultBuild = Build_ListBuilder;
        RefreshLivePreview();
      }
      else if (pages_options.SelectedPage == page_group)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_Group;
        _resultBuild = Build_Group;
        RefreshLivePreview();
      }
    }

    #region Preview
    private string Preview_Meta()
      => $"{(query_check_invert.Checked ? "!" : "")}M{GetOperator(meta_drop_operator)}{meta_txt_label.Text}::{meta_txt_value.Text}";

    private string Preview_Fulltext()
      => $"{(query_check_invert.Checked ? "!" : "")}T{GetOperator(fulltext_drop_operator)}{fulltext_txt_layer.Text}::{fulltext_txt_values.Text}";

    private string Preview_Random()
      => $"XR::{random_txt_value.Text}";

    private string Preview_ListBuilder()
    {
      return "<queryBuilder> ... </queryBuilder>";
    }

    private string Preview_Group()
    {
      return "<queryGroup> ... </queryGroup>";
    }
    #endregion

    #region Build
    private object Build_Meta()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Meta() }
      };

    private object Build_Fulltext()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Fulltext() }
      };

    private object Build_Random()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Random() }
      };

    private object Build_ListBuilder()
      => new queryBuilder
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        prefix = list_txt_prefix.Text,
        value = list_grid_values.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray()
      };

    private object Build_Group()
      => new queryGroup
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        prefix = group_txt_prefix.Text,
        @operator = group_drop_operator.SelectedItem.Text,
        query = group_grid_queries.Rows.Select(x => new query { Text = new[] { x.Cells[0].Value.ToString() } }).ToArray()
      };
    #endregion

    private void RefreshLivePreview()
    {
      txt_livePreview.Text = _liveQueryPreview();
    }

    private string GetOperator(RadDropDownList drop)
    {
      if (drop.SelectedIndex == -1)
        return null;

      var txt = drop.SelectedItem.Text;
      return txt.Substring(0, 1);
    }

    private void refreshlive_textbox(object sender, EventArgs e)
    {
      RefreshLivePreview();
    }

    private void refreshlive_dropdown(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      RefreshLivePreview();
    }
  }
}

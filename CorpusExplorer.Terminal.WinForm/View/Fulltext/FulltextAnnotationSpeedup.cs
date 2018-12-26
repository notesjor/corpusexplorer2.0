#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextAnnotationSpeedup : AbstractView
  {
    private DataTable _dt;
    private string[] _oldAnnotation;
    private HashSet<string> _oldHash;
    private AnnotationViewModel _vm;

    public FulltextAnnotationSpeedup()
    {
      InitializeComponent();
    }

    private void btn_addLayer_Click(object sender, EventArgs e)
    {
      var form = new SimpleTextInput(
        Resources.FulltextAnnotation_NewLayer,
        Resources.FulltextAnnotation_NewLayerDescription,
        Resources.layers1,
        Resources.FulltextAnnotation_NewLayerNullText);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vm.NewLayer(form.Result);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerView);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerAnnotate);
      RefreshAll();
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = dic[sfd.FilterIndex - 1].Value;
      var snapshot = _vm.SelectDocumentAsSelection();
      exporter.Export(snapshot, sfd.FileName);
    }

    private void btn_layer_add_copy_Click(object sender, EventArgs e)
    {
      var form = new SimpleTextInput(
        Resources.FulltextAnnotationSpeedup_CopyLayer,
        string.Format(
          Resources.FulltextAnnotationSpeedup_CopyLayerDescription,
          drop_layerAnnotate.SelectedItem.Text),
        Resources.cabinet,
        Resources.EnterNameHere);

      if (form.ShowDialog() != DialogResult.OK)
        return;

      if (form.Result == drop_layerAnnotate.SelectedItem.Text)
      {
        MessageBox.Show(Resources.FulltextAnnotationSpeedup_LayerCopyErrorDublicatedName);
        return;
      }

      _vm.CopyLayer(drop_layerAnnotate.SelectedItem.Text, form.Result);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerView);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerAnnotate);
      RefreshAll();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      if (drop_layerAnnotate.SelectedIndex == -1 ||
          drop_layerView.SelectedIndex == -1 ||
          drop_selecteddocument.SelectedIndex == -1 ||
          _dt == null)
        return;

      var newValues = new HashSet<string>();
      var stream = new List<string>();
      foreach (var value in radGridView1.Rows.Select(row => row.Cells[Resources.Annotationslayer].Value.ToString()))
      {
        if (!_oldHash.Contains(value))
          newValues.Add(value);

        stream.Add(value);
      }

      if (newValues.Count > 0)
        if (
          MessageBox.Show(
            string.Format(
              Resources.FulltextAnnotationSpeedup_AutoAddNewLayerValue,
              newValues.Count),
            newValues.Count + Resources.FulltextAnnotationSpeedup_CreateNewLayer,
            MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;

      Processing.Invoke(
        Resources.FulltextAnnotationSpeedup_PleaseWait,
        () =>
        {
          _vm.QuickAnnotation(
            (
              Guid
            )
            drop_selecteddocument
              .SelectedValue,
            (
              Guid
            )
            drop_layerAnnotate
              .SelectedValue,
            newValues,
            stream);
          RefreshAll();
        });
    }

    private void btn_showMeta_Click(object sender, EventArgs e)
    {
      var form = new SimpleMetadata(_vm.DocumentMetadata);
      form.NewProperty += (o, a) => { _vm.SetNewDocumentMetadata((KeyValuePair<string, Type>) o); };

      if (form.ShowDialog() == DialogResult.OK)
        _vm.DocumentMetadata = form.DocumentMetadata;
    }

    private void drop_layerAnnotate_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshAll();
    }

    private void drop_layerView_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshAll();
    }

    private void drop_selecteddocument_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshAll();
    }

    private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
    {
      if (e.Column.Name != Resources.Annotationslayer)
        return;

      e.Row.Cells[Resources.Änderungen].Value = e.Value.ToString() == _oldAnnotation[e.RowIndex]
        ? Resources.item
        : _oldHash.Contains(e.Value.ToString())
          ? Resources.item_edit
          : Resources.item_error;
    }

    private void RefreshAll()
    {
      if (drop_layerAnnotate.SelectedIndex == -1 ||
          drop_layerView.SelectedIndex == -1 ||
          drop_selecteddocument.SelectedIndex == -1)
        return;

      var multi = _vm.GetDocumentMultilayer((Guid) drop_selecteddocument.SelectedValue);

      string[] first, second;
      radGridView1.DataBindings.Clear();
      _dt = null;

      try
      {
        first = multi[drop_layerView.SelectedItem.Text].ReduceDocumentToStreamDocument().ToArray();
        second = multi[drop_layerAnnotate.SelectedItem.Text].ReduceDocumentToStreamDocument().ToArray();
        _oldAnnotation = second;
        _oldHash = new HashSet<string>(second);

        if (first.Length != second.Length)
          return;
      }
      catch
      {
        return;
      }

      _dt = new DataTable();
      _dt.Columns.Add(new DataColumn(Resources.Anzeigelayer, typeof(string)));
      _dt.Columns.Add(new DataColumn(Resources.Annotationslayer, typeof(string)));
      _dt.Columns.Add(new DataColumn(Resources.Änderungen, typeof(Image)));

      _dt.BeginLoadData();
      for (var i = 0; i < first.Length; i++)
        _dt.Rows.Add(first[i], second[i], Resources.item);
      _dt.EndLoadData();

      radGridView1.DataSource = _dt;

      radGridView1.Columns[Resources.Anzeigelayer].ReadOnly = true;
      radGridView1.Columns[Resources.Änderungen].ReadOnly = true;
      radGridView1.Columns[Resources.Änderungen].HeaderText = "";
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    private void SpeedTaggerVisualisation_Load(object sender, EventArgs e)
    {
    }

    private void SpeedTaggerVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<AnnotationViewModel>();
      _vm.Execute();
      DictionaryBindingHelper.BindDictionary(_vm.Documents, drop_selecteddocument);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerView);
      DictionaryBindingHelper.BindDictionary(_vm.Layers, drop_layerAnnotate);
      if (_vm.Documents.Count > 0)
        drop_selecteddocument.SelectedIndex = 0;
    }
  }
}
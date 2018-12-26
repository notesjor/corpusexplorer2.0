using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates.Model;
using Telerik.WinControls.Data;

namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  public partial class GridQueryBuilder : AbstractDialog
  {
    private const string _fileExtension = "CorpusExplorer Tabellen-Abfrage (*_{0}.cetq)|*_{0}.cetq";
    private readonly Dictionary<string, Type> _defintion;
    private readonly string _name;
    private Controls.Wpf.QueryBuilder.QueryBuilderControl queryBuilderControl1 = new WinForm.Controls.Wpf.QueryBuilder.QueryBuilderControl();

    public GridQueryBuilder(Dictionary<string, Type> defintion, FilterDescriptorCollection collection, string name)
    {
      _defintion = defintion;
      _name = name;
      InitializeComponent();
      elementHost1.Child = queryBuilderControl1;
      ButtonOkClick += GridQueryBuilder_ButtonOkClick;
      queryBuilderControl1.Step_1_Initialize(_defintion);
      queryBuilderControl1.Step_2_Load(collection);
    }

    public FilterDescriptorCollection Result { get; set; }

    private void btn_load_Click(object sender, EventArgs e)
    {
      queryBuilderControl1.Step_1_Initialize(_defintion);
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = string.Format(_fileExtension, _name)
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      var model = Serializer.Deserialize<IEnumerable<FilterSetting>>(ofd.FileName);
      queryBuilderControl1.Step_2_Load(FilterDescriptorCollectionHelper.LoadColumnFilters(model));
    }

    private void btn_new_Click(object sender, EventArgs e)
    {
      queryBuilderControl1.Step_1_Initialize(_defintion);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var model = FilterDescriptorCollectionHelper.SaveColumnFilters(queryBuilderControl1.Step_3_Save());
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Format(_fileExtension, _name)
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      Serializer.SerializeXml(model, sfd.FileName);
    }

    private void GridQueryBuilder_ButtonOkClick(object sender, EventArgs e)
    {
      Result = queryBuilderControl1.Step_3_Save();
    }
  }
}
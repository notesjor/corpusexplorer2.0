#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Tool4.DocPlusEditor.Controls.Abstract;
using CorpusExplorer.Tool4.DocPlusEditor.Forms;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Controls
{
  [ToolboxItem(true)]
  public partial class MetadataEditor : AbstractUserControl
  {
    public MetadataEditor()
    {
      InitializeComponent();
    }

    public Dictionary<string, object> Metadata
    {
      get
      {
        try
        {
          return ((RadPropertyStore)property_meta.SelectedObject).ToDictionary(x => x.PropertyName, x => x.Value);
        }
        catch
        {
          return null;
        }
      }
      set
      {
        try
        {
          if (value == null)
            return;

          var store = new RadPropertyStore();

          foreach (var x in value.OrderBy(x => x.Key))
            try
            {
              var item = new PropertyStoreItem(x.Value?.GetType() ?? typeof(string),
                                               x.Key,
                                               x.Value);

              store.Add(item);
            }
            catch
            {
              // ignore
            }

          property_meta.SelectedObject = store;
        }
        catch
        {
          // ignore
        }
      }
    }

    public Dictionary<string, Type> MetadataSchema { get; set; }

    private void btn_clipboard_Click(object sender, EventArgs e)
    {
      var stb = new StringBuilder();
      foreach (var x in Metadata) stb.AppendLine($"{x.Key}\t{x.Value}");
      Clipboard.SetText(stb.ToString());
    }

    private void btn_meta_add_Click(object sender, EventArgs e)
    {
      if (NewProperty == null)
        return;

      var form = new MetadataNew(new HashSet<string>(MetadataSchema.Keys));
      if (form.ShowDialog() != DialogResult.OK)
        return;

      NewProperty(form.Result, null);
    }

    public event EventHandler NewProperty;

    private void Property_meta_CreateItemElement(object sender, CreatePropertyGridItemElementEventArgs e)
    {
      var x = e.Item as PropertyGridItem;
      if (x == null)
        return;

      if (x.PropertyType != typeof(DateTime))
        return;

      var c = x.TypeConverter as DateTimeConverter;
      if (c == null)
        // ReSharper disable once RedundantJumpStatement
        return;
    }

    private void Property_meta_EditorInitialized(object sender, PropertyGridItemEditorInitializedEventArgs e)
    {
      var editor = e.Editor as PropertyGridDateTimeEditor;
      if (editor == null)
        return;

      ((BaseDateTimeEditorElement)editor.EditorElement).Format = DateTimePickerFormat.Custom;
      // ReSharper disable once LocalizableElement
      ((BaseDateTimeEditorElement)editor.EditorElement).CustomFormat = "yyyy-MM-dd HH:mm:ss";
    }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Metadata;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class MetadataEditor : AbstractUserControl
  {
    public MetadataEditor() { InitializeComponent(); }

    public Dictionary<string, object> Metadata
    {
      get { return ((RadPropertyStore) property_meta.SelectedObject).ToDictionary(x => x.PropertyName, x => x.Value); }
      set
      {
        var store = new RadPropertyStore();
        foreach (var x in value)
          try
          {
            var item = new PropertyStoreItem(
              x.Value.GetType(),
              x.Key,
              x.Value ?? Activator.CreateInstance(x.Value.GetType()));

            store.Add(item);
          }
          catch {}

        property_meta.SelectedObject = store;
      }
    }

    private void btn_meta_add_Click(object sender, EventArgs e)
    {
      if (NewProperty == null)
        return;

      var form = new NewMetadataDialog();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      NewProperty(form.Result, null);
    }

    public event EventHandler NewProperty;

    private void btn_clipboard_Click(object sender, EventArgs e)
    {
      var stb = new StringBuilder();
      foreach (var x in Metadata)
      {
        stb.AppendLine($"{x.Key}\t{x.Value}");
      }
      Clipboard.SetText(stb.ToString());
    }

    private void Property_meta_EditorInitialized(object sender, PropertyGridItemEditorInitializedEventArgs e)
    {
      var editor = e.Editor as PropertyGridDateTimeEditor;
      if (editor == null)
        return;

      ((BaseDateTimeEditorElement) editor.EditorElement).Format = DateTimePickerFormat.Custom;
      ((BaseDateTimeEditorElement) editor.EditorElement).CustomFormat = "yyyy-MM-dd HH:mm:ss";
    }

    private void Property_meta_CreateItemElement(object sender, CreatePropertyGridItemElementEventArgs e)
    {
      var x = e.Item as PropertyGridItem;
      if (x == null)
        return;

      if (x.PropertyType != typeof(DateTime))
        return;

      var c = x.TypeConverter as DateTimeConverter;
      if (c == null)
        return;
      
    }

    private class CeDateTimeConverter : TypeConverter
    {
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
        if (destinationType == typeof(string))
        {
          return ((DateTime) value).ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        return base.ConvertTo(context, culture, value, destinationType);
      }

      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
      {
        return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
        if (value is string)
        {
          return DateTime.ParseExact(value.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        return base.ConvertFrom(context, culture, value);
      }

      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
      }
    }
  }
}
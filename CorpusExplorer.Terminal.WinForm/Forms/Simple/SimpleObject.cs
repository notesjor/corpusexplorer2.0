#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Helper.Verbalizer;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Simple.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleObject : AbstractDialog
  {
    private Dictionary<string, string> _reverseDict = null;

    public SimpleObject(object obj, string windowTitle = null)
    {
      InitializeComponent();

      if (!string.IsNullOrWhiteSpace(windowTitle))
        Text = windowTitle;

      var properties = obj.GetType().GetProperties();
      var dict = new Dictionary<string, object>();
      var describ = new Dictionary<string, string>();

      if (obj is IVerbalizerComplex vb)
      {
        _reverseDict = new Dictionary<string, string>();

        foreach (var property in properties)
        {
          if(property.PropertyType == typeof(VerbalizerComplexStorage))
            continue;

          var key = vb.VerbalizerComplexStorage.Get(property.Name).Item1;
          _reverseDict.Add(key, property.Name);
          dict.Add(key, property.GetValue(obj));
          describ.Add(key, vb.VerbalizerComplexStorage.Get(property.Name).Item2);
        }
      }
      else
      {
        foreach (var property in properties)
          dict.Add(property.Name, property.GetValue(obj));

      }

      metadataEditor1.Metadata = dict;
      metadataEditor1.AddMetadataDescription(describ);
    }

    public T GetResult<T>(T obj) where T : class
    {
      foreach (var x in metadataEditor1.Metadata)
      {
        var key = _reverseDict == null || !_reverseDict.ContainsKey(x.Key) ? x.Key : _reverseDict[x.Key];

        var prop = obj.GetType().GetProperty(key);
        if (prop != null)
          prop.SetValue(obj, x.Value);
      }

      return obj;
    }
  }
}
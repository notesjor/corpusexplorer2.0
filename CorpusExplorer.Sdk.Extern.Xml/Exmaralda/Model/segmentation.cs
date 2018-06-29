#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class segmentation
  {
    private object[] itemsField;
    private string nameField;
    private string tierrefField;

    /// <remarks />
    [XmlElement("ats", typeof(ats))]
    [XmlElement("ts", typeof(ts))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string tierref
    {
      get => tierrefField;
      set => tierrefField = value;
    }
  }
}
#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  [XmlRoot("sync-point", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class syncpoint
  {
    private string formatrefField;
    private string idField;
    private string offsetField;
    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref
    {
      get => formatrefField;
      set => formatrefField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string offset
    {
      get => offsetField;
      set => offsetField = value;
    }

    /// <remarks />
    [XmlText]
    public string Value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}
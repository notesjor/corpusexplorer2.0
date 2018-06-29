using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class cell
  {
    private string colsField;

    private milestone[] milestoneField;

    private string roleField;

    private string rowsField;

    private string tEIformField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string cols
    {
      get => colsField;
      set => colsField = value;
    }

    /// <remarks />
    [XmlElement("milestone")]
    public milestone[] milestone
    {
      get => milestoneField;
      set => milestoneField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string role
    {
      get => roleField;
      set => roleField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string rows
    {
      get => rowsField;
      set => rowsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}
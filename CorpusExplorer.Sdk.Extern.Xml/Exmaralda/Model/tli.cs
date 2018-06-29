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
  public class tli
  {
    private string bookmarkField;
    private string idField;
    private string timeField;
    private tliType typeField;
    private bool typeFieldSpecified;

    /// <remarks />
    [XmlAttribute]
    public string bookmark
    {
      get => bookmarkField;
      set => bookmarkField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string time
    {
      get => timeField;
      set => timeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public tliType type
    {
      get => typeField;
      set => typeField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified
    {
      get => typeFieldSpecified;
      set => typeFieldSpecified = value;
    }
  }
}
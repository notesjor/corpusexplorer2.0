using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class role
  {
    private string cidField;

    private string role1Field;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string cid
    {
      get => cidField;
      set => cidField = value;
    }

    /// <remarks />
    [XmlAttribute("role")]
    public string role1
    {
      get => role1Field;
      set => role1Field = value;
    }
  }
}
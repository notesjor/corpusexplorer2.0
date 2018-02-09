using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class opener
  {
    private dateline datelineField;

    private ptr ptrField;

    private salute saluteField;

    private s[] sField;

    private string typeField;

    /// <remarks />
    public dateline dateline { get { return datelineField; } set { datelineField = value; } }

    /// <remarks />
    public ptr ptr { get { return ptrField; } set { ptrField = value; } }

    /// <remarks />
    [XmlElement("s")]
    public s[] s { get { return sField; } set { sField = value; } }

    /// <remarks />
    public salute salute { get { return saluteField; } set { saluteField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}
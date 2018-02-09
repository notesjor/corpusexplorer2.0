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
  public class ta
  {
    private string eField;
    private string idField;
    private string nField;
    private string sField;
    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string e { get { return eField; } set { eField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string n { get { return nField; } set { nField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string s { get { return sField; } set { sField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}
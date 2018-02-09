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
  public class coref
  {
    private string coidField;

    private span[][] referencesField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string coid { get { return coidField; } set { coidField = value; } }

    /// <remarks />
    [XmlArrayItem("span", typeof(span), IsNullable = false)]
    public span[][] references { get { return referencesField; } set { referencesField = value; } }
  }
}
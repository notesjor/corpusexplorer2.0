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
  public class target
  {
    private string headField;

    private string idField;

    /// <remarks />
    [XmlAttribute]
    public string head { get { return headField; } set { headField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string id { get { return idField; } set { idField = value; } }
  }
}
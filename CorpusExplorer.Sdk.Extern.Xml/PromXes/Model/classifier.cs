using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PromXes.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.xes-standard.org/")]
  [XmlRoot(Namespace = "http://www.xes-standard.org/", IsNullable = false)]
  public class classifier
  {
    private string keysField;

    private string nameField;

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string keys { get { return keysField; } set { keysField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string name { get { return nameField; } set { nameField = value; } }
  }
}
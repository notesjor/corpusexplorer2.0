#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class speaker
  {
    private string nameField;
    private string speakeridField;

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlAttribute("speaker-id", DataType = "ID")]
    public string speakerid { get { return speakeridField; } set { speakeridField = value; } }
  }
}
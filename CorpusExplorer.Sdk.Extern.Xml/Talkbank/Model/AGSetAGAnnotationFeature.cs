#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  public class AGSetAGAnnotationFeature
  {
    private string nameField;
    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlText]
    public string Value { get { return valueField; } set { valueField = value; } }
  }
}
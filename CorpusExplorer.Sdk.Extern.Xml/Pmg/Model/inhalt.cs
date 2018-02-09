using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class inhalt
  {
    private text textField;

    private titelliste titellisteField;

    private string[] vorspannField;

    /// <remarks />
    public text text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlElement("titel-liste")]
    public titelliste titelliste { get { return titellisteField; } set { titellisteField = value; } }

    /// <remarks />
    [XmlElement("vorspann")]
    public string[] vorspann { get { return vorspannField; } set { vorspannField = value; } }
  }
}
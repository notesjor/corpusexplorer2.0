#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot("title", Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class modelphrase : macroparaContent
  {
    private string subtypeField;
    private string typeField;

    /// <remarks />
    [XmlAttribute]
    public string subtype { get { return subtypeField; } set { subtypeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}
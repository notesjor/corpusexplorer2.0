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
  [XmlRoot("unicode-keyboard", Namespace = "", IsNullable = false)]
  public class unicodekeyboard
  {
    private key[] keyField;
    private string nameField;

    /// <remarks />
    [XmlElement("key")]
    public key[] key { get { return keyField; } set { keyField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string name { get { return nameField; } set { nameField = value; } }
  }
}
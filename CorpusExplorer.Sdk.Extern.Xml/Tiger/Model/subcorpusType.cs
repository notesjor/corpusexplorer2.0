#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlRoot("subcorpus", Namespace = "", IsNullable = false)]
  public class subcorpusType
  {
    private string externalField;
    private object[] itemsField;
    private string nameField;

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string external { get { return externalField; } set { externalField = value; } }

    /// <remarks />
    [XmlElement("s", typeof(sentenceType), Form = XmlSchemaForm.Unqualified)]
    [XmlElement("subcorpus", typeof(subcorpusType), Form = XmlSchemaForm.Unqualified)]
    public object[] items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string name { get { return nameField; } set { nameField = value; } }
  }
}
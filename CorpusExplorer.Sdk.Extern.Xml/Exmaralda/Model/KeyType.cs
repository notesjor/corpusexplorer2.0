#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class KeyType
  {
    private string nameField;
    private string valueField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string Name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlText]
    public string Value { get { return valueField; } set { valueField = value; } }
  }
}
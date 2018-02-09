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
  public class SettingType
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("Description", typeof(DescriptionType))]
    [XmlElement("Object", typeof(ObjectType))]
    [XmlElement("Person", typeof(string), DataType = "IDREF")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}
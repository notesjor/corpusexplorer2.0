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
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("col", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class alignmentColumn
  {
    private ItemsChoiceType1[] itemsElementNameField;
    private string[] itemsField;

    /// <remarks />
    [XmlElement("actualref", typeof(string))]
    [XmlElement("modelref", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public string[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType1[] ItemsElementName
    {
      get => itemsElementNameField;
      set => itemsElementNameField = value;
    }
  }
}
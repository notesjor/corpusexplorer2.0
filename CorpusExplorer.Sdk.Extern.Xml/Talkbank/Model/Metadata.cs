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
  public class Metadata
  {
    private ItemsChoiceType[] itemsElementNameField;
    private DCelementType[] itemsField;

    /// <remarks />
    [XmlElement("appId", typeof(DCelementType))]
    [XmlElement("contributor", typeof(DCelementType))]
    [XmlElement("coverage", typeof(DCelementType))]
    [XmlElement("creator", typeof(DCelementType))]
    [XmlElement("date", typeof(DCelementType))]
    [XmlElement("description", typeof(DCelementType))]
    [XmlElement("format", typeof(DCelementType))]
    [XmlElement("identifier", typeof(DCelementType))]
    [XmlElement("language", typeof(DCelementType))]
    [XmlElement("publisher", typeof(DCelementType))]
    [XmlElement("relation", typeof(DCelementType))]
    [XmlElement("rights", typeof(DCelementType))]
    [XmlElement("source", typeof(DCelementType))]
    [XmlElement("subject", typeof(DCelementType))]
    [XmlElement("title", typeof(DCelementType))]
    [XmlElement("type", typeof(DCelementType))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public DCelementType[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get => itemsElementNameField;
      set => itemsElementNameField = value;
    }
  }
}
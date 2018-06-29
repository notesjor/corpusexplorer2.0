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
  [XmlRoot(Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class langs
  {
    private ItemChoiceType itemElementNameField;
    private string itemField;

    /// <remarks />
    [XmlElement("ambiguous", typeof(string), DataType = "language")]
    [XmlElement("multiple", typeof(string), DataType = "language")]
    [XmlElement("single", typeof(string), DataType = "language")]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public ItemChoiceType ItemElementName
    {
      get => itemElementNameField;
      set => itemElementNameField = value;
    }
  }
}
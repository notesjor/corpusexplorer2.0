#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class messageBody
  {
    private ItemsChoiceType[] itemsElementNameField;
    private object[] itemsField;
    private string[] textField;

    /// <remarks />
    [XmlElement("address", typeof(address))]
    [XmlElement("asteriskExpression", typeof(string))]
    [XmlElement("emoticon", typeof(string))]
    [XmlElement("img", typeof(img))]
    [XmlElement("nickname", typeof(nickname))]
    [XmlElement("roomname", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get { return itemsElementNameField; }
      set { itemsElementNameField = value; }
    }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}
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
  [XmlRoot("w", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class wordType
  {
    private string formSuffixField;
    private wordTypeFormType formTypeField;
    private bool formTypeFieldSpecified;
    private object[] itemsField;
    private langs langsField;
    private bool separatedprefixField;
    private bool separatedprefixFieldSpecified;
    private string[] textField;
    private wordTypeType typeField;
    private bool typeFieldSpecified;
    private wordTypeUntranscribed untranscribedField;
    private bool untranscribedFieldSpecified;
    private string userspecialformField;

    /// <remarks />
    [XmlAttribute]
    public string formSuffix { get { return formSuffixField; } set { formSuffixField = value; } }

    /// <remarks />
    [XmlAttribute]
    public wordTypeFormType formType { get { return formTypeField; } set { formTypeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool formTypeSpecified { get { return formTypeFieldSpecified; } set { formTypeFieldSpecified = value; } }

    /// <remarks />
    [XmlElement("ca-delimiter", typeof(cadelimiter))]
    [XmlElement("ca-element", typeof(caelement))]
    [XmlElement("italic", typeof(italic))]
    [XmlElement("long-feature", typeof(longfeature))]
    [XmlElement("mk", typeof(morphemic_marker))]
    [XmlElement("mor", typeof(morType))]
    [XmlElement("overlap-point", typeof(overlapPointType))]
    [XmlElement("p", typeof(prosodyType))]
    [XmlElement("pos", typeof(posType))]
    [XmlElement("replacement", typeof(replacement))]
    [XmlElement("shortening", typeof(shorteningType))]
    [XmlElement("underline", typeof(underline))]
    [XmlElement("wk", typeof(wordnetMarkerType))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    public langs langs { get { return langsField; } set { langsField = value; } }

    /// <remarks />
    [XmlAttribute("separated-prefix")]
    public bool separatedprefix { get { return separatedprefixField; } set { separatedprefixField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool separatedprefixSpecified
    {
      get { return separatedprefixFieldSpecified; }
      set { separatedprefixFieldSpecified = value; }
    }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute]
    public wordTypeType type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified { get { return typeFieldSpecified; } set { typeFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public wordTypeUntranscribed untranscribed
    {
      get { return untranscribedField; }
      set { untranscribedField = value; }
    }

    /// <remarks />
    [XmlIgnore]
    public bool untranscribedSpecified
    {
      get { return untranscribedFieldSpecified; }
      set { untranscribedFieldSpecified = value; }
    }

    /// <remarks />
    [XmlAttribute("user-special-form")]
    public string userspecialform { get { return userspecialformField; } set { userspecialformField = value; } }
  }
}
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
  public class creator
  {
    private creatorEstimatedGender estimatedGenderField;
    private string nameField;
    private string nOMField;
    private string nOTField;
    private string roleField;

    /// <remarks />
    [XmlAttribute]
    public creatorEstimatedGender estimatedGender
    {
      get { return estimatedGenderField; }
      set { estimatedGenderField = value; }
    }

    /// <remarks />
    [XmlAttribute]
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string NOM { get { return nOMField; } set { nOMField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string NOT { get { return nOTField; } set { nOTField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string role { get { return roleField; } set { roleField = value; } }
  }
}
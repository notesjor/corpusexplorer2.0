using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class @event
  {
    private string aspectField;

    private string classField;

    private string eidField;

    private string eiidField;

    private string lemmaField;

    private string polarityField;

    private string posField;

    private role[][] rolesField;

    private string spanField;

    private string tenseField;

    /// <remarks />
    [XmlAttribute]
    public string aspect { get { return aspectField; } set { aspectField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string @class { get { return classField; } set { classField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string eid { get { return eidField; } set { eidField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string eiid { get { return eiidField; } set { eiidField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string lemma { get { return lemmaField; } set { lemmaField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string polarity { get { return polarityField; } set { polarityField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string pos { get { return posField; } set { posField = value; } }

    /// <remarks />
    [XmlArrayItem("role", typeof(role), IsNullable = false)]
    public role[][] roles { get { return rolesField; } set { rolesField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string span { get { return spanField; } set { spanField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string tense { get { return tenseField; } set { tenseField = value; } }
  }
}
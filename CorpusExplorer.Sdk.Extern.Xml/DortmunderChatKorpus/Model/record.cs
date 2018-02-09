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
  public class record
  {
    private string plattformNameField;
    private string plattformURLField;
    private string recByField;
    private string recDateField;
    private string recEndField;
    private string recStartField;
    private string tNOMField;
    private string tNOTField;
    private string viewField;

    /// <remarks />
    [XmlAttribute]
    public string plattformName { get { return plattformNameField; } set { plattformNameField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string plattformURL { get { return plattformURLField; } set { plattformURLField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string recBy { get { return recByField; } set { recByField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string recDate { get { return recDateField; } set { recDateField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string recEnd { get { return recEndField; } set { recEndField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string recStart { get { return recStartField; } set { recStartField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string TNOM { get { return tNOMField; } set { tNOMField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string TNOT { get { return tNOTField; } set { tNOTField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string view { get { return viewField; } set { viewField = value; } }
  }
}
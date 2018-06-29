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
    public string plattformName
    {
      get => plattformNameField;
      set => plattformNameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string plattformURL
    {
      get => plattformURLField;
      set => plattformURLField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string recBy
    {
      get => recByField;
      set => recByField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string recDate
    {
      get => recDateField;
      set => recDateField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string recEnd
    {
      get => recEndField;
      set => recEndField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string recStart
    {
      get => recStartField;
      set => recStartField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string TNOM
    {
      get => tNOMField;
      set => tNOMField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string TNOT
    {
      get => tNOTField;
      set => tNOTField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string view
    {
      get => viewField;
      set => viewField = value;
    }
  }
}
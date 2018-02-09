using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class td : Flow
  {
    private string abbrField;

    private string colspanField;

    private string headersField;

    private string rowspanField;

    public td()
    {
      rowspanField = "1";
      colspanField = "1";
    }

    /// <remarks />
    [XmlAttribute]
    public string abbr { get { return abbrField; } set { abbrField = value; } }

    /// <remarks />
    [XmlAttribute]
    [DefaultValue("1")]
    public string colspan { get { return colspanField; } set { colspanField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREFS")]
    public string headers { get { return headersField; } set { headersField = value; } }

    /// <remarks />
    [XmlAttribute]
    [DefaultValue("1")]
    public string rowspan { get { return rowspanField; } set { rowspanField = value; } }
  }
}
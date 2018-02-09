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
  [XmlRoot("table", Namespace = "", IsNullable = false)]
  public class block
  {
    private Inline captionField;

    private object[] itemsField;

    private Flow[][] tfootField;

    private Flow[][] theadField;

    /// <remarks />
    public Inline caption { get { return captionField; } set { captionField = value; } }

    /// <remarks />
    [XmlElement("tbody", typeof(tbody))]
    [XmlElement("tr", typeof(tr))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlArrayItem("tr", IsNullable = false)]
    [XmlArrayItem("td", typeof(td), IsNullable = false, NestingLevel = 1)]
    [XmlArrayItem("th", typeof(th), IsNullable = false, NestingLevel = 1)]
    public Flow[][] tfoot { get { return tfootField; } set { tfootField = value; } }

    /// <remarks />
    [XmlArrayItem("tr", IsNullable = false)]
    [XmlArrayItem("td", typeof(td), IsNullable = false, NestingLevel = 1)]
    [XmlArrayItem("th", typeof(th), IsNullable = false, NestingLevel = 1)]
    public Flow[][] thead { get { return theadField; } set { theadField = value; } }
  }
}
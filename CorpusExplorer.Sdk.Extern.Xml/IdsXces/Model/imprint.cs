using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class imprint
  {
    private pubDate[] pubDateField;

    private string publisherField;

    private string pubPlaceField;

    /// <remarks />
    [XmlElement("pubDate")]
    public pubDate[] pubDate { get { return pubDateField; } set { pubDateField = value; } }

    /// <remarks />
    public string publisher { get { return publisherField; } set { publisherField = value; } }

    /// <remarks />
    public string pubPlace { get { return pubPlaceField; } set { pubPlaceField = value; } }
  }
}
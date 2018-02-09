#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("tier-format", Namespace = "", IsNullable = false)]
  public class tierformat
  {
    private tierformatAlignmentname alignmentnameField;
    private bool alignmentnameFieldSpecified;
    private tierformatBgcolorname bgcolornameField;
    private bool bgcolornameFieldSpecified;
    private property[] propertyField;
    private tierformatSize sizeField;
    private bool sizeFieldSpecified;
    private tierformatStylename stylenameField;
    private bool stylenameFieldSpecified;
    private tierformatTextcolorname textcolornameField;
    private bool textcolornameFieldSpecified;
    private string[] textField;
    private string tierrefField;

    /// <remarks />
    [XmlAttribute("alignment-name")]
    public tierformatAlignmentname alignmentname
    {
      get { return alignmentnameField; }
      set { alignmentnameField = value; }
    }

    /// <remarks />
    [XmlIgnore]
    public bool alignmentnameSpecified
    {
      get { return alignmentnameFieldSpecified; }
      set { alignmentnameFieldSpecified = value; }
    }

    /// <remarks />
    [XmlAttribute("bgcolor-name")]
    public tierformatBgcolorname bgcolorname { get { return bgcolornameField; } set { bgcolornameField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool bgcolornameSpecified
    {
      get { return bgcolornameFieldSpecified; }
      set { bgcolornameFieldSpecified = value; }
    }

    /// <remarks />
    [XmlElement("property")]
    public property[] property { get { return propertyField; } set { propertyField = value; } }

    /// <remarks />
    [XmlAttribute]
    public tierformatSize size { get { return sizeField; } set { sizeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool sizeSpecified { get { return sizeFieldSpecified; } set { sizeFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute("style-name")]
    public tierformatStylename stylename { get { return stylenameField; } set { stylenameField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool stylenameSpecified { get { return stylenameFieldSpecified; } set { stylenameFieldSpecified = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute("textcolor-name")]
    public tierformatTextcolorname textcolorname
    {
      get { return textcolornameField; }
      set { textcolornameField = value; }
    }

    /// <remarks />
    [XmlIgnore]
    public bool textcolornameSpecified
    {
      get { return textcolornameFieldSpecified; }
      set { textcolornameFieldSpecified = value; }
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string tierref { get { return tierrefField; } set { tierrefField = value; } }
  }
}
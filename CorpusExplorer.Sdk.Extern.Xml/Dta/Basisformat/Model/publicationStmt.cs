using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class publicationStmt
  {
    private availability availabilityField;

    private date[] dateField;

    private idno idnoField;

    private publisher[] publisherField;

    private pubPlace[] pubPlaceField;

    /// <remarks />
    public availability availability
    {
      get => availabilityField;
      set => availabilityField = value;
    }

    /// <remarks />
    [XmlElement("publisher")]
    public publisher[] publisher
    {
      get => publisherField;
      set => publisherField = value;
    }

    /// <remarks />
    [XmlElement("pubPlace")]
    public pubPlace[] pubPlace
    {
      get => pubPlaceField;
      set => pubPlaceField = value;
    }

    /// <remarks />
    [XmlElement("date")]
    public date[] date
    {
      get => dateField;
      set => dateField = value;
    }

    /// <remarks />
    public idno idno
    {
      get => idnoField;
      set => idnoField = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model
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

    private date dateField;

    private idno idnoField;

    private publisher publisherField;

    /// <remarks />
    public availability availability { get { return availabilityField; } set { availabilityField = value; } }

    /// <remarks />
    public date date { get { return dateField; } set { dateField = value; } }

    /// <remarks />
    public idno idno { get { return idnoField; } set { idnoField = value; } }

    /// <remarks />
    public publisher publisher { get { return publisherField; } set { publisherField = value; } }
  }
}
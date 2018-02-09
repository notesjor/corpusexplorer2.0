using System.Xml.Schema;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDComponentsTeiHeaderFileDescPublicationStmtPublisherOrgName
  {
    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string role { get; set; }

    /// <remarks />
    [XmlText]
    public string Value { get; set; }
  }
}
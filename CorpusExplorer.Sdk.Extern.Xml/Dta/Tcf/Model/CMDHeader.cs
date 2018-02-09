using System;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/")]
  public class CMDHeader
  {
    /// <remarks />
    public string MdCollectionDisplayName { get; set; }

    /// <remarks />
    [XmlElement(DataType = "date")]
    public DateTime MdCreationDate { get; set; }

    /// <remarks />
    public string MdCreator { get; set; }

    /// <remarks />
    public string MdProfile { get; set; }

    /// <remarks />
    public string MdSelfLink { get; set; }
  }
}
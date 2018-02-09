using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusAnalysisTagF
  {
    /// <remarks />
    [XmlAttribute]
    public string name { get; set; }

    /// <remarks />
    [XmlText]
    public string Value { get; set; }
  }
}
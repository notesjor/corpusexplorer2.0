using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusAnalysis
  {
    /// <remarks />
    public TextCorpusAnalysisTag tag { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get; set; }
  }
}
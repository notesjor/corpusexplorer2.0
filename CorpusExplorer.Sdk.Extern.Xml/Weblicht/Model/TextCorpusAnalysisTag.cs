using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  public class TextCorpusAnalysisTag
  {
    /// <remarks />
    [XmlArrayItem("f", IsNullable = false)]
    public TextCorpusAnalysisTagF[] fs { get; set; }
  }
}
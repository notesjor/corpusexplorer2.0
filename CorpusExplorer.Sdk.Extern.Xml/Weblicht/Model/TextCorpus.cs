using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks />
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public class TextCorpus
  {
    /// <remarks />
    public TextCorpusGeo geo { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string lang { get; set; }

    /// <remarks />
    [XmlArrayItem("lemma", IsNullable = false)]
    public TextCorpusLemma[] lemmas { get; set; }

    /// <remarks />
    [XmlArrayItem("analysis", IsNullable = false)]
    public TextCorpusAnalysis[] morphology { get; set; }

    /// <remarks />
    public TextCorpusNamedEntities namedEntities { get; set; }

    /// <remarks />
    [XmlArrayItem("correction", IsNullable = false)]
    public TextCorpusCorrection[] orthography { get; set; }

    /// <remarks />
    public TextCorpusParsing parsing { get; set; }

    /// <remarks />
    public TextCorpusPOStags POStags { get; set; }

    /// <remarks />
    [XmlArrayItem("sentence", IsNullable = false)]
    public TextCorpusSentence[] sentences { get; set; }

    /// <remarks />
    public string text { get; set; }

    /// <remarks />
    [XmlArrayItem("token", IsNullable = false)]
    public TextCorpusToken[] tokens { get; set; }
  }
}
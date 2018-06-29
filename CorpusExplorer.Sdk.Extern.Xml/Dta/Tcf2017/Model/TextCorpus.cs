using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public class TextCorpus
  {
    private string langField;

    private lemma[] lemmasField;

    private correction[] orthographyField;

    private POStags pOStagsField;

    private sentence[] sentencesField;

    private token[] tokensField;

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string lang
    {
      get => langField;
      set => langField = value;
    }

    /// <remarks />
    [XmlArrayItem("lemma", IsNullable = false)]
    public lemma[] lemmas
    {
      get => lemmasField;
      set => lemmasField = value;
    }

    /// <remarks />
    [XmlArrayItem("correction", IsNullable = false)]
    public correction[] orthography
    {
      get => orthographyField;
      set => orthographyField = value;
    }

    /// <remarks />
    public POStags POStags
    {
      get => pOStagsField;
      set => pOStagsField = value;
    }

    /// <remarks />
    [XmlArrayItem("sentence", IsNullable = false)]
    public sentence[] sentences
    {
      get => sentencesField;
      set => sentencesField = value;
    }

    /// <remarks />
    [XmlArrayItem("token", IsNullable = false)]
    public token[] tokens
    {
      get => tokensField;
      set => tokensField = value;
    }
  }
}
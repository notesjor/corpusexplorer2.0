using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data")]
  [XmlRoot("D-Spin", Namespace = "http://www.dspin.de/data", IsNullable = false)]
  public class DSpin
  {
    private source metaDataField;

    private TextCorpus textCorpusField;

    private string versionField;

    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/metadata")]
    public source MetaData
    {
      get => metaDataField;
      set => metaDataField = value;
    }

    /// <remarks />
    [XmlElement(Namespace = "http://www.dspin.de/data/textcorpus")]
    public TextCorpus TextCorpus
    {
      get => textCorpusField;
      set => textCorpusField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string version
    {
      get => versionField;
      set => versionField = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class externalRef
  {
    private string confidenceField;

    private string referenceField;

    private string resourceField;

    /// <remarks />
    [XmlAttribute]
    public string confidence
    {
      get => confidenceField;
      set => confidenceField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string reference
    {
      get => referenceField;
      set => referenceField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string resource
    {
      get => resourceField;
      set => resourceField = value;
    }
  }
}
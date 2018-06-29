using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Gate.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class AnnotationSet
  {
    private Annotation[] annotationField;

    private string nameField;

    /// <remarks />
    [XmlElement("Annotation")]
    public Annotation[] Annotation
    {
      get => annotationField;
      set => annotationField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }
  }
}
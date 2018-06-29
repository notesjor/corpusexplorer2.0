using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class encodingDesc
  {
    private editorialDecl editorialDeclField;

    private projectDesc projectDescField;

    private samplingDecl samplingDeclField;

    private tagUsage[] tagsDeclField;

    /// <remarks />
    public editorialDecl editorialDecl
    {
      get => editorialDeclField;
      set => editorialDeclField = value;
    }

    /// <remarks />
    public projectDesc projectDesc
    {
      get => projectDescField;
      set => projectDescField = value;
    }

    /// <remarks />
    public samplingDecl samplingDecl
    {
      get => samplingDeclField;
      set => samplingDeclField = value;
    }

    /// <remarks />
    [XmlArrayItem("tagUsage", IsNullable = false)]
    public tagUsage[] tagsDecl
    {
      get => tagsDeclField;
      set => tagsDeclField = value;
    }
  }
}
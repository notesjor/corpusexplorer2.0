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
  [XmlRoot("h.keywords", Namespace = "", IsNullable = false)]
  public class hkeywords
  {
    private keyTerm keyTermField;

    /// <remarks />
    public keyTerm keyTerm
    {
      get => keyTermField;
      set => keyTermField = value;
    }
  }
}
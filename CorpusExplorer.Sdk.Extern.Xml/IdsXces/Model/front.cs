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
  public class front
  {
    private div[] divField;

    private titlePage titlePageField;

    /// <remarks />
    [XmlElement("div")]
    public div[] div
    {
      get => divField;
      set => divField = value;
    }

    /// <remarks />
    public titlePage titlePage
    {
      get => titlePageField;
      set => titlePageField = value;
    }
  }
}
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
  public class externalReferences
  {
    private externalRef[] externalRefField;

    /// <remarks />
    [XmlElement("externalRef")]
    public externalRef[] externalRef
    {
      get => externalRefField;
      set => externalRefField = value;
    }
  }
}
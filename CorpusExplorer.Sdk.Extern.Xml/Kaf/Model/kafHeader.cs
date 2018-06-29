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
  public class kafHeader
  {
    private fileDesc fileDescField;

    private linguisticProcessors[] linguisticProcessorsField;

    private @public publicField;

    /// <remarks />
    public fileDesc fileDesc
    {
      get => fileDescField;
      set => fileDescField = value;
    }

    /// <remarks />
    [XmlElement("linguisticProcessors")]
    public linguisticProcessors[] linguisticProcessors
    {
      get => linguisticProcessorsField;
      set => linguisticProcessorsField = value;
    }

    /// <remarks />
    public @public @public
    {
      get => publicField;
      set => publicField = value;
    }
  }
}
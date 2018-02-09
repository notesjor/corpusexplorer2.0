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
  public class biblStruct
  {
    private analytic analyticField;

    private string defaultField;

    private monogr monogrField;

    /// <remarks />
    public analytic analytic { get { return analyticField; } set { analyticField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string Default { get { return defaultField; } set { defaultField = value; } }

    /// <remarks />
    public monogr monogr { get { return monogrField; } set { monogrField = value; } }
  }
}
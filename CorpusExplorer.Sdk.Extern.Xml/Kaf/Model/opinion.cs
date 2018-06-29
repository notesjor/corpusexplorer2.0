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
  public class opinion
  {
    private string oidField;

    private opinion_expression[] opinion_expressionField;

    private span[][] opinion_holderField;

    private span[][] opinion_targetField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string oid
    {
      get => oidField;
      set => oidField = value;
    }

    /// <remarks />
    [XmlElement("opinion_expression")]
    public opinion_expression[] opinion_expression
    {
      get => opinion_expressionField;
      set => opinion_expressionField = value;
    }

    /// <remarks />
    [XmlArrayItem("span", typeof(span), IsNullable = false)]
    public span[][] opinion_holder
    {
      get => opinion_holderField;
      set => opinion_holderField = value;
    }

    /// <remarks />
    [XmlArrayItem("span", typeof(span), IsNullable = false)]
    public span[][] opinion_target
    {
      get => opinion_targetField;
      set => opinion_targetField = value;
    }
  }
}
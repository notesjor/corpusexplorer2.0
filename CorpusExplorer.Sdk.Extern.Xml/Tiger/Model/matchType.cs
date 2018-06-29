#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class matchType
  {
    private string subgraphField;
    private varType[] variableField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string subgraph
    {
      get => subgraphField;
      set => subgraphField = value;
    }

    /// <remarks />
    [XmlElement("variable", Form = XmlSchemaForm.Unqualified)]
    public varType[] variable
    {
      get => variableField;
      set => variableField = value;
    }
  }
}
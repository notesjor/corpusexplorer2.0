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
  public class graphType
  {
    private bool discontinuousField;
    private ntType[] nonterminalsField;
    private string rootField;
    private tType[] terminalsField;

    public graphType() { discontinuousField = false; }

    /// <remarks />
    [XmlAttribute]
    [DefaultValue(false)]
    public bool discontinuous { get { return discontinuousField; } set { discontinuousField = value; } }

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("nt", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public ntType[] nonterminals { get { return nonterminalsField; } set { nonterminalsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string root { get { return rootField; } set { rootField = value; } }

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("t", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public tType[] terminals { get { return terminalsField; } set { terminalsField = value; } }
  }
}
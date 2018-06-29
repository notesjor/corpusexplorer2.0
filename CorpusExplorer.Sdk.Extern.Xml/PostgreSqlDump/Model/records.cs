using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class records
  {
    private column[][] rowField;

    /// <remarks />
    [XmlArrayItem("column", typeof(column), IsNullable = false)]
    public column[][] row
    {
      get => rowField;
      set => rowField = value;
    }
  }
}
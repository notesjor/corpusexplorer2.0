using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [XmlRoot(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public class titleStmt
  {
    private author authorField;

    private editor[] editorField;

    private respStmt[] respStmtField;

    private title[] titleField;

    /// <remarks />
    public author author
    {
      get => authorField;
      set => authorField = value;
    }

    /// <remarks />
    [XmlElement("title")]
    public title[] title
    {
      get => titleField;
      set => titleField = value;
    }

    /// <remarks />
    [XmlElement("editor")]
    public editor[] editor
    {
      get => editorField;
      set => editorField = value;
    }

    /// <remarks />
    [XmlElement("respStmt")]
    public respStmt[] respStmt
    {
      get => respStmtField;
      set => respStmtField = value;
    }
  }
}
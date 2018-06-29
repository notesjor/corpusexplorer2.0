using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class biblFull
  {
    private editionStmt editionStmtField;

    private measure[] extentField;

    private notesStmt notesStmtField;

    private publicationStmt publicationStmtField;

    private seriesStmt seriesStmtField;

    private titleStmt titleStmtField;

    /// <remarks />
    public editionStmt editionStmt
    {
      get => editionStmtField;
      set => editionStmtField = value;
    }

    /// <remarks />
    [XmlArrayItem("measure", IsNullable = false)]
    public measure[] extent
    {
      get => extentField;
      set => extentField = value;
    }

    /// <remarks />
    public notesStmt notesStmt
    {
      get => notesStmtField;
      set => notesStmtField = value;
    }

    /// <remarks />
    public publicationStmt publicationStmt
    {
      get => publicationStmtField;
      set => publicationStmtField = value;
    }

    /// <remarks />
    public seriesStmt seriesStmt
    {
      get => seriesStmtField;
      set => seriesStmtField = value;
    }

    /// <remarks />
    public titleStmt titleStmt
    {
      get => titleStmtField;
      set => titleStmtField = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true,
    Namespace = "http://www.mediawiki.org/xml/export-0.10/")]
  [XmlRoot(Namespace = "http://www.mediawiki.org/xml/export-0.10/",
    IsNullable = false)]
  public class page
  {
    private string idField;

    private string nsField;

    private redirect redirectField;

    private string restrictionsField;

    private revision revisionField;

    private string titleField;

    /// <remarks />
    public string title
    {
      get => titleField;
      set => titleField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ns
    {
      get => nsField;
      set => nsField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public redirect redirect
    {
      get => redirectField;
      set => redirectField = value;
    }

    /// <remarks />
    public string restrictions
    {
      get => restrictionsField;
      set => restrictionsField = value;
    }

    /// <remarks />
    public revision revision
    {
      get => revisionField;
      set => revisionField = value;
    }
  }
}
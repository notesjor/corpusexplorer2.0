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
  public class siteinfo
  {
    private string baseField;

    private string caseField;

    private string dbnameField;

    private string generatorField;

    private @namespace[] namespacesField;

    private string sitenameField;

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string sitename
    {
      get => sitenameField;
      set => sitenameField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string dbname
    {
      get => dbnameField;
      set => dbnameField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string @base
    {
      get => baseField;
      set => baseField = value;
    }

    /// <remarks />
    public string generator
    {
      get => generatorField;
      set => generatorField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string @case
    {
      get => caseField;
      set => caseField = value;
    }

    /// <remarks />
    [XmlArrayItem("namespace", IsNullable = false)]
    public @namespace[] namespaces
    {
      get => namespacesField;
      set => namespacesField = value;
    }
  }
}
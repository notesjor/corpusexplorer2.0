using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk
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
  public class revision
  {
    private comment commentField;

    private contributor contributorField;

    private string formatField;

    private string idField;

    private minor minorField;

    private string modelField;

    private string parentidField;

    private string sha1Field;

    private text textField;

    private DateTime timestampField;

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string parentid
    {
      get => parentidField;
      set => parentidField = value;
    }

    /// <remarks />
    public DateTime timestamp
    {
      get => timestampField;
      set => timestampField = value;
    }

    /// <remarks />
    public contributor contributor
    {
      get => contributorField;
      set => contributorField = value;
    }

    /// <remarks />
    public minor minor
    {
      get => minorField;
      set => minorField = value;
    }

    /// <remarks />
    public comment comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string model
    {
      get => modelField;
      set => modelField = value;
    }

    /// <remarks />
    public string format
    {
      get => formatField;
      set => formatField = value;
    }

    /// <remarks />
    public text text
    {
      get => textField;
      set => textField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NMTOKEN")]
    public string sha1
    {
      get => sha1Field;
      set => sha1Field = value;
    }
  }
}
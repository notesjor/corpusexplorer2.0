using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class revision
  {
    private string commentField;
    private contributor contributorField;
    private string formatField;
    private string idField;
    private minor minorField;
    private string modelField;
    private string parentidField;
    private string sha1Field;
    private text textField;
    private string timestampField;

    /// <remarks />
    public string comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    public contributor contributor
    {
      get => contributorField;
      set => contributorField = value;
    }

    /// <remarks />
    public string format
    {
      get => formatField;
      set => formatField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public minor minor
    {
      get => minorField;
      set => minorField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string parentid
    {
      get => parentidField;
      set => parentidField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NMTOKEN")]
    public string timestamp
    {
      get => timestampField;
      set => timestampField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string model
    {
      get => modelField;
      set => modelField = value;
    }


    /// <remarks />
    [XmlElement(DataType = "NMTOKEN")]
    public string sha1
    {
      get => sha1Field;
      set => sha1Field = value;
    }

    /// <remarks />
    public text text
    {
      get => textField;
      set => textField = value;
    }
  }
}
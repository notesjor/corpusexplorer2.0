#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class FileType
  {
    private string absPathField;
    private AvailabilityType availabilityField;
    private KeyType[] descriptionField;
    private string filenameField;
    private string idField;
    private string mimetypeField;
    private string relPathField;
    private string uRLField;

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string URL
    {
      get => uRLField;
      set => uRLField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string absPath
    {
      get => absPathField;
      set => absPathField = value;
    }

    /// <remarks />
    public AvailabilityType Availability
    {
      get => availabilityField;
      set => availabilityField = value;
    }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description
    {
      get => descriptionField;
      set => descriptionField = value;
    }

    /// <remarks />
    public string filename
    {
      get => filenameField;
      set => filenameField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public string mimetype
    {
      get => mimetypeField;
      set => mimetypeField = value;
    }

    /// <remarks />
    public string relPath
    {
      get => relPathField;
      set => relPathField = value;
    }
  }
}
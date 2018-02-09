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
  public class TranscriptionType
  {
    private AnnotationType annotationField;
    private AvailabilityType availabilityField;
    private KeyType[] descriptionField;
    private FileType fileField;
    private object filenameField;
    private string fileStoreField;
    private string idField;
    private object nameField;
    private string nSLinkField;

    /// <remarks />
    public AnnotationType Annotation { get { return annotationField; } set { annotationField = value; } }

    /// <remarks />
    public AvailabilityType Availability { get { return availabilityField; } set { availabilityField = value; } }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    public FileType File { get { return fileField; } set { fileField = value; } }

    /// <remarks />
    public object Filename { get { return filenameField; } set { filenameField = value; } }

    /// <remarks />
    public string FileStore { get { return fileStoreField; } set { fileStoreField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public object Name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string NSLink { get { return nSLinkField; } set { nSLinkField = value; } }
  }
}
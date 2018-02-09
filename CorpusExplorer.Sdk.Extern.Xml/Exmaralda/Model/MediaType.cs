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
  public class MediaType
  {
    private AvailabilityType availabilityField;
    private KeyType[] descriptionField;
    private object filenameField;
    private string fileStoreField;
    private string idField;
    private DateTime lastBackupField;
    private bool lastBackupFieldSpecified;
    private string nSLinkField;

    /// <remarks />
    public AvailabilityType Availability { get { return availabilityField; } set { availabilityField = value; } }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    public object Filename { get { return filenameField; } set { filenameField = value; } }

    /// <remarks />
    public string FileStore { get { return fileStoreField; } set { fileStoreField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement(DataType = "date")]
    public DateTime LastBackup { get { return lastBackupField; } set { lastBackupField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool LastBackupSpecified
    {
      get { return lastBackupFieldSpecified; }
      set { lastBackupFieldSpecified = value; }
    }

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string NSLink { get { return nSLinkField; } set { nSLinkField = value; } }
  }
}
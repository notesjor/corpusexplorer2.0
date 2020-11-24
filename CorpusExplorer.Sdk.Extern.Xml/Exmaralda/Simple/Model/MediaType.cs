#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
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
    public object Filename
    {
      get => filenameField;
      set => filenameField = value;
    }

    /// <remarks />
    public string FileStore
    {
      get => fileStoreField;
      set => fileStoreField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "date")]
    public DateTime LastBackup
    {
      get => lastBackupField;
      set => lastBackupField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool LastBackupSpecified
    {
      get => lastBackupFieldSpecified;
      set => lastBackupFieldSpecified = value;
    }

    /// <remarks />
    [XmlElement(DataType = "anyURI")]
    public string NSLink
    {
      get => nSLinkField;
      set => nSLinkField = value;
    }
  }
}
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
  public class RecordingType
  {
    private AvailabilityType availabliltyField;
    private KeyType[] descriptionField;
    private FileType[] fileField;
    private string idField;
    private MediaType[] mediaField;
    private string nameField;
    private DateTime recordingDateTimeField;
    private bool recordingDateTimeFieldSpecified;
    private long recordingDurationField;
    private bool recordingDurationFieldSpecified;

    /// <remarks />
    public AvailabilityType Availablilty { get { return availabliltyField; } set { availabliltyField = value; } }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    [XmlElement("File")]
    public FileType[] File { get { return fileField; } set { fileField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("Media")]
    public MediaType[] Media { get { return mediaField; } set { mediaField = value; } }

    /// <remarks />
    public string Name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    public DateTime RecordingDateTime { get { return recordingDateTimeField; } set { recordingDateTimeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool RecordingDateTimeSpecified
    {
      get { return recordingDateTimeFieldSpecified; }
      set { recordingDateTimeFieldSpecified = value; }
    }

    /// <remarks />
    public long RecordingDuration { get { return recordingDurationField; } set { recordingDurationField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool RecordingDurationSpecified
    {
      get { return recordingDurationFieldSpecified; }
      set { recordingDurationFieldSpecified = value; }
    }
  }
}
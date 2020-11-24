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
  public class CommunicationType
  {
    private string idField;
    private object[] itemsField;
    private string nameField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("AsocFile", typeof(AsocFileType))]
    [XmlElement("Description", typeof(DescriptionType))]
    [XmlElement("File", typeof(FileType))]
    [XmlElement("Language", typeof(LanguageType))]
    [XmlElement("Location", typeof(LocationType))]
    [XmlElement("Recording", typeof(RecordingType))]
    [XmlElement("Setting", typeof(CommunicationTypeSetting))]
    [XmlElement("Transcription", typeof(TranscriptionType))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }
  }
}
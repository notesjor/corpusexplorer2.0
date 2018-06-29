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
  public class CorpusType
  {
    private AsocFileType[] asocFileField;
    private object dBNodeField;
    private KeyType[] descriptionField;
    private string idField;
    private object[] itemsField;
    private KeyType[][] mirrorsField;
    private string nameField;
    private string parentField;
    private string schemaVersionField;
    private string uniqueSpeakerDistinctionField;

    /// <remarks />
    [XmlElement("AsocFile")]
    public AsocFileType[] AsocFile
    {
      get => asocFileField;
      set => asocFileField = value;
    }

    /// <remarks />
    public object DBNode
    {
      get => dBNodeField;
      set => dBNodeField = value;
    }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description
    {
      get => descriptionField;
      set => descriptionField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("Corpus", typeof(CorpusType))]
    [XmlElement("CorpusData", typeof(CorpusData))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlArrayItem("Key", typeof(KeyType), IsNullable = false)]
    public KeyType[][] Mirrors
    {
      get => mirrorsField;
      set => mirrorsField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "IDREF")]
    public string Parent
    {
      get => parentField;
      set => parentField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string schemaVersion
    {
      get => schemaVersionField;
      set => schemaVersionField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string uniqueSpeakerDistinction
    {
      get => uniqueSpeakerDistinctionField;
      set => uniqueSpeakerDistinctionField = value;
    }
  }
}
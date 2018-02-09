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
  public class AsocFileType
  {
    private KeyType[] descriptionField;
    private FileType fileField;
    private string idField;
    private object nameField;

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    public FileType File { get { return fileField; } set { fileField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "ID")]
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public object Name { get { return nameField; } set { nameField = value; } }
  }
}
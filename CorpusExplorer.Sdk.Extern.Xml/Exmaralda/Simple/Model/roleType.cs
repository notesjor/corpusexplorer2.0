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
  public class roleType
  {
    private DescriptionType[] itemsField;
    private string targetField;
    private string typeField;

    /// <remarks />
    [XmlElement("Description")]
    public DescriptionType[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "IDREF")]
    public string target
    {
      get => targetField;
      set => targetField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string Type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}
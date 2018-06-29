#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class speaker
  {
    private string abbreviationField;
    private string commentField;
    private string idField;
    private language[] l1Field;
    private language[] l2Field;
    private language[] languagesusedField;
    private sex sexField;
    private udinformation[] udspeakerinformationField;

    /// <remarks />
    public string abbreviation
    {
      get => abbreviationField;
      set => abbreviationField = value;
    }

    /// <remarks />
    public string comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlArrayItem("language", IsNullable = false)]
    public language[] l1
    {
      get => l1Field;
      set => l1Field = value;
    }

    /// <remarks />
    [XmlArrayItem("language", IsNullable = false)]
    public language[] l2
    {
      get => l2Field;
      set => l2Field = value;
    }

    /// <remarks />
    [XmlArray("languages-used")]
    [XmlArrayItem("language", IsNullable = false)]
    public language[] languagesused
    {
      get => languagesusedField;
      set => languagesusedField = value;
    }

    /// <remarks />
    public sex sex
    {
      get => sexField;
      set => sexField = value;
    }

    /// <remarks />
    [XmlArray("ud-speaker-information")]
    [XmlArrayItem("ud-information", IsNullable = false)]
    public udinformation[] udspeakerinformation
    {
      get => udspeakerinformationField;
      set => udspeakerinformationField = value;
    }
  }
}
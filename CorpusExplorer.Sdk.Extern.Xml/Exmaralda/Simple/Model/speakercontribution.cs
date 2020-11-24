#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("speaker-contribution", Namespace = "", IsNullable = false)]
  public class speakercontribution
  {
    private string abbreviationField;
    private annotation[] annotationField;
    private string commentField;
    private ats[][] dependentField;
    private string idField;
    private language[] l1Field;
    private language[] l2Field;
    private language[] languagesusedField;
    private main mainField;
    private sex sexField;
    private string speakerField;
    private udinformation[] udspeakerinformationField;

    /// <remarks />
    public string abbreviation
    {
      get => abbreviationField;
      set => abbreviationField = value;
    }

    /// <remarks />
    [XmlElement("annotation")]
    public annotation[] annotation
    {
      get => annotationField;
      set => annotationField = value;
    }

    /// <remarks />
    public string comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    [XmlArrayItem("ats", typeof(ats), IsNullable = false)]
    public ats[][] dependent
    {
      get => dependentField;
      set => dependentField = value;
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
    public main main
    {
      get => mainField;
      set => mainField = value;
    }

    /// <remarks />
    public sex sex
    {
      get => sexField;
      set => sexField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string speaker
    {
      get => speakerField;
      set => speakerField = value;
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
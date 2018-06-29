#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  public class participantType
  {
    private string ageField;
    private string ageToField;
    private DateTime birthdayField;
    private bool birthdayFieldSpecified;
    private string birthplaceField;
    private string customfieldField;
    private string educationField;
    private string firstlanguageField;
    private string groupField;
    private string idField;
    private string[] languageField;
    private string nameField;
    private roleType roleField;
    private string sESField;
    private sexType sexField;
    private bool sexFieldSpecified;

    /// <remarks />
    [XmlAttribute(DataType = "duration")]
    public string age
    {
      get => ageField;
      set => ageField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "duration")]
    public string ageTo
    {
      get => ageToField;
      set => ageToField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "date")]
    public DateTime birthday
    {
      get => birthdayField;
      set => birthdayField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool birthdaySpecified
    {
      get => birthdayFieldSpecified;
      set => birthdayFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string birthplace
    {
      get => birthplaceField;
      set => birthplaceField = value;
    }

    /// <remarks />
    [XmlAttribute("custom-field")]
    public string customfield
    {
      get => customfieldField;
      set => customfieldField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string education
    {
      get => educationField;
      set => educationField = value;
    }

    /// <remarks />
    [XmlAttribute("first-language", DataType = "language")]
    public string firstlanguage
    {
      get => firstlanguageField;
      set => firstlanguageField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string group
    {
      get => groupField;
      set => groupField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "language")]
    public string[] language
    {
      get => languageField;
      set => languageField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public roleType role
    {
      get => roleField;
      set => roleField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string SES
    {
      get => sESField;
      set => sESField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public sexType sex
    {
      get => sexField;
      set => sexField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool sexSpecified
    {
      get => sexFieldSpecified;
      set => sexFieldSpecified = value;
    }
  }
}
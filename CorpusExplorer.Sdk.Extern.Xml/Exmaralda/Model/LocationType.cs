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
  public class LocationType
  {
    private string cityField;
    private string countryField;
    private KeyType[] descriptionField;
    private PeriodType periodField;
    private string postalCodeField;
    private string streetField;
    private string typeField;

    /// <remarks />
    public string City { get { return cityField; } set { cityField = value; } }

    /// <remarks />
    public string Country { get { return countryField; } set { countryField = value; } }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] Description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    public PeriodType Period { get { return periodField; } set { periodField = value; } }

    /// <remarks />
    public string PostalCode { get { return postalCodeField; } set { postalCodeField = value; } }

    /// <remarks />
    public string Street { get { return streetField; } set { streetField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified)]
    public string Type { get { return typeField; } set { typeField = value; } }
  }
}
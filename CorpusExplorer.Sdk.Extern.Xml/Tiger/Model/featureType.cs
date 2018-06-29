#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class featureType
  {
    private featureTypeDomain domainField;
    private string nameField;
    private featurevalueType[] valueField;

    /// <remarks />
    [XmlAttribute]
    public featureTypeDomain domain
    {
      get => domainField;
      set => domainField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlElement("value", Form = XmlSchemaForm.Unqualified)]
    public featurevalueType[] value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}
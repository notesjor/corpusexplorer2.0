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
  public class annotationType
  {
    private featurevalueType[] edgelabelField;
    private featureType[] featureField;
    private featurevalueType[] secedgelabelField;

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("value", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public featurevalueType[] edgelabel { get { return edgelabelField; } set { edgelabelField = value; } }

    /// <remarks />
    [XmlElement("feature", Form = XmlSchemaForm.Unqualified)]
    public featureType[] feature { get { return featureField; } set { featureField = value; } }

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("value", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public featurevalueType[] secedgelabel { get { return secedgelabelField; } set { secedgelabelField = value; } }
  }
}
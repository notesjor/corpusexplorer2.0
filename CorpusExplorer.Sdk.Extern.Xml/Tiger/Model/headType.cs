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
  [XmlRoot("head", Namespace = "", IsNullable = false)]
  public class headType
  {
    private annotationType annotationField;
    private string externalField;
    private metaType metaField;

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public annotationType annotation { get { return annotationField; } set { annotationField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string external { get { return externalField; } set { externalField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public metaType meta { get { return metaField; } set { metaField = value; } }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd")]
  [XmlRoot(Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd", IsNullable = false)]
  public class Configuration
  {
    private string keyField;
    private string valueField;

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string Key { get { return keyField; } set { keyField = value; } }

    /// <remarks />
    public string Value { get { return valueField; } set { valueField = value; } }
  }
}
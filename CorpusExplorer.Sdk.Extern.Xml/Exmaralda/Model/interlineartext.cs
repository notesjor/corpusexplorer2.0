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
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  [XmlRoot("interlinear-text", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class interlineartext
  {
    private string formatrefField;
    private format[] formatsField;
    private object[] itemsField;
    private udattribute[] udinformationField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref { get { return formatrefField; } set { formatrefField = value; } }

    /// <remarks />
    [XmlArrayItem("format", IsNullable = false)]
    public format[] formats { get { return formatsField; } set { formatsField = value; } }

    /// <remarks />
    [XmlElement("it-bundle", typeof(itbundle))]
    [XmlElement("line", typeof(line))]
    [XmlElement("page-break", typeof(pagebreak))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlArray("ud-information")]
    [XmlArrayItem("ud-attribute", IsNullable = false)]
    public udattribute[] udinformation { get { return udinformationField; } set { udinformationField = value; } }
  }
}
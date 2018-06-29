using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Light.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class lg
  {
    private string[] lField;

    private lg lg1Field;

    private pb pbField;

    /// <remarks />
    [XmlElement("lg")]
    public lg lg1
    {
      get => lg1Field;
      set => lg1Field = value;
    }

    /// <remarks />
    [XmlElement("l")]
    public string[] l
    {
      get => lField;
      set => lField = value;
    }


    /// <remarks />
    public pb pb
    {
      get => pbField;
      set => pbField = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class wf
  {
    private string lengthField;

    private string offsetField;

    private string pageField;

    private string paraField;

    private string sentField;

    private string[] textField;

    private string widField;

    private string xpathField;

    /// <remarks />
    [XmlAttribute]
    public string length
    {
      get => lengthField;
      set => lengthField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string offset
    {
      get => offsetField;
      set => offsetField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string page
    {
      get => pageField;
      set => pageField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string para
    {
      get => paraField;
      set => paraField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string sent
    {
      get => sentField;
      set => sentField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string wid
    {
      get => widField;
      set => widField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string xpath
    {
      get => xpathField;
      set => xpathField = value;
    }
  }
}
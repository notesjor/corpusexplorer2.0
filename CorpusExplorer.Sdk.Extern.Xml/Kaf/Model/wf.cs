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
    public string length { get { return lengthField; } set { lengthField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string offset { get { return offsetField; } set { offsetField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string page { get { return pageField; } set { pageField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string para { get { return paraField; } set { paraField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string sent { get { return sentField; } set { sentField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string wid { get { return widField; } set { widField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string xpath { get { return xpathField; } set { xpathField = value; } }
  }
}
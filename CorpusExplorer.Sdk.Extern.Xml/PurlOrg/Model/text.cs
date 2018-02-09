using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class text
  {
    private string anredeField;

    private string datumField;

    private string excerptField;

    private string ortField;

    private string personField;

    private string rohtextField;

    private string titelField;

    private string untertitelField;

    private string urlField;

    /// <remarks />
    [XmlAttribute]
    public string anrede { get { return anredeField; } set { anredeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string datum { get { return datumField; } set { datumField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string excerpt { get { return excerptField; } set { excerptField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string ort { get { return ortField; } set { ortField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string person { get { return personField; } set { personField = value; } }

    /// <remarks />
    public string rohtext { get { return rohtextField; } set { rohtextField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string titel { get { return titelField; } set { titelField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string untertitel { get { return untertitelField; } set { untertitelField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string url { get { return urlField; } set { urlField = value; } }
  }
}
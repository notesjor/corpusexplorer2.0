using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class metadaten
  {
    private string artikelidField;

    private string artikelpdfField;

    private autor[] autorField;

    private string[] firmaField;

    private string[] ortField;

    private string[] personField;

    private quelle quelleField;

    private string[] seitenpdfField;

    private string urheberinformationField;

    private string weblinkField;

    private string worteField;

    /// <remarks />
    [XmlElement("artikel-id")]
    public string artikelid { get { return artikelidField; } set { artikelidField = value; } }

    /// <remarks />
    [XmlElement("autor")]
    public autor[] autor { get { return autorField; } set { autorField = value; } }

    /// <remarks />
    [XmlElement("seiten-pdf")]
    public string[] seitenpdf { get { return seitenpdfField; } set { seitenpdfField = value; } }

    /// <remarks />
    [XmlElement("artikel-pdf")]
    public string artikelpdf { get { return artikelpdfField; } set { artikelpdfField = value; } }


    /// <remarks />
    [XmlElement("firma")]
    public string[] firma { get { return firmaField; } set { firmaField = value; } }

    /// <remarks />
    [XmlElement("person")]
    public string[] person { get { return personField; } set { personField = value; } }

    /// <remarks />
    [XmlElement("ort")]
    public string[] ort { get { return ortField; } set { ortField = value; } }


    /// <remarks />
    public quelle quelle { get { return quelleField; } set { quelleField = value; } }


    /// <remarks />
    public string urheberinformation
    {
      get { return urheberinformationField; }
      set { urheberinformationField = value; }
    }

    /// <remarks />
    public string weblink { get { return weblinkField; } set { weblinkField = value; } }

    /// <remarks />
    public string worte { get { return worteField; } set { worteField = value; } }
  }
}
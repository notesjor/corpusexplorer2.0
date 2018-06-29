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
    public string artikelid
    {
      get => artikelidField;
      set => artikelidField = value;
    }

    /// <remarks />
    [XmlElement("autor")]
    public autor[] autor
    {
      get => autorField;
      set => autorField = value;
    }

    /// <remarks />
    [XmlElement("seiten-pdf")]
    public string[] seitenpdf
    {
      get => seitenpdfField;
      set => seitenpdfField = value;
    }

    /// <remarks />
    [XmlElement("artikel-pdf")]
    public string artikelpdf
    {
      get => artikelpdfField;
      set => artikelpdfField = value;
    }


    /// <remarks />
    [XmlElement("firma")]
    public string[] firma
    {
      get => firmaField;
      set => firmaField = value;
    }

    /// <remarks />
    [XmlElement("person")]
    public string[] person
    {
      get => personField;
      set => personField = value;
    }

    /// <remarks />
    [XmlElement("ort")]
    public string[] ort
    {
      get => ortField;
      set => ortField = value;
    }


    /// <remarks />
    public quelle quelle
    {
      get => quelleField;
      set => quelleField = value;
    }


    /// <remarks />
    public string urheberinformation
    {
      get => urheberinformationField;
      set => urheberinformationField = value;
    }

    /// <remarks />
    public string weblink
    {
      get => weblinkField;
      set => weblinkField = value;
    }

    /// <remarks />
    public string worte
    {
      get => worteField;
      set => worteField = value;
    }
  }
}
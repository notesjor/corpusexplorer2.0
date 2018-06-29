using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.BonnerFruehneuhochdeutschkorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class annotation
  {
    private string adj_linksField;

    private string adj_rechtsField;

    private string adj_rolleField;

    private string adverbialField;

    private string anno_nrField;

    private string fern_teileField;

    private string flexivField;

    private string formField;

    private string fremdwortField;

    private string gefundenField;

    private string gelesenField;

    private string genusField;

    private string kasusField;

    private string klasseField;

    private string komparationField;

    private string komparationsstufeField;

    private string leerField;

    private string lemmaField;

    private string link_lemmaField;

    private string modusField;

    private string numerusField;

    private string personField;

    private praefix_block[] praefix_blockField;

    private string praefixeField;

    private string praefixField;

    private string suffixField;

    private string tempusField;

    private string typField;

    private string vokalField;

    private string vorzeichenField;

    private string wf_nrField;

    private string zeichenField;

    /// <remarks />
    [XmlAttribute]
    public string adj_links
    {
      get => adj_linksField;
      set => adj_linksField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string adj_rechts
    {
      get => adj_rechtsField;
      set => adj_rechtsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string adj_rolle
    {
      get => adj_rolleField;
      set => adj_rolleField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string adverbial
    {
      get => adverbialField;
      set => adverbialField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string anno_nr
    {
      get => anno_nrField;
      set => anno_nrField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string fern_teile
    {
      get => fern_teileField;
      set => fern_teileField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string flexiv
    {
      get => flexivField;
      set => flexivField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string form
    {
      get => formField;
      set => formField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string fremdwort
    {
      get => fremdwortField;
      set => fremdwortField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string gefunden
    {
      get => gefundenField;
      set => gefundenField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string gelesen
    {
      get => gelesenField;
      set => gelesenField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string genus
    {
      get => genusField;
      set => genusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string kasus
    {
      get => kasusField;
      set => kasusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string klasse
    {
      get => klasseField;
      set => klasseField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string komparation
    {
      get => komparationField;
      set => komparationField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string komparationsstufe
    {
      get => komparationsstufeField;
      set => komparationsstufeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string leer
    {
      get => leerField;
      set => leerField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string lemma
    {
      get => lemmaField;
      set => lemmaField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string link_lemma
    {
      get => link_lemmaField;
      set => link_lemmaField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string modus
    {
      get => modusField;
      set => modusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string numerus
    {
      get => numerusField;
      set => numerusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string person
    {
      get => personField;
      set => personField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string praefix
    {
      get => praefixField;
      set => praefixField = value;
    }

    /// <remarks />
    [XmlElement("praefix_block")]
    public praefix_block[] praefix_block
    {
      get => praefix_blockField;
      set => praefix_blockField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string praefixe
    {
      get => praefixeField;
      set => praefixeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string suffix
    {
      get => suffixField;
      set => suffixField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string tempus
    {
      get => tempusField;
      set => tempusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string typ
    {
      get => typField;
      set => typField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string vokal
    {
      get => vokalField;
      set => vokalField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string vorzeichen
    {
      get => vorzeichenField;
      set => vorzeichenField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string wf_nr
    {
      get => wf_nrField;
      set => wf_nrField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string zeichen
    {
      get => zeichenField;
      set => zeichenField = value;
    }
  }
}
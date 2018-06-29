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
  public class Zusatz
  {
    private string druckerField;

    private string edit_AnmField;

    private Edit_Eingr edit_EingrField;

    private string schreiberField;

    private Textart textartField;

    private string uebersetzerField;

    private string verfasserField;

    private string vorlageField;

    /// <remarks />
    public string Drucker
    {
      get => druckerField;
      set => druckerField = value;
    }

    /// <remarks />
    public string Edit_Anm
    {
      get => edit_AnmField;
      set => edit_AnmField = value;
    }

    /// <remarks />
    public Edit_Eingr Edit_Eingr
    {
      get => edit_EingrField;
      set => edit_EingrField = value;
    }

    /// <remarks />
    public string Schreiber
    {
      get => schreiberField;
      set => schreiberField = value;
    }

    /// <remarks />
    public Textart Textart
    {
      get => textartField;
      set => textartField = value;
    }

    /// <remarks />
    public string Uebersetzer
    {
      get => uebersetzerField;
      set => uebersetzerField = value;
    }

    /// <remarks />
    public string Verfasser
    {
      get => verfasserField;
      set => verfasserField = value;
    }

    /// <remarks />
    public string Vorlage
    {
      get => vorlageField;
      set => vorlageField = value;
    }
  }
}
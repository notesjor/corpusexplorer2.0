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
  [XmlRoot("titel-liste", Namespace = "", IsNullable = false)]
  public class titelliste
  {
    private string dachzeileField;

    private string kurztitelField;

    private string ressortField;

    private string rubrikField;

    private string seitentitelField;

    private string serientitelField;

    private string titelField;

    private string untertitelField;

    /// <remarks />
    public string dachzeile
    {
      get => dachzeileField;
      set => dachzeileField = value;
    }

    /// <remarks />
    public string kurztitel
    {
      get => kurztitelField;
      set => kurztitelField = value;
    }

    /// <remarks />
    public string ressort
    {
      get => ressortField;
      set => ressortField = value;
    }

    /// <remarks />
    public string rubrik
    {
      get => rubrikField;
      set => rubrikField = value;
    }

    /// <remarks />
    public string seitentitel
    {
      get => seitentitelField;
      set => seitentitelField = value;
    }

    /// <remarks />
    public string serientitel
    {
      get => serientitelField;
      set => serientitelField = value;
    }

    /// <remarks />
    public string titel
    {
      get => titelField;
      set => titelField = value;
    }

    /// <remarks />
    public string untertitel
    {
      get => untertitelField;
      set => untertitelField = value;
    }
  }
}
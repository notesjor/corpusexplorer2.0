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
  public class Basis
  {
    private string aufgenommenField;

    private Ersch erschField;

    private string hrsgField;

    private Kurztitel kurztitelField;

    private Landschaft landschaftField;

    private string quelleField;

    private string titelField;

    private Zeit zeitField;

    /// <remarks />
    public string aufgenommen
    {
      get => aufgenommenField;
      set => aufgenommenField = value;
    }

    /// <remarks />
    public Ersch Ersch
    {
      get => erschField;
      set => erschField = value;
    }

    /// <remarks />
    public string Hrsg
    {
      get => hrsgField;
      set => hrsgField = value;
    }

    /// <remarks />
    public Kurztitel Kurztitel
    {
      get => kurztitelField;
      set => kurztitelField = value;
    }

    /// <remarks />
    public Landschaft Landschaft
    {
      get => landschaftField;
      set => landschaftField = value;
    }

    /// <remarks />
    public string Quelle
    {
      get => quelleField;
      set => quelleField = value;
    }

    /// <remarks />
    public string Titel
    {
      get => titelField;
      set => titelField = value;
    }

    /// <remarks />
    public Zeit Zeit
    {
      get => zeitField;
      set => zeitField = value;
    }
  }
}
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
  public class autor
  {
    private string autoridField;

    private string autorkurzField;

    private string autornameField;

    /// <remarks />
    [XmlElement("autor-name")]
    public string autorname
    {
      get => autornameField;
      set => autornameField = value;
    }

    /// <remarks />
    [XmlElement("autor-id")]
    public string autorid
    {
      get => autoridField;
      set => autoridField = value;
    }

    /// <remarks />
    [XmlElement("autor-kurz")]
    public string autorkurz
    {
      get => autorkurzField;
      set => autorkurzField = value;
    }
  }
}
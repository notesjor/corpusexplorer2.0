using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class edition
  {
    private appearance appearanceField;

    private string furtherField;

    private string kindField;

    /// <remarks />
    public appearance appearance
    {
      get => appearanceField;
      set => appearanceField = value;
    }

    /// <remarks />
    public string further
    {
      get => furtherField;
      set => furtherField = value;
    }

    /// <remarks />
    public string kind
    {
      get => kindField;
      set => kindField = value;
    }
  }
}
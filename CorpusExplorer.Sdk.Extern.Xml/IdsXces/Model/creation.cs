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
  public class creation
  {
    private string creatDateField;

    private string creatRefField;

    private string creatRefShortField;

    /// <remarks />
    public string creatDate
    {
      get => creatDateField;
      set => creatDateField = value;
    }

    /// <remarks />
    public string creatRef
    {
      get => creatRefField;
      set => creatRefField = value;
    }

    /// <remarks />
    public string creatRefShort
    {
      get => creatRefShortField;
      set => creatRefShortField = value;
    }
  }
}
#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class uncertain
  {
    private w[][] alternativeField;
    private w[] wField;

    /// <remarks />
    [XmlArrayItem("w", typeof(w), IsNullable = false)]
    public w[][] alternative
    {
      get => alternativeField;
      set => alternativeField = value;
    }

    /// <remarks />
    [XmlElement("w")]
    public w[] w
    {
      get => wField;
      set => wField = value;
    }
  }
}
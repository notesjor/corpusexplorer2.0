#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class TEI
  {
    private teiHeader teiHeaderField;
    private text textField;

    /// <remarks />
    public teiHeader teiHeader
    {
      get => teiHeaderField;
      set => teiHeaderField = value;
    }

    /// <remarks />
    public text text
    {
      get => textField;
      set => textField = value;
    }
  }
}
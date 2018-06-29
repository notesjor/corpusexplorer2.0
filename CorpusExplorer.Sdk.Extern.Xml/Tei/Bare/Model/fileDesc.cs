#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.tei-c.org/ns/1.0")]
  public class fileDesc
  {
    private fileDesc1 fileDesc1Field;

    /// <remarks />
    [XmlElement("fileDesc")]
    public fileDesc1 fileDesc1
    {
      get => fileDesc1Field;
      set => fileDesc1Field = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class lp
  {
    private string nameField;

    private string timestampField;

    private string versionField;

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string timestamp
    {
      get => timestampField;
      set => timestampField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string version
    {
      get => versionField;
      set => versionField = value;
    }
  }
}
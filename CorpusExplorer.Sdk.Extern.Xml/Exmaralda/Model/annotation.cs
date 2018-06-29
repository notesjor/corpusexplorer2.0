#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class annotation
  {
    private string nameField;
    private ta[] taField;
    private string tierrefField;

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlElement("ta")]
    public ta[] ta
    {
      get => taField;
      set => taField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string tierref
    {
      get => tierrefField;
      set => tierrefField = value;
    }
  }
}
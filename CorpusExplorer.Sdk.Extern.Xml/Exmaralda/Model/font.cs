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
  public class font
  {
    private fontFace faceField;
    private string nameField;
    private fontSize sizeField;

    /// <remarks />
    [XmlAttribute]
    public fontFace face
    {
      get => faceField;
      set => faceField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public fontSize size
    {
      get => sizeField;
      set => sizeField = value;
    }
  }
}
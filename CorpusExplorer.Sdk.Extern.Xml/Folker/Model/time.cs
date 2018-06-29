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
  public class time
  {
    private string timepointreferenceField;

    /// <remarks />
    [XmlAttribute("timepoint-reference", DataType = "IDREF")]
    public string timepointreference
    {
      get => timepointreferenceField;
      set => timepointreferenceField = value;
    }
  }
}
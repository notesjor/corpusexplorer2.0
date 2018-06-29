#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("ca-element", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class caelement
  {
    private caelementtype typeField;

    /// <remarks />
    [XmlAttribute]
    public caelementtype type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}
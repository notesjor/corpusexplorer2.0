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
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("menx", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class morphemicTranslationType
  {
    private string valueField;

    /// <remarks />
    [XmlText]
    public string Value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}
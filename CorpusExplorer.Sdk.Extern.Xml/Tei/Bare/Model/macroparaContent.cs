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
  [XmlType(TypeName = "macro.paraContent", Namespace = "http://www.tei-c.org/ns/1.0")]
  public class macroparaContent
  {
    private object[] itemsField;
    private string[] textField;

    /// <remarks />
    [XmlElement("model.inter", typeof(object))]
    [XmlElement("model.phrase", typeof(modelphrase))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}
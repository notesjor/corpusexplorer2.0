#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class w
  {
    private object[] itemsField;
    private string[] textField;
    private wTransition transitionField;
    private bool transitionFieldSpecified;

    /// <remarks />
    [XmlElement("lengthening", typeof(lengthening))]
    [XmlElement("stress", typeof(stress))]
    [XmlElement("time", typeof(time))]
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

    /// <remarks />
    [XmlAttribute]
    public wTransition transition
    {
      get => transitionField;
      set => transitionField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool transitionSpecified
    {
      get => transitionFieldSpecified;
      set => transitionFieldSpecified = value;
    }

    public static implicit operator w(w[] obj)
    {
      return obj[0];
    }

    public static implicit operator w[](w obj)
    {
      return new[] {obj};
    }
  }
}
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
  public class AGSetAGAnchor
  {
    private string idField;
    private string offsetField;
    private string signalsField;
    private string unitField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string offset
    {
      get => offsetField;
      set => offsetField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREFS")]
    public string signals
    {
      get => signalsField;
      set => signalsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string unit
    {
      get => unitField;
      set => unitField = value;
    }
  }
}
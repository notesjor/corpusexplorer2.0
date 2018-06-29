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
  public class entity
  {
    private string eidField;

    private span[][] referencesField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string eid
    {
      get => eidField;
      set => eidField = value;
    }

    /// <remarks />
    [XmlArrayItem("span", typeof(span), IsNullable = false)]
    public span[][] references
    {
      get => referencesField;
      set => referencesField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}
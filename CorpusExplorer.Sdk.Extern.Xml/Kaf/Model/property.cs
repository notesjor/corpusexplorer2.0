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
  public class property
  {
    private string lemmaField;

    private string pidField;

    private span[][] referencesField;

    /// <remarks />
    [XmlAttribute]
    public string lemma
    {
      get => lemmaField;
      set => lemmaField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string pid
    {
      get => pidField;
      set => pidField = value;
    }

    /// <remarks />
    [XmlArrayItem("span", typeof(span), IsNullable = false)]
    public span[][] references
    {
      get => referencesField;
      set => referencesField = value;
    }
  }
}
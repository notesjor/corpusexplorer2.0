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
  public class features
  {
    private category[][] categoriesField;

    private property[][] propertiesField;

    /// <remarks />
    [XmlArrayItem("category", typeof(category), IsNullable = false)]
    public category[][] categories
    {
      get => categoriesField;
      set => categoriesField = value;
    }

    /// <remarks />
    [XmlArrayItem("property", typeof(property), IsNullable = false)]
    public property[][] properties
    {
      get => propertiesField;
      set => propertiesField = value;
    }
  }
}
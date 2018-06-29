using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class address
  {
    private string addrLineField;

    private string countryField;

    /// <remarks />
    public string addrLine
    {
      get => addrLineField;
      set => addrLineField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "NCName")]
    public string country
    {
      get => countryField;
      set => countryField = value;
    }
  }
}
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class tfoot
  {
    private Flow[][] trField;

    /// <remarks />
    [XmlArrayItem("td", typeof(td), IsNullable = false)]
    [XmlArrayItem("th", typeof(th), IsNullable = false)]
    public Flow[][] tr { get { return trField; } set { trField = value; } }
  }
}
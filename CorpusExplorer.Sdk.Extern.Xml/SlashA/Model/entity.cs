using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public class entity
  {
    private string classField;

    private string tokenIDsField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string @class { get { return classField; } set { classField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string tokenIDs { get { return tokenIDsField; } set { tokenIDsField = value; } }
  }
}
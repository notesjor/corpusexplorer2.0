#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class head
  {
    private metainformation metainformationField;
    private speaker[] speakertableField;

    /// <remarks />
    [XmlElement("meta-information")]
    public metainformation metainformation
    {
      get { return metainformationField; }
      set { metainformationField = value; }
    }

    /// <remarks />
    [XmlArrayItem("speaker", IsNullable = false)]
    public speaker[] speakertable { get { return speakertableField; } set { speakertableField = value; } }
  }
}
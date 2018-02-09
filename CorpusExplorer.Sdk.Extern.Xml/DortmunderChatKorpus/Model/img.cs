#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class img
  {
    private string heightField;
    private string srcField;
    private imgType typeField;
    private bool typeFieldSpecified;
    private string widthField;

    /// <remarks />
    [XmlAttribute]
    public string height { get { return heightField; } set { heightField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string src { get { return srcField; } set { srcField = value; } }

    /// <remarks />
    [XmlAttribute]
    public imgType type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool typeSpecified { get { return typeFieldSpecified; } set { typeFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string width { get { return widthField; } set { widthField = value; } }
  }
}
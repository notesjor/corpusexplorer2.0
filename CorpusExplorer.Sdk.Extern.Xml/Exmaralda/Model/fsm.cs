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
  public class fsm
  {
    private charset[] charsetField;
    private endstate endstateField;
    private string nameField;
    private startstate startstateField;
    private transitions[] transitionsField;

    /// <remarks />
    [XmlElement("char-set")]
    public charset[] charset { get { return charsetField; } set { charsetField = value; } }

    /// <remarks />
    [XmlElement("end-state")]
    public endstate endstate { get { return endstateField; } set { endstateField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    [XmlElement("start-state")]
    public startstate startstate { get { return startstateField; } set { startstateField = value; } }

    /// <remarks />
    [XmlElement("transitions")]
    public transitions[] transitions { get { return transitionsField; } set { transitionsField = value; } }
  }
}
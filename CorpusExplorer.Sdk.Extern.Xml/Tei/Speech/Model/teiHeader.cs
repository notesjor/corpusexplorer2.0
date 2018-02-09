#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class teiHeader
  {
    private fileDesc fileDescField;
    private profileDesc profileDescField;
    private revisionDesc revisionDescField;

    /// <remarks />
    public fileDesc fileDesc { get { return fileDescField; } set { fileDescField = value; } }

    /// <remarks />
    public profileDesc profileDesc { get { return profileDescField; } set { profileDescField = value; } }

    /// <remarks />
    public revisionDesc revisionDesc { get { return revisionDescField; } set { revisionDescField = value; } }
  }
}
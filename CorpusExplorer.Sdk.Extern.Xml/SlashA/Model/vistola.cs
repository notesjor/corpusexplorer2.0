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
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/metadata")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class vistola
  {
    private correspondence correspondenceField;

    private dates datesField;

    private editor editorField;

    private number numberField;

    private postmark postmarkField;

    /// <remarks />
    public correspondence correspondence { get { return correspondenceField; } set { correspondenceField = value; } }

    /// <remarks />
    public dates dates { get { return datesField; } set { datesField = value; } }

    /// <remarks />
    public editor editor { get { return editorField; } set { editorField = value; } }

    /// <remarks />
    public number number { get { return numberField; } set { numberField = value; } }

    /// <remarks />
    public postmark postmark { get { return postmarkField; } set { postmarkField = value; } }
  }
}
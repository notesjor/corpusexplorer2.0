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
    public correspondence correspondence
    {
      get => correspondenceField;
      set => correspondenceField = value;
    }

    /// <remarks />
    public dates dates
    {
      get => datesField;
      set => datesField = value;
    }

    /// <remarks />
    public editor editor
    {
      get => editorField;
      set => editorField = value;
    }

    /// <remarks />
    public number number
    {
      get => numberField;
      set => numberField = value;
    }

    /// <remarks />
    public postmark postmark
    {
      get => postmarkField;
      set => postmarkField = value;
    }
  }
}
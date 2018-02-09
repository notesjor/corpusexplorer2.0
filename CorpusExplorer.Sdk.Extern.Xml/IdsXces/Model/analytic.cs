using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class analytic
  {
    private biblNote biblNoteField;

    private biblScope[] biblScopeField;

    private string editorField;

    private string hauthorField;

    private htitle[] htitleField;

    private imprint imprintField;

    /// <remarks />
    public biblNote biblNote { get { return biblNoteField; } set { biblNoteField = value; } }

    /// <remarks />
    [XmlElement("h.title")]
    public htitle[] htitle { get { return htitleField; } set { htitleField = value; } }

    /// <remarks />
    [XmlElement("h.author")]
    public string hauthor { get { return hauthorField; } set { hauthorField = value; } }

    /// <remarks />
    [XmlElement("biblScope")]
    public biblScope[] biblScope { get { return biblScopeField; } set { biblScopeField = value; } }

    /// <remarks />
    public string editor { get { return editorField; } set { editorField = value; } }


    /// <remarks />
    public imprint imprint { get { return imprintField; } set { imprintField = value; } }
  }
}
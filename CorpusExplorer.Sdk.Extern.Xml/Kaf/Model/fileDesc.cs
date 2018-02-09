using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class fileDesc
  {
    private string authorField;

    private string creationtimeField;

    private string filenameField;

    private string filetypeField;

    private string pagesField;

    private string titleField;

    /// <remarks />
    [XmlAttribute]
    public string author { get { return authorField; } set { authorField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string creationtime { get { return creationtimeField; } set { creationtimeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string filename { get { return filenameField; } set { filenameField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string filetype { get { return filetypeField; } set { filetypeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string pages { get { return pagesField; } set { pagesField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string title { get { return titleField; } set { titleField = value; } }
  }
}
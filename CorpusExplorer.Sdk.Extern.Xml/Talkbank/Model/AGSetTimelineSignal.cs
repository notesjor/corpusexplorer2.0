#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  public class AGSetTimelineSignal
  {
    private string encodingField;
    private string hrefField;
    private string idField;
    private Metadata metadataField;
    private string mimeClassField;
    private string mimeTypeField;
    private string trackField;
    private string unitField;

    /// <remarks />
    [XmlAttribute]
    public string encoding { get { return encodingField; } set { encodingField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string href { get { return hrefField; } set { hrefField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public Metadata Metadata { get { return metadataField; } set { metadataField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string mimeClass { get { return mimeClassField; } set { mimeClassField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string mimeType { get { return mimeTypeField; } set { mimeTypeField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string track { get { return trackField; } set { trackField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string unit { get { return unitField; } set { unitField = value; } }
  }
}
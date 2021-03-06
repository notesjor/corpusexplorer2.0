#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class ntType
  {
    private XmlAttribute[] anyAttrField;
    private edgeType[] edgeField;
    private string idField;
    private secedgeType[] secedgeField;

    /// <remarks />
    [XmlAnyAttribute]
    public XmlAttribute[] AnyAttr
    {
      get => anyAttrField;
      set => anyAttrField = value;
    }

    /// <remarks />
    [XmlElement("edge", Form = XmlSchemaForm.Unqualified)]
    public edgeType[] edge
    {
      get => edgeField;
      set => edgeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("secedge", Form = XmlSchemaForm.Unqualified)]
    public secedgeType[] secedge
    {
      get => secedgeField;
      set => secedgeField = value;
    }
  }
}
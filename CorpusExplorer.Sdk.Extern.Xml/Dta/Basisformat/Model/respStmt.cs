using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class respStmt
  {
    private string correspField;

    private string idField;

    private object[] itemsField;

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("orgName", typeof(orgName))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("resp", typeof(resp))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}
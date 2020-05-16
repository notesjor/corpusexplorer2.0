#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class corpus
  {
    private headType _headField;
    private object[] bodyField;
    private string idField;
    private string versionField;

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("s", typeof(sentenceType), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    [XmlArrayItem("subcorpus", typeof(subcorpusType), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public object[] body
    {
      get => bodyField;
      set => bodyField = value;
    }

    /// <remarks />
    [XmlElement("head", Form = XmlSchemaForm.Unqualified)]
    public headType head
    {
      get => _headField;
      set => _headField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string version
    {
      get => versionField;
      set => versionField = value;
    }
  }
}
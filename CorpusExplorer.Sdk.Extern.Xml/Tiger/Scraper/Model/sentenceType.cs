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
  public class sentenceType
  {
    private graphType graphField;
    private string idField;
    private matchType[] matchesField;

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public graphType graph
    {
      get => graphField;
      set => graphField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("match", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public matchType[] matches
    {
      get => matchesField;
      set => matchesField = value;
    }
  }
}
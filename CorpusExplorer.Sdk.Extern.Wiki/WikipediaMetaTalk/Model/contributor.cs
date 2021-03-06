﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true,
    Namespace = "http://www.mediawiki.org/xml/export-0.10/")]
  [XmlRoot(Namespace = "http://www.mediawiki.org/xml/export-0.10/",
    IsNullable = false)]
  public class contributor
  {
    private string deletedField;

    private ItemsChoiceType[] itemsElementNameField;

    private string[] itemsField;

    /// <remarks />
    [XmlElement("id", typeof(string), DataType = "integer")]
    [XmlElement("ip", typeof(string), DataType = "NMTOKEN")]
    [XmlElement("username", typeof(string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public string[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get => itemsElementNameField;
      set => itemsElementNameField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string deleted
    {
      get => deletedField;
      set => deletedField = value;
    }
  }
}
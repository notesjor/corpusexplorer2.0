﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class tr
  {
    private Flow[] itemsField;

    /// <remarks />
    [XmlElement("td", typeof(td))]
    [XmlElement("th", typeof(th))]
    public Flow[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }
  }
}
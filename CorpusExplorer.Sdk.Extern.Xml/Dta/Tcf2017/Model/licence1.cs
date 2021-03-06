﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [XmlRoot("licence", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438",
    IsNullable = false)]
  public class licence1
  {
    private string pField;

    private string targetField;

    /// <remarks />
    public string p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string target
    {
      get => targetField;
      set => targetField = value;
    }
  }
}
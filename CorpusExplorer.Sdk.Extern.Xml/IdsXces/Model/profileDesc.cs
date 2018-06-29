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
  public class profileDesc
  {
    private creation creationField;

    private langUsage langUsageField;

    private textClass textClassField;

    private textDesc textDescField;

    /// <remarks />
    public creation creation
    {
      get => creationField;
      set => creationField = value;
    }

    /// <remarks />
    public langUsage langUsage
    {
      get => langUsageField;
      set => langUsageField = value;
    }

    /// <remarks />
    public textClass textClass
    {
      get => textClassField;
      set => textClassField = value;
    }

    /// <remarks />
    public textDesc textDesc
    {
      get => textDescField;
      set => textDescField = value;
    }
  }
}
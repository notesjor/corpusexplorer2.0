using System;
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
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1")]
  [XmlRoot(Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public class Header
  {
    private string mdCollectionDisplayNameField;

    private string mdCreationDateField;

    private string mdCreatorField;

    private string mdProfileField;

    private string mdSelfLinkField;

    /// <remarks />
    public string MdCollectionDisplayName
    {
      get => mdCollectionDisplayNameField;
      set => mdCollectionDisplayNameField = value;
    }

    /// <remarks />
    public string MdCreationDate
    {
      get => mdCreationDateField;
      set => mdCreationDateField = value;
    }

    /// <remarks />
    public string MdCreator
    {
      get => mdCreatorField;
      set => mdCreatorField = value;
    }

    /// <remarks />
    public string MdProfile
    {
      get => mdProfileField;
      set => mdProfileField = value;
    }

    /// <remarks />
    public string MdSelfLink
    {
      get => mdSelfLinkField;
      set => mdSelfLinkField = value;
    }
  }
}
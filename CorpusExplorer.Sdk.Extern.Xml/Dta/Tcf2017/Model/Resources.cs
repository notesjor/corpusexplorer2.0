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
  public class Resources
  {
    private JournalFileProxyList journalFileProxyListField;

    private ResourceProxy[] resourceProxyListField;

    private ResourceRelationList resourceRelationListField;

    /// <remarks />
    public JournalFileProxyList JournalFileProxyList
    {
      get => journalFileProxyListField;
      set => journalFileProxyListField = value;
    }

    /// <remarks />
    [XmlArrayItem("ResourceProxy", IsNullable = false)]
    public ResourceProxy[] ResourceProxyList
    {
      get => resourceProxyListField;
      set => resourceProxyListField = value;
    }

    /// <remarks />
    public ResourceRelationList ResourceRelationList
    {
      get => resourceRelationListField;
      set => resourceRelationListField = value;
    }
  }
}
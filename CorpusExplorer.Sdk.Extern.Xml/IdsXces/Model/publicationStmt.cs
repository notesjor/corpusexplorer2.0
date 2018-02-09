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
  public class publicationStmt
  {
    private availability availabilityField;

    private string distributorField;

    private string pubAddressField;

    private pubDate pubDateField;

    private string telephoneField;

    /// <remarks />
    public availability availability { get { return availabilityField; } set { availabilityField = value; } }

    /// <remarks />
    public string distributor { get { return distributorField; } set { distributorField = value; } }

    /// <remarks />
    public string pubAddress { get { return pubAddressField; } set { pubAddressField = value; } }

    /// <remarks />
    public pubDate pubDate { get { return pubDateField; } set { pubDateField = value; } }

    /// <remarks />
    public string telephone { get { return telephoneField; } set { telephoneField = value; } }
  }
}
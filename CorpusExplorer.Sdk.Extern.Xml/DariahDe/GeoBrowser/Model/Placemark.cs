using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.DariahDe.GeoBrowser.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class Placemark
  {
    private string addressField;

    private description descriptionField;

    private string nameField;

    private Point pointField;

    private TimeStamp timeStampField;

    /// <remarks />
    public string address { get { return addressField; } set { addressField = value; } }

    /// <remarks />
    public description description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    public string name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    public Point Point { get { return pointField; } set { pointField = value; } }

    /// <remarks />
    public TimeStamp TimeStamp { get { return timeStampField; } set { timeStampField = value; } }
  }
}
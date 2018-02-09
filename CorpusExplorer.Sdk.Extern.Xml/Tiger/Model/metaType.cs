#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class metaType
  {
    private string authorField;
    private string dateField;
    private string descriptionField;
    private string formatField;
    private string historyField;
    private string nameField;

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string author { get { return authorField; } set { authorField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string date { get { return dateField; } set { dateField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string description { get { return descriptionField; } set { descriptionField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string format { get { return formatField; } set { formatField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string history { get { return historyField; } set { historyField = value; } }

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string name { get { return nameField; } set { nameField = value; } }
  }
}
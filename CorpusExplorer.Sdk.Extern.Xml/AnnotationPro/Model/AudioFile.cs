using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd")]
  [XmlRoot(Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd", IsNullable = false)]
  public class AudioFile
  {
    private bool currentField;
    private bool externalField;
    private string fileNameField;
    private string idField;
    private string nameField;

    /// <remarks />
    public bool Current { get { return currentField; } set { currentField = value; } }

    /// <remarks />
    public bool External { get { return externalField; } set { externalField = value; } }

    /// <remarks />
    public string FileName { get { return fileNameField; } set { fileNameField = value; } }

    /// <remarks />
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public string Name { get { return nameField; } set { nameField = value; } }
  }
}
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
    public bool Current
    {
      get => currentField;
      set => currentField = value;
    }

    /// <remarks />
    public bool External
    {
      get => externalField;
      set => externalField = value;
    }

    /// <remarks />
    public string FileName
    {
      get => fileNameField;
      set => fileNameField = value;
    }

    /// <remarks />
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }
  }
}
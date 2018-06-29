#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("gra", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class graType
  {
    private int headField;
    private int indexField;
    private string relationField;
    private string typeField;

    /// <remarks />
    [XmlAttribute]
    public int head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public int index
    {
      get => indexField;
      set => indexField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string relation
    {
      get => relationField;
      set => relationField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}
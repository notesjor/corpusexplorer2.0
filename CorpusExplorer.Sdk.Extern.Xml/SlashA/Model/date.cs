using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/metadata")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class date
  {
    private calculated calculatedField;

    private rough roughField;

    private window windowField;

    private written writtenField;

    /// <remarks />
    public calculated calculated { get { return calculatedField; } set { calculatedField = value; } }

    /// <remarks />
    public rough rough { get { return roughField; } set { roughField = value; } }

    /// <remarks />
    public window window { get { return windowField; } set { windowField = value; } }

    /// <remarks />
    public written written { get { return writtenField; } set { writtenField = value; } }
  }
}
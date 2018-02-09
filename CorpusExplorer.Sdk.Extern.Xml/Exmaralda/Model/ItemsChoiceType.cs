#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(IncludeInSchema = false)]
  public enum ItemsChoiceType
  {
    /// <remarks />
    AsocFile,

    /// <remarks />
    Description,

    /// <remarks />
    KnownHuman,

    /// <remarks />
    Language,

    /// <remarks />
    Location,

    /// <remarks />
    Pseudo,

    /// <remarks />
    Sex,

    /// <remarks />
    Sigle,

    /// <remarks />
    role
  }
}
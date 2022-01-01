#region

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Blocks.NamedEntityRecognition
{
  [XmlRoot]
  [Serializable]
  public class Entity
  {
    [XmlAttribute]
    public string Name { get; set; }

    [XmlArray]
    public Rule[] Rules { get; set; } = new Rule[0];
  }
}
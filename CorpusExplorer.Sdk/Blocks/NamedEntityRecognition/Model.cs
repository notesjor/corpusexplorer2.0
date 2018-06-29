using System;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.NamedEntityRecognition
{
  [XmlRoot]
  [Serializable]
  public class Model
  {
    [XmlAttribute]
    public string Displayname { get; set; }

    [XmlArray]
    public Entity[] Entities { get; set; }

    public static Model Load(string path)
    {
      return Serializer.Deserialize<Model>(path);
    }

    public void Save(string path)
    {
      Serializer.Serialize(this, path, false);
    }
  }
}
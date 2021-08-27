#region usings

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  [XmlRoot("entry"), Serializable]
  public abstract class AbstrakterMetaEintrag : ICloneable
  {
    [XmlAttribute("description")]
    public string Beschreibung { get; set; }

    [XmlAttribute("isNull")]
    public abstract bool IsNull { get; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlElement]
    public object InternValue { get; set; }

    public abstract object Clone();

    public override string ToString()
    {
      return InternValue.ToString();
    }
  }
}
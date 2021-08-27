#region usings

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  [XmlRoot("entry"), Serializable]
  public class MetaEintragText : AbstrakterMetaEintrag, IAbstrakterMetaEintrag<string>
  {
    /*
    public override object Clone()
    {
      var res = new MetaEintragText();
      res.Beschreibung = Beschreibung;
      res.Name = Name;
      res.Value = string.Empty;

      return res;
    }
    */

    public override bool IsNull
    {
      get { return string.IsNullOrEmpty(Value); }
    }

    public string Value
    {
      get { return (string) InternValue; }
      set { InternValue = value; }
    }

    public override object Clone()
    {
      return new MetaEintragText {Beschreibung = Beschreibung, Name = Name, Value = Value};
    }
  }
}
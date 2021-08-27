#region usings

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  [XmlRoot("entry"), Serializable]
  public class MetaEintragZahl : AbstrakterMetaEintrag, IAbstrakterMetaEintrag<int>
  {
    /*
    public override object Clone()
    {
      var res = new MetaEintragZahl();
      res.Beschreibung = Beschreibung;
      res.Name = Name;
      res.Value = 0;

      return res;
    }
    */

    public override bool IsNull
    {
      get { return false; }
    }

    public int Value
    {
      get { return (int) InternValue; }
      set { InternValue = value; }
    }

    public override object Clone()
    {
      return new MetaEintragZahl {Beschreibung = Beschreibung, Name = Name, Value = Value};
    }
  }
}
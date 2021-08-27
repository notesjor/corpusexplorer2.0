#region usings

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  [XmlRoot("entry"), Serializable]
  public class MetaEintragDatum : AbstrakterMetaEintrag, IAbstrakterMetaEintrag<DateTime>
  {
    /*
    public override object Clone()
    {
      var res = new MetaEintragZahl();
      res.Beschreibung = Beschreibung;
      res.Name = Name;
      res.Value = DateTime.MinValue;

      return res;
    }
    */

    public override bool IsNull
    {
      get { return Value == DateTime.MinValue; }
    }

    public DateTime Value
    {
      get { return InternValue == null ? DateTime.MinValue : (DateTime) InternValue; }
      set { InternValue = value; }
    }

    public override object Clone()
    {
      return new MetaEintragDatum {Beschreibung = Beschreibung, Name = Name, Value = Value};
    }
  }
}
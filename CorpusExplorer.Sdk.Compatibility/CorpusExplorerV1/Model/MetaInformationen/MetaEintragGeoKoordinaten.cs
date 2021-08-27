#region usings

using System;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.MetaInformationen
{
  /// <summary>
  ///   Class <see cref="MetaEintragGeoKoordinaten" />
  /// </summary>
  [XmlRoot("entry"), Serializable]
  public class MetaEintragGeoKoordinaten : AbstrakterMetaEintrag
  {
    /// <summary>
    ///   The
    ///   <see cref="CorpusExplorer.Sdk.Data.Model.MetaInformationen.MetaEintragGeoKoordinaten._latitude" />
    /// </summary>
    private string _latitude;

    /// <summary>
    ///   The
    ///   <see cref="CorpusExplorer.Sdk.Data.Model.MetaInformationen.MetaEintragGeoKoordinaten._longitude" />
    /// </summary>
    private string _longitude;

    /// <summary>
    ///   Gets a value indicating whether this instance is null.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is null; otherwise, <c>false</c> .
    /// </value>
    public override bool IsNull
    {
      get { return string.IsNullOrEmpty(_longitude) || string.IsNullOrEmpty(_latitude); }
    }

    /// <summary>
    ///   Gets or sets the latitude.
    /// </summary>
    /// <value>
    ///   The latitude.
    /// </value>
    public string Latitude
    {
      get { return _latitude; }
      set
      {
        _latitude = value;
        InternValue = _latitude + ";" + _longitude;
      }
    }

    /// <summary>
    ///   Gets or sets the longitude.
    /// </summary>
    /// <value>
    ///   The longitude.
    /// </value>
    public string Longitude
    {
      get { return _longitude; }
      set
      {
        _longitude = value;
        InternValue = _latitude + ";" + _longitude;
      }
    }

    /*
    public override object Clone()
    {
      var res = new MetaEintragGeoKoordinaten();
      res.Beschreibung = Beschreibung;
      res.Name = Name;
      res.Value = new[] {Longitude, Latitude};
      res.Longitude = Longitude;
      res.Latitude = Latitude;

      return res;
    }
    */

    /// <summary>
    ///   Clones this instance.
    /// </summary>
    /// <returns>
    ///   System.Object.
    /// </returns>
    public override object Clone()
    {
      return new MetaEintragGeoKoordinaten
      {
        Beschreibung = Beschreibung,
        Name = Name,
        Latitude = Latitude,
        Longitude = Longitude
      };
    }
  }
}
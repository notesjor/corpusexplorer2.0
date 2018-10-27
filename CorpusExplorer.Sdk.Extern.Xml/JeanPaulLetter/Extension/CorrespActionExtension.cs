using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Extension
{
  public static class CorrespActionExtension
  {
    public static IEnumerable<placeName> PlaceNames(this correspAction obj)
      => obj.Items.OfType<placeName>();
  }
}

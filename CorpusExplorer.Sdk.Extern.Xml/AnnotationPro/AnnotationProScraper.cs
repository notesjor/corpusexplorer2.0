using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using Telerik.Windows.Zip;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro
{
  public sealed class AnnotationProScraper : AbstractXmlScraper
  {
    public override string DisplayName => "AnnotationPro";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      AnnotationSystemDataSet model = null;
      using(var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var zip = ZipArchive.Read(fs))
        model = XmlSerializerHelper.Deserialize<AnnotationSystemDataSet>(zip.GetEntry("annotation.xml").Open());
      
      var guid = model?.Layer.Where(layer => layer.Name == "Text").Select(layer => layer.Id).FirstOrDefault();
      if (guid == null)
        return null;

      return from segment in model.Segment
        where segment.IdLayer == guid
        select new Dictionary<string, object>
        {
          {"Text", segment.Label},
          {"Duration", segment.Duration},
          {"Feature", segment.Feature},
          {"Group", segment.Group},
          {"Id", segment.Id},
          {"Language", segment.Language},
          {"Markter", segment.Marker},
          {"Nane", segment.Name},
          {"Paramter1", segment.Parameter1},
          {"Paramter2", segment.Parameter2},
          {"Paramter3", segment.Parameter3}
        };
    }
  }
}
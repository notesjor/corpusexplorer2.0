using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.ZipFileIndex;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro
{
  public sealed class AnnotationProScraper : AbstractXmlScraper
  {
    public override string DisplayName => "AnnotationPro";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      AnnotationSystemDataSet model = null;
      var zipFile = new ZipFileIndex(file);
      zipFile.ZipDirectoryRoot.ZipFiles.FirstOrDefault(x => x.NameFile == "annotation.xml")?.Read(ms =>
      {
        model = XmlSerializerHelper.Deserialize<AnnotationSystemDataSet>(ms);
      });

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
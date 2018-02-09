using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Serializer;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro
{
  public sealed class AnnotationProScraper : AbstractGenericXmlSerializerFormatScraper<AnnotationSystemDataSet>
  {
    public override string DisplayName { get { return "AnnotationPro"; } }

    protected override AbstractGenericSerializer<AnnotationSystemDataSet> Serializer
    {
      get { return new AnnotationProSerializer(); }
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(AnnotationSystemDataSet model)
    {
      var guid = model.Layer.Where(layer => layer.Name == "Text").Select(layer => layer.Id).FirstOrDefault();
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
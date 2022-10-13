#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Telerik.Windows.Zip;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro
{
  public sealed class ExporterAnnoationPro : AbstractExporter
  {
    private static Segment BuildSegment(Segment segmentPrototyp, Guid documentGuid, AbstractLayerAdapter layer) =>
      new Segment
      {
        Id = Guid.NewGuid().ToString("D"),
        BackColor = segmentPrototyp.BackColor,
        BorderColor = segmentPrototyp.BorderColor,
        Duration = segmentPrototyp.Duration,
        Feature = segmentPrototyp.Feature,
        ForeColor = segmentPrototyp.ForeColor,
        Group = segmentPrototyp.Group,
        IdLayer = layer.Guid.ToString("D"),
        IsMarker = segmentPrototyp.IsMarker,
        IsSelected = segmentPrototyp.IsSelected,
        Marker = segmentPrototyp.Marker,
        Label = layer.GetReadableDocumentByGuid(documentGuid).ReduceDocumentToText(),
        Language = segmentPrototyp.Language,
        Name = segmentPrototyp.Name,
        Parameter1 = segmentPrototyp.Parameter1,
        Parameter2 = segmentPrototyp.Parameter2,
        Parameter3 = segmentPrototyp.Parameter3,
        RScript = segmentPrototyp.RScript,
        Start = segmentPrototyp.Start
      };

    public override void Export(IHydra hydra, string path)
    {
      AnnotationSystemDataSet ant = null;
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var zip = new ZipArchive(fs))
        ant = XmlSerializerHelper.Deserialize<AnnotationSystemDataSet>(zip.GetEntry("annotation.xml").Open());

      if (ant == null)
        return;

      var antLayer = new List<Layer>(ant.Layer);
      antLayer.AddRange(
                        hydra.Layers.Where(layer => layer.Displayname != "Wort" && layer.Displayname != "Satz")
                             .Select(
                                     layer =>
                                       new Layer
                                       {
                                         Id = layer.Guid.ToString("D"),
                                         IsVisible = true,
                                         Name = layer.Displayname,
                                         ShowOnSpectrogram = true,
                                         BackColor = "-3281999",
                                         ForeColor = "-16777216",
                                         Height = "70",
                                         ChartMinimum = "0",
                                         ChartMaximum = "100",
                                         FontSize = "10"
                                       }));
      ant.Layer = antLayer.ToArray();

      var dic = ant.Segment.ToDictionary(segment => segment.Id);

      var antSegments = new List<Segment>(ant.Segment);
      antSegments.AddRange(
                           from documentGuid in hydra.DocumentGuids
                           let meta = hydra.GetDocumentMetadata(documentGuid)
                           where meta.ContainsKey("Id") && dic.ContainsKey(meta["Id"].ToString())
                           let segment = dic[meta["Id"].ToString()]
                           from layer in hydra.Layers
                           where layer.Displayname != "Wort" && layer.Displayname != "Satz"
                           select BuildSegment(segment, documentGuid, layer));
      ant.Segment = antSegments.ToArray();

      var dir = Path.GetDirectoryName(path);
      if (dir == null)
        throw new DirectoryNotFoundException();

      var nFile = Path.Combine(dir, Path.GetFileNameWithoutExtension(path) + ".bak.ant");
      if (!File.Exists(nFile))
        File.Copy(path, nFile, false);

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
      using (var zip = new ZipArchive(fs, ZipArchiveMode.Update, true, null))
      {
        var stream = zip.GetEntry("annotation.xml").Open();
        var xml = new XmlSerializer(typeof(AnnotationSystemDataSet));
        xml.Serialize(stream, ant);
      }
    }
  }
}
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Properties;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper;
using CorpusExplorer.Sdk.Utils.ReMapper.Model;
using Telerik.Windows.Zip;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class ExporterKorap : AbstractExporter
  {
    public string ReplaceCorpusExplorerFoundry { get; set; } = null;

    public override void Export(IHydra hydra, string path)
    {
      var map = new ReMapperStandoff();
      var foundries = GetFoundries(hydra, path);

      var packages = ExportPackageHelper.MakePackages(hydra);
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var zip = ZipArchive.Create(fs))
      {
        var csigle = Path.GetFileNameWithoutExtension(path);

        // Korpus-Metadaten
        using (var entry = zip.CreateEntry($"{csigle}/header.xml"))
        using (var writer = new StreamWriter(entry.Open()))
          writer.Write(Resources.Template_Ids_KorAP_Root.Replace("{CSIGLE}", csigle)
            .Replace("{CYEAR}", DateTime.Now.Year.ToString("D4"))
            .Replace("{DATE}", DateTime.Now.ToString("yyyy-MM-dd")));

        foreach (var package in packages)
        {
          var subcsigle = $"{csigle}/{package.Key}";

          // Sub-Korpus-Metadaten (meist JAHR/MONAT)
          using (var entry = zip.CreateEntry($"{csigle}/{package.Key}/header.xml"))
          using (var writer = new StreamWriter(entry.Open()))
            writer.Write(Resources.Template_Ids_KorAP_Year
              .Replace("{SubCSigle}", subcsigle));

          var i = 0;
          foreach (var dsel in package.Value)
          {
            var doccsigle = $"{csigle}/{package.Key}.{i:D6}";
            var docid = $"{csigle}_{package.Key}.{i:D6}";

            var meta = hydra.GetDocumentMetadata(dsel);
            var title = meta.ContainsKey("Titel") && meta["Titel"] != null ? meta["Titel"].ToString() : "";
            var date = meta.ContainsKey("Datum") && meta["Datum"] is DateTime dt ? dt : DateTime.MinValue;

            meta = ExportXenodataHelper.RemoveDataByKey(meta, "Titel");
            meta = ExportXenodataHelper.RemoveDataByKey(meta, "Datum");

            // Dokument-Metadaten
            using (var entry = zip.CreateEntry($"{csigle}/{package.Key}/{i:D6}/header.xml"))
            using (var writer = new StreamWriter(entry.Open()))
              writer.Write(Resources.Template_Ids_KorAP_ZDoc.Replace("{DocSigle}", doccsigle)
                .Replace("{TITLE}", title)
                .Replace("{MONTH}", date.Month.ToString("D2"))
                .Replace("{DAY}", date.Day.ToString("D2"))
                .Replace("{YEAR}", date.Year.ToString("D4"))
                .Replace("{TIME}", date.ToString("HH:mm:ss zzz"))
                .Replace("{XENODATA}", ExportXenodataHelper.GenerateXenoData(meta)));

            var doc = hydra.GetReadableDocument(dsel, "Wort").Select(x => x.ToArray()).ToArray();
            // ReSharper disable once ArgumentsStyleStringLiteral
            var text = doc.ReduceDocumentToText(sentenceSeparator: " ");

            // Dokument-Rohtext
            using (var entry = zip.CreateEntry($"{csigle}/{package.Key}/{i:D6}/data.xml"))
            using (var writer = new StreamWriter(entry.Open()))
              writer.Write(Resources.Template_Ids_KorAP_Data
                .Replace("{DocId}", docid)
                .Replace("{TEXT}", text));

            var align = map.ExtractAlignment(text, doc);
            
            // Token-Standoff
            using (var entry = zip.CreateEntry($"{csigle}/{package.Key}/{i:D6}/base/tokens.xml"))
            using (var writer = new StreamWriter(entry.Open()))
              writer.Write(Resources.Template_Ids_KorAP_Tokens
                .Replace("{DocId}", docid)
                .Replace("{TOKENS}", MakeTokens(align)));

            // Structure
            using (var entry = zip.CreateEntry($"{csigle}/{package.Key}/{i:D6}/struct/structure.xml"))
            using (var writer = new StreamWriter(entry.Open()))
              writer.Write(Resources.Template_Ids_KorAP_Structure
                .Replace("{DocId}", docid)
                .Replace("{To}", align.Max(x => x.TextCharTo).ToString())
                .Replace("{Sentences}", GenerateSentenceSpans(doc, align)));

            // >>>>>>>>>>>>>>>>>>>>>
            // FOUNDRY - EXPORT >>>> 
            // >>>>>>>>>>>>>>>>>>>>>

            var csel = hydra.GetCorpusGuidOfDocument(dsel);
            foreach (var foundry in foundries.Where(f => f.CorpusGuid == csel))
            {
              var layer = GetLayers(hydra, foundry, dsel);
              if(layer == null || layer.Count == 0)
                continue;

              var lnames = layer.Keys.ToArray();

              var anno = new List<string>();
              for (var j = 0; j < align.Count; j++)
              {
                var tags = lnames.Select(lname => $"      <f name=\"{lname}\">{layer[lname][j]}</f>");

                if (align[j].TextCharFrom == align[j].TextCharTo)
                  continue;

                anno.Add(Resources.Template_Ids_KorAP_Morpho_Span
                                  .Replace("{j}", j.ToString())
                                  .Replace("{From}", align[j].TextCharFrom.ToString())
                                  .Replace("{To}", align[j].TextCharTo.ToString())
                                  .Replace("{TAGS}", string.Join("\r\n", tags)));
              }

              using (var entry = foundry.Zip.CreateEntry($"{csigle}/{package.Key}/{i:D6}/{foundry.FoundryName}/morpho.xml"))
              using (var writer = new StreamWriter(entry.Open()))
                writer.Write(Resources.Template_Ids_KorAP_Morpho
                  .Replace("{DocId}", docid)
                  .Replace("{ANNO}", string.Join("\r\n", anno)));
            }

            // Zähler
            i++;
          }
        }
      }

      foreach (var foundry in foundries)
        foundry.Close();
    }

    private string GenerateSentenceSpans(string[][] doc, List<ReMapperEntry> align)
    {
      var stb = new StringBuilder();
      var queue = new Queue<ReMapperEntry>(align);

      var id = 3; // Wichtig, im Template sind die ersten beiden IDs reserviert

      foreach (var s in doc)
      {
        if(queue.Count == 0)
          break;

        var from = -1;
        var to = -1;
        foreach (var w in s)
        {
          if (queue.Count == 0)
            break;

          var entry = queue.Dequeue();
          if (from == -1)
            from = entry.TextCharFrom;
          to = entry.TextCharTo;
        }

        if (from == -1 || to == -1)
          continue;

        stb.AppendLine(Resources.Template_Ids_KorAP_Structure_Sentence
          .Replace("{id}", id.ToString())
          .Replace("{from}", from.ToString())
          .Replace("{to}", to.ToString()));
        id++;
      }

      return stb.ToString();
    }

    private Dictionary<string, string[]> GetLayers(IHydra hydra, Foundry foundry, Guid dsel)
    {
      var match = new HashSet<string>(foundry.LayerDisplaynames);
      var res = new Dictionary<string, string[]>();

      foreach (var layer in hydra.GetLayersOfDocument(dsel).Where(x => match.Contains(x.Displayname)))
      {
        var name = layer.Displayname.ToLower();
        if (name == "pos")
          name = "ctag";

        var doc = layer.GetReadableDocumentByGuid(dsel);
        var tmp = new List<string>();
        foreach (var x in doc)
          tmp.AddRange(x);

        res.Add(name, tmp.ToArray());
      }

      return res;
    }

    private string MakeTokens(List<ReMapperEntry> align)
    {
      var stb = new StringBuilder();
      for (var i = 0; i < align.Count; i++)
        stb.AppendLine($"    <span id=\"t_{i}\" from=\"{align[i].TextCharFrom}\" to=\"{align[i].TextCharTo}\" />");
      return stb.ToString();
    }

    private struct Foundry
    {
      private readonly FileStream _fs;

      public Foundry(string path, string foundry, Guid corpusGuid, string foundryLayerInfo, string[] layerDisplaynames)
      {
        foundry = foundry.ToLower();
        FoundryName = foundry == "treetagger" ? "tree_tagger" : foundry;
        FoundryShortName = foundry == "treetagger" ? "tt" : foundry;

        var dir = Path.GetDirectoryName(path);
        var name = Path.GetFileNameWithoutExtension(path);
        path = Path.Combine(dir, $"{name}.{FoundryName}.zip");

        _fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        Zip = ZipArchive.Create(_fs);

        CorpusGuid = corpusGuid;
        LayerDisplaynames = layerDisplaynames;
        FoundryLayerInfo = foundryLayerInfo;
      }

      public Guid CorpusGuid { get; private set; }
      public string FoundryShortName { get; private set; }
      public string FoundryName { get; private set; }
      public string[] LayerDisplaynames { get; private set; }
      public string FoundryLayerInfo { get; private set; }
      public ZipArchive Zip { get; private set; }

      public void Close()
      {
        Zip?.Dispose();
        _fs?.Close();
      }
    }

    private List<Foundry> GetFoundries(IHydra hydra, string path)
    {
      var res = new List<Foundry>();
      var csels = new HashSet<Guid>(hydra.CorporaGuids);

      #region 1. Beste Lösung - Korpus-Metadaten (erst ab 2022-02 unterstützt)
      var arr = csels.ToArray();
      foreach (var csel in arr)
      {
        var corpus = hydra.GetCorpus(csel);

        var foundry = corpus.GetCorpusMetadata("Foundry")?.ToString();
        if (string.IsNullOrEmpty(foundry))
          continue;

        var info = corpus.GetCorpusMetadata("FoundryLayerInfo")?.ToString();
        if (string.IsNullOrEmpty(info))
          continue;

        res.Add(new Foundry(path,
                            foundry,
                            csel,
                            info,
                            corpus.LayerDisplaynames.Where(x => x != "Wort").ToArray()));

        csels.Remove(csel);
      }
      #endregion

      #region 2. Klassische Multi-Merge Layer Korpora
      arr = csels.ToArray();
      foreach (var csel in arr)
      {
        var corpus = hydra.GetCorpus(csel);
        var layerNames = corpus.LayerDisplaynames.Where(x => x != "Wort").ToArray();

        if (!layerNames.All(name => name.EndsWith(")") && name.Contains("(")))
          continue;

        var foundry = "";
        foreach (var name in layerNames)
        {
          var last = name.Split(new[] { "(" }, StringSplitOptions.RemoveEmptyEntries).Last().Replace(")", "");
          if (foundry == "")
            foundry = last;

          if (foundry == last)
            continue;

          foundry = null;
          break;
        }

        if (foundry == null)
          continue;

        res.Add(new Foundry(path,
                            foundry,
                            csel,
                            string.Join(" ", layerNames.Select(x => x.ToLower()), layerNames),
                            layerNames));

        csels.Remove(csel);
      }
      #endregion

      #region 3. Fallback - Keine Foundry aber POS- / Lemma-Layer

      res.AddRange(from csel in csels
                   let corpus = hydra.GetCorpus(csel)
                   let layerNames = corpus.LayerDisplaynames.Where(x => x != "Wort").ToArray()
                   select new Foundry(path,
                                      ReplaceCorpusExplorerFoundry ?? "CorpusExplorer",
                                      csel,
                                      string.Join(" ", layerNames.Select(x => x.ToLower())),
                                      layerNames));

      #endregion

      return res;
    }    
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Json.Speedy.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy
{
  public class ExporterSpeedy : AbstractExporter
  {
    private const string _ceGuid = "436f7270-7573-4578-706c-6f7265720002";

    public override void Export(IHydra hydra, string path)
    {
      try
      {
        var dir = Path.GetDirectoryName(path);
        var name = Path.GetFileNameWithoutExtension(path);
        dir = Path.Combine(dir, name);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);

        foreach (var dsel in hydra.DocumentGuids)
        {
          try
          {
            var text = CleanText(hydra.GetReadableDocument(dsel, "Wort").ReduceDocumentToText(" "));
            var idxs = new ReMapperStandoff().ExtractAlignment(text, hydra.GetDocument(dsel, "Wort"),
                                                               hydra.GetLayerOfDocument(dsel, "Wort"));

            FileIO.Write(Path.Combine(dir, $"{dsel:N}.json"), JsonConvert.SerializeObject(new Model.Speedy
            {
              Text = text,
              Properties = GetProperties(idxs, hydra.GetLayersOfDocument(dsel), dsel)
            }));
          }
          catch (Exception ex)
          {

          }
        }
      }
      catch (Exception ex)
      {

      }
    }

    private string CleanText(string text)
    {
      return text.Replace("  ", " ");
    }

    private IList<Property> GetProperties(IEnumerable<Tuple<int, int, int, int>> idxs,
                                          IEnumerable<AbstractLayerAdapter> layers, Guid dsel)
    {
      var wLayer = (from x in layers where x.Displayname == "Wort" select x).FirstOrDefault();
      if (wLayer == null)
        return null;

      var res = new List<Model.Property>();

      foreach (var layer in layers)
      {
        if (layer.Displayname == "Wort")
          continue;

        var doc = layer[dsel];
        if (doc == null)
          continue;

        Property pro = null;
        string current = null;
        foreach (var idx in idxs)
        {
          var value = layer[doc[idx.Item1][idx.Item2]];
          if (current != value)
          {
            if (value == "-null-") // -null- für SPEEDy-ReExport - muss auch im Importer geändert werden.
            {
              if (pro != null)
                res.Add(pro);
              current = null;
              pro = null;
              continue;
            }
            current = value;
            if (pro != null)
            {
              res.Add(pro);
              pro = null;
            }
          }

          if (pro == null)
            pro = new Property
            {
              Index = res.Count,
              Guid = Guid.NewGuid().ToString(),
              Text = wLayer[doc[idx.Item1][idx.Item2]],
              StartIndex = idx.Item3,
              EndIndex = idx.Item4 + 1,
              Type = layer.Displayname,
              UserGuid = _ceGuid,
              Value = value
            };
          else
            pro.EndIndex = idx.Item4 + 1;
        }
        if (pro != null)
          res.Add(pro);
      }
      return res;
    }
  }
}

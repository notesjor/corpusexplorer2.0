using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Tlv
{
  public class ExporterTlv : AbstractExporter
  {
    private readonly Regex _regex = new Regex(@"<[^>]*>");

    public override void Export(IHydra hydra, string path)
    {
      var stb = new StringBuilder();
      stb.Append("<xml><meta>");

      AbstractCorpusAdapter corpus = null;
      if (hydra is AbstractCorpusAdapter)
        corpus = (AbstractCorpusAdapter) hydra;
      if (hydra is Project)
        corpus = ((Project) hydra).ToCorpus();
      if (hydra is Selection)
        corpus = ((Selection) hydra).ToCorpus();

      if (corpus == null)
        return;

      #region <meta> - Korpusmetadaten

      var cmeta = new Dictionary<string, object>();
      var ccmeta = corpus.GetCorpusMetadata();
      foreach (var x in ccmeta)
        if (!cmeta.ContainsKey(x.Key))
          cmeta.Add(x.Key, x.Value);
        else if (cmeta[x.Key] == null)
          cmeta[x.Key] = x.Value;
      foreach (var x in cmeta)
        if (x.Value != null)
          stb.Append(
            $"<entry category=\"{x.Key}\" type=\"{x.Value.GetType()}\">{CleanText(HttpUtility.HtmlDecode(x.Value.ToString()))}</entry>");

      #endregion

      stb.Append("</meta><layers>");

      #region <layers>

      var layers = new Dictionary<Guid, int>();
      var lyDict = new Dictionary<Guid, Dictionary<string, int>>();
      foreach (var layer in corpus.Layers)
      {
        // Wort-Layer muss verworfen werden
        if (layer.Displayname == "Wort")
          continue;

        stb.Append($"<layer name=\"{layer.Displayname}\" l=\"{layers.Count}\">");
        layers.Add(layer.Guid, layers.Count);
        lyDict.Add(layer.Guid, new Dictionary<string, int>());

        foreach (var x in layer.ReciveRawLayerDictionary())
        {
          stb.Append($"<value label=\"{HttpUtility.HtmlEncode(x.Key)}\" v=\"{x.Value}\"/>");
          lyDict[layer.Guid].Add(x.Key, x.Value);
        }

        stb.Append("</layer>");
      }

      #endregion

      stb.Append("</layers><docs>");

      #region <docs>

      foreach (var dsel in corpus.DocumentGuids)
      {
        stb.Append("<doc>");

        #region <meta> - Dokumentmetadaten

        stb.Append("<meta>");

        var meta = corpus.GetDocumentMetadata(dsel);
        foreach (var x in meta)
          if (x.Value != null)
            stb.Append(
              $"<entry category=\"{x.Key}\" type=\"{x.Value.GetType()}\">{CleanText(HttpUtility.HtmlDecode(x.Value.ToString()))}</entry>");

        stb.Append("</meta>");

        #endregion

        #region <body>

        stb.Append("<body>");

        // Wort-Layer muss verworfen werden.
        var dlayers = corpus.GetLayersOfDocument(dsel).Where(x => x.Displayname != "Wort")
          .ToDictionary(x => x.Displayname, x => x.Guid);
        var d3D = corpus.GetReadableMultilayerDocument(dsel)
          .ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
        var wordLayer = d3D["Wort"];
        d3D.Remove("Wort");

        for (var s = 0; s < wordLayer.Length; s++)
        for (var w = 0; w < wordLayer[s].Length; w++)
        {
          var word = new StringBuilder(CleanText(HttpUtility.HtmlDecode(wordLayer[s][w])));
          word.Append(" ");

          foreach (var otherLayer in d3D)
          {
            word.Insert(0,
              $"<t l=\"{layers[dlayers[otherLayer.Key]]}\" v=\"{lyDict[dlayers[otherLayer.Key]][otherLayer.Value[s][w]]}\">");
            word.Append("</t>");
          }

          stb.Append(word);
          stb.Append(" ");
        }

        stb.Append("</body>");

        #endregion

        stb.Append("</doc>");
      }

      #endregion

      stb.Append("</docs></xml>");
      FileIO.Write(path, stb.ToString(), Configuration.Encoding);
    }

    private string CleanText(string input)
    {
      return HttpUtility.HtmlEncode(_regex.Replace(input, string.Empty));
    }
  }
}
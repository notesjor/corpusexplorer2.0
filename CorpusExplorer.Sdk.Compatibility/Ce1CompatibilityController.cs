#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Data.Model;
using CorpusExplorer.Sdk.Data.Model.MetaInformationen;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

#endregion

namespace CorpusExplorer.Sdk.Compatibility
{
  /// <summary>
  ///   The controler.
  /// </summary>
  public static class Ce1CompatibilityController
  {
    /// <summary>
    ///   The upgrade.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    public static AbstractCorpusAdapter Upgrade(string path)
    {
      var pathInfo = new DirectoryInfo(path);
      var name = pathInfo.Name;
      var multi = new MultiLayer(name);
      var nmeta = new Dictionary<Guid, Dictionary<string, object>>();
      var nlayers = new List<LayerValueState>();
      var map = new Dictionary<string, Guid>();

      // FIX
      var fix = new Dictionary<string, List<AbstrakterMetaEintrag>>();
      foreach (var pair in multi.MetadatenDokumente)
      {
        if (!fix.ContainsKey(pair.Key))
        {
          fix.Add(pair.Key, pair.Value);
          continue;
        }

        for (var i = 1; i < 1000000000; i++)
        {
          var key = $"{pair.Key} ({i})";

          if (fix.ContainsKey(key))
            continue;
          fix.Add(key, pair.Value);
          break;
        }
      }

      // CONVERT META
      foreach (var pair in fix)
      {
        var guid = Guid.NewGuid();
        nmeta.Add(guid, pair.Value.ToDictionary(entry => entry.Name, entry => entry.InternValue));
        map.Add(pair.Key, guid);
      }

      // CONVERT LAYER
      foreach (var layerOld in multi)
      {
        var ndic = new Dictionary<string, int>();
        var lod = layerOld.Daten;
        for (var i = 0; i < lod.Length; i++)
          ndic.Add(lod[i], i);

        var ndocs = new Dictionary<Guid, int[][]>();
        foreach (var pair in layerOld)
          try
          {
            if (map.ContainsKey(pair.Key))
            {
              ndocs.Add(map[pair.Key], pair.Value);
            }
            else
            {
              var guid = Guid.NewGuid();
              map.Add(pair.Key, guid);
              ndocs.Add(guid, pair.Value);
              nmeta.Add(guid, new Dictionary<string, object>());
            }
          }
          catch
          {
          }

        nlayers.Add(new LayerValueState(layerOld.LayerName, nlayers.Count, ndic, ndocs));
      }

      // FIX CLEAN
      var master = nlayers.FirstOrDefault(x => x.Displayname == "Wort");
      if (master == null)
        return null;

      var fmeta = master.GetDocuments().ToDictionary(guid => guid.Key, guid => nmeta[guid.Key]);

      // STORE
      var builder = new CorpusBuilderWriteDirect();
      var corpus = builder.Create(nlayers, fmeta, null, null).FirstOrDefault();
      return corpus;
    }
  }
}
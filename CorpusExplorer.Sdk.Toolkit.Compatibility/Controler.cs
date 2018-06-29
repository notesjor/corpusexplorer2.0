#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Data.Model;
using CorpusExplorer.Sdk.Data.Model.MetaInformationen;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

#endregion

namespace CorpusExplorer.Sdk.Toolkit.Compatibility
{
  /// <summary>
  ///   The controler.
  /// </summary>
  public static class Controler
  {
    #region Static Fields

    /// <summary>
    ///   The _dirs.
    /// </summary>
    private static string[] _dirs;

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets the dirs.
    /// </summary>
    public static string[] Dirs => _dirs;

    /// <summary>
    ///   Gets the level 1.
    /// </summary>
    public static int Level1 => _dirs.Count(NeedsUpgradeToLayer2);

    /// <summary>
    ///   Gets the level 2.
    /// </summary>
    public static int Level2 => _dirs.Count(NeedsUpgradeToLayer3) + Level1;

    /// <summary>
    ///   Gets a value indicating whether need conversion.
    /// </summary>
    public static bool NeedConversion => Level1 + Level2 > 0;

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   The init.
    /// </summary>
    public static void Init()
    {
      CorpusExplorerEcosystem.InitializeMinimal();
      _dirs = Directory.GetDirectories(Configuration.MyCorpora);
    }

    /// <summary>
    ///   The needs upgrade to layer 2.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public static bool NeedsUpgradeToLayer2(string path)
    {
      return Directory.GetFiles(path, "*.layer").Length > 0 && Directory.GetFiles(path, "*.layer2").Length <= 0;
    }

    /// <summary>
    ///   The needs upgrade to layer 3.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public static bool NeedsUpgradeToLayer3(string path)
    {
      return Directory.GetFiles(path, "*.layer2").Length > 0;
    }

    /// <summary>
    ///   The upgrade.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    public static void Upgrade(string path, AbstractCorpusBuilder builder = null)
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

          if (!fix.ContainsKey(key))
          {
            fix.Add(key, pair.Value);
            break;
          }
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
        for (var i = 0; i < lod.Length; i++) ndic.Add(lod[i], i);

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

        nlayers.Add(new LayerValueState(layerOld.LayerName, nlayers.Count)
        {
          Documents = ndocs,
          Cache = ndic
        });
      }

      // FIX CLEAN
      var master = nlayers.FirstOrDefault(x => x.Displayname == "Wort");
      if (master == null) return;

      var fmeta = master.Documents.ToDictionary(guid => guid.Key, guid => nmeta[guid.Key]);

      // STORE
      if (builder == null)
        builder = new CorpusBuilderWriteDirect();
      var corpus = builder.Create(
        nlayers,
        fmeta,
        null,
        null).First();
      corpus.Save(Path.Combine(Configuration.MyCorpora, name + ".cec5"));
    }

    #endregion
  }
}
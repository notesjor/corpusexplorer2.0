﻿#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Blocks.Measure;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Cache;
using CorpusExplorer.Sdk.Model.Cache.Abstract;
using CorpusExplorer.Sdk.Model.Localization;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.CorpusExplorerV6;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using Newtonsoft.Json;
using Bcs.IO;


#if UNIVERSAL
#else
using Bcs.Addon;
#endif

#endregion

namespace CorpusExplorer.Sdk.Ecosystem.Model
{
  /// <summary>
  ///   Class <see cref="Configuration" />
  /// </summary>
  public static class Configuration
  {
    private static List<AbstractAdditionalTagger> _addonAdditionalTaggers = new List<AbstractAdditionalTagger>();

    private static Dictionary<string, AbstractCorpusBuilder> _addonBackends =
      new Dictionary<string, AbstractCorpusBuilder>();

    private static List<object> _addonSideLoadFeatures = new List<object>();
    private static List<IAction> _addonConsoleActions = new List<IAction>();
    private static List<AbstractCrawler> _addonCrawlers = new List<AbstractCrawler>();
    private static Dictionary<string, AbstractExporter> _addonExporters = new Dictionary<string, AbstractExporter>();
    private static Dictionary<string, AbstractImporter> _addonImporters = new Dictionary<string, AbstractImporter>();
    private static Dictionary<string, AbstractScraper> _addonScrapers = new Dictionary<string, AbstractScraper>();
    private static Dictionary<string, AbstractTableWriter> _addonTableWriters = new Dictionary<string, AbstractTableWriter>();
    private static List<AbstractTagger> _addonTaggers = new List<AbstractTagger>();
#if UNIVERSAL
#else
    private static List<IAddonView> _addonViews = new List<IAddonView>();
#endif
    private static Encoding _encoding;
    private static bool? _rightToLeftSupport;
    private static ISignificance _significance = new PoissonSignificance();

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    public static IEnumerable<AbstractAdditionalTagger> AddonAdditionalTaggers => _addonAdditionalTaggers;

    public static void AddonAdditionalTaggersAdd(IEnumerable<AbstractAdditionalTagger> list)
    {
      if (list != null)
        _addonAdditionalTaggers.AddRange(list);
    }

    /// <summary>
    ///   Verfügbare Backends
    /// </summary>
    /// <value>The addon backends.</value>
    public static IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends
    {
      get
      {
        var list = _addonBackends.Where(x => !string.IsNullOrWhiteSpace(x.Key)).OrderBy(x => x.Key).ToList();
        var cec6 =
          (from x in list where x.Value.GetType() == typeof(CorpusBuilderWriteDirect) select x).FirstOrDefault();
        list.Remove(cec6);
        list.Insert(0, cec6);
        return list;
      }
    }

    public static void AddonBackendsAdd(IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> list)
    {
      if (list != null)
        foreach (var x in list.Where(x => !_addonImporters.ContainsKey(x.Key)))
          _addonBackends.Add(x.Key, x.Value);
    }

    public static IEnumerable<IAction> AddonConsoleActions => _addonConsoleActions;

    public static void AddonConsoleActionsAdd(IEnumerable<IAction> list)
    {
      if (list != null)
        _addonConsoleActions.AddRange(list);
    }

    /// <summary>
    ///   Zusätzliche Crawler
    /// </summary>
    public static IEnumerable<AbstractCrawler> AddonCrawlers => _addonCrawlers;

    public static IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters
    {
      get
      {
        var list = _addonExporters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).OrderBy(x => x.Key).ToList();
        var cec6 = (from x in list where x.Value.GetType() == typeof(ExporterCec6) select x).FirstOrDefault();
        list.Remove(cec6);
        list.Insert(0, cec6);
        return list;
      }
    }

    public static void AddonExportersAdd(IEnumerable<KeyValuePair<string, AbstractExporter>> list)
    {
      if (list != null)
        foreach (var x in list.Where(x => !_addonImporters.ContainsKey(x.Key)))
          _addonExporters.Add(x.Key, x.Value);
    }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public static IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporters
    {
      get
      {
        var list = _addonImporters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).OrderBy(x => x.Key).ToList();
        var cec6 = (from x in list where x.Value.GetType() == typeof(ImporterCec6) select x).FirstOrDefault();
        list.Remove(cec6);
        list.Insert(0, cec6);
        return list;
      }
    }

    public static void AddonImportersAdd(IEnumerable<KeyValuePair<string, AbstractImporter>> list)
    {
      if (list != null)
        foreach (var x in list.Where(x => !_addonImporters.ContainsKey(x.Key)))
          _addonImporters.Add(x.Key, x.Value);
    }

    public static void AddonTableWriterAdd(IEnumerable<KeyValuePair<string, AbstractTableWriter>> list)
    {
      if (list != null)
        foreach (var x in list.Where(x => !_addonImporters.ContainsKey(x.Key)))
          _addonTableWriters.Add(x.Key, x.Value);
    }

    public static AbstractExporter GetExporter(string exporter)
      => (from x in _addonExporters where x.Value.GetType().Name.EndsWith(exporter) select x.Value).FirstOrDefault();

    public static AbstractTableWriter GetTableWriter(string tableWriterTag)
    {
      if (tableWriterTag.StartsWith("F:"))
      {
        GetTableWriterAdditionalPath(tableWriterTag, out tableWriterTag, out var path);

        var res = _addonTableWriters.Where(x => x.Value.TableWriterTag == tableWriterTag)
                                    .Select(x => x.Value)
                                    .FirstOrDefault() ?? new TsvTableWriter();

        if (path == null)
          return res;

        res.OutputStream = new FileStream(path, FileMode.Create, FileAccess.Write);
        res.Path = path;
        return res;
      }

      // ReSharper disable once InvertIf
      if (tableWriterTag.StartsWith("FNT:"))
      {
        GetTableWriterAdditionalPath(tableWriterTag, out tableWriterTag, out var path);

        var f = tableWriterTag.Replace("FNT:", "F:");

        var res = _addonTableWriters.Where(x => x.Value.TableWriterTag == f)
                                    .Select(x => x.Value)
                                    .FirstOrDefault() ?? _addonTableWriters.First().Value;

        res.WriteTid = false;
        if (path == null)
          return res;

        res.OutputStream = new FileStream(path, FileMode.Create, FileAccess.Write);
        res.Path = path;
        return res;
      }

      return null;
    }

    public static void GetTableWriterAdditionalPath(string tableWriterTag, out string tag, out string path)
    {
      if (tableWriterTag.Contains("#"))
      {
        var split = tableWriterTag.Split('#');
        tag = split[0];
        path = split[1];
      }
      else
      {
        tag = tableWriterTag;
        path = null;
      }
    }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public static IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      _addonScrapers.Where(x => !string.IsNullOrWhiteSpace(x.Key)).OrderBy(x => x.Key);

    public static void AddonScrapersAdd(IEnumerable<KeyValuePair<string, AbstractScraper>> list)
    {
      if (list != null)
        foreach (var x in list.Where(x => !_addonImporters.ContainsKey(x.Key)))
          _addonScrapers.Add(x.Key, x.Value);
    }

    /// <summary>
    /// Export für Analysedaten im Tabellenformat
    /// </summary>
    public static IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter =>
      _addonTableWriters.Where(x => !string.IsNullOrWhiteSpace(x.Key)).OrderBy(x => x.Key);

    /// <summary>
    ///   Tagger
    /// </summary>
    public static IEnumerable<AbstractTagger> AddonTaggers => _addonTaggers;

    public static void AddonTaggersAdd(IEnumerable<AbstractTagger> list)
    {
      if (list != null)
        _addonTaggers.AddRange(list);
    }

    /// <summary>
    /// Gets the layer display name localization.
    /// </summary>
    /// <value>The layer display name localization.</value>
    public static ModelLocalization LayerDisplayNameLocalization { get; } = new ModelLocalization();

    /// <summary>
    /// Gets the document metadata localization.
    /// </summary>
    /// <value>The document metadata localization.</value>
    public static ModelLocalization DocumentMetadataLocalization { get; } = new ModelLocalization();

    public static void LoadLocalizations(string directory)
    {
      try
      {
        var path = Path.Combine(directory, "layer.local");
        if (File.Exists(path))
          LayerDisplayNameLocalization.LoadLocalization(path);
      }
      catch
      {
        //ignore
      }
      try
      {
        var path = Path.Combine(directory, "meta.local");
        if (File.Exists(path))
          DocumentMetadataLocalization.LoadLocalization(path);
      }
      catch
      {
        // ignore
      }
    }


#if UNIVERSAL
#else
    /// <summary>
    ///   Externe Analysemodule.
    /// </summary>
    public static IEnumerable<IAddonView> AddonViews => _addonViews;
#endif

    /// <summary>
    ///   Gets the app config path.
    /// </summary>
    public static string AppConfigPath { get; private set; }

    /// <summary>
    ///   Gets the app path.
    /// </summary>
    public static string AppPath
    {
      get
      {
        try
        {
          return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        catch
        {
          return "";
        }
      }
    }

    public static AbstractCacheStrategy Cache { get; set; } = new CacheStrategyDisableCaching();

    public static Encoding Encoding
    {
      get
      {
        if (_encoding != null)
          return _encoding;

        try
        {
          _encoding = Encoding.GetEncoding(GetSetting("Encoding (CodePage)", Encoding.UTF8.CodePage));
        }
        catch
        {
          _encoding = Encoding.UTF8;
        }

        return _encoding;
      }
      set
      {
        _encoding = value ?? Encoding.UTF8;
        SetSetting("Encoding (CodePage)", _encoding.CodePage.ToString());
      }
    }

    /// <summary>
    ///   Gets the extern app path.
    /// </summary>
    public static string ExternAppPath { get; private set; }

    public static bool IsInitialized { get; private set; }

    /// <summary>
    ///   Gets or sets the measure.
    /// </summary>
    public static IMeasure Measure { get; set; } = new DiceCoefficient();

    /// <summary>
    ///   Gets or sets the minimum frequency.
    /// </summary>
    public static int MinimumFrequency { get; set; } = 1;

    /// <summary>
    ///   Gets or sets the minimum significance.
    /// </summary>
    public static double MinimumSignificance { get; set; } = 0.9;

    /// <summary>
    ///   Gibt das Verzeichnis zurück in dem der Benutzer Crawler/Addons ablegen kann ohne diese Installieren zu müssen.
    /// </summary>
    public static string MyAddons { get; private set; }

    /// <summary>
    ///   Pfad zu den Korpora
    /// </summary>
    public static string MyCorpora { get; private set; }

    public static string MyDataSources { get; private set; }

    /// <summary>
    ///   Pfad zum Projektordner
    /// </summary>
    public static string MyProjects { get; private set; }

    public static ParallelOptions ParallelOptions { get; set; } =
      new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

    public static bool ProtectMemoryOverflow
    {
      get => GetSetting("RAM-Selbstschutz", true);
      set => SetSetting("RAM-Selbstschutz", value.ToString());
    }

    public static double DefaultFontSize
    {
      get => (double)GetSetting("Schriftgröße", 12.0);
      set => SetSetting("Schriftgröße", value.ToString());
    }

    public static Random Random { get; private set; } = new Random();

    public static bool RightToLeftSupport
    {
      get
      {
        if (_rightToLeftSupport.HasValue)
          return _rightToLeftSupport.Value;

        try
        {
          _rightToLeftSupport = GetSetting("R/L-Support", false);
        }
        catch
        {
          _rightToLeftSupport = false;
        }

        return _rightToLeftSupport.Value;
      }
      set
      {
        _rightToLeftSupport = value;
        SetSetting("R/L-Support", value.ToString());
      }
    }

    /// <summary>
    /// Ändrn um eine andere Metaangabe als Bezeichnung für ein Dokument zu verwenden.
    /// </summary>
    public static string TitleMetaKey { get; set; } = Resources.Title;

    /// <summary>
    ///   Pfad zu den temporären Dateien
    /// </summary>
    public static string TempPath
    {
      get
      {
        try
        {
          var res = Path.Combine(Path.GetTempPath(), "CorpusExplorer");
          if (Directory.Exists(res))
            return res;

          Directory.CreateDirectory(res);
          if (!res.StartsWith("/tmp/"))
            return res;

          // Unix
          try
          {
            var process = Process.Start(new ProcessStartInfo
            {
              FileName = "chmod",
              Arguments = "777 " + res,
              UseShellExecute = false
            });
            process.WaitForExit();
          }
          catch
          {
            // ignore
          }
          return res;
        }
        catch
        {
          return "TEMP";
        }
      }
    }

    /// <summary>
    ///   Pfad zu den Abhängigkeiten - nutzen Sie GetDependencyPath(string subPath) um einen relativen Pfad in einen absoluten
    ///   umzuwandeln.
    /// </summary>
    /// <value>The dependency path.</value>
    public static string DependencyPath
    {
      get
      {
        try
        {
          return Path.Combine(AppPath, "XDependencies");
        }
        catch
        {
          return "XDependencies";
        }
      }
    }

    /// <summary>
    ///   Dateipfad der Einstellungsdatei
    /// </summary>
    private static string SettingsAppPath { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [use chrome].
    /// </summary>
    /// <value><c>true</c> if [use chrome]; otherwise, <c>false</c>.</value>
    public static bool UseChrome { get; set; } = true;
    public static int IOBufferSize
    {
      get => GetSetting("Puffergröße", 1024 * 1024 * 100);
      set => SetSetting("Puffergröße", value.ToString());
    }

    public static IAction GetConsoleAction(string actionName)
    {
      return (from x in AddonConsoleActions where x.Action == actionName select x).FirstOrDefault();
    }

    public static IEnumerable<T> GetSideloadFeature<T>()
    {
      return _addonSideLoadFeatures.OfType<T>();
    }

    public static void SetSignificance(ISignificance significance)
    {
      _significance = significance;
      MinimumSignificance = significance.MinimumSignificance;
    }

    public static ISignificance GetSignificance(double a, double n)
    {
      return _significance.PreCalculationSetup(a, n);
    }

    public static Type GetSignificanceType()
    {
      return _significance.GetType();
    }

    /// <summary>
    ///   Gibt den Pfad zur Abhängigen (externen) Programmkomponente zurück
    /// </summary>
    /// <param name="subPath">Unterpfad</param>
    /// <returns>Pfad</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public static string GetDependencyPath(string subPath)
    {
      try
      {
        var res = Path.Combine(Path.Combine(AppPath, "XDependencies"), subPath);
        if (Directory.Exists(res))
          return res;

        var alternative =
          Path.Combine(
                       Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                    @"CorpusExplorer\App\XDependencies"),
                       subPath);
        if (Directory.Exists(alternative) || File.Exists(alternative))
          res = alternative;

        return res;
      }
      catch
      {
        return "XDependencies";
      }
    }

    /// <summary>
    ///   Gibt eine Einstellung zurück (safety cast)
    /// </summary>
    /// <param name="settingName">
    ///   Name der Einstellung
    /// </param>
    /// <param name="defaultValue">
    ///   Wert, der gesetzt wird, wenn der Eintrag noch nicht exsistiert
    /// </param>
    /// <returns>
    ///   Wert
    /// </returns>
    public static string GetSetting(string settingName, string defaultValue)
    {
      try
      {
        var obj = GetSettings();
        if (obj != null && obj.ContainsKey(settingName))
          return obj[settingName];

        SetSetting(settingName, defaultValue);
        return defaultValue;
      }
      catch
      {
        return defaultValue;
      }
    }

    public static int GetSetting(string settingName, int defaultValue)
    {
      try
      {
        var get = GetSetting(settingName, defaultValue.ToString());
        return int.TryParse(get, out var res) ? res : defaultValue;
      }
      catch
      {
        return defaultValue;
      }
    }

    public static double GetSetting(string settingName, double defaultValue)
    {
      try
      {
        var get = GetSetting(settingName, defaultValue.ToString());
        return double.TryParse(get, out var res) ? res : defaultValue;
      }
      catch
      {
        return defaultValue;
      }
    }

    public static bool GetSetting(string settingName, bool defaultValue)
    {
      try
      {
        var get = GetSetting(settingName, defaultValue.ToString());
        return bool.TryParse(get, out var res) ? res : defaultValue;
      }
      catch
      {
        return defaultValue;
      }
    }

    private static object _cacheSettingsLock = new object();
    private static Dictionary<string, string> _cacheSettings = null;

    public static Dictionary<string, string> GetSettings(string alternativePath = null)
    {
      lock (_cacheSettingsLock)
        try
        {
          if (_cacheSettings == null)
            _cacheSettings = File.Exists(alternativePath ?? SettingsAppPath)
              ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(alternativePath ?? SettingsAppPath, Encoding.UTF8))
              : new Dictionary<string, string>();

          return _cacheSettings;
        }
        catch
        {
          return new Dictionary<string, string>();
        }
    }

    public static void Reload3rdPartyAddons(string alternativePath = null)
    {
      _addonCrawlers.Clear();
      _addonImporters.Clear();
      _addonTaggers.Clear();
      _addonAdditionalTaggers.Clear();
      _addonScrapers.Clear();
      _addonTableWriters.Clear();
#if UNIVERSAL
#else
      _addonViews.Clear();
#endif
      _addonBackends.Clear();
      _addonConsoleActions.Clear();
      _addonSideLoadFeatures.Clear();

      string location = null;
      try
      {
        location = Path.GetDirectoryName(string.IsNullOrEmpty(alternativePath)
                                           ? Assembly.GetExecutingAssembly().Location
                                           : alternativePath);
      }
      catch
      {
        // ignore
      }
#if UNIVERSAL
#else
      if (location == null)
        return;

      Load3RdPartyAddons(location);

      // Nur relevant, wenn USB/Pendrive oder DEBUG
      if (location != AppPath)
        Load3RdPartyAddons(AppPath);
#endif
    }

    /// <summary>
    ///   Speichert eine Einstellung
    /// </summary>
    /// <param name="settingName">
    ///   Name der Einstellung
    /// </param>
    /// <param name="value">
    ///   Wert
    /// </param>
    public static void RemoveSetting(string settingName)
    {
      var obj = GetSettings();

      if (!obj.ContainsKey(settingName))
        return;

      obj.Remove(settingName);
      SetSettings(obj);
    }

    /// <summary>
    ///   The serialize in memory.
    /// </summary>
    /// <param name="obj">
    ///   The obj.
    /// </param>
    /// <returns>
    ///   The byte[]
    /// </returns>
    public static byte[] SerializeInMemory(object obj)
    {
      using (var ms = new MemoryStream())
      {
        using (var gs = new GZipStream(ms, CompressionMode.Compress))
        {
          var bf = new BinaryFormatter();
          bf.Serialize(gs, obj);

          gs.Seek(0, SeekOrigin.Begin);
          var res = new byte[gs.Length];
          gs.Read(res, 0, res.Length);
          return res;
        }
      }
    }

    public static void SetSetting(string settingName, int value)
      => SetSetting(settingName, value.ToString());

    public static void SetSetting(string settingName, double value)
      => SetSetting(settingName, value.ToString());

    public static void SetSetting(string settingName, bool value)
      => SetSetting(settingName, value.ToString());

    /// <summary>
    ///   Speichert eine Einstellung
    /// </summary>
    /// <param name="settingName">
    ///   Name der Einstellung
    /// </param>
    /// <param name="value">
    ///   Wert
    /// </param>
    public static void SetSetting(string settingName, string value)
    {
      var obj = GetSettings() ?? new Dictionary<string, string>();
      if (obj.ContainsKey(settingName))
        obj[settingName] = value;
      else
        obj.Add(settingName, value);

      SetSettings(obj);
    }

    public static void SetSettings(Dictionary<string, string> settings, string alternativePath = null)
    {
      lock (_cacheSettingsLock)
      {
        _cacheSettings = null;
        try
        {
          FileIO.Write(alternativePath ?? SettingsAppPath, JsonConvert.SerializeObject(settings));
        }
        catch
        {
          // ignore
        }
      }
    }

    /// <summary>
    ///   The initialize.
    /// </summary>
    internal static void Initialize(InitialOptionsEnum options, bool forceReInitialization = false,
                                    string alternative3rdPartyPath = null)
    {
      if (IsInitialized && !forceReInitialization)
        return;

      InitializeMinimal(forceReInitialization);

      // Ergänze mit 3rd-Party
      if (options == InitialOptionsEnum.MinimalAnd3rdParty)
        Reload3rdPartyAddons(alternative3rdPartyPath);

      IsInitialized = true;
    }

    /// <summary>
    ///   Stellt sicher, das der Pfad exsisitert
    /// </summary>
    /// <param name="path">
    ///   Pfad
    /// </param>
    /// <returns>
    ///   Gibt den sichergestellten Pfad zurück
    /// </returns>
    private static string EnsurePath(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      return path;
    }

    private static string GetRelativAppDirectory(string directory)
    {
      try
      {
        var res = string.IsNullOrEmpty(directory) ? AppPath : Path.Combine(AppPath, directory);
        if (res != null && !Directory.Exists(res))
          Directory.CreateDirectory(res);
        return res;
      }
      catch
      {
        return directory;
      }
    }

    /// <summary>
    ///   Wandelt einen relativen Pfad in einen absoluten Pfad um
    /// </summary>
    /// <param name="path">
    ///   Pfad
    /// </param>
    /// <returns>
    ///   Absoluter Pfad (Anwendungsdaten\CorpusExplorer\Application\ + path)
    /// </returns>
    private static string GetRelativAppFilePath(string path)
    {
      try
      {
        var res = string.IsNullOrEmpty(path) ? AppPath : Path.Combine(AppPath, path);
        var dir = Path.GetDirectoryName(res);
        if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
          Directory.CreateDirectory(dir);
        return res;
      }
      catch
      {
        return path;
      }
    }

    /// <summary>
    ///   The get relativ path.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    private static string GetRelativPath(string path)
    {
      try
      {
        var res = Path.Combine(
                             Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                             "CorpusExplorer\\" + path);
        return EnsurePath(res);
      }
      catch
      {
        return EnsurePath(path);
      }
    }

    private static void InitializeMinimal(bool forceReInitialization = false)
    {
      if (IsInitialized && !forceReInitialization)
        return;

      Random = new Random();

      SetSignificance(new PoissonSignificance());

      try // notwendig z. B. unter AZURE
      {
        AppConfigPath = GetRelativAppDirectory("myConfig");
        ExternAppPath = GetRelativAppDirectory("extern");
      }
      catch
      {
        // ignore
      }

      try // notwendig z. B. unter AZURE
      {
        MyCorpora = GetRelativPath(Resources.MyCorpora);
        MyAddons = GetRelativPath(Resources.MyExtension);
        MyDataSources = GetRelativPath(Resources.MyDataSources);
        MyProjects = GetRelativPath(Resources.MyProjects);
      }
      catch
      {
        // ignore
      }

      // Anwendungskonfiguration
      try // notwendig z. B. unter AZURE
      {
        SettingsAppPath = GetRelativAppFilePath("settings.bin");
      }
      catch
      {
        // ignore
      }

      ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };

      try // notwendig z. B. unter AZURE
      {
        if (!Directory.Exists(TempPath))
          Directory.CreateDirectory(TempPath);

        var files = Directory.GetFiles(TempPath, "*.*");
        foreach (var file in files)
          try
          {
            File.Delete(file);
          }
          catch
          {
            // ignore
          }
      }
      catch
      {
        // ignore
      }

      // notwendig - Aufruf get > set setzt lädt bzw. initialisiert die Eigenschaften
      Encoding = Encoding;
      RightToLeftSupport = RightToLeftSupport;
      ProtectMemoryOverflow = ProtectMemoryOverflow;
      DefaultFontSize = DefaultFontSize;

      _addonSideLoadFeatures = new List<object>();
      _addonBackends = new Dictionary<string, AbstractCorpusBuilder>();
      _addonConsoleActions = new List<IAction>();
      _addonCrawlers = new List<AbstractCrawler>();
      _addonExporters = new Dictionary<string, AbstractExporter>();
      _addonImporters = new Dictionary<string, AbstractImporter>();
      _addonTaggers = new List<AbstractTagger>();
      _addonAdditionalTaggers = new List<AbstractAdditionalTagger>();
      _addonScrapers = new Dictionary<string, AbstractScraper>();
      _addonTableWriters = new Dictionary<string, AbstractTableWriter>();
#if UNIVERSAL
#else
      _addonViews = new List<IAddonView>();
#endif

      IsInitialized = true;
    }

#if UNIVERSAL
#else
    private static void Load3RdPartyAddons(string path)
    {
      if (string.IsNullOrEmpty(path))
        return;

      var host = new AddonHost();
      host.SearchInDirectoryForAddons(path);

      if (host.AvailableAddons == null)
        return;

      var repos = host.AvailableAddons.OfType<IAddonRepository>();
      foreach (var repo in repos)
        try
        {
          if (repo.AddonScrapers != null)
            foreach (var s1 in repo.AddonScrapers.Where(s1 => !_addonScrapers.ContainsKey(s1.Key)))
              try
              {
                if (!s1.Key.Contains("|"))
                  throw new
                    CustomAttributeFormatException($"SCRAPER - WRONG ENTRY FOR: {s1.Key} - {s1.Value.GetType().FullName}");

                _addonScrapers.Add(s1.Key, s1.Value);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonImporter != null)
            foreach (var s2 in repo.AddonImporter.Where(s2 => !_addonImporters.ContainsKey(s2.Key)))
              try
              {
                if (!s2.Key.Contains("|"))
                  throw new
                    CustomAttributeFormatException($"IMPORTER - WRONG ENTRY FOR: {s2.Key} - {s2.Value.GetType().FullName}");

                _addonImporters.Add(s2.Key, s2.Value);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonExporters != null)
            foreach (var s3 in repo.AddonExporters.Where(s3 => !_addonExporters.ContainsKey(s3.Key)))
              try
              {
                if (!s3.Key.Contains("|"))
                  throw new
                    CustomAttributeFormatException($"EXPORTER - WRONG ENTRY FOR: {s3.Key} - {s3.Value.GetType().FullName}");

                _addonExporters.Add(s3.Key, s3.Value);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonTableWriter != null)
            foreach (var s3 in repo.AddonTableWriter.Where(s3 => !_addonTableWriters.ContainsKey(s3.Key)))
              try
              {
                if (!s3.Key.Contains("|"))
                  throw new
                    CustomAttributeFormatException($"TABLEWRITER - WRONG ENTRY FOR: {s3.Key} - {s3.Value.GetType().FullName}");

                _addonTableWriters.Add(s3.Key, s3.Value);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonConsoleActions != null)
            foreach (var s in
              repo.AddonConsoleActions.Where(s => !_addonConsoleActions.Exists(x => x.Action == s.Action)))
              try
              {
                _addonConsoleActions.Add(s);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonViews != null)
            foreach (var s in repo.AddonViews.Where(s => !_addonViews.Exists(x => x.Label == s.Label)))
              try
              {
                _addonViews.Add(s);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonBackends != null)
            foreach (var s3 in repo.AddonBackends.Where(s3 => !_addonBackends.ContainsKey(s3.Key)))
              try
              {
                _addonBackends.Add(s3.Key, s3.Value);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonSideloadFeature != null)
            foreach (var s in repo.AddonSideloadFeature.Where(
                                                              s => !_addonSideLoadFeatures.Contains(s)))
              try
              {
                _addonSideLoadFeatures.Add(s);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          if (repo.AddonAdditionalTagger != null)
            foreach (var s in repo.AddonAdditionalTagger.Where(
                                                               s =>
                                                                 !_addonAdditionalTaggers.Exists(x => x.DisplayName ==
                                                                                                      s.DisplayName)))
              try
              {
                _addonAdditionalTaggers.Add(s);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }

          // ReSharper disable once InvertIf
          if (repo.AddonTagger != null)
            foreach (var s in repo.AddonTagger.Where(s => !_addonTaggers.Exists(x => x.DisplayName == s.DisplayName)))
              try
              {
                _addonTaggers.Add(s);
              }
              catch (Exception ex)
              {
                InMemoryErrorConsole.Log(ex);
              }
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      Load3RdPartyCrawler(MyDataSources);
    }

    private static void Load3RdPartyCrawler(string path)
    {
      if (string.IsNullOrEmpty(path))
        return;

      var files = Directory.GetFiles(path, "*.cml");
      foreach (var file in files)
        try
        {
          var crawler = XpathWebCrawler.Load(file);
          if (_addonCrawlers.All(c => c.DisplayName != crawler.DisplayName))
            _addonCrawlers.Add(XpathWebCrawler.Load(file));
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
    }
#endif
  }
}
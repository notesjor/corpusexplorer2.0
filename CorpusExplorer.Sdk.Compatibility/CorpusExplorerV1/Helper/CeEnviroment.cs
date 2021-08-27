#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

#endregion

namespace CorpusExplorer.Sdk.Data.Helper
{
  public static class CeEnviroment
  {
    /// <summary>
    ///   Pfad zum Ordner der Anwendungseinstellungen
    /// </summary>
    public static string AppDataPath
    {
      get
      {
        return IsPortable
          ? GetRelativAppFilePath(null)
          : EnsurePath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CorpusExplorer"));
      }
    }

    public static bool IsPortable
    {
      get { return File.Exists(GetRelativAppFilePath("isportable.flag")); }
    }

    /// <summary>
    ///   Pfad zu den Korpora
    /// </summary>
    public static string MeineDatenquellen
    {
      get { return GetRelativPath("Meine Datenquellen"); }
    }

    /// <summary>
    ///   Pfad zu den Korpora
    /// </summary>
    public static string MeineKorpora
    {
      get { return GetRelativPath("Meine Korpora"); }
    }

    /// <summary>
    ///   Pfad zu
    ///   <see cref="CorpusExplorer.Sdk.Data.Helper.CeEnviroment.MeineProjekte" />
    /// </summary>
    public static string MeineProjekte
    {
      get { return GetRelativPath("Meine Projekte"); }
    }

    /// <summary>
    ///   Pfad zum Hauptordner LINGUNET
    /// </summary>
    public static string LinguNet
    {
      get { return GetRelativPath("LinguNet"); }
    }

    /// <summary>
    ///   Pfad zu den Einstellungsdateien von Lingunet
    /// </summary>
    public static string LinguNetSettings
    {
      get { return GetRelativPath("LinguNet\\settings.dat"); }
    }

    /// <summary>
    ///   Pfad zu den Lingunet-Korpora
    /// </summary>
    public static string LinguNetKorpora
    {
      get { return GetRelativPath("LinguNet\\Geteilte Korpora"); }
    }

    /// <summary>
    ///   Pfad zu den temporären Dateien
    /// </summary>
    public static string TempPath
    {
      get { return EnsurePath(Path.Combine(AppDataPath, "TEMP")); }
    }

    /// <summary>
    ///   Dateipfad der Einstellungsdatei
    /// </summary>
    private static string SettingsPath
    {
      get { return Path.Combine(AppDataPath, "settings.bin"); }
    }

    /// <summary>
    ///   Stellt sicher, das der Pfad exsisitert
    /// </summary>
    /// <param name="path">Pfad</param>
    /// <returns>
    ///   Gibt den sichergestellten Pfad zurück
    /// </returns>
    private static string EnsurePath(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      return path;
    }

    /// <summary>
    ///   Gibt den PFad des Korpus zurück
    /// </summary>
    /// <param name="korpusName">Name des Korpus</param>
    /// <returns>
    ///   Pfad zum Korpus
    /// </returns>
    public static string GetKorpus(string korpusName)
    {
      var res = Path.Combine(MeineKorpora, korpusName);
      if (!Directory.Exists(res))
        Directory.CreateDirectory(res);
      return res;
    }

    /// <summary>
    ///   Gibt den Basispfad der Korpora zurück
    /// </summary>
    /// <returns>
    ///   Pfad
    /// </returns>
    private static string GetPath()
    {
      return IsPortable
        ? EnsurePath(Path.Combine(AppDataPath, "PortableData"))
        : EnsurePath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CorpusExplorer"));
    }

    /// <summary>
    ///   Wandelt einen relativen Pfad in einen absoluten Pfad um
    /// </summary>
    /// <param name="path">Pfad</param>
    /// <returns>
    ///   Absoluter Pfad (Anwendungsdaten\CorpusExplorer\Application\ + path)
    /// </returns>
    public static string GetRelativAppFilePath(string path)
    {
      return string.IsNullOrEmpty(path)
        ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        : Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
    }

    /// <summary>
    ///   Wandelt einen relativen Pfad in einen absoluten Pfad um
    /// </summary>
    /// <param name="path">Pfad</param>
    /// <returns>
    ///   Absoluter Pfad (GetPath + path)
    /// </returns>
    public static string GetRelativPath(string path)
    {
      return EnsurePath(Path.Combine(GetPath(), path));
    }

    /// <summary>
    ///   Gibt eine Einstellung zurück
    /// </summary>
    /// <param name="settingName">Name der Einstellung</param>
    /// <returns>
    ///   Wert
    /// </returns>
    private static object GetSetting(string settingName)
    {
      var def = new Dictionary<string, object>();
      if (!File.Exists(SettingsPath))
        return def;

      var bin = new BinaryFormatter();
      using (var fs = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read))
        return ((Dictionary<string, object>) bin.Deserialize(fs))[settingName];
    }

    /// <summary>
    ///   Gibt eine Einstellung zurück (safety cast)
    /// </summary>
    /// <param name="settingName">Name der Einstellung</param>
    /// <returns>
    ///   Wert
    /// </returns>
    public static T GetSetting<T>(string settingName) where T : class
    {
      return GetSetting(settingName) as T;
    }

    /// <summary>
    ///   Speichert eine Einstellung
    /// </summary>
    /// <param name="settingName">Name der Einstellung</param>
    /// <param name="value">Wert</param>
    public static void SetSetting(string settingName, object value)
    {
      Dictionary<string, object> obj = null;
      var bin = new BinaryFormatter();

      if (!File.Exists(SettingsPath))
      {
        obj = new Dictionary<string, object>();
      }
      else
      {
        using (var fs = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read))
          obj = (Dictionary<string, object>) bin.Deserialize(fs);
      }

      if (obj.ContainsKey(settingName))
        obj[settingName] = value;
      else
        obj.Add(settingName, value);

      using (var fs = new FileStream(SettingsPath, FileMode.Create, FileAccess.Write))
        bin.Serialize(fs, obj);
    }

    /// <summary>
    ///   Schreibt Daten (content) in eine temporäre Datei und gibt deren PFad
    ///   zurück
    /// </summary>
    /// <param name="filename">Name der Datei (ohne Pfadangabe)</param>
    /// <param name="content">Inhalt</param>
    /// <returns>
    ///   Pfad der Datei
    /// </returns>
    public static string WriteTempFile(string filename, string content)
    {
      var path = Path.Combine(TempPath, filename);
      var buffer = Encoding.UTF8.GetBytes(content);
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        fs.Write(buffer, 0, buffer.Length);
      return path;
    }
  }
}
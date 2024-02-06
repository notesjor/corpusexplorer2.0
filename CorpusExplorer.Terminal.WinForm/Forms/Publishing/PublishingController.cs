using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.Drm;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  public static class PublishingController
  {
    private static AbstractCorpusAdapter _tmp;

    public static void Publish(Selection selection)
    {
      try
      {
        var publisher = new CorpusPublisher();
        if (publisher.ShowDialog() != DialogResult.OK)
          return;

        var info = publisher.Result;
        info.CountTokens = selection.CountToken;
        info.CountSentences = selection.CountSentences;
        info.CountDocuments = selection.CountDocuments;
        info.LayerNames = selection.LayerDisplaynames.ToArray();

        using (var dir = new TemporaryDirectory())
        {
          try
          {
            switch (publisher.ResultProtectionMode)
            {
              case 0:
                if (!Publishing_DifferentFormats(info, selection, dir))
                  return;
                break;
              case 1:
                selection = Publishing_randomizer(info, selection, dir);
                if (selection == null)
                  return;
                if (!Publishing_DifferentFormats(info, selection, dir))
                  return;
                break;
              case 2:
                if (!Publishing_Crypted(info, selection, dir))
                  return;
                break;
            }
          }
          catch
          {
            // ignore
          }

          Publishing_AddInfo(info, dir);

          // Ermittelt die Gesamtgröße
          info.FileSize = DirectoryHelper.CalculateDirectorySize(dir.Path);

          // Muss erneut hinzugefügt werden (überschreibt Werte)
          Publishing_AddInfo(info, dir);

          var sfd = new SaveFileDialog
          {
            CheckPathExists = true,
            Filter = "ZIP-Archiv (*.zip)|*.zip",
          };
          if (sfd.ShowDialog() != DialogResult.OK)
            return;

          Processing.SplashShow("Erzeuge Ausgabe-Datei...");

          ZipHelper.Compress(dir.Path, sfd.FileName);

          Processing.SplashClose();
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        Processing.SplashClose();
      }
    }

    private static void Publishing_AddInfo(CorpusInfo info, TemporaryDirectory dir)
    {
      try
      {
        File.WriteAllText(Path.Combine(dir.Path, "corpus_info.json"), JsonConvert.SerializeObject(info), Encoding.UTF8);
        File.WriteAllText(Path.Combine(dir.Path, "corpus_info.txt"), Publishing_AddInfo_InfoToText(info), Encoding.UTF8);
        File.WriteAllText(Path.Combine(dir.Path, "corpus_info.cff"), Publishing_AddInfo_InfoToCff(info), Encoding.UTF8);

        using (var wc = new WebClient())
        {
          try
          {
            if (!string.IsNullOrEmpty(info.AdditionalInfoUrl))
              wc.DownloadFile(info.AdditionalInfoUrl, Path.Combine(dir.Path, Path.GetFileName(info.AdditionalInfoUrl)));
          }
          catch
          {
            // ignore
          }
          try
          {
            if (!string.IsNullOrEmpty(info.LicenceUrl))
              wc.DownloadFile(info.LicenceUrl, Path.Combine(dir.Path, Path.GetFileName(info.LicenceUrl)));
          }
          catch
          {
            // ignore
          }
        }
      }
      catch
      {
        // ignore
      }
    }

    private static string Publishing_AddInfo_InfoToCff(CorpusInfo info)
    {
      var lines = new List<string>();
      lines.Add("# This corpus was published with CorpusExplorer.de");
      lines.Add("# Visit http://corpusexplorer.de to publish your corpora today!");
      lines.Add("");
      lines.Add("cff -version: 1.2.0");
      lines.Add($"title: {info.CorpusName}");
      lines.Add("message: >-");
      lines.Add("  If you use this corpus, please cite it using the");
      lines.Add("  metadata from this file.");
      lines.Add("type: corpus");
      lines.Add($"authors: {info.LicenceHolder}");
      lines.Add("identifiers:");
      lines.Add("  - type: url");
      lines.Add($"    value: '{info.AdditionalInfoUrl}'");
      lines.Add("    description: Additional project information");
      lines.Add("  - type: url");
      lines.Add($"    value: '{info.LicenceUrl}'");
      lines.Add("    description: Full licence text");
      lines.Add($"url: '{info.AdditionalInfoUrl}'");
      lines.Add($"license: '{info.LicenceName}'");
      lines.Add($"version: {info.Version}");
      lines.Add("abstract: >-");
      lines.Add($"  {info.CorpusDescription.Replace("\r\n", "\r\n  ")}");

      return string.Join(Environment.NewLine, lines);
    }

    private static string Publishing_AddInfo_InfoToText(CorpusInfo info)
    {
      var lines = new List<string>();
      lines.Add("CORPUS PUBLISHING INFORMATION");
      lines.Add("");
      lines.Add($"Name: {info.CorpusName} / Version: {info.Version}");
      lines.Add("Description:");
      lines.Add(info.CorpusDescription);
      lines.Add("");
      lines.Add($"More information: {info.AdditionalInfoUrl}");
      lines.Add("");
      lines.Add($"Licenceholder: {info.LicenceHolder}");
      lines.Add($"Licence: {info.LicenceName}");
      lines.Add($"Licence-URL: {info.LicenceUrl}");
      lines.Add("");
      lines.Add("Published with the aid of www.CorpusExplorer.de");

      return string.Join(Environment.NewLine, lines);
    }

    private static Selection Publishing_randomizer(CorpusInfo info, Selection selection, TemporaryDirectory dir)
    {
      var form = new CorpusRandomizer();
      if (form.ShowDialog() != DialogResult.OK)
        return null;

      Processing.SplashShow("Text wird randomisiert...");

      AbstractCorpusRandomizerStrategy _strategy;
      if (form.RandomizeSentencesAndTokens)
        _strategy = new CorpusRandomizerStrategyTokens();
      else
        _strategy = new CorpusRandomizerStrategySentences();

      _tmp = selection.ToCorpus();
      _tmp = CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizer.Randomize(_tmp, _strategy);
      _tmp.SetCorpusMetadata("[INFO]", JsonConvert.SerializeObject(info));
      _tmp.SetCorpusMetadata("[PROTECTION]", _strategy.GetType().Name);

      var subdir = Path.Combine(dir.Path, "CEC6");
      Directory.CreateDirectory(subdir);
      _tmp.Save(Path.Combine(subdir, "corpus.cec6"), false);

      Processing.SplashClose();

      return _tmp.ToSelection();
    }

    private static bool Publishing_DifferentFormats(CorpusInfo info, Selection selection, TemporaryDirectory dir)
    {
      var form = new CorpusPublisherExport();
      if (form.ShowDialog() != DialogResult.OK)
        return false;

      Processing.SplashShow("Erzeuge gewählte Exportformate...");

      _tmp = selection.ToCorpus();
      _tmp.SetCorpusMetadata("[INFO]", JsonConvert.SerializeObject(info));

      var exports = form.Result;

      foreach (var export in exports)
      {
        var subdir = Path.Combine(dir.Path, export.GetType().Name.Replace("Exporter", "").ToUpper());
        if (!Directory.Exists(subdir))
          Directory.CreateDirectory(subdir);
        var ext = form.ResultFirstFileExtension.FirstOrDefault(x => x.Key.GetType() == export.GetType()).Value;
        if (ext == null)
          continue;
        export.Export(_tmp, Path.Combine(subdir, "corpus" + ext));
      }

      Processing.SplashClose();

      return true;
    }

    private static bool Publishing_Crypted(CorpusInfo info, Selection selection, TemporaryDirectory dir)
    {
      _tmp = selection.ToCorpus();
      _tmp.SetCorpusMetadata("[INFO]", info);
      _tmp.SetCorpusMetadata("[PROTECTION]", "NOEXPORT");

      var token = Guid.NewGuid().ToString();

      var form = new DrmManager(token);
      if (form.ShowDialog() != DialogResult.OK)
        return false;

      var subdir = Path.Combine(dir.Path, "CEC6+DRM");
      Directory.CreateDirectory(subdir);
      var path = Path.Combine(subdir, "corpus.cec6.drm");

      ((CorpusAdapterWriteDirect)_tmp).Save(path, token, form.ResultUserPasswordCombinations);
      DrmDb.Create(token, form.ResultUserPasswordCombinations, path + "db");

      var drmNote = "-- GERMAN --\r\n\r\nDiese Korpus-Daten sind speziell gesichert und nur für autorisierte Personen zugänglich.\r\n\r\n1. Entpacken Sie die ZIP-Datei vollständig\r\n2. Nutzen Sie zum Öffnen die Software CorpusExplorer (www.CorpusExplorer.de)\r\n3. Verwenden Sie die mitgeteilten Zugangsdaten.\r\n\r\n--- ENGLISH ---\r\n\r\nThis corpus data is specially secured and accessible only to authorized persons.\r\n\r\n1. unpack the ZIP file completely.\r\n2. use the CorpusExplorer software to open it (www.CorpusExplorer.de)\r\n3. use the access data provided.";
      File.WriteAllText(Path.Combine(dir.Path, "CORPUS WITH DRM - READ THIS.txt"), drmNote, Encoding.UTF8);

      return true;
    }

    public static bool ReadPublishingInfo(CorpusAdapterWriteDirect corpus)
    {
      try
      {
        var data = corpus.GetCorpusMetadata("[INFO]");
        if (data == null)
          return true;
        var info = JsonConvert.DeserializeObject<CorpusInfo>(data.ToString());
        if (info == null)
          return true;

        var form = new PublishingInfo(info);
        return form.ShowDialog() == DialogResult.OK;
      }
      catch
      {
        return true;
      }
    }

    private static string _email = "";
    private static string _password = "";

    public static IEnumerable<AbstractCorpusAdapter> ReadCryptedCorpora(IEnumerable<string> paths)
    {
      var res = new List<AbstractCorpusAdapter>();

      foreach (var path in paths)
      {
        try
        {
          var corpus = CorpusAdapterWriteDirect.Create(path, _email, _password);
          if (corpus == null)
            throw new Exception();
          res.Add(corpus);
        }
        catch
        {
          try
          {
            var form = new DrmOpen();
            if (form.ShowDialog() != DialogResult.OK)
              return res;

            _email = form.EMail;
            _password = form.Password;

            var corpus = CorpusAdapterWriteDirect.Create(path, form.EMail, form.Password);
            if (corpus == null)
              throw new Exception();
            res.Add(corpus);
          }
          catch
          {
            // ignore
          }
        }
      }

      return res;
    }

    public static void ManageCryptedCorpus()
    {
      var ofd = new OpenFileDialog
      {
        Multiselect = false,
        Filter = "CorpusExplorer DRM-Datenabank (*.drmdb)|*.drmdb",
        CheckFileExists = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      var form = new DrmManagerReopen();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      var db = DrmDb.Load(ofd.FileName, form.ResultToken);
      if (db == null)
        return;

      var manager = new DrmManager(form.ResultToken);
      if (manager.ShowDialog() != DialogResult.OK)
        return;

      foreach (var entry in manager.ResultUserPasswordCombinations)
      {
        if (string.IsNullOrEmpty(entry.Key) || string.IsNullOrEmpty(entry.Value))
          continue;

        db.UserAdd(entry.Key, entry.Value);
      }

      db.Save(ofd.FileName);
    }
  }
}

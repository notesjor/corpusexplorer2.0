using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CorpusExplorer.Sdk.Helper;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Installer.ImageBuilder
{
  public class ImageBuilderViewModel
  {
    private string _addonUrl = "http://bitcutstudios.com/products/CorpusExplorer/repository_addons.manifest";
    private Dictionary<string, string> _addons = new Dictionary<string, string>();

    public ImageBuilderViewModel()
    {
      Console.WriteLine("CorpusExplorer v2.0 - [IMAGE BUILDER]");
      Console.WriteLine($"Copyright 2013-{DateTime.Now.Year} by Jan Oliver Rüdiger");
      Console.WriteLine("CorpusExplorer is licensed under the: GNU Affero General Public License v3.0");

      try
      {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
      }
      catch
      {
        // ignore
      }

      Console.Write("Load add-on list...");
      using (var wc = new WebClient())
      {
        var addons = wc.DownloadString(_addonUrl).Split(Splitter.CRLF, StringSplitOptions.RemoveEmptyEntries);

        foreach (var addon in addons)
        {
          var items = addon.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries);
          _addons.Add(items[items.Length - 1], items[items.Length - 2]);
        }
      }
      Console.WriteLine("ok!");
    }

    public IEnumerable<string> AddonNames => _addons.Keys;

    public void BuildImage(string[] args)
    {
      var tmp = "tmp";
      if (Directory.Exists(tmp))
        Directory.Delete(tmp, true);
      Directory.CreateDirectory(tmp);

      var path = "CorpusExplorer";
      if (Directory.Exists(path))
        Directory.Delete(path, true);
      Directory.CreateDirectory(path);

      var manifests = new List<string> { "http://www.bitcutstudios.com/products/corpusexplorer/standard.manifest" };
      var error = false;

      // add-ons
      if (args != null)
      {
        Console.WriteLine("Prepare add-ons for imaging:");
        foreach (var addon in args)
        {
          Console.Write($"{addon}...");
          try
          {
            var url = _addons.FirstOrDefault(x => string.Equals(x.Key, addon, StringComparison.CurrentCultureIgnoreCase)).Value;
            var ms = GetManifests(url);
            if (ms != null)
              manifests.AddRange(ms);
            else
              throw new Exception();
            Console.WriteLine("ok!");
          }
          catch
          {
            Console.WriteLine("error!");
          }
        }
      }

      // get all ZIP-files
      var urls = new List<string>();

      foreach (var manifest in manifests)
      {
        using (var wc = new WebClient())
        {
          var items = wc.DownloadString(manifest).Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
          urls.AddRange(from item in items select item.Split(Splitter.Pipe, StringSplitOptions.RemoveEmptyEntries) into split where split.Length == 2 && split[0].ToLower().EndsWith(".zip") select split[0].Replace("{CPU}", Environment.Is64BitProcess ? "x64" : "x86"));
        }
      }

      Console.WriteLine($"{urls.Count} packages found!");
      var cnt = 1;
      foreach (var url in urls)
      {
        Console.Write($"{cnt:D2}: {url}...");
        try
        {
          Console.Write("download...");
          var tmpFile = $"{tmp}/{cnt}.zip";
          using (var wc = new WebClient())
            wc.DownloadFile(url, tmpFile);

          Console.Write("unzip...");
          var zip = new FastZip();
          zip.ExtractZip(tmpFile, path, null);

          Console.WriteLine("ok!");
        }
        catch (Exception ex)
        {
          Console.WriteLine("error!");
          Console.WriteLine(ex.Message);
          error = true;
        }

        cnt++;
      }

      if (error)
      {
        Console.WriteLine("CorpusExplorer IMAGE-BUILD failed!");
        Console.WriteLine("Maybe your Firewall or Anti-Virus-Solution is blocking the imaging/installation process.");
        Console.WriteLine("Use https://notes.jan-oliver-ruediger.de/kontakt/ to send your error report.");
      }
      else
      {
        Console.WriteLine("CorpusExplorer IMAGE-BUILD succed!");
        Console.WriteLine($"The application is available in (path): {path}");
      }
      Console.WriteLine("PRESS [ENTER] TO EXIT!");
      Console.ReadLine();
    }

    private IEnumerable<string> GetManifests(string addon)
    {
      using (var wc = new WebClient())
        return wc.DownloadString(addon).Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
    }
  }
}

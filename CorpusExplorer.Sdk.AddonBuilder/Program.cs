using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Sdk.AddonBuilder
{
  internal class Program
  {
    private static readonly string _date = DateTime.Now.ToString("yyyyMMdd");

    private static void CopyAddonTemplate(string addon, string addonOutput, string zipName)
    {
      var dir = Path.GetDirectoryName(addon);
      var files = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly);
      foreach (var file in files)
      {
        if (Path.GetFileName(file) == "addon.txt")
          continue;

        var fn = Path.Combine(addonOutput, Path.GetFileName(file));

        if (file.EndsWith(".manifest"))
        {
          var lines = File.ReadAllLines(file, Encoding.UTF8);
          for (var i = 0; i < lines.Length; i++)
            lines[i] = lines[i].Replace("{ZIP}", zipName).Replace("{DATE}", _date);
          File.WriteAllLines(fn, lines, Encoding.UTF8);
        }
        else
        {
          File.Copy(file, fn);
        }
      }
    }

    private static string CreateOutputDir(string output, string addonName)
    {
      var res = Path.Combine(output, addonName);
      Directory.CreateDirectory(res);
      return res;
    }

    private static string[] GetFilesToZip(string[] originaleAppFiles, string releaseDir)
    {
      var files = Directory.GetFiles(releaseDir, "*", SearchOption.AllDirectories);
      var block = new HashSet<string>(originaleAppFiles.Select(Path.GetFileName));

      return (from file in files
              let low = file.ToLower()
              where !low.EndsWith(".zip") && !low.EndsWith(".xml") && !low.EndsWith(".pdb") &&
                    !block.Contains(Path.GetFileName(file))
              select file).ToArray();
    }

    private static string[] GetOriginalAppFiles()
    {
      var path =
        @"C:\Projekte\CorpusExplorerV2\CorpusExplorer\CorpusExplorer.Sdk.AddonBuilder\bin\Release";
      var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
      for (var i = 0; i < files.Length; i++) files[i] = files[i].Replace(path, "").Replace(path + @"\", "");

      return files;
    }

    private static void Main(string[] args)
    {
      var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var addoPath = Path.Combine(basePath, "addons");
      var addons = Directory.GetFiles(addoPath, "addon.txt", SearchOption.AllDirectories);
      var output = Path.Combine(basePath, "output");

      if (Directory.Exists(output))
        Directory.Delete(output, true);
      Directory.CreateDirectory(output);

      var originaleAppFiles = GetOriginalAppFiles();

      foreach (var addon in addons)
      {
        var addonName = Path.GetDirectoryName(addon).Replace(addoPath, "");
        while (addonName.StartsWith(@"\"))
          addonName = addonName.Substring(1);
        Console.Write(Path.GetDirectoryName(addon).Replace(addoPath, ""));

        var lines = File.ReadAllLines(addon);
        if (lines.Length != 2)
        {
          Console.WriteLine("ERROR: addon.txt only allow 2 lines.");
          continue;
        }

        var zipName = lines[0];
        var releaseDir = lines[1];
        var filesToZip = GetFilesToZip(originaleAppFiles, releaseDir);

        var addonOutput = CreateOutputDir(output, addonName);
        CopyAddonTemplate(addon, addonOutput, zipName);
        ProduceZipPackage(filesToZip, releaseDir, addonOutput, zipName);
        Console.WriteLine("OK!");
      }
    }

    private static void ProduceZipPackage(string[] filesToZip, string releaseDir, string addonOutput, string zipName)
    {
      if (!releaseDir.EndsWith(@"\"))
        releaseDir += @"\";

      using (var zip = ZipFile.Create(Path.Combine(addonOutput, zipName)))
      {
        zip.BeginUpdate();
        foreach (var f in filesToZip)
          zip.Add(f, f.Replace(releaseDir, ""));
        zip.CommitUpdate();
      }
    }
  }
}
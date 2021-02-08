using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;

namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public class ZipFileIndex
  {
    protected internal string _path;
    private ZipDirectoryEntry _root = new ZipDirectoryEntry();

    public ZipFileIndex(string path)
    {
      _path = path;

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var zip = new ZipFile(fs))
        foreach (ZipEntry entry in zip)
        {
          try
          {
            if (!entry.IsFile)
              continue;

            var index = entry.Name.LastIndexOf("/");
            if (index == -1)
              continue;

            var zpath = entry.Name.Substring(0, index).Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            var zfile = entry.Name.Substring(index + 1);

            BuildPath(entry.Name, zpath, zfile, 0, ref _root);
          }
          catch
          {
            // ignore
          }
        }
    }

    private void BuildPath(string path, string[] zpath, string name, int i, ref ZipDirectoryEntry entry)
    {
      if (i == zpath.Length)
      {
        entry.ZipFiles.Add(new ZipFileEntry(this, path, name));
        return;
      }

      var dirMatch = entry.ZipDirectories.FirstOrDefault(x => x.NameDirectory == zpath[i]);
      if (dirMatch == null)
      {
        dirMatch = new ZipDirectoryEntry { NameDirectory = zpath[i], NamePath = MakeNamePath(zpath, i) };
        entry.ZipDirectories.Add(dirMatch);
      }

      BuildPath(path, zpath, name, i + 1, ref dirMatch);
    }

    private string MakeNamePath(string[] zpath, int i)
    {
      var res = new List<string>();
      for (int j = 0; j <= i; j++)
        res.Add(zpath[j]);

      return string.Join("/", res);
    }

    public ZipDirectoryEntry ZipDirectoryRoot => _root;

    public void Extract(string zipPath, ZipFileEntryExtractionDelegate func)
    {
      var file = GetZipFileEntry(zipPath);
      if (file == null)
        return;

      try
      {
        file.Extract(func);
      }
      catch
      {
        // ignore
      }
    }

    public void Extract(string zipPath, ZipFileEntryExtractionStreamDelegate func)
    {
      var file = GetZipFileEntry(zipPath);
      if (file == null)
        return;

      try
      {
        file.Extract(func);
      }
      catch
      {
        // ignore
      }
    }

    public ZipFileEntry GetZipFileEntry(string zipPath)
      => GetZipFileEntry(ZipDirectoryRoot, zipPath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries), 0);

    private ZipFileEntry GetZipFileEntry(ZipDirectoryEntry root, string[] zipPath, int i)
    {
      if (i + 1 == zipPath.Length)
        return root.ZipFiles.FirstOrDefault(x => x.NameFile == zipPath[i]);

      var dir = root.ZipDirectories.FirstOrDefault(x => x.NameDirectory == zipPath[i]);
      return dir == null ? null : GetZipFileEntry(dir, zipPath, i + 1);
    }

    public ZipDirectoryEntry GetZipDirectoryEntry(string zipPath) 
      => GetZipDirectoryEntry(ZipDirectoryRoot, zipPath.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries), 0);

    private ZipDirectoryEntry GetZipDirectoryEntry(ZipDirectoryEntry root, string[] zipPath, int i)
    {
      var dir = root.ZipDirectories.FirstOrDefault(x => x.NameDirectory == zipPath[i]);
      if (dir == null)
        return null;

      i += 1;
      return i == zipPath.Length ? dir : GetZipDirectoryEntry(dir, zipPath, i);
    }
  }
}

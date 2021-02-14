using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace CorpusExplorer.Sdk.Utils.ZipFileIndex
{
  public class ZipFileIndex : IDisposable
  {
    private FileStream _fs;
    private ZipArchive _zip;
    private ZipDirectoryEntry _root = new ZipDirectoryEntry();

    public ZipFileIndex(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.Read)
    {
      Path = path;

      var zipMode = GetZipMode(mode, access);
      _fs = new FileStream(path, mode, zipMode == ZipArchiveMode.Update ? FileAccess.ReadWrite : access, share);
      _zip = new ZipArchive(_fs, zipMode, true);
      
      foreach (var entry in _zip.Entries)
        AddEntry(entry);
    }

    public string Path { get; set; }

    private void AddEntry(ZipArchiveEntry entry)
    {
      try
      {
        var zpath = entry.FullName.Replace(entry.Name, "")
                         .Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
        var zfile = entry.Name;

        BuildPath(entry.FullName, zpath, zfile, 0, ref _root);
      }
      catch
      {
        // ignore
      }
    }

    private ZipArchiveMode GetZipMode(FileMode mode, FileAccess access)
    {
      // ReSharper disable once ConvertIfStatementToSwitchStatement
      if (mode == FileMode.Open)
        return access == FileAccess.Read ? ZipArchiveMode.Read : ZipArchiveMode.Update;
      if (mode == FileMode.Create)
        return ZipArchiveMode.Create;
      return ZipArchiveMode.Read;
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

    public void Read(string zipPath, ZipFileEntryDelegate func)
    {
      var file = _zip.GetEntry(zipPath);
      if (file == null)
        return;

      try
      {
        func(file.Open());
      }
      catch
      {
        // ignore
      }
    }

    public bool Delete(string zipPath)
    {
      var file = _zip.GetEntry(zipPath);
      if (file == null)
        return false;

      try
      {
        file.Delete();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool Update(string zipPath, ZipFileEntryDelegate func)
    {
      var file = _zip.GetEntry(zipPath);
      if (file == null)
        return false;

      try
      {
        file.Delete();
        return Create(zipPath, func);
      }
      catch
      {
        return false;
      }
    }

    public bool Create(string zipPath, ZipFileEntryDelegate func)
    {
      var file = _zip.GetEntry(zipPath);
      if (file != null)
        return false;

      try
      {
        var entry = _zip.CreateEntry(zipPath);
        func(entry.Open());
        AddEntry(entry);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void Dispose()
    {
      _zip?.Dispose();
      _fs?.Dispose();
    }
  }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using CorpusExplorer.Terminal.Universal.Helper;
using CorpusExplorer.Terminal.Universal.Message.Response.FileSystem;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static string _workingDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    private static string _fsChar = Path.DirectorySeparatorChar.ToString();

    private static void FileSystemGet(HttpContext obj)
    {
      var chunks = _workingDir.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries).ToList();
      var currentDrive = chunks.First() + Path.DirectorySeparatorChar;
      chunks.RemoveAt(0);

      var dirs = FileSystemGetDirectories();
      var files = FileSystemGetFiles();

      obj.Response.Send(new ResponseFileSystem
      {
        DirectorySeparatorChar = Path.DirectorySeparatorChar,
        CurrentDrive = currentDrive,
        CurrentPath = chunks.ToArray(),
        DriveLetters = DriveInfo.GetDrives().Select(x => x.Name).ToArray(),
        Directories = dirs.ToArray(),
        Files = files.ToArray()
      });
    }
    
    private static List<string> FileSystemGetDirectories()
    {
      var dirs = new List<string> { ".." };

      try
      {
        var list = Directory.GetDirectories(_workingDir);
        if (list.Length <= 0)
          return dirs;

        foreach (var x in list)
          try
          {
            dirs.Add(x.Replace(_workingDir, "").Replace(_fsChar, ""));
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

      return dirs;
    }

    private static List<ResponseFileInfo> FileSystemGetFiles()
    {
      var files = new List<ResponseFileInfo>();
      try
      {
        var list = Directory.GetFiles(_workingDir);
        if (list.Length > 0)
          foreach (var x in list)
            try
            {
              files.Add(new ResponseFileInfo(x));
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

      return files;
    }
    
    private static void FileSystemSet(HttpContext obj)
    {
      var path = obj.Request.GetData()["path"];
      switch (path)
      {
        case "..":
          _workingDir = Path.GetDirectoryName(_workingDir);
          break;
        case "HOME":
          _workingDir = PathHelper.PathApp;
          break;
        case "CORPORA":
          _workingDir = PathHelper.PathCorpora;
          break;
        case "PROJECTS":
          _workingDir = PathHelper.PathProjects;
          break;
        default:
          _workingDir = !path.Contains(Path.DirectorySeparatorChar)
                          ? Path.Combine(_workingDir, path)
                          : path;
          break;
      }

      obj.Response.Send(HttpStatusCode.OK);
    }
  }
}

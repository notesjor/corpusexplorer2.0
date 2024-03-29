﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DirectoryHelper
  {
    public static long CalculateDirectorySize(string path)
    {
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        return CalculateDirectorySize(directoryInfo);
      }
      catch (Exception)
      {
        return 0;
      }
    }

    public static long CalculateDirectorySize(DirectoryInfo directoryInfo)
    {
      try
      {
        long size = 0;

        // Dateien in diesem Verzeichnis einbeziehen
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in fileInfos)
          size += fileInfo.Length;

        // Unterordner einbeziehen
        DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
        foreach (DirectoryInfo subDirectory in subDirectories)
          size += CalculateDirectorySize(subDirectory);

        return size;
      }
      catch (Exception)
      {
        return 0;
      }
    }
  }
}

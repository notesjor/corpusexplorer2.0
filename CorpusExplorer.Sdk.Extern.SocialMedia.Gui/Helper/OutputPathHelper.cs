using System;
using System.IO;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Helper
{
  public static class OutputPathHelper
  {
    private static string _outputPath;

    public static string OutputPath
    {
      get
      {
        if (!string.IsNullOrEmpty(_outputPath))
          return _outputPath;

        _outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SSMM");
        if (!Directory.Exists(_outputPath))
          Directory.CreateDirectory(_outputPath);
        return _outputPath;
      }
      set => _outputPath = value;
    }
  }
}
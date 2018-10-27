#region

using System;
using System.Collections.Generic;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.Parameter
{
  public static class TreeTaggerLocator
  {
    public static string TreeTaggerRootDirectory => Configuration.GetDependencyPath(@"TreeTagger");

    public static string AbbreviationFile(string language)
    {
      switch (language)
      {
        case "Deutsch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\german-abbreviations-utf8");
        case "Englisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\english-abbreviations");
        case "Französisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\french-abbreviations-utf8");
        case "Italienisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\italian-abbreviations");
        case "Niederländisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\dutch-abbreviations");
        case "Spanisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\spanish-abbreviations");
        case "Polnisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\polish-abbreviations-utf8");
        default:
          throw new ArgumentOutOfRangeException(nameof(language));
      }
    }

    /// <summary>
    ///   Erstellt ein Parsing-Skipt mit dem Pfad Configuration.GetDependencyPath(@"TreeTagger\bin\tagger.bat")
    /// </summary>
    /// <param name="language">Die gewählte Sprache</param>
    /// <param name="temporaryBatchPath">Pfad unter dem die batch-Datei gespiechert werden soll.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">language</exception>
    public static void BatchFile(string language, string temporaryBatchPath)
    {
      string file;

      switch (language)
      {
        case "Deutsch":
          file = "chunk-german.bat";
          break;
        case "Englisch":
          file = "chunk-english.bat";
          break;
        case "Französisch":
          file = "chunk-french.bat";
          break;
        case "Italienisch":
          file = "tag-italian.bat";
          break;
        case "Niederländisch":
          file = "tag-dutch.bat";
          break;
        case "Spanisch":
          file = "tag-spanish.bat";
          break;
        case "Polnisch":
          file = "tag-polish.bat";
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(language));
      }

      var path = Path.Combine(TreeTaggerRootDirectory, @"bin");
      var perl = $"\"{Configuration.GetDependencyPath(@"Perl\perl\bin\perl.exe").ShortPath()}\"";
      var input = FileIO.ReadLines(Path.Combine(path, file));
      var lines = new List<string>();

      foreach (var line in input)
        if (line == @"set TAGDIR=C:\TreeTagger")
          lines.Add("set TAGDIR=" + TreeTaggerRootDirectory.ShortPath());
        else if (line.StartsWith("perl"))
          lines.Add(perl + line.Substring(4).Replace(" perl ", $" {perl} "));
        else
          lines.Add(line);

      FileIO.Write(temporaryBatchPath, lines.ToArray());
    }

    /// <summary>
    ///   Gibt die PAR-Datei zurück
    /// </summary>
    /// <param name="language">Sprache</param>
    /// <returns>PAR-Dateipfad</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">language</exception>
    public static string ParFile(string language)
    {
      switch (language)
      {
        case "Deutsch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\german-utf8.par");
        case "Englisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\english-utf8.par");
        case "Französisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\french.par");
        case "Italienisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\italian-utf8.par");
        case "Niederländisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\dutch-utf8.par");
        case "Spanisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\spanish-utf8.par");
        case "Polnisch":
          return Path.Combine(TreeTaggerRootDirectory, @"lib\polish-utf8.par");
        default:
          throw new ArgumentOutOfRangeException(nameof(language));
      }
    }
  }
}
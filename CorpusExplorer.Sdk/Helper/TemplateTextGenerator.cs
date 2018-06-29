using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bcs.IO;

// ReSharper disable MemberCanBePrivate.Global

namespace CorpusExplorer.Sdk.Helper
{
  public static class TemplateTextGenerator
  {
    /// <summary>
    ///   Ersetzt alle Variablen (vars) im Template (input) und gibt das Resultat als String zurück.
    /// </summary>
    /// <param name="input">Template</param>
    /// <param name="vars">Variablen (die ersetzt werden sollen)</param>
    /// <returns>Ausgabe</returns>
    public static string Generate(string input, Dictionary<string, string> vars)
    {
      return vars == null
        ? input
        : vars.Aggregate(input, (current, x) => current.Replace(x.Key, x.Value));
    }

    /// <summary>
    ///   Liest ein Template aus einer Datei, ersetzt darin alle Variablen (vars) und gibt das Resultat als String zurück.
    /// </summary>
    /// <param name="path">Datei die das Template beinhaltet</param>
    /// <param name="vars">Variablen (die ersetzt werden sollen)</param>
    /// <param name="encoding">Datei-Encoding</param>
    /// <returns>Ausgabe</returns>
    public static string GenerateFromFile(string path, Dictionary<string, string> vars, Encoding encoding = null)
    {
      return Generate(FileIO.ReadText(path, encoding), vars);
    }

    /// <summary>
    ///   Liest ein Template aus einer Datei, ersetzt darin alle Variablen (vars) und speichert das Ergebnis in einer anderen
    ///   Datei ab.
    /// </summary>
    /// <param name="pathFrom">Datei die das Template beinhaltet</param>
    /// <param name="pathTo">Datei in die die Ausgabe geschrieben wird</param>
    /// <param name="vars">Variablen (die ersetzt werden sollen)</param>
    /// <param name="encoding">Datei-Encoding</param>
    public static void GenerateFromFileToFile(string pathFrom,
      string pathTo,
      Dictionary<string, string> vars,
      Encoding encoding = null)
    {
      if (pathFrom == pathTo)
        throw new NotSupportedException(
          $"{nameof(pathFrom)} und {nameof(pathTo)} dürfen nicht auf die selbe Datei verweisen.");
      FileIO.Write(pathTo, GenerateFromFile(pathFrom, vars, encoding), encoding);
    }

    /// <summary>
    ///   Ersetzt alle Variablen (vars) im Template (input) und speichert das Ergebnis in einer Datei ab.
    /// </summary>
    /// <param name="input">Template</param>
    /// <param name="pathTo">Datei in die die Ausgabe geschrieben wird</param>
    /// <param name="vars">Variablen (die ersetzt werden sollen)</param>
    /// <param name="encoding">Datei-Encoding</param>
    public static void GenerateToFile(string input,
      Dictionary<string, string> vars,
      string pathTo,
      Encoding encoding = null)
    {
      FileIO.Write(
        pathTo,
        Generate(input, vars),
        encoding);
    }
  }
}
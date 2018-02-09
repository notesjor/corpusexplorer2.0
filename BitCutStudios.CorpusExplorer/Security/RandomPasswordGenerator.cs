#region

using System;
using System.Linq;
using System.Text;

#endregion

namespace Bcs.Security
{
  // ReSharper disable once UnusedMember.Global
  public static class RandomPasswordGenerator
  {
    /// <summary>
    ///   Erzeugt ein zufälliges Passwort
    /// </summary>
    /// <param name="length">
    ///   Länge des Passworts (Empfehlung: Länger als 15)
    /// </param>
    /// <param name="lowerCases">
    ///   Sollen die folgenden Zeichen im Passwort vorkommen: 1234567890
    /// </param>
    /// <param name="upperCases">
    ///   Sollen die folgenden Zeichen im Passwort vorkommen:
    ///   abcdefghijklmnopqrstuvwxyz
    /// </param>
    /// <param name="numbers">
    ///   Sollen die folgenden Zeichen im Passwort vorkommen:
    ///   ABCDEFGHIJKLMNOPQRSTUVWXYZ
    /// </param>
    /// <param name="specials">
    ///   Sollen die folgenden Zeichen im Passwort vorkommen: +-*/.:,;-_!=?>#
    /// </param>
    /// <param name="include">Zusätzliche Zeichen</param>
    /// <param name="exclude">
    ///   Aus den bestehenden Zeichen die folgenden entfernen
    /// </param>
    /// <returns>Passwort</returns>
    public static string Generate(
      byte length,
      bool lowerCases,
      bool upperCases,
      bool numbers,
      bool specials,
      string include = "",
      string exclude = "")
    {
      if ((length == 0) ||
          !(numbers || lowerCases || upperCases || specials))
        return "";

      var rnd = new Random();
      var set = "";
      var res = new StringBuilder(length);

      if (numbers)
        set += "1234567890";
      if (lowerCases)
        set += "abcdefghijklmnopqrstuvwxyz";
      if (upperCases)
        set += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      if (specials)
        set += "+-*/.:,;-_!=?<>#";

      if (!string.IsNullOrEmpty(include))
        set += include;

      if (!string.IsNullOrEmpty(exclude))
        set = exclude.Aggregate(set, (current, c) => current.Remove(c));

      for (byte i = 1; i <= length; i++)
        res.Append(set[rnd.Next(0, set.Length)]);

      return res.ToString();
    }
  }
}
#region

using System;
using System.Security.Cryptography;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The password hasher.
  /// </summary>
  public static class PasswordHasher
  {
    /// <summary>
    ///   Erzeugt einen Hashwert aus der gegebenen Zeichenkette (Passwort)
    /// </summary>
    /// <param name="password">
    ///   Passwort
    /// </param>
    /// <returns>
    ///   Passwort-Hash
    /// </returns>
    public static string Hash(string password)
    {
      using (var sha1 = SHA1.Create())
      {
        return Convert.ToBase64String(sha1.ComputeHash(Configuration.Encoding.GetBytes(password)));
      }
    }

    /// <summary>
    ///   Erzeugt einen Hashwert aus der gegebenen Zeichenkette (Passwort)
    /// </summary>
    /// <param name="password">
    ///   Passwort
    /// </param>
    /// <param name="salt">
    ///   Salt-Wert
    /// </param>
    /// <returns>
    ///   Passwort-Hash
    /// </returns>
    public static string Hash(string password, string salt)
    {
      return Hash(Hash(salt.ToLower()) + password);
    }

    // ReSharper disable MemberCanBePrivate.Global

    // ReSharper restore MemberCanBePrivate.Global
  }
}
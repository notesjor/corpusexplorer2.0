#region

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Bcs.Security
{
  public static class EasyHash
  {
    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe eines beliebigen
    ///   Hash-Algorithmuses
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <param name="algo">Hash-Algorithmus</param>
    /// <returns>
    ///   Hashwert (Im Fehlerfall <see langword="null" /> siehe error.log)
    /// </returns>
    private static byte[] Compute(byte[] data, HashAlgorithm algo) => algo.ComputeHash(data);

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe eines beliebigen
    ///   Hash-Algorithmuses
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <param name="algo">Hash-Algorithmus</param>
    /// <returns>
    ///   Hashwert (Im Fehlerfall <see langword="null" /> siehe error.log)
    /// </returns>
    private static byte[] Compute(string data, HashAlgorithm algo) => Compute(Encoding.UTF8.GetBytes(data), algo);

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des MD5-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeMd5(byte[] data) => Compute(data, MD5.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des MD5-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeMd5(string data) => Compute(data, MD5.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des MD5-Algorithmuses.
    ///   Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeMd5To64String(byte[] data) => ComputeTo64String(data, MD5.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des MD5-Algorithmuses.
    ///   Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeMd5To64String(string data) => ComputeTo64String(data, MD5.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA1-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha1(byte[] data) => Compute(data, SHA1.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA1-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha1(string data) => Compute(data, SHA1.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA1-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha1To64String(byte[] data) => ComputeTo64String(data, SHA1.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA1-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha1To64String(string data) => ComputeTo64String(data, SHA1.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA256-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha256(byte[] data) => Compute(data, SHA256.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA256-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha256(string data) => Compute(data, SHA256.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA256-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha256To64String(byte[] data) => ComputeTo64String(data, SHA256.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA256-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha256To64String(string data) => ComputeTo64String(data, SHA256.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA512-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha512(byte[] data) => Compute(data, SHA512.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA512-Algorithmuses.
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert
    /// </returns>
    public static byte[] ComputeSha512(string data) => Compute(data, SHA512.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA512-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha512To64String(byte[] data) => ComputeTo64String(data, SHA512.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe des
    ///   SHA512-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <returns>
    ///   Hashwert (Base64String)
    /// </returns>
    public static string ComputeSha512To64String(string data) => ComputeTo64String(data, SHA512.Create());

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe eines beliebigen
    ///   Hash-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <param name="algo">Hash-Algorithmus</param>
    /// <returns>
    ///   Hashwert asl Base64String (Im Fehlerfall <see langword="null" /> siehe
    ///   error.log)
    /// </returns>
    private static string ComputeTo64String(byte[] data, HashAlgorithm algo) =>
      Convert.ToBase64String(Compute(data, algo));

    /// <summary>
    ///   Berechnet den Hashwert eines Datensatzes mithilfe eines beliebigen
    ///   Hash-Algorithmuses. Der Hashwert wird als Base64String ausgegeben
    /// </summary>
    /// <param name="data">Datensatz</param>
    /// <param name="algo">Hash-Algorithmus</param>
    /// <returns>
    ///   Hashwert asl Base64String (Im Fehlerfall <see langword="null" /> siehe
    ///   error.log)
    /// </returns>
    private static string ComputeTo64String(string data, HashAlgorithm algo) =>
      ComputeTo64String(Encoding.UTF8.GetBytes(data), algo);
  }
}
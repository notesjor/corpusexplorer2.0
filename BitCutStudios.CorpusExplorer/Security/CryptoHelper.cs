#region

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Bcs.Security
{
  /// <summary>
  ///   BCS.CryptoX Helper-Class Vereinfacht das Ver/Entschlüsseln mit RSA /
  ///   Rijndael. String2String-Support Base64String
  /// </summary>
  // ReSharper disable once MemberCanBeInternal
  public static class CryptoHelper
  {
    /// <summary>
    ///   String2String Decode with RSA
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input String (Base64)</param>
    /// <returns>
    ///   Output String (Encoding.Default)
    /// </returns>
    public static string DecodeRsa(RSACryptoServiceProvider prov, string data)
    {
      return Encoding.Default.GetString(DecodeRsa(prov, Convert.FromBase64String(data)));
    }

    /// <summary>
    ///   Liest von einem mit einem asymetrisch Schlüssel verschlüsseltem Stream
    ///   und gibt die Klartextdaten als MemoryStream zurück
    /// </summary>
    /// <param name="prov">Asymetrischer-Schlüssel</param>
    /// <param name="stream">Stream</param>
    /// <returns>
    ///   MemoryStream
    /// </returns>
    public static MemoryStream DecodeRsa(RSACryptoServiceProvider prov, Stream stream)
    {
      var buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      stream.Close();
      return new MemoryStream(DecodeRsa(prov, buffer));
    }

    /// <summary>
    ///   Deccode with RSA
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <returns>
    ///   Output Data
    /// </returns>
    internal static byte[] DecodeRsa(RSACryptoServiceProvider prov, byte[] data)
    {
      return prov.Decrypt(data, false);
    }

    /// <summary>
    ///   Liest von einem Stream, verschlüsselt dessen Daten und gibt diese als
    ///   MemoryStream zurück
    /// </summary>
    /// <param name="prov">Asymetrischer-Schlüssel</param>
    /// <param name="stream">Stream</param>
    /// <returns>
    ///   MemoryStream
    /// </returns>
    public static MemoryStream EncodeRsa(RSACryptoServiceProvider prov, Stream stream)
    {
      var buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      stream.Close();
      return new MemoryStream(EncodeRsa(prov, buffer));
    }

    /// <summary>
    ///   String2String Encode with RSA
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input String (Encoding.Default)</param>
    /// <returns>
    ///   Output String (Base64)
    /// </returns>
    public static string EncodeRsa(RSACryptoServiceProvider prov, string data)
    {
      return Convert.ToBase64String(EncodeRsa(prov, Encoding.Default.GetBytes(data)));
    }

    /// <summary>
    ///   Encode with RSA
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <returns>
    ///   Output Data
    /// </returns>
    public static byte[] EncodeRsa(RSACryptoServiceProvider prov, byte[] data)
    {
      return prov.Encrypt(data, false);
    }

    /// <summary>
    ///   Load a RSA-Provider from a XML-File
    /// </summary>
    /// <param name="path">Path of the XML-File</param>
    /// <returns>
    ///   RSA-Provider
    /// </returns>
    public static RSACryptoServiceProvider ReadRsaFromFile(string path)
    {
      var res = new RSACryptoServiceProvider();
      using (var str = new StreamReader(path))
      {
        res.FromXmlString(str.ReadToEnd());
      }

      return res;
    }

    /// <summary>
    ///   Read a RSA-Provider directly from a XML-String
    /// </summary>
    /// <param name="xml">XML-String</param>
    /// <returns>
    ///   RSA-Provider
    /// </returns>
    public static RSACryptoServiceProvider ReadRsaFromXml(string xml)
    {
      var res = new RSACryptoServiceProvider();
      res.FromXmlString(xml);
      return res;
    }

    /// <summary>
    ///   Signiert die Daten
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <returns>
    ///   Hash
    /// </returns>
    public static byte[] SignData(RSACryptoServiceProvider prov, byte[] data)
    {
      return prov.SignData(data, new SHA1CryptoServiceProvider());
    }

    /// <summary>
    ///   Signiert den String
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <returns>
    ///   Hash
    /// </returns>
    public static string SignData(RSACryptoServiceProvider prov, string data)
    {
      return Convert.ToBase64String(SignData(prov, Encoding.UTF8.GetBytes(data)));
    }

    /// <summary>
    ///   De/Encrpyt with Rijndael
    /// </summary>
    /// <param name="trans">RijndaelManagedTransform</param>
    /// <param name="data">Input</param>
    /// <returns>
    ///   Output
    /// </returns>
    public static byte[] UseRijndael(ICryptoTransform trans, byte[] data)
    {
      return trans.TransformFinalBlock(data, 0, data.Length);
    }

    /// <summary>
    ///   Liest von einem Stream, verschlüsselt dessen Daten und gibt diese als
    ///   MemoryStream zurück
    /// </summary>
    /// <param name="trans">Symetrischer-Schlüssel (als Transformation)</param>
    /// <param name="stream">Stream</param>
    /// <returns>
    ///   MemoryStream
    /// </returns>
    public static MemoryStream UseRijndael(ICryptoTransform trans, Stream stream)
    {
      var buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      stream.Close();
      return new MemoryStream(UseRijndael(trans, buffer));
    }

    /// <summary>
    ///   De/Encrpyt with Rijndael
    /// </summary>
    /// <param name="trans">RijndaelManagedTransform</param>
    /// <param name="data">Input</param>
    /// <returns>
    ///   Output
    /// </returns>
    public static string UseRijndael(ICryptoTransform trans, string data)
    {
      return Convert.ToBase64String(UseRijndael(trans, Convert.FromBase64String(data)));
    }

    /// <summary>
    ///   Überprüft ob die Daten mit dem Hash signiert wurde.
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <param name="hash">Hash</param>
    /// <returns>
    ///   Signiert?
    /// </returns>
    public static bool VerifyData(RSACryptoServiceProvider prov, byte[] data, byte[] hash)
    {
      return prov.VerifyData(data, new SHA1CryptoServiceProvider(), hash);
    }

    /// <summary>
    ///   Überprüft ob der String mit dem Hash signiert wurde.
    /// </summary>
    /// <param name="prov">RSA-Provider</param>
    /// <param name="data">Input Data</param>
    /// <param name="hash">Hash</param>
    /// <returns>
    ///   Signiert?
    /// </returns>
    public static bool VerifyData(RSACryptoServiceProvider prov, string data, string hash)
    {
      return VerifyData(prov, Encoding.UTF8.GetBytes(data), Convert.FromBase64String(hash));
    }
  }
}
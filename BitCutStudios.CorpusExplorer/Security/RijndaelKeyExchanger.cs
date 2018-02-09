#region

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

#endregion

namespace Bcs.Security
{
  /// <summary>
  ///   BCS.CryptoX Helper-Class zum Austausch von Rijndael-Schlüsseln
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public static class RijndaelKeyExchanger
  {
    /// <summary>
    ///   Decrypt + Deserialize a XML-String to Rijndael
    /// </summary>
    /// <param name="prov">RSA-Provider to decrypt the XML</param>
    /// <param name="check">RSA-Provider to check CheckSum</param>
    /// <param name="xml">
    ///   XML-String (Serialized with
    ///   BCS.CryptoX.KeyExchanger.EncodeRijndael2Xml())
    /// </param>
    /// <returns>
    ///   Rijndael
    /// </returns>
    public static RijndaelManaged DecodeXml2Rijndael(
      RSACryptoServiceProvider prov,
      RSACryptoServiceProvider check,
      string xml)
    {
      var res = new RijndaelManaged();
      var doc = new XmlDocument();
      doc.LoadXml(xml);

      if (doc.GetElementsByTagName("Key").Count != 1)
        throw new InvalidDataException("The <Key>-Tag was not found");

      if (doc.GetElementsByTagName("IV").Count != 1)
        throw new InvalidDataException("The <IV>-Tag was not found");

      if (doc.GetElementsByTagName("SIGN").Count != 1)
        throw new InvalidDataException("The <SIGN>-Tag was not found");

      var bufferK = Convert.FromBase64String(doc.GetElementsByTagName("Key")[0].InnerText);
      var bufferI = Convert.FromBase64String(doc.GetElementsByTagName("IV")[0].InnerText);
      var bufferC = Convert.FromBase64String(doc.GetElementsByTagName("SIGN")[0].InnerText);

      bufferK = CryptoHelper.DecodeRsa(prov, bufferK);
      bufferI = CryptoHelper.DecodeRsa(prov, bufferI);

      byte[] buffer;
      using (var ms = new MemoryStream())
      {
        ms.Write(bufferK, 0, bufferK.Length);
        ms.Write(bufferI, 0, bufferI.Length);
        ms.Seek(0, SeekOrigin.Begin);
        buffer = new byte[ms.Length];
        ms.Read(buffer, 0, buffer.Length);
      }

      using (var sha = new SHA1Managed())
      {
        buffer = sha.ComputeHash(buffer);
      }

      if (!check.VerifyHash(buffer, CryptoConfig.MapNameToOID("SHA1"), bufferC))
        throw new InvalidDataException("The SHA1-Hash is not valid");

      res.Key = bufferK;
      res.IV = bufferI;

      return res;
      // return KeyExchanger.XML2Rijndael(KeyHelper.DecodeRSA(prov, xml));
    }

    /// <summary>
    ///   Serialize + Crpyt a Rijndael to an XML-String
    /// </summary>
    /// <param name="prov">RSA-Provider to crypt the Rijndael</param>
    /// <param name="sign">RSA-Provider to sign the CheckSum</param>
    /// <param name="key">Rijndael</param>
    /// <returns>
    ///   XML-String
    /// </returns>
    public static string EncodeRijndael2Xml(
      RSACryptoServiceProvider prov,
      RSACryptoServiceProvider sign,
      RijndaelManaged key)
    {
      var ms = new MemoryStream();
      var stb = new StringBuilder();

      stb.Append("<BitCutStudios><Rijndael IsCrypted=\"true\"><Key>");

      var buffer = CryptoHelper.EncodeRsa(prov, key.Key);
      ms.Write(key.Key, 0, key.Key.Length);
      stb.Append(Convert.ToBase64String(buffer));

      stb.Append("</Key><IV>");

      buffer = CryptoHelper.EncodeRsa(prov, key.IV);
      ms.Write(key.IV, 0, key.IV.Length);
      stb.Append(Convert.ToBase64String(buffer));

      stb.Append("</IV></Rijndael><SIGN>");

      ms.Seek(0, SeekOrigin.Begin);
      buffer = new byte[ms.Length];
      ms.Read(buffer, 0, buffer.Length);
      ms.Close();
      using (var sha = new SHA1Managed())
      {
        buffer = sha.ComputeHash(buffer);
      }

      stb.Append(Convert.ToBase64String(sign.SignHash(buffer, CryptoConfig.MapNameToOID("SHA1"))));

      stb.Append("</SIGN></BitCutStudios>");

      return stb.ToString();
      // return KeyHelper.EncodeRSA(prov, KeyExchanger.Rijndael2XML(key));
    }

    /// <summary>
    ///   Convert a symetric Rijndael to XML-String
    /// </summary>
    /// <param name="rijn">Rijndael Key</param>
    /// <returns>
    ///   XML-String
    /// </returns>
    public static string Rijndael2Xml(RijndaelManaged rijn)
    {
      var stb = new StringBuilder();
      stb.Append("<BitCutStudios><Rijndael><Key>");
      stb.Append(Convert.ToBase64String(rijn.Key));
      stb.Append("</Key><IV>");
      stb.Append(Convert.ToBase64String(rijn.IV));
      stb.Append("</IV></Rijndael></BitCutStudios>");
      return stb.ToString();
    }

    /// <summary>
    ///   Convert a XML-String to Rijndael
    /// </summary>
    /// <param name="xml">
    ///   XML-String (Serialized with BCS.CryptoX.KeyExchanger.Rijndael2XML())
    /// </param>
    /// <returns>
    ///   Rijndael2XML
    /// </returns>
    public static RijndaelManaged Xml2Rijndael(string xml)
    {
      var res = new RijndaelManaged();
      var doc = new XmlDocument();
      doc.LoadXml(xml);

      if (doc.GetElementsByTagName("Key").Count != 1)
        throw new InvalidDataException("The <Key>-Tag was not found");

      if (doc.GetElementsByTagName("IV").Count != 1)
        throw new InvalidDataException("The <IV>-Tag was not found");

      res.Key = Convert.FromBase64String(doc.GetElementsByTagName("Key")[0].InnerText);
      res.IV = Convert.FromBase64String(doc.GetElementsByTagName("IV")[0].InnerText);

      return res;
    }
  }
}
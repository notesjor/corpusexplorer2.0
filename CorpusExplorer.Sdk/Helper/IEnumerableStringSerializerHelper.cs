using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class IEnumerableStringSerializerHelper
  {
    public static void Serialize(IEnumerable<string> hashSet, Stream stream)
    {
      // ReSharper disable once RedundantAssignment
      var bufferInt = new byte[sizeof(int)]; // Statischer Buffer für Länge und Index
      foreach (var x in hashSet)
      {
        var buffer = Configuration.Encoding.GetBytes(x); // Konvertiere Token zu Token-byte[]
        bufferInt = BitConverter.GetBytes(buffer.Length); // Ermittle Token-byte[]-Länge
        stream.Write(bufferInt, 0, bufferInt.Length); // Schreibe Token-byte[]-Länge
        stream.Write(buffer, 0, buffer.Length); // Schreibe Token-byte[]
      }

      // SPLIT (durch int.MinValue)
      bufferInt = BitConverter.GetBytes(int.MinValue);
      stream.Write(bufferInt, 0, bufferInt.Length);
    }

    public static void Deserialize(Stream stream, ref List<string> hashSet)
    {
      var bufferInt = new byte[sizeof(int)];
      while (true)
      {
        // Lese Token-byte[]-Länge
        stream.Read(bufferInt, 0, bufferInt.Length);
        var length = BitConverter.ToInt32(bufferInt, 0);
        // Abbruch, wenn length == int.min (SPLIT-Marker) erreicht wurde.
        if (length == int.MinValue)
          break;

        // Lese Token
        var buffer = new byte[length];
        stream.Read(buffer, 0, buffer.Length);
        var token = Configuration.Encoding.GetString(buffer);

        // Fügen Token/Index bzw. Index/Token den Wörterbüchern hinzu.
        hashSet.Add(token);
      }
    }
  }
}

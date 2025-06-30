using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DictionarySerializerHelper
  {
    public static void Serialize(Dictionary<string, int> dict, Stream stream)
    {
      // ReSharper disable once RedundantAssignment
      var bufferInt = new byte[sizeof(int)]; // Statischer Buffer für Länge und Index
      foreach (var x in dict)
      {
        var buffer = Configuration.Encoding.GetBytes(x.Key); // Konvertiere Token zu Token-byte[]
        bufferInt = BitConverter.GetBytes(buffer.Length); // Ermittle Token-byte[]-Länge
        stream.Write(bufferInt, 0, bufferInt.Length); // Schreibe Token-byte[]-Länge
        stream.Write(buffer, 0, buffer.Length); // Schreibe Token-byte[]
        bufferInt = BitConverter.GetBytes(x.Value); // Index zu Index-byte[]
        stream.Write(bufferInt, 0, bufferInt.Length); // Schreibe Index-byte[]
      }

      // SPLIT (durch int.MinValue)
      bufferInt = BitConverter.GetBytes(int.MinValue);
      stream.Write(bufferInt, 0, bufferInt.Length);
    }

    public static void Deserialize(Stream stream, ref Dictionary<string, int> dictionary, ref Dictionary<int, string> reverse)
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

        // Lese Index
        stream.Read(bufferInt, 0, bufferInt.Length);
        var index = BitConverter.ToInt32(bufferInt, 0);
        
        // Fügen Token/Index bzw. Index/Token den Wörterbüchern hinzu.
        // Fix für fehlerhafte Token-Kodierung aus externen Korpora wie KorAP
        if (!dictionary.ContainsKey(token))                            
          dictionary.Add(token, index);
        reverse.Add(index, token);
      }
    }

    public static void Deserialize(Stream stream, ref Dictionary<string, int> dictionary)
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

        // Lese Index
        stream.Read(bufferInt, 0, bufferInt.Length);
        var index = BitConverter.ToInt32(bufferInt, 0);

        // Fügen Token/Index bzw. Index/Token den Wörterbüchern hinzu.
        dictionary.Add(token, index);
      }
    }

    public static void Deserialize(Stream stream, ref Dictionary<int, string> reverse)
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

        // Lese Index
        stream.Read(bufferInt, 0, bufferInt.Length);
        var index = BitConverter.ToInt32(bufferInt, 0);

        // Fügen Token/Index bzw. Index/Token den Wörterbüchern hinzu.
        reverse.Add(index, token);
      }
    }
  }
}

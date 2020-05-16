#region

using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndex.Indices
{
  public static class Cec6FileIndex
  {
    public static Dictionary<Guid, long> Create(CorpusAdapterWriteDirect corpus, string pathToCec6,
                                                string layerDisplayname)
    {
      var res = corpus.WriteFuriousIndex(layerDisplayname, pathToCec6 + $"_{layerDisplayname}.fif");
      using (var fs = new FileStream(pathToCec6 + $"_{layerDisplayname}.fi", FileMode.Create, FileAccess.Write))
      {
        foreach (var x in res)
        {
          var buffer = x.Key.ToByteArray(); // Konvertiere Guid zu guid-byte[]
          var bufferLong = BitConverter.GetBytes(x.Value); // Position zu pos-byte[]
          fs.Write(buffer, 0, buffer.Length); // Schreibe guid-byte[]
          fs.Write(bufferLong, 0, bufferLong.Length); // Schreibe pos-byte[]
        }

        // Kein SPLIT
      }

      return res;
    }

    public static Dictionary<Guid, long> Read(string pathToCec6, string layerDisplayname)
    {
      var res = new Dictionary<Guid, long>();
      var bufferLong = new byte[sizeof(long)];
      var bufferGuid = new byte[16];

      using (var stream = new FileStream(pathToCec6 + $"_{layerDisplayname}.fi", FileMode.Open, FileAccess.Read,
                                         FileShare.Read))
      {
        while (stream.Read(bufferGuid, 0, bufferGuid.Length) > 0)
        {
          var guid = new Guid(bufferGuid);
          stream.Read(bufferLong, 0, bufferLong.Length);
          var pos = BitConverter.ToInt64(bufferLong, 0);
          res.Add(guid, pos);
        }
      }

      return res;
    }
  }
}
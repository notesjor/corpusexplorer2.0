using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Db.Elastic.Helper
{
  public class EsSerializer
  {
    public static int[][] DeserializeDocument(string buffer64)
    {
      var buffer = Convert.FromBase64String(buffer64);

      var header = new int[buffer.Length / 4];

      Buffer.BlockCopy(buffer, 0, header, 0, buffer.Length);
      var content = header;

      var res = new List<int[]>();
      for (var i = 1; i < content.Length;)
      {
        var length = content[i];
        var dst = new int[length];
        Buffer.BlockCopy(content, (i + 1) * 4, dst, 0, length * 4);
        res.Add(dst);
        i += length + 1;
      }

      return res.ToArray();
    }

    public static string SerializeDocument(int[][] document)
    {
      try
      {
        var list = new List<int> {document.Length};

        foreach (var x in document)
        {
          if (x == null)
          {
            list[0] = list[0] - 1;
            continue;
          }

          list.Add(x.Length);
          list.AddRange(x);
        }

        var arr = list.ToArray();
        var buffer = new byte[arr.Length * 4];
        Buffer.BlockCopy(arr, 0, buffer, 0, buffer.Length);
        return Convert.ToBase64String(buffer);
      }
      catch
      {
        return null;
      }
    }
  }
}
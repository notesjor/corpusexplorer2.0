using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FileBased.QueryToSentence
{
  public static class QueryToSentenceIndexReader
  {
    public static Dictionary<Guid, HashSet<int>> Search(string pathToCec6, string word)
    {
      var dic = new Dictionary<string, int>();
      using (var fs = new FileStream(pathToCec6 + ".dic", FileMode.Open, FileAccess.Read))
        DictionarySerializerHelper.Deserialize(fs, ref dic);

      return !dic.ContainsKey(word) ? null : Search(pathToCec6, dic[word]);
    }

    public static Dictionary<Guid, HashSet<int>> Search(string pathToCec6, int index)
    {
      using (var fs = new FileStream(pathToCec6 + ".idx", FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        var fPosition = FindPosition(index, fs);

        if (fPosition == -1)
          return null;

        fs.Seek(fPosition, SeekOrigin.Begin);

        return ReadIndex(fs);
      }
    }

    private static Dictionary<Guid, HashSet<int>> ReadIndex(Stream stream)
    {
      var res = new Dictionary<Guid, HashSet<int>>();
      var bufferGuid = new byte[16];
      var bufferInt = new byte[sizeof(int)];
      while (true)
      {
        stream.Read(bufferGuid, 0, bufferGuid.Length);
        var guid = new Guid(bufferGuid);
        if (guid == Guid.Empty)
          break;

        stream.Read(bufferInt, 0, bufferInt.Length);
        var size = BitConverter.ToInt32(bufferInt, 0);
        var hash = new HashSet<int>();
        var buffer = new byte[size * sizeof(int)];
        stream.Read(buffer, 0, buffer.Length);

        for (var i = 0; i < buffer.Length; i += sizeof(int))
          hash.Add(BitConverter.ToInt32(buffer, i));

        res.Add(guid, hash);
      }
      return res;
    }

    private static long FindPosition(int index, Stream stream)
    {
      var bufferLong = new byte[sizeof(long)];
      stream.Seek(-1 * bufferLong.Length, SeekOrigin.End);
      stream.Read(bufferLong, 0, bufferLong.Length);

      const int jmp = sizeof(int) + sizeof(long);
      var lpo = BitConverter.ToInt64(bufferLong, 0);
      long fPosition;

      var now = index;
      var pos = lpo + (jmp * now);
      while (true)
      {
        var intBuffer = new byte[sizeof(int)];
        if (pos < 0 || pos > stream.Length)
          return -1;

        stream.Seek(pos, SeekOrigin.Begin);
        stream.Read(intBuffer, 0, intBuffer.Length);
        var fIndex = BitConverter.ToInt32(intBuffer, 0);

        if (fIndex == index)
        {
          stream.Read(bufferLong, 0, bufferLong.Length);
          fPosition = BitConverter.ToInt64(bufferLong, 0);
          break;
        }

        if (fIndex < index)
        {
          var val = (index - fIndex) / 2;
          if (val < 1)
            val = 1;
          now += val;
        }
        else
        {
          var val = (index - fIndex) / 2;
          if (val > -1)
            val = -1;
          now += val;
        }

        pos = lpo + (jmp * now);
      }

      return fPosition;
    }
  }
}
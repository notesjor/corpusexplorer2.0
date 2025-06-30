using CorpusExplorer.Sdk.Ecosystem.Model;
using System;
using System.IO;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DocumentSerializerHelper
  {
    private static readonly int _isize = sizeof(int);
    private static readonly byte[] _split = BitConverter.GetBytes(int.MinValue);

    public static int[][] Deserialize(byte[] array)
    {
      return Deserialize(new MemoryStream(array));
    }

    public static int[][] Deserialize(Stream ms)
    {
      var bufferLength = new byte[_isize];
      ms.Read(bufferLength, 0, bufferLength.Length);
      var length = BitConverter.ToInt32(bufferLength, 0);
      if(Configuration.ProtectMemoryOverflow && length > 1000000) 
        return null;

      var idx = 0;
      var current = new int[length][];

      ms.Read(bufferLength, 0, bufferLength.Length);
      length = BitConverter.ToInt32(bufferLength, 0);
      if (length == 0)
      {
        ms.Read(bufferLength, 0, bufferLength.Length);
        length = BitConverter.ToInt32(bufferLength, 0);
        if (length == int.MinValue)
          return new int[0][];
        throw new IndexOutOfRangeException();
      }

      while (length > 0)
      {
        var buffer = new byte[length];
        ms.Read(buffer, 0, buffer.Length);

        var value = new int[buffer.Length / _isize];
        Buffer.BlockCopy(buffer, 0, value, 0, buffer.Length);
        current[idx++] = value;

        ms.Read(bufferLength, 0, bufferLength.Length);
        length = BitConverter.ToInt32(bufferLength, 0);
      }

      return current;
    }

    public static int[][] Deserialize(string stream)
    {
      return Deserialize(Convert.FromBase64String(stream));
    }

    public static int[][] DeserializeDocumentFromStreamPosition(Stream ms, long position)
    {
      ms.Seek(position, SeekOrigin.Begin);
      return Deserialize(ms);
    }

    public static long DeserializeDocumentStreamPosition(Stream ms)
    {
      var start = ms.Position;

      var bufferLength = new byte[_isize];
      ms.Read(bufferLength, 0, bufferLength.Length);
      var length = BitConverter.ToInt32(bufferLength, 0);

      ms.Read(bufferLength, 0, bufferLength.Length);
      length = BitConverter.ToInt32(bufferLength, 0);
      if (length == 0)
      {
        ms.Read(bufferLength, 0, bufferLength.Length);
        length = BitConverter.ToInt32(bufferLength, 0);
        if (length == int.MinValue)
          return start;
        throw new IndexOutOfRangeException();
      }

      while (length > 0)
      {
        var buffer = new byte[length];
        ms.Read(buffer, 0, buffer.Length);

        ms.Read(bufferLength, 0, bufferLength.Length);
        length = BitConverter.ToInt32(bufferLength, 0);
      }

      return start;
    }

    public static byte[] Serialize(int[][] array)
    {
      using (var ms = new MemoryStream())
      {
        Serialize(ms, array);
        return ms.ToArray();
      }
    }

    public static void Serialize(Stream stream, int[][] array)
    {
      var buffer = BitConverter.GetBytes(array.Length);
      stream.Write(buffer, 0, buffer.Length);

      foreach (var s in array)
        if (s == null || s.Length == 0)
        {
          buffer = BitConverter.GetBytes(0);
          stream.Write(buffer, 0, buffer.Length);
        }
        else
        {
          var buffer2 = new byte[s.Length * _isize];
          Buffer.BlockCopy(s, 0, buffer2, 0, buffer2.Length);
          buffer = BitConverter.GetBytes(buffer2.Length);
          stream.Write(buffer, 0, buffer.Length);
          stream.Write(buffer2, 0, buffer2.Length);
        }

      stream.Write(_split, 0, _isize);
    }

    public static string SerializeToBase64String(int[][] array)
    {
      return Convert.ToBase64String(Serialize(array));
    }
  }
}
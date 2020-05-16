using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bcs.Security
{
  public class BloomFilter
  {
    private object _filterLock = new object();
    private readonly BitArray _filter;
    private readonly Func<string, byte[]> _hash;
    private readonly HashAlgorithm _algo;

    public BloomFilter(BloomFilterSize size)
    {
      _filter = new BitArray((int)size, false);
      switch (size)
      {
        case BloomFilterSize.SHA512:
          _algo = SHA512.Create();
          _hash = (t) =>_algo.ComputeHash(Encoding.UTF8.GetBytes(t));
          break;
        case BloomFilterSize.SHA256:
          _algo = SHA256.Create();
          _hash = (t) =>_algo.ComputeHash(Encoding.UTF8.GetBytes(t));
          break;
        case BloomFilterSize.SHA1:
          _algo = SHA1.Create();
          _hash = (t) =>_algo.ComputeHash(Encoding.UTF8.GetBytes(t));
          break;
        case BloomFilterSize.MD5:
          _algo = MD5.Create();
          _hash = (t) => _algo.ComputeHash(Encoding.UTF8.GetBytes(t));
          break;
        case BloomFilterSize.FNV:
          _algo = null;
          _hash = (t) => BitConverter.GetBytes(FNV.CalculateHash(Encoding.UTF8.GetBytes(t)));
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(size), size, null);
      }
    }

    public double FillRatio => _filter.Cast<bool>().Count(bit => bit) / (double)_filter.Length;

    public bool ContainsAdd(string text)
    {
      return ContainsAdd(_hash(text));
    }

    private bool ContainsAdd(byte[] hash)
    {
      var hsh = new BitArray(hash);
      var ist = new List<int>();
      for (var i = 0; i < hsh.Count; i++)
        if (hsh[i])
          ist.Add(i);

      var res = true;
      lock (_filterLock)
      {
        if (ist.Any(x => !_filter[x]))
          res = false;
        foreach (var x in ist)
          _filter[x] = true;
      }

      return res;
    }

    public void Add(string text)
    {
      Add(_hash(text));
    }

    private void Add(byte[] hash)
    {
      var hsh = new BitArray(hash);
      var ist = new List<int>();
      for (var i = 0; i < hsh.Count; i++)
        if (hsh[i])
          ist.Add(i);

      lock (_filterLock)
        foreach (var x in ist)
          _filter[x] = true;
    }

    public bool Contains(string text)
    {
      return Contains(_hash(text));
    }

    private bool Contains(byte[] hash)
    {
      var hsh = new BitArray(hash);
      var ist = new List<int>();
      for (var i = 0; i < hsh.Count; i++)
        if (hsh[i])
          ist.Add(i);

      lock (_filterLock)
        if (ist.Any(x => !_filter[x]))
          return false;

      return true;
    }

    public enum BloomFilterSize : int
    {
      SHA512 = 512,
      SHA256 = 256,
      SHA1 = 160,
      MD5 = 128,
      FNV = 64
    }
  }
}

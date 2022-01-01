#region

using System.Linq;

#endregion

namespace Bcs.Security
{
  public static class FNV
  {
    public static ulong CalculateHash(byte[] buffer)
    {
      ulong MagicPrime = 0x00000100000001b3;
      return buffer.Aggregate(0xcbf29ce484222325, (current, t) => (current ^ t) * MagicPrime);
    }
  }
}
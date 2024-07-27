using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Model.CorpusExplorer
{
  public struct CeRange
  {
    public int From { get; private set; }
    public int To { get; private set; }

    public CeRange(int position)
    {
      From = position;
      To = position + 1;
    }

    public CeRange(int from, int to)
    {
      From = from;
      To = to;
    }

    public int Length => To - From;

    public override int GetHashCode()
    {
      return HashCode.Combine(From, To);
    }
  }
}

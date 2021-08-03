using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.ReMapper.Model
{
  public struct ReMapperEntry
  {
    public int SentenceIndex { get; set; }
    public int TokenIndex { get; set; }
    public int TextCharFrom { get; set; }
    public int TextCharTo { get; set; }
  }
}

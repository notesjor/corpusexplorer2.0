using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.Filter.Interface
{
  public interface IFilterQueryWithLayerValues
  {
    IEnumerable<string> LayerQueries { get; set; }
  }
}

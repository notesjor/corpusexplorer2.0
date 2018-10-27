using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Interface
{
  public interface ISimpleAuthenticationForm
  {
    Dictionary<string, string> RequestData(Dictionary<string, string> settings);
  }
}

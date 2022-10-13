using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Terminal.Universal.Message.Response.Size;

namespace CorpusExplorer.Terminal.Universal.Message.Response.Snapshot
{
  public class ResponseSnapshot
  {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public ResponseSnapshot[] Children { get; set; }
    public ResponseSize Size { get; set; }
  }
}

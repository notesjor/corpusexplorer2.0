using System;
using System.Collections.Generic;
using CorpusExplorer.Terminal.Universal.Message.Response.Size;

namespace CorpusExplorer.Terminal.Universal.Message.Response.Snapshot
{
  public class ResponseSnapshot
  {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public ResponseSnapshot[] Children { get; set; }
    public ResponseSize Size { get; set; }
    public HashSet<string> LayerNames { get; set; }
    public bool IsActive { get; set; }
  }
}

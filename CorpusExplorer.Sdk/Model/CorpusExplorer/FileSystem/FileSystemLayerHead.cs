using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Model.CorpusExplorer.FileSystem
{
  [Serializable]
  public class FileSystemLayerHead
  {
    public CeDictionary Dictionary { get; set; }
    public string Displayname { get; set; }
    public HashSet<Guid> DocumentGuids { get; set; } = new HashSet<Guid>();
    public Guid Guid { get; set; }
  }
}
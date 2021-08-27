#region usings

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Data.Model
{
  public class GenerateGroupsFromMetadataEntry
  {
    public GenerateGroupsFromMetadataEntry(object value)
    {
      Value = value;
      Documents = new List<string>();
    }

    public List<string> Documents { get; set; }

    public object Value { get; set; }
  }
}
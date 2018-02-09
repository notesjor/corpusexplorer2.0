using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class SortDocuments : AbstractBlock
  {
    public Guid[] DocumentGuids { get; set; }
    public string MetadataKey { get; set; } = "Datum";

    public override void Calculate()
    {
      var meta = Selection.DocumentMetadata;
      var list = (from doc in meta
                  where doc.Value.ContainsKey(MetadataKey)
                  let value = doc.Value[MetadataKey] as IComparable
                  where value != null
                  select new KeyValuePair<IComparable, Guid>(value, doc.Key)).ToList();
      list.Sort((x, y) => x.Key.CompareTo(y.Key));
      DocumentGuids = list.Select(x => x.Value).ToArray();
    }
  }
}
#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class MetaAddGuidAutoFix : AbstractAutoFix
  {
    public override void Apply(ref List<Dictionary<string, object>> docs)
    {
      // ReSharper disable once ForCanBeConvertedToForeach
      for (var dKey = 0; dKey < docs.Count; dKey++)
        if (!docs[dKey].ContainsKey("GUID"))
          docs[dKey].Add("GUID", Guid.NewGuid());
    }
  }
}
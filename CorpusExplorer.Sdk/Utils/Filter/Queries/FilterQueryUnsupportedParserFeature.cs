using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  public class FilterQueryUnsupportedParserFeature : AbstractFilterQueryMeta
  {
    public override object Clone()
    {
      return new FilterQueryUnsupportedParserFeature
      {
        Guid = Guid.NewGuid(),
        Inverse = Inverse,
        MetaLabel = MetaLabel,
        MetaValues = MetaValues,
        OrFilterQueries = (from x in OrFilterQueries select (AbstractFilterQuery)x.Clone())
      };
    }

    public override string Verbal => "Funktion wird vom Query-Parser nicht unterstützt.";
    protected override void TransformMetaValues(IEnumerable<object> metaValues)
    {
    }

    protected override bool ValidateCallCall(string value)
    {
      return false;
    }
  }
}

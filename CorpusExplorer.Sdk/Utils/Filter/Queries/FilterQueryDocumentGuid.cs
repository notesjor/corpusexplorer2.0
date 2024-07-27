using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  public class FilterQueryDocumentGuid : AbstractFilterQuery
  {
    public override object Clone()
      => new FilterQueryDocumentGuid { DocumentGuids = new HashSet<Guid>(DocumentGuids) };

    public override string Verbal
      => $"Der GUID des Dokuments muss auf der Liste DocumentGuid aufgeführt sein (Listen-Umfang: {DocumentGuids.Count} GUIDs)";

    public HashSet<Guid> DocumentGuids { get; set; } = new HashSet<Guid>();

    protected override CeRange? GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (DocumentGuids.Contains(documentGuid))
        return new CeRange(0, corpus.GetDocumentSentencesLength(documentGuid, sentence));
      return null;
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
      => DocumentGuids.Contains(documentGuid) ? RangeHelper.Range(0, corpus.GetDocument(documentGuid, "Wort").Length) : null;

    public override IEnumerable<CeRange> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
      => DocumentGuids.Contains(documentGuid) ? new[] { new CeRange(0, corpus.GetDocument(documentGuid, "Wort")[sentence].Length) } : null;

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
      => DocumentGuids.Contains(documentGuid);
  }
}

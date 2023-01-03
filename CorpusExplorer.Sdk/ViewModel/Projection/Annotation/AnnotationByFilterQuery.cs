using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.ViewModel.Projection.Annotation.Abstract;

namespace CorpusExplorer.Sdk.ViewModel.Projection.Annotation
{
  public class AnnotationByFilterQuery : AbstractAnnotation
  {
    private AnnotationByFilterQuery() { }

    public AnnotationByFilterQuery(IEnumerable<AbstractFilterQuery> queries, Selection selection)
    {
      Queries = queries;
      Refresh(selection);
    }

    public IEnumerable<AbstractFilterQuery> Queries { get; set; }

    public void Refresh(Selection selection)
    {
      Matches = (from c in QuickQuery.AndSearchOnWordLevel(selection, Queries) from d in c.Value from s in d.Value select new Tuple<Guid, int, int, int>(d.Key, s.Key, s.Value.Min(), s.Value.Max())).ToList();
    }

    public List<Tuple<Guid, int, int, int>> Matches { get; set; }

    public AnnotationByUser Convert(int matchId)
      => new AnnotationByUser(Matches[matchId].Item1, Matches[matchId].Item2, Matches[matchId].Item3,
                              Matches[matchId].Item4)
      {
        Priority = Priority + 1, 
        Displayname = Displayname, 
        Value = Value
      };

    public override bool IsMatch(Guid documentGuid, int sentence, int @from, int to) => throw new NotImplementedException();
  }
}
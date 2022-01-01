using System;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.ViewModel.Projection.Annotation.Abstract
{
  public abstract class AbstractAnnotation : CeObject
  {
    public int Priority { get; set; } = -1;
    public string Value { get; set; }

    public abstract bool IsMatch(Guid documentGuid, int sentence, int from, int to);
  }
}

using System;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.ViewModel.Projection.Annotation.Abstract;

namespace CorpusExplorer.Sdk.ViewModel.Projection.Annotation
{
  public class AnnotationByUser : AbstractAnnotation
  {
    private AnnotationByUser(){}

    public AnnotationByUser(Guid documentGuid, int senetenceId, int from, int to)
    {
      DocumentGuid = documentGuid;
      SenetenceId = senetenceId;
      From = from;
      To = to;
    }

    public Guid DocumentGuid { get; }
    public int SenetenceId { get; }
    public int From { get; }
    public int To { get; }

    public override bool IsMatch(Guid documentGuid, int sentenceId, int from, int to) 
      => documentGuid == DocumentGuid && (sentenceId == SenetenceId && (from <= From && to >= To));
  }
}

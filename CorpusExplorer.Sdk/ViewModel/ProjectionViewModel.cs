using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ProjectionViewModel :AbstractViewModel
  {
    private Guid selectedDocument;
    private int from;
    private int to;

    protected override void ExecuteAnalyse()
    {
      Snippet = Selection.GetReadableMultilayerDocument(SelectedDocument, From, To);
    }

    public Dictionary<string, IEnumerable<IEnumerable<string>>> Snippet { get; set; }

    public IEnumerable<Guid> DocumentGuids => Selection.DocumentGuids;

    public Guid SelectedDocument
    {
      get => selectedDocument;
      set
      {
        selectedDocument = value;
        ExecuteAnalyse();
      }
    }

    public int From
    {
      get => from;
      set { 
        from = value;
        ExecuteAnalyse();
      }
    }

    public int To
    {
      get => to;
      set
      {
        to = value;
        ExecuteAnalyse();
      }
    }

    protected override bool Validate() => true;
  }
}

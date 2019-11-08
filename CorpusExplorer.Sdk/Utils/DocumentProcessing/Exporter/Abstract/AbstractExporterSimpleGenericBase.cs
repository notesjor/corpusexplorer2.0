using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract
{
  public abstract class AbstractExporterSimpleGenericBase<TCB, TCA> : AbstractExporter
    where TCB : AbstractCorpusBuilder, new()
    where TCA : AbstractCorpusAdapter
  {
    public override void Export(IHydra hydra, string path)
    {
      PreAction();

      if (hydra is Project project)
        project.ToCorpus(new TCB()).Save(path, UseCompression);
      if (hydra is Selection selection)
        selection.ToCorpus(new TCB()).Save(path, UseCompression);

      if (!(hydra is AbstractCorpusAdapter))
        return;

      if (hydra is TCA tca)
      {
        tca.Save(path, UseCompression);
      }
      else
      {
        var merger = new CorpusMerger {CorpusBuilder = new TCB()};
        merger.Input((AbstractCorpusAdapter) hydra);
        merger.Execute();
        merger.Output.FirstOrDefault()?.Save(path, UseCompression);
      }
    }

    protected virtual void PreAction()
    {
    }

    public bool UseCompression { get; set; } = false;
  }
}
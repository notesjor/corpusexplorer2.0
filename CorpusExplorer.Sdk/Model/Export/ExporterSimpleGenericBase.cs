using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

namespace CorpusExplorer.Sdk.Model.Export
{
  public abstract class ExporterSimpleGenericBase<TCB, TCA> : AbstractExporter
    where TCB : AbstractCorpusBuilder, new()
    where TCA : AbstractCorpusAdapter
  {
    public override void Export(IHydra hydra, string path)
    {
      PreAction();

      if (hydra is Project)
        ((Project)hydra).ToCorpus(new TCB()).Save(path, false);
      if (hydra is Selection)
        ((Selection)hydra).ToCorpus(new TCB()).Save(path, false);

      if (!(hydra is AbstractCorpusAdapter))
        return;

      if (hydra is TCA)
      {
        ((TCA)hydra).Save(path, false);
      }
      else
      {
        var merger = new CorpusMerger { CorpusBuilder = new TCB() };
        merger.Input((AbstractCorpusAdapter)hydra);
        merger.Execute();
        merger.Output.FirstOrDefault()?.Save(path, false);
      }
    }

    protected virtual void PreAction()
    {      
    }
  }
}

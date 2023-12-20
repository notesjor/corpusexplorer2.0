#region

using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using System;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract
{
  public abstract class AbstractExporter
  {
    public void Export(AbstractCorpusAdapter corpus, string path)
    {
      Export(corpus.ToSelection(), path);
    }

    public void Export(Selection selection, string path)
    {
      if (!selection.AllowExport)
        throw new Exception("Export not allowed");

      Export((IHydra)selection, path);
    }

    public void Export(Project project, string path)
    {
      Export(project.CurrentSelection, path);
    }

    public abstract void Export(IHydra hydra, string path);
  }
}
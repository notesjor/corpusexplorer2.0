﻿#region

using CorpusExplorer.Sdk.Diagnostic;
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
      try
      {
        Export(corpus.ToSelection(), path);
      }
      catch (Exception e)
      {
        InMemoryErrorConsole.Log(e);
      }
    }

    public void Export(Selection selection, string path)
    {
      if (!selection.AllowExport)
        throw new Exception("Export not allowed");

      try
      {
        Export((IHydra)selection, path);
      }
      catch (Exception e)
      {
        InMemoryErrorConsole.Log(e);
      }
    }

    public void Export(Project project, string path)
    {
      try
      {
        Export(project.CurrentSelection, path);
      }
      catch (Exception e)
      {
        InMemoryErrorConsole.Log(e);
      }
    }

    public abstract void Export(IHydra hydra, string path);
  }
}
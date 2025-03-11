using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Model.Extension
{
  public static class HydraConversionExtension
  {
    public static AbstractCorpusAdapter ToCorpus(this IHydra hydra, AbstractCorpusBuilder builder = null)
    {
      return hydra is AbstractCorpusAdapter
               ? ToCorpus((AbstractCorpusAdapter)hydra, builder)
               : hydra is Project
                 ? ToCorpus((Project)hydra, builder)
                 : hydra is Selection
                   ? ToCorpus((Selection)hydra, builder)
                   : null;
    }

    public static AbstractCorpusAdapter ToCorpus(this AbstractCorpusAdapter corpus,
                                                 AbstractCorpusBuilder builder = null)
    {
      if (builder == null)
        builder = new CorpusBuilderWriteDirect();

      var merger = new CorpusMerger { CorpusBuilder = builder };
      merger.Input(corpus);
      merger.Execute();

      return merger.Output.Single();
    }

    public static AbstractCorpusAdapter ToCorpus(this Project project, AbstractCorpusBuilder builder = null)
    {
      return project.SelectAll.ToCorpus(builder);
    }

    public static AbstractCorpusAdapter ToCorpus(this Selection selection, AbstractCorpusBuilder builder = null)
    {
      var nlayers = new Dictionary<string, LayerValueState>();
      var documents = new HashSet<Guid>();

      if (selection.CountCorpora == 1)
        ToCorpus_SingleCorporaStrategy(selection, ref nlayers, ref documents);
      else
        ToCorpus_MultiCorporaStrategy(selection, ref nlayers, ref documents);

      if (builder == null)
        builder = new CorpusBuilderWriteDirect();

      return builder.Create(
                            nlayers.Select(x => x.Value),
                            documents.ToDictionary(document => document, selection.GetDocumentMetadata),
                            selection.Metadata,
                            null).FirstOrDefault();
    }

    private static void ToCorpus_SingleCorporaStrategy(Selection selection, ref Dictionary<string, LayerValueState> nlayers, ref HashSet<Guid> documents)
    {
      foreach (var layer in selection.Layers)
      {
        var nlayer = new LayerValueState(layer.Displayname, nlayers.Count);

        foreach (var dsel in selection.DocumentGuids)
          if (layer.ContainsDocument(dsel))
          {
            documents.Add(dsel);
            nlayer.AddCompleteDocument(dsel, layer.GetReadableDocumentByGuid(dsel));
          }

        nlayers.Add(layer.Displayname, nlayer);
      }
    }

    private static void ToCorpus_MultiCorporaStrategy(Selection selection, ref Dictionary<string, LayerValueState> nlayers, ref HashSet<Guid> documents)
    {
      foreach (var layer in selection.Layers)
      {
        if (!nlayers.ContainsKey(layer.Displayname))
          nlayers.Add(layer.Displayname, new LayerValueState(layer.Displayname, nlayers.Count));

        foreach (var dsel in selection.DocumentGuids)
          if (layer.ContainsDocument(dsel))
          {
            documents.Add(dsel);
            nlayers[layer.Displayname].AddCompleteDocument(dsel, layer.GetReadableDocumentByGuid(dsel));
          }
      }
    }

    public static Project ToProject(this IHydra hydra)
    {
      return hydra is AbstractCorpusAdapter
               ? ToProject((AbstractCorpusAdapter)hydra)
               : hydra is Project
                 ? ToProject((Project)hydra)
                 : hydra is Selection
                   ? ToProject((Selection)hydra)
                   : null;
    }

    public static Project ToProject(this Project project)
    {
      return project;
    }

    public static Project ToProject(this AbstractCorpusAdapter corpus)
    {
      var project = Project.Create();
      project.Add(corpus);
      return project;
    }

    public static Project ToProject(this Selection selection)
    {
      return selection.ToCorpus().ToProject();
    }

    public static Selection ToSelection(this IHydra hydra)
    {
      return hydra is AbstractCorpusAdapter
               ? ToSelection((AbstractCorpusAdapter)hydra)
               : hydra is Project
                 ? ToSelection((Project)hydra)
                 : hydra is Selection
                   ? ToSelection((Selection)hydra)
                   : null;
    }

    public static Selection ToSelection(this Selection selection)
    {
      return selection;
    }

    public static Selection ToSelection(this Project project)
    {
      return project.SelectAll;
    }

    public static Selection ToSelection(this AbstractCorpusAdapter corpus)
    {
      return Selection.Create(corpus.ToProject(),
                              new Dictionary<Guid, HashSet<Guid>>
                              {
                                {
                                  corpus.CorpusGuid,
                                  new HashSet<Guid>(corpus.DocumentGuids)
                                }
                              },
                              corpus.CorpusDisplayname,
                              null, true);
    }

    public static Selection ToSelection(this AbstractCorpusAdapter corpus, IEnumerable<Guid> documentGuids)
    {
      return Selection.Create(corpus.ToProject(),
        new Dictionary<Guid, HashSet<Guid>>
        {
          {
            corpus.CorpusGuid,
            new HashSet<Guid>(documentGuids)
          }
        },
        corpus.CorpusDisplayname,
        null, true);
    }

    public static Selection ToSelection(this IEnumerable<AbstractCorpusAdapter> corpora)
    {
      var res = Project.Create();
      foreach (var corpus in corpora)
        res.Add(corpus);
      return res.SelectAll;
    }
  }
}
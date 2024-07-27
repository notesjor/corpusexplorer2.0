#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.HdfFive.Builder;
using CorpusExplorer.Sdk.Extern.HdfFive.Exporter;
using CorpusExplorer.Sdk.Extern.HdfFive.Importer;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.HdfFive
{
  // ReSharper disable once UnusedMember.Global
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends
      => new Dictionary<string, AbstractCorpusBuilder>
      {
        { "HDF5", new CorpusBuilderHdf5() }
      };

    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters
      => new Dictionary<string, AbstractExporter>
      {
        { "HDF5 (*.hdf5)|*.hdf5", new ExporterHdf5() }
      };
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter
      => new Dictionary<string, AbstractImporter>
      {
        { "HDF5 (*.hdf5)|*.hdf5", new ImporterHdf5() }
      };
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override IEnumerable<IAction> AddonConsoleActions => null;
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override string Guid => "CorpusExplorer.Sdk.Extern.HdfFive";
  }
}
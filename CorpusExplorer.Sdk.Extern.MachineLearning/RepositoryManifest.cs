#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.MachineLearning.Action;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.MachineLearning
{
  // ReSharper disable once UnusedMember.Global
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter => null;
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override IEnumerable<IAction> AddonConsoleActions => new IAction[]
    {
      new LdaAction()
    };
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override string Guid => "CorpusExplorer.Sdk.Extern.MachineLearning";
  }
}
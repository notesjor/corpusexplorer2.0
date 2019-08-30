using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Tagger;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus
{
  public class AddonRepository : AbstractAddonRepository
  {
    public override string Guid => "CorpusExplorer.Sdk.Extern.OpenThesaurus";

    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger
      => new AbstractAdditionalTagger[]
      {
        new OpenThesaurusTagger()
      };

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;

    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter => null;

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;

    public override IEnumerable<AbstractTagger> AddonTagger => null;

    public override IEnumerable<IAction> AddonConsoleActions => null;

    public override IEnumerable<IAddonView> AddonViews => null;

    public override IEnumerable<object> AddonSideloadFeature => null;
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.SocialMedia.Blogger.Data;
using CorpusExplorer.Sdk.Extern.SocialMedia.Rss.Format;
using CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr.Data;
using CorpusExplorer.Sdk.Extern.SocialMedia.Youtube;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia
{
  public class AddonRepository : AbstractAddonRepository
  {
    public override string Guid => "CorpusExplorer.Sdk.Extern.SocialMedia";
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter => null;    
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAction> AddonConsoleActions => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override IEnumerable<object> AddonSideloadFeature => null;

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers
      => new Dictionary<string, AbstractScraper>
      {
        {"Blogger-XML (*.xml)|*.xml", new BloggerScraper()},
        {"Tumblr-XML (*.xml)|*.xml", new TumblrScraper()},
        {"YouTube-JSON (*.json)|*.json", new YouTubeScraper() },
        {"RSS-Feed (*.xml)|*.xml", new RssFeedItemScraper() }
      };
  }
}

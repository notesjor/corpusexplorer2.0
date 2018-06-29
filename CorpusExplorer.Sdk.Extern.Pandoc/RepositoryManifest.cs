using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Pandoc.Pandoc;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.Pandoc
{
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter => null;

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {"PANDOC [commonmark] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.commonmark}},
        {
          "PANDOC [docbook] (*.docbook; *.xml; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.docbook}
        },
        {"PANDOC [Microsoft Word] (*.docx)|*.docx", new PandocScraper {Format = PandocScraper.InputFormat.docx}},
        {"PANDOC [epub] (*.epub)|*.epub", new PandocScraper {Format = PandocScraper.InputFormat.epub}},
        {"PANDOC [haddock] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.haddock}},
        {"PANDOC [html] (*.html)|*.html", new PandocScraper {Format = PandocScraper.InputFormat.html}},
        {"PANDOC [json] (*.json)|*.json", new PandocScraper {Format = PandocScraper.InputFormat.json}},
        {"PANDOC [LaTeX] (*.tex; *.latex; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.latex}},
        {"PANDOC [markdown] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.markdown}},
        {
          "PANDOC [markdown - github] (*.txt; *.*)|*.*",
          new PandocScraper {Format = PandocScraper.InputFormat.markdown_github}
        },
        {
          "PANDOC [markdown - mnd] (*.txt; *.*)|*.*",
          new PandocScraper {Format = PandocScraper.InputFormat.markdown_mmd}
        },
        {
          "PANDOC [markdown - phpextra] (*.txt; *.*)|*.*",
          new PandocScraper {Format = PandocScraper.InputFormat.markdown_phpextra}
        },
        {
          "PANDOC [markdown - strict] (*.txt; *.*)|*.*",
          new PandocScraper {Format = PandocScraper.InputFormat.markdown_strict}
        },
        {
          "PANDOC [wikipedia / mediawiki] (*.txt; *.*)|*.*",
          new PandocScraper {Format = PandocScraper.InputFormat.mediawiki}
        },
        {"PANDOC [native] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.native}},
        {"PANDOC [OpenOffice / LibreOffice] (*.odt)|*.odt", new PandocScraper {Format = PandocScraper.InputFormat.odt}},
        {"PANDOC [opml] (*.opml; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.opml}},
        {"PANDOC [org] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.org}},
        {"PANDOC [rst] (*.rst; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.rst}},
        {"PANDOC [t2t] (*.t2t; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.t2t}},
        {"PANDOC [textile] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.textile}},
        {"PANDOC [twiki] (*.txt; *.*)|*.*", new PandocScraper {Format = PandocScraper.InputFormat.twiki}}
      };

    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override string Guid => "CorpusExplorer.Sdk.Extern.Pandoc";
  }
}
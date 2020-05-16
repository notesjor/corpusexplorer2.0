#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.SaltAndPepper
{
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;
    public override IEnumerable<IAction> AddonConsoleActions => null;

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {
          "ANNIS XML (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Annis}
        },
        {
          "DOT (*.dot)|*.dot",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Dot}
        },
        {
          "GraphANNO (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.GraphAnno}
        },
        {
          "MMAX2 (*.mmax2)|*.mmax2",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Mmax2}
        },
        {
          "Paula (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Paula}
        },
        {
          "PennTreebank (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.PennTreebank}
        },
        {
          "RelANNIS (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.RelAnnis}
        },
        {
          "SaltInfo (*.html)|*.html",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.SaltInfo}
        },
        {
          "SaltXML (*.xml)|*.xml",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.SaltXml}
        },
        {
          "Tcf (*.tcf)|*.tcf",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Tcf}
        },
        {
          "Text (*.txt)|*.txt",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.Text}
        },
        {
          "TreeTagger (*.txt)|*.txt",
          new ExporterSaltAndPepper {Module = ExporterSaltAndPepper.PepperOutputModule.TreeTagger}
        }
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {
          "Aldt XML 1.0 (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Aldt10}
        },
        {
          "Aldt XML 1.5 (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Aldt15}
        },
        {
          "CoNLL (*.conll)|*.conll", new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Conll}
        },
        {
          "CoraXML (*.xml)|*.xml", new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.CoraXml}
        },
        {
          "EXMARaLDA (*.exs)|*.exs",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Exmaralda}
        },
        {
          "Elan (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Elan}
        },
        {
          "GATE 2.0 (*.xml)|*.xml", new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Gate20}
        },
        {
          "GATE 3.0 (*.xml)|*.xml", new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Gate30}
        },
        {
          "Generic-XML (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.GenericXml}
        },
        {
          "Graf (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Graf}
        },
        {
          "MMAX2 (*.mmax2)|*.mmax2", new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Mmax2}
        },
        {
          "Paula (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Paula}
        },
        {
          "PennTreebank (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.PennTreebank}
        },
        {
          "RST (*.rst)|*.rst",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Rst}
        },
        {
          "SaltXml (*.xml; *.salt)|*.xml;*.salt",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.SaltXml}
        },
        {
          "TCF (*.tcf)|*.tcf",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Tcf}
        },
        {
          "TEI-XML (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Tei}
        },
        {
          "Tiger-XML (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Tiger1}
        },
        {
          "Tiger2-XML (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Tiger2}
        },
        {
          "Uam (*.xml)|*.xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Uam}
        },
        {
          "Excel (*.xls)|*.xls",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Spreadsheet1}
        },
        {
          "Excel (*.xlsx)|*.xlsx",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Spreadsheet2}
        },
        {
          "Toolbox-XML (*.toolbox-xml)|*.toolbox-xml",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Toolbox}
        },
        {
          "TreeTagger (*.txt)|*.txt",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.TreeTagger}
        },
        {
          "WebannoTSV (*.tsv)|*.tsv",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.WebannoTsv}
        },
        {
          "Wolof (*.wolof)|*.wolof",
          new ImporterSaltAndPepper {Module = ImporterSaltAndPepper.PepperImportModule.Wolof}
        }
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override string Guid => "CorpusExplorer.Sdk.Extern.SaltAndPepper";
  }
}
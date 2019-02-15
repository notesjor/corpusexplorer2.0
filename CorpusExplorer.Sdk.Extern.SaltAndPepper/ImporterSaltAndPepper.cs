using System.Collections.Generic;
using System.Diagnostics;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.SaltAndPepper
{
  public class ImporterSaltAndPepper : AbstractImporter
  {
    public enum PepperImportModule
    {
      None,
      Aldt10,
      Aldt15,
      Conll,
      CoraXml,
      Exmaralda,
      Elan,
      Gate20,
      Gate30,
      GenericXml,
      Graf,
      Mmax2,
      Paula,
      PennTreebank,
      Rst,
      SaltXml,
      Tcf,
      Tei,
      Tiger1,
      Tiger2,
      Uam,
      Spreadsheet1,
      Spreadsheet2,
      Toolbox,
      TreeTagger,
      WebannoTsv,
      Wolof
    }

    private readonly ImporterConll _importer;

    public ImporterSaltAndPepper()
    {
      _importer = new ImporterConll();
    }

    public PepperImportModule Module { get; set; } = PepperImportModule.None;

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      using (var scriptTemp = new TemporaryFile(Configuration.TempPath))
      using (var outputTemp = new TemporaryFile(Configuration.TempPath))
      {
        var script =
          "<?xml version=\"1.0\" encoding=\"UTF-8\"?><?xml-model href=\"https://korpling.german.hu-berlin.de/saltnpepper/pepper/schema/10/pepper.rnc\" type=\"application/relax-ng-compact-syntax\"?><pepper-job version=\"1.0\"><importer name=\"FORMAT_NAME\" path=\"SOURCE_PATH\"/><manipulator name=\"MANIPULATOR_NAME\"/><exporter name=\"EXPORTER_NAME\" path=\"TARGET_PATH\"/></pepper-job>";

        var formatName = GetFormatName();
        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (formatName == null)
          return null;
        if (formatName == "-!-")
          return _importer.Execute(new[] {outputTemp.Path});

        var vars = new Dictionary<string, string>
        {
          {
            "FORMAT_NAME",
            formatName
          },
          {
            "SOURCE_PATH",
            importFilePath
          },
          {
            "<manipulator name=\"MANIPULATOR_NAME\"/>",
            "" // aktuell nicht unterstützt
          },
          {
            "EXPORTER_NAME",
            "CoNLLExporter"
          },
          {
            "TARGET_PATH",
            outputTemp.Path
          }
        };
        TemplateTextGenerator.GenerateToFile(script, vars, scriptTemp.Path);

        var pepperPath = (Configuration.GetDependencyPath(@"pepper") + @"\").Replace(@"\", "/");
        var javaArguments =
          $"-cp {pepperPath}lib/*;{pepperPath}plugins/*; -Dfile.encoding=UTF-8 -Dlogback.configurationFile={pepperPath}/conf/logback.xml org.corpus_tools.pepper.cli.PepperStarter {scriptTemp}";

        var pepper = new Process
        {
          StartInfo =
            new ProcessStartInfo(Configuration.GetDependencyPath(@"Java\bin\java.exe"))
            {
              Arguments
                = javaArguments,
              UseShellExecute
                = false,
              RedirectStandardOutput
                = false,
              RedirectStandardError
                = false,
              CreateNoWindow
                = false,
              WindowStyle
                = ProcessWindowStyle
                 .Hidden,
              WorkingDirectory = pepperPath,
              StandardOutputEncoding = Configuration.Encoding
            }
        };
        pepper.Start();
        pepper.WaitForExit();

        return _importer.Execute(new[] {outputTemp.Path});
      }
    }

    private string GetFormatName()
    {
      switch (Module)
      {
        default:
          return null;
        case PepperImportModule.None:
          return null;
        case PepperImportModule.Conll:
          return "-!-";
        case PepperImportModule.Aldt10:
        case PepperImportModule.Aldt15:
          return "AldtImporter";
        case PepperImportModule.CoraXml:
          return "CoraXMLImporter";
        case PepperImportModule.Exmaralda:
          return "EXMARaLDAImporter";
        case PepperImportModule.Elan:
          return "ElanImporter";
        case PepperImportModule.Gate20:
        case PepperImportModule.Gate30:
          return "GateImporter";
        case PepperImportModule.GenericXml:
          return "GenericXMLImporter";
        case PepperImportModule.Graf:
          return "GrAFImporter";
        case PepperImportModule.Mmax2:
          return "MMAX2Importer";
        case PepperImportModule.Paula:
          return "PAULAImporter";
        case PepperImportModule.PennTreebank:
          return "PTBImporter";
        case PepperImportModule.Rst:
          return "RSTImporter";
        case PepperImportModule.SaltXml:
          return "SaltXMLImporter";
        case PepperImportModule.Tcf:
          return "TCFImporter";
        case PepperImportModule.Tei:
          return "TEIImporter";
        case PepperImportModule.Tiger1:
        case PepperImportModule.Tiger2:
          return "Tiger2Importer";
        case PepperImportModule.Uam:
          return "UAMImporter";
        case PepperImportModule.Spreadsheet1:
        case PepperImportModule.Spreadsheet2:
          return "SpreadsheetImporter";
        case PepperImportModule.Toolbox:
          return "ToolboxImporter";
        case PepperImportModule.TreeTagger:
          return "TreetaggerImporter";
        case PepperImportModule.WebannoTsv:
          return "WebannoTSVImporter";
        case PepperImportModule.Wolof:
          return "WolofImporter";
      }
    }
  }
}
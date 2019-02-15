using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.SaltAndPepper
{
  public class ExporterSaltAndPepper : AbstractExporter
  {
    public enum PepperOutputModule
    {
      None,
      Conll,
      Annis,
      Dot,
      GraphAnno,
      Mmax2,
      Paula,
      PennTreebank,
      RelAnnis,
      SaltInfo,
      SaltXml,
      Tcf,
      Text,
      TreeTagger
    }

    public PepperOutputModule Module { get; set; } = PepperOutputModule.None;

    public override void Export(IHydra hydra, string path)
    {
      var formatName = GetFormatName();
      if (string.IsNullOrEmpty(formatName) || formatName == "-!-")
        ExportDirect(hydra, path);

      ExportBySaltAndPepper(hydra, path, formatName);
    }

    private static void ExportBySaltAndPepper(IHydra hydra, string path, string formatName)
    {
      path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      using (var scriptTemp = new TemporaryFile(Configuration.TempPath))
      using (var inputTemp = new TemporaryDirectory())
      {
        var script =
          "<?xml version=\"1.0\" encoding=\"UTF-8\"?><?xml-model href=\"https://korpling.german.hu-berlin.de/saltnpepper/pepper/schema/10/pepper.rnc\" type=\"application/relax-ng-compact-syntax\"?><pepper-job version=\"1.0\"><importer name=\"FORMAT_NAME\" path=\"SOURCE_PATH\"/><manipulator name=\"MANIPULATOR_NAME\"/><exporter name=\"EXPORTER_NAME\" path=\"TARGET_PATH\"/></pepper-job>";

        var vars = new Dictionary<string, string>
        {
          {
            "FORMAT_NAME",
            "CoNLLImporter"
          },
          {
            "SOURCE_PATH",
            inputTemp.Path
          },
          {
            "<manipulator name=\"MANIPULATOR_NAME\"/>",
            "" // aktuell nicht unterstützt
          },
          {
            "EXPORTER_NAME",
            formatName
          },
          {
            "TARGET_PATH",
            path
          }
        };
        TemplateTextGenerator.GenerateToFile(script, vars, scriptTemp.Path);

        var pepperPath = (Configuration.GetDependencyPath(@"pepper") + @"\").Replace(@"\", "/");
        var javaArguments =
          $"-cp {pepperPath}lib/*;{pepperPath}plugins/*; -Dfile.encoding=UTF-8 -Dlogback.configurationFile={pepperPath}/conf/logback.xml org.corpus_tools.pepper.cli.PepperStarter {scriptTemp}";

        var exporter = new ExporterConll();
        exporter.Export(hydra, inputTemp.Path);

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
      }
    }

    private void ExportDirect(IHydra hydra, string path)
    {
      var exporter = new ExporterConll();
      exporter.Export(hydra, path);
    }

    private string GetFormatName()
    {
      switch (Module)
      {
        default:
          return null;
        case PepperOutputModule.None:
          return null;
        case PepperOutputModule.Conll:
          return "-!-";
        case PepperOutputModule.Mmax2:
          return "MMAX2Exporter";
        case PepperOutputModule.Paula:
          return "PAULAExporter";
        case PepperOutputModule.PennTreebank:
          return "PTBExporter";
        case PepperOutputModule.SaltXml:
          return "SaltXMLExporter";
        case PepperOutputModule.Tcf:
          return "TCFExporter";
        case PepperOutputModule.TreeTagger:
          return "TreetaggerExporter";
      }
    }
  }
}
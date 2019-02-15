using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Bcs.IO;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Mtld;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Blocks
{
  public class MtldBlock : AbstractBlock
  {
    public Dictionary<string, double> Diversity { get; private set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public string MetadataKey { get; set; } = "Autor";
    public double Threshold { get; set; } = 0.71;

    /// <summary>
    ///   Type / Token / TypeTokenRatio
    /// </summary>
    public Dictionary<string, double[]> TypeTokenRatio { get; private set; }

    public Dictionary<string, double> Variance { get; private set; }
    public WeightingMode WeightingMode { get; set; } = WeightingMode.WithinOnly;

    public override void Calculate()
    {
      var clusterBlock = Selection.CreateBlock<SelectionClusterBlock>();
      clusterBlock.ClusterGenerator = new SelectionClusterGeneratorStringValue();
      clusterBlock.MetadataKey = MetadataKey;
      clusterBlock.Calculate();

      if (clusterBlock.Cluster == null || clusterBlock.Cluster.Length == 0)
        return;

      TypeTokenRatio = new Dictionary<string, double[]>();
      Diversity = new Dictionary<string, double>();
      Variance = new Dictionary<string, double>();

      foreach (var cluster in clusterBlock.Cluster)
        using (var scriptTemp = new TemporaryFile(Configuration.TempPath))
        using (var dataTemp = new TemporaryFile(Configuration.TempPath))
        {
          const string script =
            "use File::Slurp;\r\nuse Lingua::Diversity::MTLD;\r\nuse Lingua::Diversity::Utils qw( split_text split_tagged_text );\r\nmy $text = read_file('index.html');\r\n# Create a Diversity object...\r\nmy $diversity = Lingua::Diversity::MTLD->new(\r\n'threshold'         => 0.71,\r\n'weighting_mode'    => 'within_and_between',\r\n);\r\n# Given some text, get a reference to an array of words...\r\nmy $word_array_ref = split_text(\r\n'text'          => \\$text,\r\n'unit_regexp'   => qr{[^a-zA-Z]+},\r\n);\r\n# Measure lexical diversity...\r\nmy $result = $diversity->measure( $word_array_ref );\r\n# Display results...\r\nprint $result->get_diversity(), \"|\", $result->get_variance();";
          var vars = new Dictionary<string, string>
          {
            {
              "read_file('index.html');",
              $"read_file('{dataTemp.Path.Replace(@"\", "/")}');"
            },
            {
              "=> 0.71,",
              $"=> {Threshold.ToString(CultureInfo.InvariantCulture)},"
            },
            {
              "=> 'within_and_between',",
              WeightingMode == WeightingMode.WithinOnly
                ? "=> 'within_only',"
                : "=> 'within_and_between',"
            }
          };
          TemplateTextGenerator.GenerateToFile(script, vars, scriptTemp.Path);

          var exporter = new ExporterPlaintextPureInOneFile {LayerDisplayname = LayerDisplayname};
          var selection = Selection.CreateTemporary(cluster.DocumentGuids);
          var data = exporter.Export(selection)
                             .Replace("+<", "")
                             .Replace("+//.", "")
                             .Replace("+//?", "")
                             .Replace("+//!", "")
                             .Replace("[*]", "")
                             .Replace("+/.", "")
                             .Replace("+...", "")
                             .Replace("...", "")
                             .Replace("..", "")
                             .Replace(".", "")
                             .Replace("!", "")
                             .Replace("#", "")
                             .Replace("[?]", "")
                             .Replace("[*]", "")
                             .Replace("?", "")
                             .Replace("+", "")
                             .Replace("\r\n", " ")
                             .Replace("  ", " ")
                             .Replace("  ", " ");
          FileIO.Write(dataTemp.Path, data);

          var perl = new Process
          {
            StartInfo = new ProcessStartInfo(Configuration.GetDependencyPath(@"Perl\perl\bin\perl.exe"))
            {
              Arguments = scriptTemp.Path,
              UseShellExecute = false,
              RedirectStandardOutput = true,
              RedirectStandardError = true,
              CreateNoWindow = false,
              StandardOutputEncoding = Configuration.Encoding,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          perl.Start();
          var output = perl.StandardOutput.ReadToEnd();
          perl.StandardError.ReadToEnd();
          perl.WaitForExit();

          var vals = output.Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
          double d, v;
          if (vals.Length != 2 || !double.TryParse(vals[0], NumberStyles.Float, CultureInfo.InvariantCulture, out d) ||
              !double.TryParse(vals[1], NumberStyles.Float, CultureInfo.InvariantCulture, out v))
            continue;
          Diversity.Add(cluster.Displayname, d);
          Variance.Add(cluster.Displayname, v);

          var ttr = new QuickInfoTtrViewModel {Selection = selection, LayerDisplayname = LayerDisplayname};
          ttr.Execute();
          TypeTokenRatio.Add(cluster.Displayname,
                             new[] {ttr.CounterTypes, ttr.CounterTokens, ttr.CounterTypeTokenRatio});
        }
    }
  }
}
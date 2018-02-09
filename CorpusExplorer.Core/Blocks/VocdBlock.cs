using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Core.Exporter;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Core.Blocks
{
  public class VocdBlock : AbstractBlock
  {
    public int SampleRangeStart { get; set; } = 35;
    public int SampleRangeStop { get; set; } = 50;
    public int NumberOfSubsampels { get; set; } = 100;
    public int ValueMin { get; set; } = 1;
    public int ValueMax { get; set; } = 200;
    public double Precision { get; set; } = 0.01;
    public int NumberOfTrails { get; set; } = 3;
    public string MetadataKey { get; set; } = "Autor";
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    /// Type / Token / TypeTokenRatio
    /// </summary>
    public Dictionary<string, double[]> TypeTokenRatio { get; private set; }
    public Dictionary<string, double> Diversity { get; private set; }
    public Dictionary<string, double> Variance { get; private set; }

    public override void Calculate()
    {
      var clusterBlock = Selection.CreateBlock<SelectionClusterBlock>();
      clusterBlock.ClusterGenerator = new SelectionClusterGeneratorByStringValue();
      clusterBlock.MetadataKey = MetadataKey;
      clusterBlock.Calculate();

      if (clusterBlock.Cluster == null || clusterBlock.Cluster.Length == 0)
        return;

      TypeTokenRatio = new Dictionary<string, double[]>();
      Diversity = new Dictionary<string, double>();
      Variance = new Dictionary<string, double>();

      foreach (var cluster in clusterBlock.Cluster)
      {
        using (var scriptTemp = new TemporaryFile(Configuration.TempPath))
        using (var dataTemp = new TemporaryFile(Configuration.TempPath))
        {
          const string script = "use File::Slurp;\r\nuse Lingua::Diversity::VOCD;\r\nuse Lingua::Diversity::Utils qw( split_text split_tagged_text );\r\nmy $text = read_file('index.html');\r\n# Create a Diversity object...\r\nmy $diversity = Lingua::Diversity::VOCD->new(\r\n'length_range'      => [ 35..50 ],\r\n'num_subsamples'    => 100,\r\n'min_value'         => 1,\r\n'max_value'         => 200,\r\n'precision'         => 0.01,\r\n'num_trials'        => 3\r\n);\r\n# Given some text, get a reference to an array of words...\r\nmy $word_array_ref = split_text(\r\n'text'          => \\$text,\r\n'unit_regexp'   => qr{[^a-zA-Z]+},\r\n);\r\n# Measure lexical diversity...\r\nmy $result = $diversity->measure( $word_array_ref );\r\n# Display results...\r\nprint $result->get_diversity(), \"|\", $result->get_variance();";
          var vars = new Dictionary<string, string>
                       {
                         {
                           "read_file('index.html');",
                           $"read_file('{dataTemp.Path.Replace(@"\","/")}');"
                         },
                         {
                           "=> [ 35..50 ],",
                           $"=> [ {SampleRangeStart}..{SampleRangeStop} ],"
                         },
                         {
                           "=> 100,",
                           $"=> {NumberOfSubsampels},"
                         },
                         {
                           "=> 1,",
                           $"=> {ValueMin},"
                         },
                         {
                           "=> 200,",
                           $"=> {ValueMax},"
                         },
                         {
                           "=> 0.01,",
                           $"=> {Precision.ToString(CultureInfo.InvariantCulture)},"
                         },
                         {
                           "=> 3",
                           $"=> {NumberOfTrails}"
                         }
                       };
          TemplateTextGenerator.GenerateToFile(script, vars, scriptTemp.Path);

          var exporter = new ExporterPlaintextPureInOneFile { LayerDisplayname = LayerDisplayname };
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

          var vals = output.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
          double d, v;
          if (vals.Length != 2 || !double.TryParse(vals[0], NumberStyles.Float, CultureInfo.InvariantCulture, out d) || !double.TryParse(vals[1], NumberStyles.Float, CultureInfo.InvariantCulture, out v))
            continue;
          Diversity.Add(cluster.Displayname, d);
          Variance.Add(cluster.Displayname, v);

          var ttr = new QuickInfoTtrViewModel { Selection = selection, LayerDisplayname = LayerDisplayname };
          ttr.Analyse();
          TypeTokenRatio.Add(cluster.Displayname, new[] { ttr.CounterTypes, ttr.CounterTokens, ttr.CounterTypeTokenRatio });
        }
      }
    }
  }
}

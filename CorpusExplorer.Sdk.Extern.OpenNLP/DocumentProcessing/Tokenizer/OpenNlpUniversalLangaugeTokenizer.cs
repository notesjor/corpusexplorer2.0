using System;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tagger.Parameter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tokenizer
{
  // ReSharper disable once UnusedMember.Global
  public class OpenNlpUniversalLangaugeTokenizer : AbstractTokenizer
  {
    public override string DisplayName => "OpenNLP Tokenizer (universal language)";

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public bool ForceOneWordPerLine { get; set; }
    public override string Language { get; set; }

    public override string Execute(string input)
    {
      var fin = Path.Combine(Configuration.TempPath, "input.txt");
      FileIO.Write(fin, input);

      try
      {
        var fout = fin + ".out";

        if (File.Exists(fout))
          try
          {
            File.Delete(fout);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }

        var process = new Process
        {
          StartInfo =
          {
            FileName = OpenNlpLocator.BatchFile,
            Arguments = $"SimpleTokenizer < {fin} > {fout}",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            StandardOutputEncoding = Configuration.Encoding,
            WindowStyle = ProcessWindowStyle.Hidden
          }
        };
        process.Start();
        process.WaitForExit();

        var res = FileIO.ReadText(fout, Configuration.Encoding);
        return ForceOneWordPerLine ? res.Replace(" ", "\r\n") : res;
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}
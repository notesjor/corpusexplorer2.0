#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Python.JusText
{
  public class JusTextCleanup : AbstractCleanup
  {
    private readonly string[] _germanPostFilter = {"Cookie", "Datenschutz", "zustimmen"};

    public JusTextCleanup()
    {
      PythonManager.InstallPackage("justext");
    }

    public override string DisplayName => "Python jusText";
    public string Language { get; set; } = "German";
    public int LengthHeight { get; set; } = 150;
    public int LengthLow { get; set; } = 70;
    public int MaxHeadingDistance { get; set; } = 150;
    public float MaxLinkDensity { get; set; } = 0.8f;
    public bool NoHeadings { get; set; } = true;
    public float StopwordsHeight { get; set; } = 0.3f;
    public float StopwordsLow { get; set; } = 0.2f;
    public bool UseGermanPostFilter { get; set; } = true;

    protected override string Execute(string key, string input)
    {
      using (var iF = new TemporaryFile(Configuration.TempPath))
      using (var oF = new TemporaryFile(Configuration.TempPath))
      {
        try
        {
          FileIO.Write(iF.Path, input, Encoding.UTF8);
          PythonManager
           .RunPythonCommand($"-m justext -s {Language} --enc-force {(NoHeadings ? "--no-headings" : "")} --max-heading-distance={MaxHeadingDistance} --length-low={LengthLow} --length-high={LengthHeight} --stopwords-low={StopwordsLow.ToString(CultureInfo.InvariantCulture)} --stopwords-high={StopwordsHeight.ToString(CultureInfo.InvariantCulture)} --max-link-density={MaxLinkDensity.ToString(CultureInfo.InvariantCulture)} -o \"{oF.Path}\" \"{iF.Path}\"");
          var text = EncodingFixer.Fix(FileIO.ReadText(oF.Path, Encoding.UTF8));
          text = UseGermanPostFilter ? GermanPostFilter(text) : text.Replace("<p> ", "");
          return string.IsNullOrWhiteSpace(text) ? input : text;
        }
        catch
        {
          return input;
        }
      }
    }

    private string GermanPostFilter(string text)
    {
      var ps = text.Split(new[] {"<p> "}, StringSplitOptions.RemoveEmptyEntries);
      var res = new List<string>();

      foreach (var p in ps)
      {
        if (p.Length > 500) // Längere Texte nicht berücksichtigen.
          res.Add(p);

        if (_germanPostFilter.Count(t => p.Contains(t)) < 2)
          res.Add(p);
      }

      return string.Join(" ", res);
    }
  }
}
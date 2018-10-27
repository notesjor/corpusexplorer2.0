using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.ConllTagger.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.UDPipe
{
  public class UdPipeExeTagger : AbstractConllStyleTagger
  {
    private Dictionary<string, string> _languagesAvailable = new Dictionary<string, string>();
    private string _languageSelected;
    private string _model;

    public UdPipeExeTagger()
    {
      AddValueLayer("Wort", 1);
      AddValueLayer("Lemma", 2);
      AddValueLayer("POS", 4);


      Configuration.GetSetting("UDPipe", @"C:\UDPipe\udpipe.exe");

      // ReSharper disable once VirtualMemberCallInConstructor
      InstallationPath = InstallationPath; // notwendig zum Laden der Sprachdaten
    }

    public override string DisplayName => "UDPipe (eigene/externe Installation)";

    public override string InstallationPath
    {
      get => Configuration.GetSetting("UDPipe", @"C:\UDPipe\udpipe.exe") as string;
      set
      {
        _languagesAvailable = new Dictionary<string, string>();

        try
        {
          Configuration.SetSetting("UDPipe", value);
        }
        catch
        {
          // ignore
        }

        try
        {
          var dir = Path.GetDirectoryName(value);
          var files = Directory.GetFiles(dir, "*.udpipe", SearchOption.AllDirectories);

          foreach (var file in files)
          {
            var fn = Path.GetFileNameWithoutExtension(file);
            if (!_languagesAvailable.ContainsKey(fn))
              _languagesAvailable.Add(fn, file);
          }
        }
        catch
        {
          // ignore
        }
      }
    }

    public override IEnumerable<string> LanguagesAvailabel => _languagesAvailable.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (value == _languageSelected)
          return;

        _languageSelected = value;
        _model = _languagesAvailable[_languageSelected];
      }
    }

    protected override string ExecuteTagger(string text)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = InstallationPath,
              Arguments = $"--tokenize --tag \"{_model}\" \"{fileInput.Path}\"",
              CreateNoWindow = true,
              UseShellExecute = false,
              StandardOutputEncoding = Configuration.Encoding,
              RedirectStandardOutput = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();

          var res = process.StandardOutput.ReadToEnd();
          process.WaitForExit();

          return res;
        }
        catch
        {
          return string.Empty;
        }
      }
    }
  }
}
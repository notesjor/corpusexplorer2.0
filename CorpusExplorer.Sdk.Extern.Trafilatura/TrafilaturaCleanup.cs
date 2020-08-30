using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using System.Diagnostics;
using System.Text;

namespace CorpusExplorer.Sdk.Extern.Trafilatura
{
  public class TrafilaturaCleanup : AbstractCleanup
  {
    public override string DisplayName => "Trafilatura";
    protected override string Execute(string key, string input)
    {
      try
      {
        if (key != "Text")
          return input;

        string res;
        using (Process p = new Process())
        {
          p.StartInfo.FileName = "trafilatura --nocomments --notables";
          p.StartInfo.UseShellExecute = false;
          p.StartInfo.RedirectStandardInput = true;
          p.StartInfo.RedirectStandardOutput = true;
          p.StartInfo.StandardOutputEncoding = Encoding.UTF8;

          p.Start();

          using(var writer = p.StandardInput)
            writer.Write(Encoding.UTF8.GetBytes(input));

          res = p.StandardOutput.ReadToEnd();
          p.WaitForExit();
        }

        return res;
      }
      catch
      {
        return input;
      }
    }
  }
}

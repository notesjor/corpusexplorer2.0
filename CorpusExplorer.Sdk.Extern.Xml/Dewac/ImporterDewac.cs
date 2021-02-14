using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Dewac
{
  public class ImporterDewac : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var buffer = new byte[4096];
      var text = "";
      var cnt = 0;

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        while (true)
        {
          var length = bs.Read(buffer, 0, buffer.Length);
          if (length < 1)
            break;

          text += Encoding.Default.GetString(buffer, 0, length);

          while (text.IndexOf("</text>") > -1)
          {
            var idStart = text.IndexOf("id=", StringComparison.Ordinal) + 4;
            var idEnd = text.IndexOf("\"", idStart + 1, StringComparison.Ordinal);
            var textStart = text.IndexOf(">", idEnd + 1, StringComparison.Ordinal) + 1;
            var textEnd = text.IndexOf("</text>", textStart, StringComparison.Ordinal);

            BuildDocument(
              text.Substring(idStart, idEnd - idStart).Replace("\"", "").Trim(),
              text.Substring(textStart, textEnd - textStart)
                .Replace("<s>", "")
                .Trim()
                .Split(new[] {"</s>"}, StringSplitOptions.RemoveEmptyEntries));

            text = text.Substring(textEnd + 7).TrimStart();
            cnt++;

            if (cnt % 1000 == 0)
            {
              GC.Collect();
              GC.WaitForPendingFinalizers();
            }
          }
        }
      }
    }

    private void BuildDocument(string id, IEnumerable<string> sentences)
    {
      var guid = Guid.NewGuid();
      AddDocumentMetadata(guid, "id", id);

      var wDoc = new List<string[]>();
      var pDoc = new List<string[]>();
      var lDoc = new List<string[]>();

      foreach (var sentence in sentences)
      {
        var words = sentence.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

        var wSent = new List<string>();
        var pSent = new List<string>();
        var lSent = new List<string>();

        foreach (var word in words)
        {
          var data = word.Split(new[] {"\t", " "}, StringSplitOptions.RemoveEmptyEntries);
          if (data.Length == 0)
            continue;
          wSent.Add(data[0]);
          if (data.Length == 1)
            continue;
          pSent.Add(data[1]);
          if (data.Length == 2)
            continue;
          lSent.Add(data[2]);
        }

        wDoc.Add(wSent.ToArray());
        pDoc.Add(pSent.ToArray());
        lDoc.Add(lSent.ToArray());
      }

      AddDocument("Wort", guid, wDoc.ToArray());
      AddDocument("POS", guid, pDoc.ToArray());
      AddDocument("Lemma", guid, lDoc.ToArray());
    }
  }
}
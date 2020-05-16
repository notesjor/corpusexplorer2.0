using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Plaintext.Redewiedergabe
{
  public class ImporterRedewiedergabe : AbstractImporterBase
  {
    private Dictionary<string, Guid> _files = new Dictionary<string, Guid>();

    protected override void ExecuteCall(string path)
    {
      if (!path.ToLower().EndsWith("metadata.tsv"))
        return;

      ReadMetaData(path);
      ReadDocuments(Path.GetDirectoryName(path));
    }

    private void ReadDocuments(string dir)
    {
      foreach (var file in _files)
      {
        var path = Path.Combine(dir, file.Key);
        if (!File.Exists(path))
          continue;

        var lines = FileIO.ReadLines(path, Configuration.Encoding, stringSplitOptions: StringSplitOptions.RemoveEmptyEntries);
        if (lines == null || lines.Length == 0 || lines[0] != "tok\tnormtok\tlemma\tpos\trfpos\tsentstart\tstwr\tframe\tspeaker\tintexpr\tnote") // siehe unten: if (split.Length != 11)
          continue;

        var dWord = new List<string[]>();
        var dNWord = new List<string[]>();
        var dLemma = new List<string[]>();
        var dPos = new List<string[]>();
        var dRPos = new List<string[]>();
        var dStwr = new List<string[]>();
        var dFrame = new List<string[]>();
        var dSpeaker = new List<string[]>();
        var dIntexpr = new List<string[]>();
        var dNote = new List<string[]>();

        var sWord = new List<string>();
        var sNWord = new List<string>();
        var sLemma = new List<string>();
        var sPos = new List<string>();
        var sRPos = new List<string>();
        var sStwr = new List<string>();
        var sFrame = new List<string>();
        var sSpeaker = new List<string>();
        var sIntexpr = new List<string>();
        var sNote = new List<string>();

        for (var i = 1; i < lines.Length; i++)
        {
          var split = lines[i].Split(new[] { "\t" }, StringSplitOptions.None);
          if (split.Length != 11) // siehe oben: if (... lines[0] != "tok\tnormtok\tlemma\tpos\trfpos\tsentstart\tstwr\tframe\tspeaker\tintexpr\tnote")
            continue;

          if (split[5] == "yes") // Satzanfang
          {
            if (sWord.Count > 0)
            {
              dWord.Add(sWord.ToArray());
              dNWord.Add(sNWord.ToArray());
              dLemma.Add(sLemma.ToArray());
              dPos.Add(sPos.ToArray());
              dRPos.Add(sRPos.ToArray());
              dStwr.Add(sStwr.ToArray());
              dFrame.Add(sFrame.ToArray());
              dSpeaker.Add(sSpeaker.ToArray());
              dIntexpr.Add(sIntexpr.ToArray());
              dNote.Add(sNote.ToArray());
            }

            sWord.Clear();
            sNWord.Clear();
            sLemma.Clear();
            sPos.Clear();
            sRPos.Clear();
            sStwr.Clear();
            sFrame.Clear();
            sSpeaker.Clear();
            sIntexpr.Clear();
            sNote.Clear();
          }

          sWord.Add(split[0]);
          sNWord.Add(split[1]);
          sLemma.Add(split[2]);
          sPos.Add(split[3]);
          sRPos.Add(split[4]);
          sStwr.Add(split[6]);
          sFrame.Add(split[7]);
          sSpeaker.Add(split[8]);
          sIntexpr.Add(split[9]);
          sNote.Add(split[10]);
        }

        if (sWord.Count > 0)
        {
          dWord.Add(sWord.ToArray());
          dNWord.Add(sNWord.ToArray());
          dLemma.Add(sLemma.ToArray());
          dPos.Add(sPos.ToArray());
          dRPos.Add(sRPos.ToArray());
          dStwr.Add(sStwr.ToArray());
          dFrame.Add(sFrame.ToArray());
          dSpeaker.Add(sSpeaker.ToArray());
          dIntexpr.Add(sIntexpr.ToArray());
          dNote.Add(sNote.ToArray());
        }

        if (dWord.Count > 0)
        {
          AddDocumet("Wort", file.Value, dWord.ToArray());
          AddDocumet("Normiert", file.Value, dNWord.ToArray());
          AddDocumet("Lemma", file.Value, dLemma.ToArray());
          AddDocumet("POS", file.Value, dPos.ToArray());
          AddDocumet("POS (erweitert)", file.Value, dRPos.ToArray());
          AddDocumet("STWR", file.Value, dStwr.ToArray());
          AddDocumet("Frame", file.Value, dFrame.ToArray());
          AddDocumet("Sprecher", file.Value, dSpeaker.ToArray());
          AddDocumet("INTEXPR", file.Value, dIntexpr.ToArray());
          AddDocumet("Notiz", file.Value, dNote.ToArray());
        }
      }
    }

    private void ReadMetaData(string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding, stringSplitOptions: StringSplitOptions.RemoveEmptyEntries);
      if (lines == null || lines.Length == 0 || lines[0] != "file\torig_filename\tyear\tdecade\tsource\ttitle\tauthor\tfictional\ttext_type\tnarrative\tcabtokens\tdialect\tperspective\tquotes") // siehe unten: if (split.Length != 14)
        return;

      _files = new Dictionary<string, Guid>();
      for (var i = 1; i < lines.Length; i++)
      {
        var split = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length != 14) // siehe oben: if (... lines[0] != "file\torig_filename\tyear\tdecade\tsource\ttitle\tauthor\tfictional\ttext_type\tnarrative\tcabtokens\tdialect\tperspective\tquotes")
          continue;

        if (!split[0].EndsWith(".tsv"))
          split[0] += ".tsv";

        var guid = Guid.NewGuid();
        _files.Add(split[0], guid);

        AddDocumentMetadata(guid, new Dictionary<string, object>
        {
          { "Datei", split[0] },
          { "Jahr", int.Parse(split[2])  },
          { "Dekade", int.Parse(split[3])  },
          { "Quelle", split[4] },
          { "Titel", split[5] },
          { "Autor", split[6] },
          { "Fiktional?", split[7] == "yes" },
          { "Textsorte", split[8] },
          { "Narrative", split[9] },
          { "CAB-Tokens", split[10] },
          { "Dialekt", split[11] },
          { "Perspektive", split[12] },
          { "Anführungszeichen", split[13] },
        });
      }
    }
  }
}

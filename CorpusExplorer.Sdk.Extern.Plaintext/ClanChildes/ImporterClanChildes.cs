#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes
{
  public sealed class ImporterClanChildes : AbstractImporterSimple3Steps<ImporterClanChildes.ClanChildesImportData>
  {
    private int _counter = 1;
    private Dictionary<string, object> _documentMetadataPrototyp;
    private string _filename;
    private string _path;

    public ImporterClanChildes()
    {
      Errors = new List<ClanChildesError>();
    }

    public List<ClanChildesError> Errors { get; }

    protected override ClanChildesImportData ImportStep_1_ReadFile(string path)
    {
      _path = path;
      _filename = Path.GetFileNameWithoutExtension(path);
      var text = FileIO.ReadText(path, Configuration.Encoding);

      text =
        text.Replace("[+ imi]", "")
          .Replace("[+imi]", "")
          .Replace("[+ cit]", "")
          .Replace("[+cit]", "")
          .Replace("[+ pds]", "")
          .Replace("[+pds]", "")
          .Replace("[+ ads]", "")
          .Replace("[+ads]", "");

      return new ClanChildesImportData
      {
        Text = text.Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries),
        Rules = File.Exists(path + ".cecclanr") ? Serializer.Deserialize<ClanChildesRule[]>(path + ".cecclanr") : null
      };
    }

    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref ClanChildesImportData data)
    {
      var lines = data.Text;

      var language = "";
      var media = "";
      var date = "";
      var transcriber = "";
      var comment = "";
      var location = "";
      var situation = "";

      foreach (var line in lines.TakeWhile(line => line.StartsWith("@")))
      {
        if (line.StartsWith("@Languages:"))
          language = line.Replace("@Languages:", "").Trim();
        if (line.StartsWith("@Media:"))
          media = line.Replace("@Media:", "").Trim();
        if (line.StartsWith("@Date:"))
          date = line.Replace("@Date:", "").Trim();
        if (line.StartsWith("@Transcriber:"))
          transcriber = line.Replace("@Transcriber:", "").Trim();
        if (line.StartsWith("@Comment:"))
          comment = comment + " " + line.Replace("@Comment:", "").Trim();
        if (line.StartsWith("@Location:"))
          location = line.Replace("@Location:", "").Trim();
        if (line.StartsWith("@Situation:"))
          situation = line.Replace("@Situation:", "").Trim();
      }

      AddCorpusMetadata("Kommentar", comment.Trim());

      _documentMetadataPrototyp = new Dictionary<string, object>
      {
        {"Sprache", language},
        {"Media", media},
        {"Datum", date},
        {"Autor (Transkript)", transcriber},
        {"Ort", location},
        {"Situation", situation},
        {"Dateiname", _filename}
      };
    }

    // ReSharper disable once FunctionComplexityOverflow
    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref ClanChildesImportData data)
    {
      var rules = data.Rules;

      var sentenceMarks = new HashSet<string> { ".", "!", "?", ",", ";", "+", "#" };
      string lineUtterance = null;
      var lineNumberUtterance = 0;

      RestAllValues(
        out var dguid,
        out var comment,
        out var speaker,
        out var mod,
        out var action,
        out var sentenceEnd,
        out var parallelSpeech,
        out var inSentenceComment,
        out var original,
        out var speakerError,
        out var category,
        out var isValid,
        out var layerWord,
        out var layerPos,
        out var layerPosInfo,
        out var layerPosPerson,
        out var layerLemma,
        out var layerLemmaInfo,
        out var layerCategory);

      
      // Zeile für Zeile einlesen
      string[] text = null;
      for (var i = 0; i < data.Text.Length; i++)
      {
        var line = data.Text[i];

        if (line.StartsWith("@"))
          continue;

        if (line.StartsWith("*"))
        {
          if (layerWord != null)
            Save(
              dguid,
              layerWord,
              layerLemma,
              layerLemmaInfo,
              layerPos,
              layerPosInfo,
              layerPosPerson,
              layerCategory,
              speaker,
              comment,
              mod,
              action,
              sentenceEnd,
              parallelSpeech,
              inSentenceComment,
              original,
              speakerError,
              ref rules);
          RestAllValues(
            out dguid,
            out comment,
            out speaker,
            out mod,
            out action,
            out sentenceEnd,
            out parallelSpeech,
            out inSentenceComment,
            out original,
            out speakerError,
            out category,
            out isValid,
            out layerWord,
            out layerPos,
            out layerPosInfo,
            out layerPosPerson,
            out layerLemma,
            out layerLemmaInfo,
            out layerCategory);

          var split = CleanTextLine(line).Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries);

          speaker = split[0].Replace("*", "").Replace(":", "");
          original = split[1]; // Orignal ohne Modifikationen

          text = ProcessText(
            original.Replace("xxx", ""),
            out isValid,
            ref category,
            ref action,
            ref sentenceEnd,
            ref parallelSpeech,
            ref inSentenceComment,
            ref speakerError,
            ref comment);

          lineUtterance = split[1]; // Wird für Fehlerbehebung benötigt
          lineNumberUtterance = i; // Wird für Fehlerbehebung benötigt
          layerWord = Convert("Wort", text);
        }

        if (line[0] != '%')
          continue;
        if (line.StartsWith("%com"))
        {
          comment = (comment.Length != 0 ? comment + " " : "") + line.Replace("%com:", "").Trim();
          continue;
        }

        var splits = line.Split(Splitter.Colon, StringSplitOptions.RemoveEmptyEntries);
        mod = splits[0].Replace("%", "");
        var lineAnnotation = line.Replace("%" + mod + ":", "").Trim();
        var lineNumberAnnoation = i;

        var mor = line.Replace("%" + mod + ":", "").Trim().Split(Splitter.Space, StringSplitOptions.RemoveEmptyEntries);
        var lem = new List<string>();
        var lemI = new List<string>();
        var pos = new List<string>();
        var posI = new List<string>();
        var posP = new List<string>();

        var pVIndex = -1;
        string pV = null;

        for (var mIndex = 0; mIndex < mor.Length; mIndex++)
          try
          {
            // PV-Einschub
            if (pVIndex > -1 && (pVIndex == mor.Length && mIndex + 1 == mor.Length || pVIndex == mIndex))
            {
              lem.Add(pV);
              lemI.Add("");
              pos.Add("PV");
              posP.Add("");
              try
              {
                if (pVIndex >= posI.Count)
                  posI.Add("");
                else
                  posI.Insert(pVIndex, "");
              }
              catch
              {
              }

              pVIndex = -1;
            }

            var m = mor[mIndex];
            var split = m.Split(Splitter.Pipe, StringSplitOptions.RemoveEmptyEntries);

            // POS-Tag Extraktion
            var p = split[0];
            // Wenn POS-Tag folgenden Format entspricht, dann spalte die POS-Info ab: INFO#POS
            if (p.Contains("#"))
            {
              var pS = p.Split(Splitter.Hashtag, StringSplitOptions.RemoveEmptyEntries);
              if (pS.Length == 2)
              {
                p = pS[1];
                posI.Add(pS[0]);
                // Wenn X#V: - dann ist X ein Partikelverb
                if (p.StartsWith("V:"))
                {
                  pV = pS[0];
                  pVIndex = 0;
                  var found = false;

                  for (; pVIndex < text.Length; pVIndex++)
                    if (text[pVIndex] == pV)
                    {
                      found = true;
                      break;
                    }

                  if (!found)
                  {
                    pVIndex = -1;
                  }
                  else
                  {
                    if (pVIndex == mIndex)
                    {
                      lem.Add(pV);
                      lemI.Add("");
                      pos.Add("PV");
                      posI.Insert(pVIndex, "");
                      posP.Add("");
                      pVIndex = -1;
                    }

                    if (pVIndex < mIndex)
                    {
                      // Nachträgliches Einfügen
                      lem.Insert(pVIndex, pV);
                      lemI.Insert(pVIndex, "");
                      pos.Insert(pVIndex, "PV");
                      posI.Insert(pVIndex, "");
                      posP.Insert(pVIndex, "");
                      pVIndex = -1;
                    }

                    // Wenn das Partikelverb erst später kommt, wird es erst dann eingeschoben (siehe oben: PV-Einschub)
                  }
                }
              }
              else
              {
                posI.Add("");
              }
            }
            else
            {
              posI.Add("");
            }

            // Wichtig: POS-Info muss vor POS-Person abgespalten werden

            // Wenn POS-Tag ein Satzzeichen ist, dann normiere es
            if (sentenceMarks.Contains(p))
            {
              pos.Add("$.");
              posP.Add("");
            }
            // Wenn alternativ das POS-Tag dem Format entspricht, dann spalte die POS-Person ab: POS:PERSON
            else if (p.Contains(":"))
            {
              var idx = p.IndexOf(":", StringComparison.Ordinal);
              pos.Add(p.Substring(0, idx));
              posP.Add(p.Substring(idx + 1));
            }
            else
            // Wenn Normalform ODER normiert, dann speichere das POS-Tag
            {
              pos.Add(p);
              posP.Add("");
            }

            // Lemma-Tag Extraktion
            var l = split.Length == 1 ? split[0] : split[1];
            // Wenn Lemma-Tag folgenden Format entspricht, dann spalte die Lemma-Info ab: LEMMA-INFO
            if (l.Contains("-"))
            {
              var lS = l.Split(Splitter.Dash, StringSplitOptions.RemoveEmptyEntries);
              lem.Add(lS.Length == 2 ? lS[0] : l);
              lemI.Add(lS.Length == 2 ? lS[1] : "");
            }
            else
            {
              lem.Add(l);
              lemI.Add("");
            }
          }
          catch
          {
          }

        var hasError = false;

        layerLemma = Convert("Lemma", lem.ToArray(), isValid, ref hasError);
        layerLemmaInfo = Convert("Lemma-Info", lemI.ToArray(), isValid, ref hasError);
        layerPos = Convert("POS", pos.ToArray(), isValid, ref hasError);
        layerPosInfo = Convert("POS-Info", posI.ToArray(), isValid, ref hasError);
        layerPosPerson = Convert("POS-Person", posP.ToArray(), isValid, ref hasError);
        layerCategory = Convert("@-Kategorie", category, isValid, ref hasError);

        if (hasError)
          Errors.Add(
            new ClanChildesError(
              _path,
              lineNumberUtterance,
              lineUtterance,
              lineNumberAnnoation,
              lineAnnotation,
              string.Join(" ", text)));
      }

      if (layerWord != null)
        Save(
          dguid,
          layerWord,
          layerLemma,
          layerLemmaInfo,
          layerPos,
          layerPosInfo,
          layerPosPerson,
          layerCategory,
          speaker,
          comment,
          mod,
          action,
          sentenceEnd,
          parallelSpeech,
          inSentenceComment,
          original,
          speakerError,
          ref rules);
    }

    private IEnumerable<string> BuildFixes(string[] words, int i, out int pre, out int post)
    {
      // Einfaches Wort ersetzen
      if (words[i] == "[:")
      {
        pre = i - 1;
        var res = GetBracesContent(words, ref i);
        post = i + 1;
        return res;
      }

      var scorpus = 0;

      // Scorpusgrenze
      if (words[i] == "<" ||
          words[i].StartsWith("<"))
      {
        scorpus = i - 1;

        for (; i < words.Length; i++)
          if (words[i].EndsWith(">") ||
              words[i] == ">")
            break;
      }

      pre = scorpus;
      i++;

      // Lösche da Ausdruck wiederholt wird
      switch (words[i])
      {
        case "[/]":
        case "[//]":
          post = i + 1;
          return new string[0];
        case "[:":
          i = i + 1;
          var res = GetBracesContent(words, ref i);
          post = i + 1;
          return res;
        default:
          // Debug.WriteLine("[: -> " + words[i]);
          post = i;
          return new string[0];
      }
    }

    private static string CleanTextLine(string text)
    {
      text = text.Replace("\r", " ").Replace("\n", " ").Replace("(.)", " ").Replace("(..)", " ");

      while (text.Contains("  "))
        text = text.Replace("  ", " ");
      while (text.Contains("\t\t"))
        text = text.Replace("\t\t", "\t");
      text = text.Trim();
      return text;
    }

    private int[] Convert(string layerName, string[] arr, bool[] isValid, ref bool hasError)
    {
      var res = new int[isValid.Length];
      var j = 0;

      try
      {
        for (var i = 0; i < isValid.Length; i++)
          if (isValid[i])
          {
            var key = arr[j];
            res[i] = ConvertToLayer(layerName, key);
            j++;
          }
          else
          {
            res[i] = -1;
          }
      }
      catch (IndexOutOfRangeException)
      {
        for (var i = 0; i < res.Length; i++)
          res[i] = -1;

        hasError = true;
      }

      return res;
    }

    private int[] Convert(string layerName, string[] arr)
    {
      var res = new int[arr.Length];

      for (var i = 0; i < arr.Length; i++)
        res[i] = ConvertToLayer(layerName, arr[i]);

      return res;
    }

    private Dictionary<string, object> GenerateDictionary(
      string speaker,
      string comment,
      string but,
      string action,
      string sentenceEnd,
      string parallelSpeech,
      string inSentenceComment,
      string original,
      string speakerError,
      ref ClanChildesRule[] rules)
    {
      var res = _documentMetadataPrototyp.ToDictionary(entry => entry.Key, entry => entry.Value);
      var cnt = _counter++;
      res.Add("Sprecher", speaker);
      res.Add("Kommentar", comment);
      res.Add("Kommentar (im Satz)", inSentenceComment);
      res.Add("Satz ID", cnt);
      res.Add("Äußerungsmodus", but); // but -> nach Basic Utterance Terminator
      res.Add("Handlung", action);
      res.Add("Satzende", sentenceEnd);
      res.Add("Gleichzeitigkeit", parallelSpeech);
      res.Add("Original", original);
      res.Add("Titel", $"{_filename.Replace(".mor", "").Replace(".longtr", "").Replace(".cex", "")} - {cnt:00000}");
      res.Add("Fehler", speakerError);

      if (rules == null)
        return res;

      foreach (var r in from r in rules
                        where cnt >= r.SentenceIndexStart
                        where cnt <= r.SentenceIndexEnd
                        where !res.ContainsKey(r.MetaLabel)
                        select r)
        res.Add(r.MetaLabel, r.MetaValue);

      return res;
    }

    private static IEnumerable<string> GetBracesContent(string[] words, ref int i)
    {
      var res = new List<string>();

      i++;
      for (; i < words.Length; i++)
      {
        if (words[i].EndsWith("]"))
        {
          res.Add(words[i].Replace("]", ""));
          break;
        }

        res.Add(words[i]);
      }

      return res;
    }

    // ReSharper disable once RedundantAssignment
    private string[] ProcessText(
      string text,
      out bool[] valid,
      ref string[] categoryArray,
      ref string action,
      ref string sentenceEnd,
      ref string parallelSpeech,
      ref string inSentenceComment,
      ref string speakerError,
      ref string comment)
    {
      text = CleanTextLine(text);

      var words = text.Split(Splitter.Space, StringSplitOptions.RemoveEmptyEntries);
      var res = new List<string>();
      var isValid = new List<bool>();
      var category = new List<string>();

      // Fehlerniveau
      if (text.Contains("[/]"))
        speakerError += "[/]";
      if (text.Contains("[//]"))
        speakerError += "[//]";
      if (text.Contains("[:")) // ] muss fehlen, da die Syntax wie folgt lautet: [: koorektur xy z]
        speakerError += "[:]";
      if (text.Contains("[*]"))
        speakerError += "[*]";

      // Die Abfragen der einzelnen Levels dürfen nur innerhalb des Levels rangieren.

      for (var i = 0; i < words.Length; i++)
      {
        var word = words[i].Replace("(", "").Replace(")", "");

        // Level 1 - Bei derartigen Änderungen muss ALLES zurückgesetzt werden

        if (word == "<" ||
            word.StartsWith("<") ||
            word == "[:")
        {
          WordsPatch(i, ref words);

          res = new List<string>();
          isValid = new List<bool>();
          category = new List<string>();
          i = -1;

          continue;
        }

        // Level 2 - Einzelbereichskorrekturen

        if (i == 0 &&
            word.StartsWith("+"))
        {
          parallelSpeech = string.IsNullOrEmpty(parallelSpeech) ? word : parallelSpeech + " & " + word;
          isValid.Add(false);
          res.Add(word);
          continue;
        }

        if (word == "[?]" ||
            word == "[*]" ||
            word.StartsWith("&") ||
            word.StartsWith("#"))
        {
          isValid.Add(false);
          res.Add(word);
          continue;
        }

        switch (word)
        {
          case "[/]":
          case "[//]":
            res.RemoveAt(res.Count - 1);
            isValid.RemoveAt(isValid.Count - 1);
            continue;
          case "[=!":
            action = string.Join(" ", GetBracesContent(words, ref i));
            continue;
          case "[=?":
            comment = string.Join(" ", GetBracesContent(words, ref i));
            continue;
          case "[%":
            inSentenceComment = string.Join(" ", GetBracesContent(words, ref i));
            continue;
        }

        // Level 3 - Hinterlegen von Werten für den Kategorie-Layer

        if (word.Contains("@"))
        {
          var parts = word.Split(Splitter.At, StringSplitOptions.RemoveEmptyEntries);
          if (parts.Length == 2)
          {
            word = parts[0];
            category.Add(parts[1]);
          }
        }
        else
        {
          category.Add("");
        }

        // Level 4 - Satzende

        if (i == words.Length - 1) sentenceEnd = word;

        // Level 5 - Hinzufügen

        isValid.Add(true);
        res.Add(word);
      }

      categoryArray = category.ToArray();
      valid = isValid.ToArray();
      return res.ToArray();
    }

    private static void RestAllValues(
      out Guid dguid,
      out string comment,
      out string speaker,
      out string mod,
      out string action,
      out string sentenceEnd,
      out string parallelSpeech,
      out string inSentenceComment,
      out string original,
      out string speakerError,
      out string[] category,
      out bool[] isValid,
      out int[] layerWord,
      out int[] layerPos,
      out int[] layerPosInfo,
      out int[] layerPosPerson,
      out int[] layerLemma,
      out int[] layerLemmaInfo,
      out int[] layerCategory)
    {
      dguid = Guid.NewGuid();
      comment = "";
      speaker = "";
      mod = "";
      action = "";
      sentenceEnd = "";
      parallelSpeech = "";
      inSentenceComment = "";
      original = "";
      speakerError = "";
      category = null;
      isValid = null;
      layerWord = null;
      layerPos = null;
      layerPosInfo = null;
      layerPosPerson = null;
      layerLemma = null;
      layerLemmaInfo = null;
      layerCategory = null;
    }

    private void Save(
      Guid dguid,
      int[] layerWord,
      int[] layerLemma,
      int[] layerLemmaInfo,
      int[] layerPos,
      int[] layerPosInfo,
      int[] layerPosPerson,
      int[] layerCategory,
      string speaker,
      string comment,
      string mod,
      string action,
      string sentenceEnd,
      string parallelSpeech,
      string inSentenceComment,
      string original,
      string speakerError,
      ref ClanChildesRule[] rules)
    {
      // Speichern
      if (layerWord == null)
        return;

      AddDocument("Wort", dguid, new[] { layerWord });
      AddDocument("Lemma", dguid, new[] { layerLemma });
      AddDocument("Lemma-Info", dguid, new[] { layerLemmaInfo });
      AddDocument("POS", dguid, new[] { layerPos });
      AddDocument("POS-Info", dguid, new[] { layerPosInfo });
      AddDocument("POS-Person", dguid, new[] { layerPosPerson });
      AddDocument("@-Kategorie", dguid, new[] { layerCategory });
      AddDocumentMetadata(
        dguid,
        GenerateDictionary(
          speaker,
          comment,
          mod,
          action,
          sentenceEnd,
          parallelSpeech,
          inSentenceComment,
          original,
          speakerError,
          ref rules));
    }

    private void WordsPatch(int i, ref string[] words)
    {
      var fixes = BuildFixes(words, i, out var pre, out var post);

      var nWords = new List<string>();
      for (var j = 0; j < pre; j++)
        nWords.Add(words[j]);
      nWords.AddRange(fixes);
      for (var j = post; j < words.Length; j++)
        nWords.Add(words[j]);
      words = nWords.ToArray();
    }

    public class ClanChildesImportData
    {
      public ClanChildesRule[] Rules { get; set; }
      public string[] Text { get; set; }
    }
  }
}
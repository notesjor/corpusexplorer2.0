using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia;
using CorpusExplorer.Sdk.Extern.Wiki.Wiktionary.Model.Original;
using CorpusExplorer.Sdk.Extern.Wiki.Wiktionary.Model.Parsed;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Wiki.Wiktionary
{
  public static class WiktionaryParser
  {
    private static WikipediaCleanup _integratedWikiSyntaxCleanup = new WikipediaCleanup();

    public static void Parse(string inputXml, string outputDirectory)
    {
      using (var fs = new FileStream(inputXml, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      using (var reader = XmlReader.Create(bs))
        while (reader.Read())
        {
          if (reader.Name != "page")
            continue;

          try
          {
            var xml = reader.ReadOuterXml();

            if (xml.Contains("<redirect ") || xml.Contains("< redirect "))
              continue;

            page model;

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
              var serializer = new XmlSerializer(typeof(page));
              model = serializer.Deserialize(ms) as page;
              if (model == null || model.redirect != null || model.revision == null)
                continue;
            }

            var rev = model.revision;
            if (rev?.text?.Text == null)
              continue;

            if (string.Join("\r\n", rev.text.Text).Length < 250)
              continue;

            var fn = Path.Combine(outputDirectory, $"{model.id}.json");
            if (File.Exists(fn))
              continue;

            ThreadPool.QueueUserWorkItem((obj) =>
            {
              var data = obj as WorkItem;
              if (data == null)
                return;

              try
              {
                var lem = Parse(EnsureLineBreak(data.Lines));
                if (lem == null)
                  return;

                using (var fso = new FileStream(data.Path, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(fso))
                  writer.Write(JsonConvert.SerializeObject(lem));
              }
              catch (Exception ex)
              {
#if DEBUG
                WriteException(ex);
#endif
              }
            }, new WorkItem { Lines = rev.text.Text, Path = fn });
          }
          catch (Exception ex)
          {
#if DEBUG
            WriteException(ex);
#else
            InMemoryErrorConsole.Log(ex);
#endif
          }
        }

      while (true)
      {
        ThreadPool.GetMaxThreads(out var work, out _);
        ThreadPool.GetAvailableThreads(out var avail, out _);

        if (work == avail)
          break;

        Thread.Sleep(2000);
      }
    }

    private class WorkItem
    {
      public string[] Lines { get; set; }
      public string Path { get; set; }
    }

#if DEBUG
    private static void WriteException(Exception ex)
    {
      try
      {
        var list = new List<string>();
        list.Add(ex.Message);
        list.Add(ex.StackTrace);
        if (ex.InnerException != null)
        {
          list.Add("---");
          list.Add(ex.InnerException.Message);
          list.Add(ex.InnerException.StackTrace);
        }

        var text = string.Join("\r\n", list);
        string fn;
        using (var hsh = System.Security.Cryptography.MD5.Create())
          fn = $"{Convert.ToBase64String(hsh.ComputeHash(Encoding.UTF8.GetBytes(text)))}.err";

        fn = fn.Replace("+", "-").Replace("/", "_").Replace("=", "");

        if (File.Exists(fn))
          return;

        File.WriteAllLines(fn, list.ToArray(), Encoding.UTF8);
      }
      catch
      {
        // ignore
      }
    }
#endif

    private static string[] EnsureLineBreak(string[] lines)
    {
      var res = new List<string>();
      foreach (var line in lines)
        if (!string.IsNullOrWhiteSpace(line))
          res.AddRange(line.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries));
      return res.ToArray();
    }

    private static object Parse(string[] lines)
    {
      try
      {
        var i = 0;
        if (lines[i].StartsWith("{{")) // skip something like: {{Siehe auch|[[schiff]]}}
          i++;

        if (i >= lines.Length || !lines[i].StartsWith("== ") || !lines[i].Contains("|Deutsch}}")) // ensures the following format: == Schiff ({{Sprache|Deutsch}}) ==
          return null;

        var res = new Entry();

        var nxt = lines[i].Replace("==", "");
        var idx = nxt.IndexOf("(");
        res.Lemma = nxt.Substring(0, idx).Trim();

        i++;
        var spl = lines[i].Split(new[] { "|" }, StringSplitOptions.None); // extract the information from: === {{Wortart|Substantiv|Deutsch}}, {{n}} ===
        if (spl.Length > 1)
          res.POS = spl[1];
        if (spl.Length > 2 && spl[2].Contains(",")) // extract Genus-Information: Deutsch}}, {{n}} ===
        {
          idx = spl[2].IndexOf(",");
          nxt = spl[2].Substring(idx + 1).Replace("{", "").Replace("}", "").Replace("=", "").Replace(" ", "");
          if (nxt.Length == 1)
            res.Genus = nxt;
        }

        while (++i < lines.Length && !lines[i].StartsWith("}}")) // extract Form-Information (Wiktionary is a little bit buggy, but ok): |Dativ Singular=Schiff
        {
          if (!lines[i].StartsWith("|"))
            continue;

          // extract diffrent Wordforms: |Partizip II=geregelt
          spl = lines[i].Substring(1).Split(new[] { "=" }, StringSplitOptions.None);
          if (spl.Length == 2 && !spl[1].Contains("|"))
            res.Forms.Add(new Form { Label = spl[0], Token = spl[1] });
        }

        i++;
        for (; i < lines.Length; i++)
        {
          if (lines[i].StartsWith(":{{IPA}}")) // Extracts IPA-codes like: :{{IPA}} {{Lautschrift|ˈʁeːɡl̩n}}
            res.Ipa = lines[i].Replace(":{{IPA}}", "").Replace("{{Lautschrift|", "").Replace("}", "").Trim();

          if (lines[i].Contains("{{Worttrennung}}")) // Extract data from: :re·geln, {{Prät.}} re·gel·te, {{Part.}} ge·re·gelt
          {
            i++;
            if (lines[i].StartsWith(":"))
              ApplyHyphenation(ref res, lines[i].Substring(1));
          }

          if (lines[i].Contains("{{Bedeutungen}}"))
            break;
        }

        if (i >= lines.Length || !lines[i].Contains("{{Bedeutungen}}"))
          return null;
        i++;

        while (++i < lines.Length && lines[i].StartsWith(":[")) // Reconstruct Meanings like: :[2] etwas in einen gewünschten Zustand bringen, zum Beispiel ein Gerät
        {
          nxt = lines[i++].Substring(2);
          idx = nxt.IndexOf("]");

          if (int.TryParse(nxt.Substring(0, idx), out var id))
            res.Meanings.Add(new Meaning
            {
              Id = id,
              Definition = _integratedWikiSyntaxCleanup.ExecuteInline(nxt.Substring(idx + 1).Trim()).Trim()
            });
          else
            res.Meanings.Add(new Meaning
            {
              Id = -1,
              Definition = _integratedWikiSyntaxCleanup.ExecuteInline(nxt.Substring(idx + 1).Trim()).Trim()
            });
        }

        for (; i < lines.Length; i++)
        {
          if (lines[i].StartsWith("==") || lines[i].StartsWith("{{Referenzen}}") || lines[i].StartsWith("{{Quellen}}"))
            break;

          if (lines[i].Contains("{{Herkunft}}") || lines[i].Contains("{{Etymologie}}"))
          {
            i++;
            var ps = new List<string>();
            while (i < lines.Length && lines[i].StartsWith(":"))
              ps.Add(lines[i++].Substring(1));
            res.Etymology = _integratedWikiSyntaxCleanup.ExecuteInline(string.Join("\r\n", ps)).Trim();
          }

          if (i < lines.Length && lines[i].Contains("{{Sinnverwandte Wörter}}") || lines[i].Contains("{{Synonyme}}"))
            ApplyAlignedEntries(ref lines, ref i, false, res, (m) => m.Synonyms);

          if (i < lines.Length && lines[i].Contains("{{Gegenwörter}}") || lines[i].Contains("{{Antonyme}}"))
            ApplyAlignedEntries(ref lines, ref i, false, res, (m) => m.Antonyms);

          if (i < lines.Length && lines[i].Contains("{{Oberbegriffe}}") || lines[i].Contains("{{Hyperonyme}}"))
            ApplyAlignedEntries(ref lines, ref i, false, res, (m) => m.Hyperonyms);

          if (i < lines.Length && lines[i].Contains("{{Unterbegriffe}}") || lines[i].Contains("{{Hyponyme}}"))
            ApplyAlignedEntries(ref lines, ref i, false, res, (m) => m.Hyponyms);

          if (i < lines.Length && lines[i].Contains("{{Beispiele}}"))
            ApplyAlignedEntries(ref lines, ref i, true, res, (m) => m.Samples);

          if (i < lines.Length && lines[i].Contains("{{Redewendungen}}"))
            ApplyAlignedEntries(ref lines, ref i, true, res, (m) => m.Phrases);

          if (i < lines.Length && lines[i].Contains("{{Sprichwörter}}"))
            ApplyAlignedEntries(ref lines, ref i, true, res, (m) => m.Sayings);

          if (i < lines.Length && lines[i].Contains("{{Charakteristische Wortkombinationen}}"))
            ApplyAlignedEntries(ref lines, ref i, false, res, (m) => m.Cowords);
        }

        return res;
      }
      catch (Exception ex)
      {
#if DEBUG
        WriteException(ex);
#endif
        return null;
      }
    }

    private static List<string> CleanSampels(List<string> input)
      => (from item
            in input
          let idx = item.IndexOf("1\r\n\r\n")
          select idx > -1 ? item.Substring(0, idx) : item).ToList();

    private static Regex _applyAlignedEntriesAlternateNumbering = new Regex(@"[A-z]");

    private static void ApplyAlignedEntries(ref string[] lines, ref int i, bool getFulltext, Entry entry, Func<Meaning, List<string>> func)
    {
      foreach (var x in GetAlignedEntries(ref lines, ref i, getFulltext))
      {
        var found = false;

        if (x.Key == "*")
        {
          found = true;
          foreach (var m in entry.Meanings)
            func(m).AddRange(x.Value);
        }
        else if (x.Key.Contains("-"))
        {
          var spl = x.Key.Split('-');
          if (spl.Length != 2)
            continue;

          try
          {
            var start = int.Parse(_applyAlignedEntriesAlternateNumbering.Replace(spl[0], ""));
            var end = int.Parse(_applyAlignedEntriesAlternateNumbering.Replace(spl[1], ""));

            foreach (var m in entry.Meanings)
              if (m.Id >= start && m.Id <= end)
              {
                found = true;
                func(m).AddRange(x.Value);
              }
          }
          catch
          {
            // ignore > no found
          }
        }
        else
        {
          if (int.TryParse(_applyAlignedEntriesAlternateNumbering.Replace(x.Key, ""), out var idx))
            foreach (var m in entry.Meanings)
              if (m.Id == idx)
              {
                func(m).AddRange(x.Value);
                found = true;
              }
        }

        if (found)
          continue;

        var none = (from e in entry.Meanings where e.Id == -1 select e).FirstOrDefault();
        if (none == null)
        {
          none = new Meaning { Id = -1, Definition = "NONE" };
          entry.Meanings.Add(none);
        }

        func(none).AddRange(x.Value);
      }
    }

    private static Dictionary<string, List<string>> GetAlignedEntries(ref string[] lines, ref int i, bool getFulltext)
    {
      i++;
      // Sample: :[2] [[Bahn]], [[Gang]], [[Gleis]]
      // Result >>> Key = 2 / Value = {Bahn, Gang, Gleis}
      var res = new Dictionary<string, List<string>>();

      while (i < lines.Length && lines[i].StartsWith(":"))
      {
        var line = lines[i++].Substring(1);

        string key;
        List<string> values;
        if (line.Length > 0 && line[0] == '[' && line?.Substring(1)?.IndexOf("]") > -1)
        {
          line = line.Substring(1);
          var idx = line.IndexOf("]");
          key = line.Substring(0, idx);
          line = line.Substring(idx + 1);
          values = GetAlignedEntryValues(line, getFulltext);
        }
        else
        {
          key = "NONE";
          values = GetAlignedEntryValues(line, getFulltext);
        }

        if (res.ContainsKey(key))
          res[key].AddRange(values);
        else
          res.Add(key, values);
      }

      return res;
    }

    private static List<string> GetAlignedEntryValues(string line, bool getFulltext)
    {
      // getFulltext = true >>> :[2] Du bist schon auf dem richtigen ''Weg.''  >>> { "Du bist schon auf dem richtigen Weg." }
      // getFulltext = false >> :[3] [[Route]], [[Verbindung]], [[Zugang]]     >>> { "Route", "Verbindung", "Zugang" }

      return getFulltext
               ? new List<string>
               { _integratedWikiSyntaxCleanup.ExecuteInline(line.Replace("[", "").Replace("]", "").Trim()).Trim() }
               : _integratedWikiSyntaxCleanup.ExecuteInline(line).Split(new[] { "," }, StringSplitOptions.None)
                                             .Select(x => x.Replace("[", "").Replace("]", "").Trim()).ToList();
    }

    private static Regex _hyphenation = new Regex(@"\{{2}[\w\s.]*\}{2}");

    private static void ApplyHyphenation(ref Entry entry, string hyphenation)
    {
      var spl = hyphenation.Split(new[] { "," }, StringSplitOptions.None);
      var vrs = new Dictionary<string, string>();

      foreach (var s in spl)
      {
        var cur = _hyphenation.Replace(s, "").Replace("  ", " ").Trim();
        var nrm = cur.Replace("·", "");
        if (!vrs.ContainsKey(nrm))
          vrs.Add(nrm, cur);
      }

      foreach (var x in entry.Forms)
        if (vrs.ContainsKey(x.Token))
          x.Hyphenation = vrs[x.Token];
    }
  }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CorpusExplorer.Terminal.Console.Xml.Extensions;
using CorpusExplorer.Terminal.Console.Xml.Model;

namespace CorpusExplorer.Terminal.Automate
{
  public class AutomateViewModel
  {
    private cescript _script;

    public AutomateViewModel()
    {
      New();
    }

    public void New()
    {
      _script = new cescript
      {
        version = "1.0",
        head = new[]
        {
          new meta
          {
            key = "Projektname",
            Value = ""
          },
          new meta
          {
            key = "Kurzbeschreibung",
            Value = ""
          },
        },
        sessions = new sessions { mode = "asynchron", session = new session[0] }
      };
    }

    public void Load(string path)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        var se = new XmlSerializer(typeof(cescript));
        _script = se.Deserialize(fs) as cescript;
      }
    }

    public void Save(string path, string version, string sessionMode, KeyValuePair<string, string>[] metas)
    {
      Version = version;
      SessionMode = sessionMode;
      Metas = metas;

      var enc = Encoding.UTF8;

      var settings = new XmlWriterSettings
      {
        Encoding = enc,
        CheckCharacters = false,
        Indent = true,
      };

      string xml;
      using (var ms = new MemoryStream())
      using (var writer = XmlWriter.Create(ms, settings))
      {
        var se = new XmlSerializer(typeof(cescript));
        se.Serialize(writer, _script);
        xml = enc.GetString(ms.ToArray());
      }

      xml = xml.Replace("_x0020_", " ")
               .Replace("_x0021_", "!")
               .Replace("_x0023_", "#")
               .Replace("_x0025_", "%")
               .Replace("_x0026_", "&")
               .Replace("_x0028_", "(")
               .Replace("_x0029_", ")")
               .Replace("_x002A_", "*")
               .Replace("_x002B_", "+")
               .Replace("_x002C_", ",")
               .Replace("_x002E_", ".")
               .Replace("_x002D_", "-")
               .Replace("_x002F_", "/")
               .Replace("_x0022_", "\"")

               .Replace("_x0030_", "0")
               .Replace("_x0031_", "1")
               .Replace("_x0032_", "2")
               .Replace("_x0033_", "3")
               .Replace("_x0034_", "4")
               .Replace("_x0035_", "5")
               .Replace("_x0036_", "6")
               .Replace("_x0037_", "7")
               .Replace("_x0038_", "8")
               .Replace("_x0039_", "9")

               .Replace("_x003A_", ":")
               .Replace("_x003B_", ";")
               .Replace("_x003C_", "<")
               .Replace("_x003D_", "=")
               .Replace("_x003E_", ">")
               .Replace("_x003F_", "?")

               .Replace("_x005B_", "[")
               .Replace("_x005D_", "]")
               .Replace("_x005F_", "_")
               .Replace("_x007B_", "{")
               .Replace("_x007C_", "|")
               .Replace("_x007D_", "}")
               .Replace("_x007E_", "~")

               .Replace("_x00A7_", "§")
               .Replace("_x005C_", "/")
               .Replace("_x0040_", "@")
               .Replace("_x20AC_", "€")

               .Replace("﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
      File.WriteAllText(path, xml, enc);
    }

    public void Execute(string path) =>
      Process.Start(new ProcessStartInfo
      {
        FileName = "cec",
        Arguments = $"FILE:\"{path}\""
      })?.WaitForExit();

    public void Add(session newSession)
    {
      if (_script.sessions == null)
        _script.sessions = new sessions();

      _script.sessions.session = _script.sessions.session == null
                                   ? new[] { newSession }
                                   : _script.sessions.session.Concat(new[] { newSession }).ToArray();
    }

    public void Change(int pos, session session)
    {
      _script.sessions.session[pos] = session;
    }

    public void Delete(int pos)
    {
      var list = new List<session>(_script.sessions.session);
      list.RemoveAt(pos);
      _script.sessions.session = list.ToArray();
    }

    public IEnumerable<string> List()
      => _script.sessions?.session?.Select(x => $"Sources (mode=\"{x.sources?.processing}\"): {x.sources?.Items?.Length} | Queries: {x.queries?.Length} | Actions (mode=\"{x.actions?.mode}\"): {x.actions?.action?.Length}");

    public IEnumerable<KeyValuePair<string, string>> Metas
    {
      get => _script.head.meta().Select(x => new KeyValuePair<string, string>(x.key, x.Value));
      set => _script.head = value.Select(x => new meta { key = x.Key, Value = x.Value }).ToArray();
    }

    public string Version
    {
      get => _script.version;
      set => _script.version = value;
    }

    public string SessionMode
    {
      get => _script.sessions.mode;
      set => _script.sessions.mode = value;
    }

    public string Parallel
    {
      get => _script.sessions.parallel;
      set => _script.sessions.parallel = value;
    }

    public session Get(int index)
    {
      return _script.sessions.session[index];
    }
  }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        head = new meta[0],
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
      
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        var se = new XmlSerializer(typeof(cescript));
        se.Serialize(fs, _script);
      }
    }

    public void Execute(string path) =>
      Process.Start(new ProcessStartInfo
      {
        FileName = "cec",
        Arguments = $"FILE:\"{path}\""
      })?.WaitForExit();

    public void Add(session newSession)
    {
      _script.sessions.session = _script.sessions.session.Concat(new[] {newSession}).ToArray();
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
      => _script.sessions.session?.Select(x => $"Sources (mode=\"{x.sources?.processing}\"): {x.sources?.Items?.Length} | Queries: {x.queries?.Items?.Length} | Actions (mode=\"{x.actions?.mode}\"): {x.actions?.action?.Length}");

    public IEnumerable<KeyValuePair<string, string>> Metas
    {
      get => _script.head.meta().Select(x => new KeyValuePair<string, string>(x.key, x.Value));
      set => _script.head = value.Select(x => new meta {key = x.Key, Value = x.Value}).ToArray();
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

    public session Get(int index)
    {
      return _script.sessions.session[index];
    }
  }
}

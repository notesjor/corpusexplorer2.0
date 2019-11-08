using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CorpusExplorer.Terminal.Console.Xml.Model;

namespace CorpusExplorer.Terminal.Automate
{
  public class AutomateViewModel
  {
    private cescript _script;

    public void New()
    {
      _script = new cescript
      {
        version = (decimal)1.0,
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

    public void Save(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        var se = new XmlSerializer(typeof(cescript));
        se.Serialize(fs, _script);
      }
    }

    public void Execute(string path)
    {

    }

    public void LoadBasicInformation(out string version, 
                                     out Dictionary<string, string> meta, 
                                     out string sessionMode,
                                     out string[] sessions)
    {

    }

    public void SaveBasicInformation(string version,
                                     Dictionary<string, string> meta,
                                     string sessionMode)
    {

    }

    public void LoadSession(int sessionIndex,
                            out string sessionOverride,
                            out string sourcesProcessing,
                            out string[] sources,
                            out string[] queries, 
                            out string actionsMode,
                            out string[] actions)
    {

    }

    public void SaveSession(int sessionIndex,
                            string sessionOverride,
                            string sourcesProcessing,
                            string actionsMode)
    {

    }
  }
}

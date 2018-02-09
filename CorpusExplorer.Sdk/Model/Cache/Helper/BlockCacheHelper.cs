using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Model.Cache.Helper
{
  public class BlockCacheHelper
  {
    private Dictionary<string, object> _settings;

    public bool AbortCalculation(Dictionary<string, object> settings)
    {
      if (_settings == null)
      {
        _settings = settings;
        return false;
      }

      var abort = true;
      foreach (var x in settings)
        if (_settings.ContainsKey(x.Key))
        {
          if (_settings[x.Key].Equals(x.Value))
            continue;

          _settings[x.Key] = x.Value;
          abort = false;
        }
        else
        {
          _settings.Add(x.Key, x.Value);
          abort = false;
        }

      return abort;
    }
  }
}
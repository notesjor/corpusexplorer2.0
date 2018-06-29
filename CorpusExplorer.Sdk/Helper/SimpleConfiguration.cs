using CorpusExplorer.Sdk.Properties;

#region

using System;
using System.Collections.Generic;
using System.Configuration;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  [Serializable]
  public class SimpleConfiguration
  {
    private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

    public bool Exsists(params string[] path)
    {
      return _dictionary.ContainsKey(GetKey(path));
    }

    public T Get<T>(T defaultValue, params string[] path)
    {
      var key = GetKey(path);

      if (_dictionary.ContainsKey(key))
        return (T) _dictionary[key];

      Set(defaultValue, path);

      return defaultValue;
    }

    public Type GetSettingType(params string[] path)
    {
      var key = GetKey(path);

      return _dictionary.ContainsKey(key) ? _dictionary[key].GetType() : null;
    }

    public void Set(object value, params string[] path)
    {
      var key = GetKey(path);
      if (_dictionary.ContainsKey(key))
      {
        if (_dictionary[key].GetType() != value.GetType())
          throw new SettingsPropertyWrongTypeException(
            Resources.MetaDataTypeExcetion);
        _dictionary[key] = value;
      }
      else
      {
        _dictionary.Add(key, value);
      }
    }

    private static string GetKey(string[] path)
    {
      return string.Join("/", path);
    }
  }
}
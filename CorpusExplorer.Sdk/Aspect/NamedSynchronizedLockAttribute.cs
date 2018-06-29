#region

using System;
using System.Collections.Generic;
using PostSharp.Aspects;

#endregion

namespace CorpusExplorer.Sdk.Aspect
{
  [Serializable]
  public sealed class NamedSynchronizedLockAttribute : MethodInterceptionAspect
  {
    [NonSerialized] private static readonly Dictionary<string, string> Cache = new Dictionary<string, string>();

    private readonly string _name;

    public NamedSynchronizedLockAttribute(string name)
    {
      _name = name;
    }

    private NamedSynchronizedLockAttribute()
    {
    }

    public override void OnInvoke(MethodInterceptionArgs args)
    {
      if (!Cache.ContainsKey(_name))
        Cache.Add(_name, null);

      if (!string.IsNullOrEmpty(Cache[_name]))
        return;

      Cache[_name] = args.Method.Name;
      try
      {
        args.Invoke(args.Arguments);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }

      Cache[_name] = null;
    }
  }
}
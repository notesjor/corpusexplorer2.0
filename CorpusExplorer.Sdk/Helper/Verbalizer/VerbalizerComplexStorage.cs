using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper.Verbalizer
{
  public class VerbalizerComplexStorage
  {
    private Dictionary<string, Tuple<string, string>> _propertyInfo = new Dictionary<string, Tuple<string, string>>();

    public IEnumerable<string> PropertyNames => _propertyInfo.Keys;

    public Tuple<string, string> Get(string propertyName)
      => _propertyInfo.ContainsKey(propertyName) ? _propertyInfo[propertyName] : new Tuple<string, string>(propertyName, "");

    public void Add(string propertyName, string readableName, string description)
      => _propertyInfo.Add(propertyName, new Tuple<string, string>(readableName, description));
  }
}
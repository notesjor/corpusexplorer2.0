using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model
{
  [Serializable]
  public class UniversalStorage
  {
    [NonSerialized]
    private Dictionary<Selection, Dictionary<string, Dictionary<string, DataTable>>> _data =
      new Dictionary<Selection, Dictionary<string, Dictionary<string, DataTable>>>();

    private object _dataLock = new object();

    private Tuple<Selection, string, string, DataTable>[] _dataSerialized;

    public void Set(Selection selection, string method, string modification, DataTable dataTable)
    {
      if (dataTable == null || dataTable.Columns.Count == 0 || dataTable.Rows.Count == 0)
        return;

      lock (_dataLock)
      {
        if (!_data.ContainsKey(selection))
          _data.Add(selection, new Dictionary<string, Dictionary<string, DataTable>>());
        if (!_data[selection].ContainsKey(method))
          _data[selection].Add(method, new Dictionary<string, DataTable>());
        if (!_data[selection][method].ContainsKey(modification))
          _data[selection][method].Add(modification, dataTable);
        else
          _data[selection][method][modification] = dataTable;
      }
    }

    public bool Contains(Selection selection, string method, string modification)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection) && _data[selection].ContainsKey(method) && _data[selection][method].ContainsKey(modification);
    }

    public bool Contains(Selection selection, string method)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection) && _data[selection].ContainsKey(method);
    }

    public DataTable Get(Selection selection, string method, string modification)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection)
               ? (_data[selection].ContainsKey(method)
                    ? (_data[selection][method].ContainsKey(modification)
                         ? _data[selection][method][modification]
                         : null)
                    : null)
               : null;
    }

    public IEnumerable<Selection> AllSelections
    {
      get
      {
        lock (_dataLock)
          return _data.Keys;
      }
    }

    public IEnumerable<string> AllMethods()
    {
      lock (_dataLock)
        return new HashSet<string>(_data.SelectMany(x => x.Value.Keys));
    }

    public IEnumerable<string> AllModifications()
    {
      lock (_dataLock)
        return new HashSet<string>(from x in _data from y in x.Value from z in y.Value.Keys select z);
    }

    public IEnumerable<string> AllMethodsIn(Selection selection)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection) ? _data[selection].Keys : null;
    }

    public IEnumerable<string> AllModificationsIn(Selection selection)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection) ? new HashSet<string>(_data[selection].SelectMany(y => y.Value.Keys)) : null;
    }

    public IEnumerable<string> AllModificationsIn(Selection selection, string method)
    {
      lock (_dataLock)
        return _data.ContainsKey(selection)
               ? (_data[selection].ContainsKey(method)
                    ? _data[selection][method].Keys
                    : null)
               : null;
    }

    [OnSerializing]
    public void OnSerializing(StreamingContext context)
    {
      _dataSerialized = (from x in _data from y in x.Value from z in y.Value select new Tuple<Selection, string, string, DataTable>(x.Key, y.Key, z.Key, z.Value)).ToArray();
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _dataSerialized = new Tuple<Selection, string, string, DataTable>[0];
      _dataSerialized = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      _data = new Dictionary<Selection, Dictionary<string, Dictionary<string, DataTable>>>();
      if (_dataSerialized == null)
        return;

      foreach (var entry in _dataSerialized)
      {
        if (!_data.ContainsKey(entry.Item1))
          _data.Add(entry.Item1, new Dictionary<string, Dictionary<string, DataTable>>());
        if (!_data[entry.Item1].ContainsKey(entry.Item2))
          _data[entry.Item1].Add(entry.Item2, new Dictionary<string, DataTable>());
        if (!_data[entry.Item1][entry.Item2].ContainsKey(entry.Item3))
          _data[entry.Item1][entry.Item2].Add(entry.Item3, entry.Item4);
        else
          _data[entry.Item1][entry.Item2][entry.Item3] = entry.Item4;
      }

      OnSerialized(context);
    }
  }
}

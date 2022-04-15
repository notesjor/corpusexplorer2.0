using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.Helper
{
  public class ViewModelLayerDisplaynameMapper
  {
    private PropertyInfo[] _property;
    private readonly AbstractViewModel _mappedViewModel;

    public ViewModelLayerDisplaynameMapper(AbstractViewModel mappedViewModel, IEnumerable<string> propertyNames)
    {
      _mappedViewModel = mappedViewModel;

      var type = mappedViewModel.GetType();
      _property = propertyNames.Select(x => type.GetProperty(x)).ToArray();
    }

    public string[] MappedLayerDisplaynames
    {
      get
      {
        var lst = _property.Select(p => p.GetValue(_mappedViewModel)?.ToString())
                           .Where(x => !string.IsNullOrWhiteSpace(x))
                           .ToList();

        while(lst.Count < _property.Length)
          lst.Add(null);

        return lst.ToArray();
      }
      set
      {
        // CLEAN mappedViewModel
        foreach (var p in _property)
          p.SetValue(_mappedViewModel, null);

        // CLEAN value
        var names = value.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        // SET
        for (var i = 0; i < names.Length; i++)
          _property[i].SetValue(_mappedViewModel, names[i]);
      }
    }
  }
}

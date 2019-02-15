using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates.Model;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class FilterDescriptorCollectionHelper
  {
    public static FilterDescriptorCollection LoadColumnFilters(IEnumerable<FilterSetting> settings)
    {
      var res = new FilterDescriptorCollection();

      foreach (var setting in settings)
      {
        if (setting.Conditions       == null ||
            setting.Conditions.Count == 0    ||
            string.IsNullOrEmpty(setting.PropertyName))
          continue;

        if (setting.Conditions.Count == 1)
        {
          res.Add(
                  new FilterDescriptor
                  {
                    PropertyName = setting.PropertyName,
                    Operator = setting.Conditions.FirstOrDefault()?.Operator ?? FilterOperator.Contains,
                    Value = setting.Conditions.FirstOrDefault()?.Value,
                    IsFilterEditor = true
                  });
        }
        else
        {
          var compositeFilter = new CompositeFilterDescriptor
          {
            LogicalOperator = setting.LogicalOperator,
            NotOperator = setting.InvertFilter
          };
          foreach (var c in setting.Conditions)
            compositeFilter.FilterDescriptors.Add(new FilterDescriptor(setting.PropertyName, c.Operator, c.Value));

          res.Add(compositeFilter);
        }
      }

      return res;
    }

    public static IEnumerable<FilterSetting> SaveColumnFilters(RadGridView grid)
    {
      return SaveColumnFilters(grid.FilterDescriptors);
    }

    public static IEnumerable<FilterSetting> SaveColumnFilters(FilterDescriptorCollection collection)
    {
      return (from filter in collection
              where filter != null
              select new FilterSetting
              {
                PropertyName = filter.PropertyName,
                Conditions =
                  (filter as CompositeFilterDescriptor)?.FilterDescriptors.Select(GetFilterConditions).ToList() ??
                  new List<FilterConditions> {GetFilterConditions(filter)},
                InvertFilter = (filter as CompositeFilterDescriptor)?.NotOperator        ?? false,
                LogicalOperator = (filter as CompositeFilterDescriptor)?.LogicalOperator ?? FilterLogicalOperator.And
              }).ToList();
    }

    private static FilterConditions GetFilterConditions(FilterDescriptor filter)
    {
      return new FilterConditions
      {
        Operator = filter.Operator,
        Value = filter.Value
      };
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
using Telerik.WinControls.Data;
using Telerik.Windows.Controls.Data.DataFilter;
using Telerik.Windows.Data;
using CompositeFilterDescriptor = Telerik.WinControls.Data.CompositeFilterDescriptor;
using FilterDescriptor = Telerik.WinControls.Data.FilterDescriptor;
using FilterDescriptorCollection = Telerik.WinControls.Data.FilterDescriptorCollection;
using FilterOperator = Telerik.WinControls.Data.FilterOperator;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.QueryBuilder
{
  /// <summary>
  ///   Interaktionslogik für QueryBuilderControl.xaml
  /// </summary>
  public partial class QueryBuilderControl
  {
    private readonly Dictionary<FilterOperator, Telerik.Windows.Data.FilterOperator> _convert = new Dictionary
      <FilterOperator, Telerik.Windows.Data.FilterOperator>
      {
        {FilterOperator.Contains, Telerik.Windows.Data.FilterOperator.Contains},
        {FilterOperator.NotContains, Telerik.Windows.Data.FilterOperator.DoesNotContain},
        {FilterOperator.EndsWith, Telerik.Windows.Data.FilterOperator.EndsWith},
        {FilterOperator.IsContainedIn, Telerik.Windows.Data.FilterOperator.IsContainedIn},
        {FilterOperator.IsEqualTo, Telerik.Windows.Data.FilterOperator.IsEqualTo},
        {FilterOperator.IsGreaterThan, Telerik.Windows.Data.FilterOperator.IsGreaterThan},
        {FilterOperator.IsGreaterThanOrEqualTo, Telerik.Windows.Data.FilterOperator.IsGreaterThanOrEqualTo},
        {FilterOperator.IsLessThan, Telerik.Windows.Data.FilterOperator.IsLessThan},
        {FilterOperator.IsLessThanOrEqualTo, Telerik.Windows.Data.FilterOperator.IsLessThanOrEqualTo},
        {FilterOperator.IsNotContainedIn, Telerik.Windows.Data.FilterOperator.IsNotContainedIn},
        {FilterOperator.IsNotEqualTo, Telerik.Windows.Data.FilterOperator.IsNotEqualTo},
        {FilterOperator.IsNotNull, Telerik.Windows.Data.FilterOperator.IsNotNull},
        {FilterOperator.IsNull, Telerik.Windows.Data.FilterOperator.IsNull},
        {FilterOperator.StartsWith, Telerik.Windows.Data.FilterOperator.StartsWith}
      };

    public QueryBuilderControl()
    {
      XamlHighDpiExceptionHelper.Ensure(InitializeComponent);
    }

    public void Step_1_Initialize(Dictionary<string, Type> settings)
    {
      filter1.FilterDescriptors.Clear();
      filter1.ItemPropertyDefinitions.Clear();
      foreach (var setting in settings)
        filter1.ItemPropertyDefinitions.Add(new ItemPropertyDefinition(setting.Key, setting.Value));
    }

    public void Step_2_Load(FilterDescriptorCollection collection)
    {
      filter1.FilterDescriptors.Clear();
      foreach (var f in collection)
        filter1.FilterDescriptors.Add(ConvertRecursive(f));
    }

    public FilterDescriptorCollection Step_3_Save()
    {
      return new FilterDescriptorCollection {ConvertRecursive(filter1.ViewModel.CompositeFilter)};
    }

    private FilterOperator ConvertOperator(Telerik.Windows.Data.FilterOperator? @operator)
    {
      return (from o in _convert where o.Value == @operator select o.Key).FirstOrDefault();
    }

    private Telerik.Windows.Data.FilterOperator ConvertOperator(FilterOperator @operator)
    {
      return (from o in _convert where o.Key == @operator select o.Value).FirstOrDefault();
    }

    private IFilterDescriptor ConvertRecursive(FilterDescriptor f)
    {
      if (!(f is CompositeFilterDescriptor))
        return new Telerik.Windows.Data.FilterDescriptor(f.PropertyName, ConvertOperator(f.Operator), f.Value);

      var fca = (CompositeFilterDescriptor) f;
      var res = new Telerik.Windows.Data.CompositeFilterDescriptor
      {
        LogicalOperator =
          fca.LogicalOperator == FilterLogicalOperator.Or
            ? FilterCompositionLogicalOperator.Or
            : FilterCompositionLogicalOperator.And
      };
      foreach (var x in fca.FilterDescriptors)
        res.FilterDescriptors.Add(ConvertRecursive(x));
      return res;
    }

    private CompositeFilterDescriptor ConvertRecursive(CompositeFilterViewModel f)
    {
      var res = new CompositeFilterDescriptor
      {
        LogicalOperator =
          f.LogicalOperator == FilterCompositionLogicalOperator.Or
            ? FilterLogicalOperator.Or
            : FilterLogicalOperator.And
      };
      foreach (var x in f.Filters)
        res.FilterDescriptors.Add(ConvertRecursive(x));
      return res;
    }

    private FilterDescriptor ConvertRecursive(FilterViewModel f)
    {
      if (f.CompositeFilter               != null &&
          f.CompositeFilter.Filters.Count > 0)
        return ConvertRecursive(f.CompositeFilter);
      if (f.SimpleFilter != null)
        return new FilterDescriptor(
                                    f.SimpleFilter.Member,
                                    ConvertOperator(f.SimpleFilter.Operator),
                                    f.SimpleFilter.Value);
      return null;
    }

    private FilterDescriptor ConvertRecursive(IFilterDescriptor f)
    {
      if (f is Telerik.Windows.Data.FilterDescriptor fca)
        return new FilterDescriptor(fca.Member, ConvertOperator(fca.Operator), fca.Value);

      var fcb = f as Telerik.Windows.Data.CompositeFilterDescriptor;
      if (fcb == null)
        return null;

      var res = new CompositeFilterDescriptor
      {
        LogicalOperator =
          fcb.LogicalOperator == FilterCompositionLogicalOperator.Or
            ? FilterLogicalOperator.Or
            : FilterLogicalOperator.And
      };
      foreach (var x in fcb.FilterDescriptors)
        res.FilterDescriptors.Add(ConvertRecursive(x));

      return null;
    }
  }
}
#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter
{
  public static class QueryParser
  {
    private static AbstractFilterQuery BuildQuery(
      bool inverse,
      char type,
      string name,
      char oper,
      string values)
    {
      switch (type)
      {
        case 'M':
        case 'm':
          switch (oper)
          {
            case '?':
              return new FilterQueryMetaRegex
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
            case ':':
              return new FilterQueryMetaContainsCaseSensitive
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
            case '.':
              return new FilterQueryMetaContains
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
            case '=':
              return new FilterQueryMetaExactMatchCaseSensitive
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
            case '-':
              return new FilterQueryMetaExactMatch
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
            case '!':
              return new FilterQueryMetaIsEmpty
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] { values }
              };
          }
          return null;
        case 'T':
        case 't':
          switch (oper)
          {
            case '~':
              return new FilterQuerySingleLayerAnyMatch
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
              };
            case '-':
              return new FilterQuerySingleLayerAllInOnDocument
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
              };
            case '=':
              return new FilterQuerySingleLayerAllInOneSentence
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
              };
            case '§':
              return new FilterQuerySingleLayerExactPhrase
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
              };
          }
          return null;
        case 'X':
        case 'x':
          switch (oper)
          {
            case 'R':
              return new FilterQueryUnsupportedParserFeature
              {
                Inverse = inverse,
                MetaLabel = "<:RANDOM:>",
                MetaValues = new[] {values}
              };
            case 'S':
              return new FilterQueryUnsupportedParserFeature
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = new[] {values}
              };
          }
          break;
      }

      return null;
    }

    public static string Serialize(AbstractFilterQuery query)
    {
      return query.OrFilterQueries != null && query.OrFilterQueries.Any()
               ? $"({SerializeEntry(query)}|{string.Join("|", query.OrFilterQueries.Select(SerializeEntry))})"
               : SerializeEntry(query);
    }

    private static string SerializeEntry(AbstractFilterQuery query)
    {
      var inv = query.Inverse ? "!" : "";
      string key, value;

      if (query is AbstractFilterQueryMeta)
      {
        key = ((AbstractFilterQueryMeta)query).MetaLabel;
        value = ((AbstractFilterQueryMeta)query).MetaValues.FirstOrDefault()?.ToString();

        if (query is FilterQueryMetaRegex)
          return
            $"{inv}M?{key}::{value}";

        if (query is FilterQueryMetaContains)
          return
            $"{inv}M.{key}::{value}";

        if (query is FilterQueryMetaContainsCaseSensitive)
          return
            $"{inv}M:{key}::{value}";

        if (query is FilterQueryMetaExactMatch)
          return
            $"{inv}M-{key}::{value}";

        if (query is FilterQueryMetaExactMatchCaseSensitive)
          return
            $"{inv}M={key}::{value}";

        if (query is FilterQueryMetaIsEmpty)
          return
            $"{inv}M!{key}::{value}";
      }
      if (query is AbstractFilterQuerySingleLayer)
      {
        key = ((AbstractFilterQuerySingleLayer)query).LayerDisplayname;
        value = string.Join(";", ((AbstractFilterQuerySingleLayer)query).LayerQueries);

        if (query is FilterQuerySingleLayerAnyMatch)
          return
            $"{inv}T~{key}::{value}";
        if (query is FilterQuerySingleLayerAllInOnDocument)
          return
            $"{inv}T-{key}::{value}";
        if (query is FilterQuerySingleLayerAllInOneSentence)
          return
            $"{inv}T={key}::{value}";
      }
      return query is FilterQuerySingleLayerExactPhrase
               ? $"{inv}T§{((FilterQuerySingleLayerExactPhrase)query).LayerDisplayname}::{string.Join(";", (FilterQuerySingleLayerExactPhrase)query)}"
               : null;
    }

    public static AbstractFilterQuery Parse(string query)
    {
      // Wenn keine OR-Gruppe vorliegt
      if (query[0] != '(')
        return ParseEntry(query);

      // Baue OR-Gruppe auf
      var entries = query.Substring(1, query.Length - 2)
                         .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries)
                         .Select(x => x.Trim())
                         .ToArray();
      var master = ParseEntry(entries[0]);
      if (master == null)
        return null;

      var orQueries = new List<AbstractFilterQuery>();
      for (var i = 1; i < entries.Length; i++)
      {
        var tmp = ParseEntry(entries[i]);
        if (tmp != null)
          orQueries.Add(ParseEntry(entries[i]));
      }
      master.OrFilterQueries = orQueries;
      return master;
    }

    private static AbstractFilterQuery ParseEntry(string query)
    {
      var invert = query[0] == '!';
      var type = invert ? query[1] : query[0];
      var oper = invert ? query[2] : query[1];
      var indx = query.IndexOf("::", StringComparison.InvariantCulture);
      var name = query.Substring(invert ? 3 : 2, indx - (invert ? 3 : 2)).Trim();
      var vals = query.Substring(indx + 2).Trim();

      return BuildQuery(invert, type, name, oper, vals);
    }
  }
}
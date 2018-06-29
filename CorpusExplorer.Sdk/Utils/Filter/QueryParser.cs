#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter
{
  public static class QueryParser
  {
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

    public static string Serialize(AbstractFilterQuery query)
    {
      return query.OrFilterQueries != null && query.OrFilterQueries.Any()
        ? $"({SerializeEntry(query)}|{string.Join("|", query.OrFilterQueries.Select(SerializeEntry))})"
        : SerializeEntry(query);
    }

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
                MetaValues = DeserializeMetaValues(values)
              };
            case ':':
              return new FilterQueryMetaContainsCaseSensitive
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case '.':
              return new FilterQueryMetaContains
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case '=':
              return new FilterQueryMetaExactMatchCaseSensitive
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case '-':
              return new FilterQueryMetaExactMatch
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case '(':
              return new FilterQueryMetaStartsWith
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case ')':
              return new FilterQueryMetaEndsWith
              {
                Inverse = inverse,
                MetaLabel = name,
                MetaValues = DeserializeMetaValues(values)
              };
            case '!':
              return new FilterQueryMetaIsEmpty
              {
                Inverse = inverse,
                MetaLabel = name
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
                LayerQueries = values.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries)
              };
            case '-':
              return new FilterQuerySingleLayerAllInOnDocument
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries)
              };
            case '=':
              return new FilterQuerySingleLayerAllInOneSentence
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries)
              };
            case '§':
              return new FilterQuerySingleLayerExactPhrase
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries)
              };
            case '1':
              return new FilterQuerySingleLayerFirstAndAnyOtherMatch
              {
                Inverse = inverse,
                LayerDisplayname = name,
                LayerQueries = values.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries)
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
            case 'C':
              return new FilterQueryUnsupportedParserFeature
              {
                Inverse = false,
                MetaLabel = "<:CORPUS:>",
                MetaValues = null
              };
          }

          break;
      }

      return null;
    }

    private static string[] DeserializeMetaValues(string values)
    {
      if (values[0] == '"' && values[values.Length - 1] == '"')
        values = values.Substring(1, values.Length - 2);
      return new[] {values.Replace("''", "\"")};
    }

    private static AbstractFilterQuery ParseEntry(string query)
    {
      var invert = query[0] == '!';
      var type = invert ? query[1] : query[0];
      var oper = invert ? query[2] : query[1];
      var indx = query.IndexOf("::", StringComparison.InvariantCulture);
      var name = indx == -1 ? query : query.Substring(invert ? 3 : 2, indx - (invert ? 3 : 2)).Trim();
      var vals = indx == -1 ? null : query.Substring(indx + 2).Trim();

      return BuildQuery(invert, type, name, oper, vals);
    }

    private static string SerializeEntry(AbstractFilterQuery query)
    {
      var inv = query.Inverse ? "!" : "";
      string value;

      switch (query)
      {
        case AbstractFilterQueryMeta q:
          value = q.MetaValues.FirstOrDefault()?.ToString();
          if (!string.IsNullOrEmpty(value))
          {
            value = value.Replace("\"", "''");
            if (value.Contains(" "))
              value = $"\"{value}\"";
          }

          switch (query)
          {
            case FilterQueryMetaRegex _:
              return
                $"{inv}M?{q.MetaLabel}::{value}";
            case FilterQueryMetaContains _:
              return
                $"{inv}M.{q.MetaLabel}::{value}";
            case FilterQueryMetaContainsCaseSensitive _:
              return
                $"{inv}M:{q.MetaLabel}::{value}";
            case FilterQueryMetaExactMatch _:
              return
                $"{inv}M-{q.MetaLabel}::{value}";
            case FilterQueryMetaExactMatchCaseSensitive _:
              return
                $"{inv}M={q.MetaLabel}::{value}";
            case FilterQueryMetaIsEmpty _:
              return
                $"{inv}M!{q.MetaLabel}";
            case FilterQueryMetaStartsWith _:
              return
                $"{inv}M({q.MetaLabel}::{value}";
            case FilterQueryMetaEndsWith _:
              return
                $"{inv}M){q.MetaLabel}::{value}";
          }

          break;
        case AbstractFilterQuerySingleLayer q:
          value = string.Join(";", q.LayerQueries);

          switch (query)
          {
            case FilterQuerySingleLayerAnyMatch _:
              return
                $"{inv}T~{q.LayerDisplayname}::{value}";
            case FilterQuerySingleLayerAllInOnDocument _:
              return
                $"{inv}T-{q.LayerDisplayname}::{value}";
            case FilterQuerySingleLayerAllInOneSentence _:
              return
                $"{inv}T={q.LayerDisplayname}::{value}";
          }

          break;
        case FilterQuerySingleLayerExactPhrase q:
          return $"{inv}T§{q.LayerDisplayname}::{string.Join(";", q.LayerQueries)}";
        case FilterQuerySingleLayerFirstAndAnyOtherMatch q:
          return $"{inv}T1{q.LayerDisplayname}::{string.Join(";", q.LayerQueries)}";
      }

      return null;
    }
  }
}
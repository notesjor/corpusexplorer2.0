﻿using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Helper
{
  public static class AutoSplitBlockHelper
  {
    public static IEnumerable<Selection> RunAutoSplit(Selection selection, FilterQueryUnsupportedParserFeature query,
                                                      object[] values)
    {
      var block = selection.CreateBlock<SelectionClusterBlock>();
      var split = values[0].ToString().Split(Splitter.Semicolon, StringSplitOptions.RemoveEmptyEntries).ToList();
      if (split.Count < 1 || split.Count > 4)
        return null;

      var window = 0;
      if (split[0].StartsWith("WINDOW"))
      {
        window = int.Parse(split[0].Replace("WINDOW", ""));
        split.RemoveAt(0);
      }

      switch (split[0])
      {
        case "TEXT":
        case "text":
        case "Text":
          block.ClusterGenerator = new SelectionClusterGeneratorStringValue();
          break;
        case "INT":
        case "int":
        case "Int":
          if (split.Count != 2)
            return null;
          block.ClusterGenerator = new SelectionClusterGeneratorIntegerRange
          {
            Ranges = int.Parse(split[1]),
            AutoDetectMinMax = true
          };
          break;
        case "FLOAT":
        case "float":
        case "Float":
          block.ClusterGenerator = new SelectionClusterGeneratorDoubleRange
          {
            Ranges = int.Parse(split[1]),
            AutoDetectMinMax = true
          };
          break;
        case "DATE":
        case "date":
        case "Date":
          switch (split[1])
          {
            case "CLUSTER":
              if (split.Count != 3)
                return null;
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeRange
              {
                Ranges = int.Parse(split[2]),
                AutoDetectMinMax = true
              };
              break;
            case "CEN":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeCentury();
              break;
            case "DEC":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeDecade();
              break;
            case "Y":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYear();
              break;
            case "YW":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearWeek();
              break;
            case "YQ":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearQuarter();
              break;
            case "YM":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearMonth();
              break;
            case "YMD":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearMonthDay();
              break;
            case "YMDH":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearMonthDayHour();
              break;
            case "YMDHM":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearMonthDayHourMinute();
              break;
            case "ALL":
              block.ClusterGenerator = new SelectionClusterGeneratorDateTime();
              break;
          }

          break;
      }

      block.MetadataKey = query.MetaLabel;
      block.Calculate();

      return window > 1 ? block.GetSelectionClustersWindowed(window) : block.GetSelectionClusters();
    }
  }
}
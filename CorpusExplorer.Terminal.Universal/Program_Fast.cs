using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tfres;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using System.Net.Sockets;

namespace CorpusExplorer.Terminal.Universal
{
  public partial class Program
  {
    private static Selection _fast_selection = null;
    private static CeDictionaryMemoryFriendly<double> _fast_coocCache = null;
    private static Guid _fast_coocCacheSelection = Guid.Empty;

    private static Selection Fast_Selection
    {
      get
      {
        if (_fast_selection == null)
          Fast_Selection = _terminal.Project.SelectAll;

        return _fast_selection;
      }
      set
      {
        Fast_Selection = value;

        try
        {
          _server.SendToAll("update");
        }
        catch
        {
          // ignore
        }
      }
    }

    private static void FastNormData(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(new
        {
          Corpora = 0,
          Documents = 0,
          Sentences = 0,
          Tokens = 0
        });
        return;
      }

      try
      {
        var getData = context.GetData();
        var select = "all"; // select kann auch Y, YM oder YMD sein.
        if (getData.ContainsKey("selection"))
          select = getData["selection"];

        if (select == "all")
        {
          context.Response.Send(new
          {
            Corpora = Fast_Selection.CountCorpora,
            Documents = Fast_Selection.CountDocuments,
            Sentences = Fast_Selection.CountSentences,
            Tokens = Fast_Selection.CountToken
          });
        }
        else
        {
          var meta = "Datum";
          if (getData.ContainsKey("date-meta"))
            meta = getData["date-meta"];

          var block = Fast_Selection.CreateBlock<SelectionClusterBlock>();
          block.ClusterGenerator = GetFastCluster(select); // select ist Y, YM oder YMD.
          block.MetadataKey = meta;
          block.Calculate();

          var info = "simple";
          if (getData.ContainsKey("info"))
            info = getData["info"];

          if (info == "full")
          {
            var dict = new Dictionary<string, object>();
            foreach (var x in block.SelectionClusters)
            {
              var s = Fast_Selection.CreateTemporary(x.Value);
              dict.Add(x.Key, new
              {
                Corpora = s.CountCorpora,
                Documents = s.CountDocuments,
                Sentences = s.CountSentences,
                Tokens = s.CountToken
              });
            }

            context.Response.Send(dict);
          }
          else
          {
            context.Response.Send(block.SelectionClusters.ToDictionary(x => x.Key, x => Fast_Selection.CreateTemporary(x.Value).CountToken));
          }
        }
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastCount(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      try
      {
        var vm = GetFastTLS(GetFastQuery(context.GetData()));

        context.Response.Send(new
        {
          Corpora = vm.ResultCountCorpora,
          Documents = vm.ResultCountDocuments,
          Sentences = vm.ResultCountSentences,
          Tokens = vm.ResultCountTokens
        });
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastKwic(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      try
      {
        var vm = GetFastTLS(GetFastQuery(context.GetData()));

        using (var ms = new MemoryStream())
        {
          var tw = new JsonTableWriter { Path = "", WriteTid = false, OutputStream = context.Response.GetChunkedOutputStream("application/json") };
          tw.WriteTable(vm.GetDataTable());
          context.Response.SendFinalChunk();
        }
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastFulltext(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      try
      {
        var getData = context.GetData();
        var guid = Guid.Parse(getData["guid"]);
        var sentence = -1;
        if (getData.ContainsKey("sentence"))
          sentence = int.Parse(getData["sentence"]);
        var from = sentence;
        var to = sentence;
        if (getData.ContainsKey("from"))
          from = int.Parse(getData["from"]);
        if (getData.ContainsKey("to"))
          to = int.Parse(getData["to"]);

        if (from == to && from == -1)
          context.Response.Send(Fast_Selection.GetReadableMultilayerDocument(guid));
        else
          context.Response.Send(Fast_Selection.GetReadableMultilayerDocument(guid, from, to));
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastCooccurrences(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      try
      {
        var getData = context.GetData();
        var query = getData["q"];

        if(_fast_coocCacheSelection != Fast_Selection.Guid)
        {
          _fast_coocCache = null;
          _fast_coocCacheSelection = Fast_Selection.Guid;
        }

        if (_fast_coocCache == null)
        {
          var block = Fast_Selection.CreateBlock<CooccurrenceBlock>();
          block.Calculate();

          _fast_coocCache = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionaryMemoryFriendly();

          block.CooccurrenceFrequency.Clear();
          block.CooccurrenceSignificance.Clear();
          block = null;
          GC.Collect();
        }

        if (_fast_coocCache.ContainsKey(query))
        {
          context.Response.Send(_fast_coocCache[query]);
          return;
        }
        else
          context.Response.Send(HttpStatusCode.NotFound);
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastTimeline(HttpContext context)
    {
      if (Fast_Selection == null)
      {
        context.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      try
      {
        var getData = context.GetData();
        AbstractFilterQuery query = GetFastQuery(getData);
        var date = "YM";
        if (getData.ContainsKey("date"))
          date = getData["date"];
        var meta = "Datum";
        if (getData.ContainsKey("date-meta"))
          meta = getData["date-meta"];

        var preSelection = Fast_Selection.CreateTemporary(query);

        var block = preSelection.CreateBlock<SelectionClusterBlock>();
        block.ClusterGenerator = GetFastCluster(date);
        block.MetadataKey = meta;
        block.Calculate();

        var info = "simple";
        if (getData.ContainsKey("info"))
          info = getData["info"];

        if (info == "full")
        {
          var res = new Dictionary<string, object>();
          foreach (var x in block.SelectionClusters)
          {
            var s = Fast_Selection.CreateTemporary(x.Value);
            var vm = GetFastTLS(query, s);
            res.Add(x.Key, new
            {
              Corpora = vm.ResultCountCorpora,
              Documents = vm.ResultCountDocuments,
              Sentences = vm.ResultCountSentences,
              Tokens = vm.ResultCountTokens
            });
          }
          context.Response.Send(res);
        }
        else
        {
          var res = new Dictionary<string, int>();
          foreach (var x in block.SelectionClusters)
          {
            var s = Fast_Selection.CreateTemporary(x.Value);
            var vm = GetFastTLS(query, s);
            res.Add(x.Key, vm.ResultCountTokens);
          }
          context.Response.Send(res);
        }
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastSnapshop(HttpContext context)
    {
      try
      {
        var data = context.Request.PostDataAsString;
        if (string.IsNullOrWhiteSpace(data))
        {
          Fast_Selection = _terminal.Project.SelectAll;
          context.Response.Send(HttpStatusCode.OK);
          return;
        }

        var query = QuerySystemHelper.ConvertToQuery(data);
        Fast_Selection = _terminal.Project.SelectAll.CreateTemporary(query);
        context.Response.Send(HttpStatusCode.OK);
      }
      catch
      {
        context.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void FastSubscribe(HttpContext context)
    {
      try
      {
        var socket = context.GetWebSocket();
        if (socket == null)
          return;

        socket.KeepOpenAndRecive(context, (msg) =>
        {
          // ignore msg from client
        }).Wait();
      }
      catch
      {
        // ignore
      }
    }

    #region PRIVATE

    private static AbstractSelectionClusterGenerator GetFastCluster(string date)
    {
      switch (date)
      {
        case "C":
          return new SelectionClusterGeneratorDateTimeCentury();
        case "Y":
          return new SelectionClusterGeneratorDateTimeYear();
        default: // YM
          return new SelectionClusterGeneratorDateTimeYearMonth();
        case "YMD":
          return new SelectionClusterGeneratorDateTimeYearMonthDay();
      }
    }

    private static AbstractFilterQuery GetFastQuery(Dictionary<string, string> getData)
    {
      var q = getData["q"].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

      AbstractFilterQuery query = null;
      if (q.Length > 1)
      {
        query = new FilterQuerySingleLayerExactPhrase
        {
          LayerDisplayname = "Wort",
          LayerQueries = q
        };
      }
      else
      {
        query = new FilterQuerySingleLayerAnyMatch
        {
          LayerDisplayname = "Wort",
          LayerQueries = q
        };
      }

      return query;
    }

    private static TextLiveSearchViewModel GetFastTLS(AbstractFilterQuery query, Selection select = null)
    {
      var vm = new TextLiveSearchViewModel { Selection = select == null ? Fast_Selection : select };
      vm.AddQuery(query);
      vm.Execute();
      return vm;
    }

    #endregion
  }
}

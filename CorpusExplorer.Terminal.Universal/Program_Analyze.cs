﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Terminal.Universal.Message.Request.Analyze;
using CorpusExplorer.Terminal.Universal.TableWriter;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void Analyze(HttpContext obj)
    {
      var request = obj.Request.PostData<RequestAnalyze>();
      var action = Configuration.GetConsoleAction(request.Action);
      if (action == null)
      {
        obj.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      var tw = new DirectJsonTableWriter(obj);
      action.Execute(_terminal.Project.CurrentSelection, request.Arguments, tw);
      tw.Destroy(false);

      obj.Response.SendFinalChunk();
    }
  }
}
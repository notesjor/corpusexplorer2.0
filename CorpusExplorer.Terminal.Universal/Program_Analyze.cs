using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Terminal.Universal.Message.Request.Analyze;
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

      var parameter = obj.Request.GetData();
      var format = parameter.ContainsKey("f") ? parameter["f"] : "json";

      AbstractTableWriter tw = null;

      switch (format)
      {
        default:
          tw = new JsonTableWriter();
          break;
        case "JSONR":
          tw = new JsonRoundedTableWriter();
          break;
        case "CSV":
          tw = new CsvTableWriter();
          break;
        case "TSV":
          tw = new TsvTableWriter();
          break;
        case "TSVR":
          tw = new TsvRoundedTableWriter();
          break;
        case "TRTD":
          tw = new HtmlTableSnippetTableWriter();
          break;
        case "HTML":
          tw = new HtmlTableWriter();
          break;
        case "XML":
          tw = new XmlTableWriter();
          break;
        case "SQL":
          tw = new SqlTableWriter();
          break;
      }

      // Prepare TableWriter
      tw.Path = "";
      tw.WriteTid = parameter.ContainsKey("tid") && parameter["tid"] == "true";
      tw.OutputStream = obj.Response.GetChunkedOutputStream(tw.MimeType);

      action.Execute(_terminal.Project.CurrentSelection, request.Arguments, tw);
      tw.Destroy(false);

      obj.Response.SendFinalChunk();
    }
  }
}

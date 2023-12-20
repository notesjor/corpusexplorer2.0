using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Terminal.Universal.Message.Response.Size;
using CorpusExplorer.Terminal.Universal.Message.Response.Snapshot;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void SelectionNew(HttpContext obj)
    {
      throw new NotImplementedException();
    }

    private static void SelectionReduce(HttpContext obj)
    {
      throw new NotImplementedException();
    }

    private static void SelectionInfo(HttpContext obj)
    {
      obj.Response.Send(Convert_Selection(_terminal.Project.Selections.ToList()));
    }

    private static ResponseSnapshot[] Convert_Selection(IEnumerable<Selection> selections)
    {
      if (selections == null || !selections.Any())
        return null;

      return selections.Select(Convert_Selection).ToArray();
    }

    private static ResponseSnapshot Convert_Selection(Selection selection)
    {
      var layers = new HashSet<string>(selection.LayerDisplaynames);

      return new ResponseSnapshot
      {
        Guid = selection.Guid,
        Name = Translate(selection.Displayname),
        Children = Convert_Selection(selection.SubSelections),
        Size = new ResponseSize
        {
          Corpora = selection.CountCorpora,
          Documents = selection.CountDocuments,
          Layers = layers.Count,
          Tokens = selection.CountToken
        },
        LayerNames = layers,
        IsActive = selection == _terminal.Project.CurrentSelection
      };
    }

    private static void SelectionGuids(HttpContext obj)
    {
      obj.Response.Send(_terminal.Project.CurrentSelection.DocumentGuids);
    }

    private static void SelectionMeta(HttpContext obj)
    {
      var guid = Guid.Parse(obj.Request.GetData()["guid"]);
      if (guid == Guid.Empty)
      {
        obj.Response.Send(HttpStatusCode.NotFound);
        return;
      }
      obj.Response.Send(_terminal.Project.CurrentSelection.GetDocumentMetadata(guid));
    }

    private static void SelectionChange(HttpContext obj)
    {
      var guid = Guid.Parse(obj.Request.GetData()["guid"]);
      if (guid == Guid.Empty)
      {
        obj.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      var selection = _terminal.Project.SelectionsRecursive.FirstOrDefault(x => x.Guid == guid);
      if (selection == null)
      {
        obj.Response.Send(HttpStatusCode.NotFound);
        return;
      }

      _terminal.Project.CurrentSelection = selection;
    }
  }
}

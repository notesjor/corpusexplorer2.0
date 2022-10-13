using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model;
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
      var selections = _terminal.Project.Selections.ToList();
      selections.Insert(0, _terminal.Project.SelectAll);

      obj.Response.Send(Convert_Selection(selections));
    }

    private static ResponseSnapshot[] Convert_Selection(IEnumerable<Selection> selections)
    {
      if(selections == null || !selections.Any())
        return null;

      return selections.Select(selection => new ResponseSnapshot
      {
        Guid = selection.Guid, 
        Name = selection.Displayname,
        Children = Convert_Selection(selection.SubSelections),
        Size = new ResponseSize
        {
          Corpora = selection.CountCorpora, 
          Documents = selection.CountDocuments, 
          Layers = new HashSet<string>(selection.LayerDisplaynames).Count, 
          Tokens = selection.CountToken
        }
      }).ToArray();
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

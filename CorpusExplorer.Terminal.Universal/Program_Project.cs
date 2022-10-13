using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Terminal.Universal.Message.Request.File;
using CorpusExplorer.Terminal.Universal.Message.Response.Size;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void ProjectNew(HttpContext obj)
    {
      _terminal.ProjectNew();
      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectSave(HttpContext obj)
    {
      var path = obj.Request.PostData<RequestFileSingle>()?.Path;
      _terminal.Project.Save(path, false);
      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectLoad(HttpContext obj)
    {
      var path = obj.Request.PostData<RequestFileSingle>()?.Path;
      _terminal.ProjectLoad(path, Path.GetDirectoryName(path));
      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectSettings(HttpContext obj)
    {
      throw new NotImplementedException();
    }

    private static void ProjectInfo(HttpContext obj)
    {
      obj.Response.Send(new ResponseSize
      {
        Corpora = _terminal.Project.CountCorpora,
        Documents = _terminal.Project.CountDocuments,
        Tokens =  _terminal.Project.CountToken,
        Layers = new HashSet<string>(_terminal.Project.LayerDisplaynames).Count
      });
    }
  }
}

#region

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Port.TreeTaggerTrainer.Model
{
  public static class Traindata
  {
    public static string Create(Selection selection, string layerDisplayname)
    {
      var res = new StringBuilder();
      var @lock = new object();

      Parallel.ForEach(
                       selection.DocumentGuids,
                       Configuration.ParallelOptions,
                       tguid =>
                       {
                         var text = new StringBuilder();
                         var wl = selection.GetLayerOfDocument(tguid, "Wort");
                         var tl = selection.GetLayerOfDocument(tguid, layerDisplayname);

                         if (wl == null ||
                             tl == null)
                           return;

                         string[][] wdoc, tdoc;
                         try
                         {
                           wdoc = wl.GetReadableDocumentByGuid(tguid).Select(x => x.ToArray()).ToArray();
                           tdoc = tl.GetReadableDocumentByGuid(tguid).Select(x => x.ToArray()).ToArray();
                         }
                         catch
                         {
                           return;
                         }

                         try
                         {
                           for (var i = 0; i < wdoc.Length; i++)
                           {
                             if (wdoc[i] == null)
                               continue;
                             for (var j = 0; j < wdoc[i].Length; j++)
                             {
                               if (string.IsNullOrEmpty(wdoc[i][j]) ||
                                   string.IsNullOrEmpty(tdoc[i][j]))
                                 continue;

                               text.AppendFormat("{0}\t{1}\r\n", wdoc[i][j], tdoc[i][j]);
                             }
                           }
                         }
                         catch
                         {
                           return;
                         }

                         lock (@lock)
                         {
                           res.AppendLine(text.ToString());
                         }
                       });

      return res.ToString();
    }
  }
}
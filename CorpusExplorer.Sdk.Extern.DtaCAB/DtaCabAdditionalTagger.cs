using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Helper;
using RestSharp;

namespace CorpusExplorer.Sdk.Extern.DtaCAB
{
  public class DtaCabAdditionalTagger : AbstractAdditionalTagger
  {
    public override string DisplayName => "DTA::CAB";
    protected override void Cleanup()
    {
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      return ApplyAnnoation(corpus, MakeWebRequests(MakeWebRequestClusters(GenerateDocs(corpus))));
    }

    private IEnumerable<AbstractLayerState> ApplyAnnoation(AbstractCorpusAdapter corpus, List<KeyValuePair<Guid[], string>> makeWebRequests)
    {
      if (makeWebRequests == null)
        return null;

      var layer = corpus.GetLayers("Wort").FirstOrDefault()?.ToLayerState("DTA::CAB", 2, true);
      if (layer == null)
        return null;

      if (makeWebRequests.All(x => string.IsNullOrEmpty(x.Value)))
      {
        MessageBox.Show("Der DTA::CAB-Webservice scheint nicht erreichbar. Das können Sie tun:\n1. Überprüfen Sie ihre Internetverbindung.\n2. Überprüfen Sie, ob die Webseite http://www.deutschestextarchiv.de/demo/cab/ erreichbar ist.\n3. Kontaktieren Sie die Entwickler http://CorpusExplorer.de", "Fehler DTA::CAB-Webservice nicht verfügbar", MessageBoxButtons.OK);
        return null;
      }

      var error = false;
      foreach (var webRequest in makeWebRequests)
      {
        if (string.IsNullOrEmpty(webRequest.Value))
        {
          error = true;
          continue;
        }

        var docs = webRequest.Value.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
        if (docs.Length != webRequest.Key.Length)
        {
          error = true;
          continue;
        }

        for (int i = 0; i < docs.Length; i++)
        {
          var doc = docs[i].Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(new[] { "\t" }, StringSplitOptions.None)).ToArray();

          if (!layer.ChangeCompleteDocument(webRequest.Key[i], doc, false))
            error = true;
        }
      }

      if (error)
        MessageBox.Show("Der DTA:CAB-Webservice konnte nicht alle Dokumente normalisieren. Das können Sie tun:\n1. Stellen Sie eine sicher, dass eine stabile Internetverbindung besteht.\n2. Möglicherweise ist der Webservice überlastet. Bitte probieren Sie es zu einem späteren Zeitpunkt erneut.\n3.  Kontaktieren Sie die Entwickler http://CorpusExplorer.de", "Fehler DTA::CAB nicht alle Dokumente wurden normalisiert.", MessageBoxButtons.OK);

      return new[] { layer };
    }

    private List<KeyValuePair<Guid[], string>> MakeWebRequests(List<KeyValuePair<Guid[], string>> clusters)
    {
      if (clusters == null)
        return null;

      var cnt = 0;
      var res = new List<KeyValuePair<Guid[], string>>();
      var ses = Guid.NewGuid().ToString("N");

      foreach (var cluster in clusters)
      {
        cnt++;
        if (cnt % 100 == 0)
          Thread.Sleep(5000);

        try
        {
          var client = new RestClient("http://www.deutschestextarchiv.de/demo/cab-ce-plugin/query?fmt=ceplugin");
          var request = new RestRequest(Method.POST);
          request.AddHeader("Client", "CorpusExplorer v2.0");
          request.AddHeader("Session", ses);
          request.AddHeader("cache-control", "no-cache");
          request.AddHeader("Content-Type", "text/plain");
          request.AddParameter("undefined", cluster.Value, ParameterType.RequestBody);
          res.Add(new KeyValuePair<Guid[], string>(cluster.Key, client.Execute(request).Content));
        }
        catch
        {
          res.Add(new KeyValuePair<Guid[], string>(cluster.Key, null));
        }
      }

      return res;
    }

    private List<KeyValuePair<Guid[], string>> MakeWebRequestClusters(Dictionary<Guid, string> docs)
    {
      if (docs == null)
        return null;

      var res = new List<KeyValuePair<Guid[], string>>();
      var stb = new StringBuilder();
      var lst = new List<Guid>();

      foreach (var doc in docs)
      {
        if (stb.Length + doc.Value.Length > DtaCabValidator.MaxSingleTextLength)
        {
          res.Add(new KeyValuePair<Guid[], string>(lst.ToArray(), stb.ToString()));
          stb.Clear();
          lst.Clear();
        }

        lst.Add(doc.Key);
        stb.Append("\n");
        stb.Append(doc.Value);
      }

      if (lst.Count > 0)
        res.Add(new KeyValuePair<Guid[], string>(lst.ToArray(), stb.ToString()));

      return res;
    }

    private Dictionary<Guid, string> GenerateDocs(AbstractCorpusAdapter corpus)
    {
      if (!DtaCabValidator.RuleCorpus(corpus.CountDocuments))
      {
        DisplayError(DtaCabValidator.ErrorRuleCorpus);
        return null;
      }

      var layer = corpus.GetLayers("Wort").FirstOrDefault();
      if (layer == null)
        return null;

      var sum = 0;
      var docs = new Dictionary<Guid, string>();
      foreach (var dsel in corpus.DocumentGuids)
      {
        var doc = layer.GetReadableDocumentByGuid(dsel);
        var stb = new StringBuilder();

        foreach (var s in doc)
        {
          stb.Append(string.Join("\t", s));
          stb.Append("\n");
        }

        var text = stb.ToString();
        if (!DtaCabValidator.RuleSingleTextLength(text.Length))
        {
          DisplayError(DtaCabValidator.ErrorRuleSingleTextLength);
          return null;
        }

        sum += text.Length;
        if (!DtaCabValidator.RuleCorpusLength(sum))
        {
          DisplayError(DtaCabValidator.ErrorRuleCorpusLength);
          return null;
        }

        docs.Add(dsel, stb.ToString());
      }
      return docs;
    }

    private void DisplayError(string message)
    {
      MessageBox.Show(string.Format(DtaCabValidator.ErrorTemplate, message), "Fehler", MessageBoxButtons.OK);
    }

    protected override void Initialize()
    {
    }
  }
}

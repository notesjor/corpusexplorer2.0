#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using RestSharp;

#endregion

namespace CorpusExplorer.Sdk.Extern.DtaCAB
{
  public class DtaCabAdditionalTagger : AbstractAdditionalTagger
  {
    public override string DisplayName => "DTA::CAB";

    private IEnumerable<AbstractLayerState> ApplyAnnoation(AbstractCorpusAdapter corpus,
                                                           Dictionary<Guid, string> documents)
    {
      if (documents == null)
        return null;

      var layer = corpus.GetLayers("Wort").FirstOrDefault()?.ToLayerState("DTA::CAB", 2, true);
      if (layer == null)
        return null;

      if (documents.All(x => string.IsNullOrEmpty(x.Value)))
      {
        MessageBox.Show("Der DTA::CAB-Webservice scheint nicht erreichbar. Das können Sie tun:\n1. Überprüfen Sie ihre Internetverbindung.\n2. Überprüfen Sie, ob die Webseite http://www.deutschestextarchiv.de/demo/cab/ erreichbar ist.\n3. Kontaktieren Sie die Entwickler http://CorpusExplorer.de",
                        "Fehler DTA::CAB-Webservice nicht verfügbar", MessageBoxButtons.OK);
        return null;
      }

      var error = false;
      foreach (var document in documents)
      {
        if (string.IsNullOrEmpty(document.Value))
        {
          error = true;
          continue;
        }

        var doc = document.Value.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(s => s.Split(new[] { "\t" }, StringSplitOptions.None)).ToArray();

        if (!layer.ChangeCompleteDocument(document.Key, doc, false))
          error = true;
      }

      if (error)
        MessageBox.Show("Der DTA:CAB-Webservice konnte nicht alle Dokumente normalisieren. Das können Sie tun:\n1. Stellen Sie eine sicher, dass eine stabile Internetverbindung besteht.\n2. Möglicherweise ist der Webservice überlastet. Bitte probieren Sie es zu einem späteren Zeitpunkt erneut.\n3.  Kontaktieren Sie die Entwickler http://CorpusExplorer.de",
                        "Fehler DTA::CAB nicht alle Dokumente wurden normalisiert.", MessageBoxButtons.OK);

      return new[] { layer };
    }

    protected override void Cleanup()
    {
    }

    private void DisplayError(string message)
    {
      MessageBox.Show(string.Format(DtaCabValidator.ErrorTemplate, message), "Fehler", MessageBoxButtons.OK);
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus) =>
      ApplyAnnoation(corpus, MakeWebRequests(MakeWebRequestClusters(GenerateDocs(corpus))));

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
      var res = new Dictionary<Guid, string>();
      foreach (var dsel in corpus.DocumentGuids)
      {
        var doc = layer.GetReadableDocumentByGuid(dsel);
        var stb = new StringBuilder();

        foreach (var s in doc)
        {
          var sent = s?.Select(x => x.Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "")).ToArray();
          if (sent == null || sent.Length < 0 || string.Join("", sent).Length < 1)
            continue;
          stb.Append(string.Join("\t", sent));
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

        res.Add(dsel, stb.ToString());
      }

      return res;
    }

    protected override void Initialize()
    {
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

    private Dictionary<Guid, string> MakeWebRequests(List<KeyValuePair<Guid[], string>> clusters)
    {
      if (clusters == null)
        return null;

      var cnt = 0;
      var res = new Dictionary<Guid, string>();
      var ses = Guid.NewGuid().ToString("N");

      foreach (var cluster in clusters)
      {
        cnt++;
        if (cnt % 100 == 0)
          Thread.Sleep(5000);

        try
        {
          var client = new RestClient("http://www.deutschestextarchiv.de/demo/cab-ce-plugin/query?fmt=ceplugin");
          var request = new RestRequest();
          request.AddHeader("Client", "CorpusExplorer v2.0");
          request.AddHeader("Session", ses);
          request.AddHeader("cache-control", "no-cache");
          request.AddHeader("Content-Type", "text/plain");
          request.AddParameter("undefined", cluster.Value, ParameterType.RequestBody);

          var response = client.PostAsync(request);
          response.Wait();

          var text = response.Result.Content;
          if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException(nameof(text));

          var split = text.Split(new[] { "\n\n\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                          .ToArray();
          if (split.Length != cluster.Key.Length)
            throw new IndexOutOfRangeException();

          for (var i = 0; i < split.Length; i++)
            res.Add(cluster.Key[i], split[i]);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);

          foreach (var guid in cluster.Key)
            res.Add(guid, null);
        }
      }

      return res;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Db;
using Diskursmonitor.Sdk.Model;
using Diskursmonitor.Sdk.Model.Webservice;
using Tfres;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var server = new Server("212.224.95.216", 9191, DefaultRoute);
      server.AddEndpoint(HttpVerb.GET, "/thesaurus", RequestOpenThesaurus);

      while (true)
      {
        var command = Console.ReadLine();
        if (command == "quit" || command == "exit")
          break;
      }

      server.Dispose();
    }

    private static HttpResponse RequestOpenThesaurus(HttpRequest arg)
    {
      var get = arg.GetData();
      if (get == null || !get.ContainsKey("query"))
        return new HttpResponse(arg, false, 503, null, null, null);

      var thesaurus = OpenThesaurusConnection.Open();
      var query = get["query"];

      var lemma = (from x in thesaurus.Terms where x.Word == query select x).FirstOrDefault();
      if (lemma == null)
        return new HttpResponse(arg, false, 503, null, null, null);

      var idHyper = 1;
      var idAssoz = 2;

      var synset = (from x in thesaurus.Synsets where x.Id == lemma.SynsetId select x).FirstOrDefault();
      var antonyms = from x in thesaurus.TermLinks where x.TermId == lemma.Id || x.TargetTermId == lemma.Id select x;
      var hyperonyms =
        new HashSet<string>((from x in thesaurus.SynsetLinks
                             where x.LinkTypeId == idHyper && x.SynsetId == synset.Id
                             select x).Select(x => x.SynsetTarget).SelectMany(x => x.Terms).Select(x => x.Word));
      var hyponyms =
        new HashSet<string>((from x in thesaurus.SynsetLinks
                             where x.LinkTypeId == idHyper && x.TargetSynsetId == synset.Id
                             select x).Select(x => x.SynsetTarget).SelectMany(x => x.Terms).Select(x => x.Word));

      var resSynset = synset?.Terms == null ? new[] {get["query"]} : (from x in synset.Terms select x.Word).ToArray();
      var resAntonyms =
        (from x in antonyms
         select new LexicalReference
           {Direction = "<>", Entity = x.TermSource.Word == query ? x.TermTarget.Word : x.TermSource.Word}).ToArray();
      var resHyper =
        (from x in hyperonyms select new LexicalReference {Direction = "<", Entity = string.Join(", ", x)}).ToArray();
      var resHypo =
        (from x in hyponyms select new LexicalReference {Direction = ">", Entity = string.Join(", ", x)}).ToArray();

      return new HttpResponse(arg, true, 200, null, "application/json", new LexicalResponse
      {
        Synset = resSynset,

        Antonyms = resAntonyms,
        Hyperonyms = resHyper,
        Hyponyms = resHypo
      });
    }

    private static string JoinAssos(OpenThesaurusContext context, Synset a, Synset b)
    {
      var list = (from x in context.Synsets where x.Id == a.Id select x)
                .SelectMany(x => x.Terms).Select(x => x.Word).ToList();
      list.AddRange((from x in context.Synsets where x.Id == b.Id select x)
                   .SelectMany(x => x.Terms).Select(x => x.Word));
      var res = new HashSet<string>(list);
      return string.Join(", ", res);
    }

    private static HttpResponse DefaultRoute(HttpRequest arg)
    {
      return new HttpResponse(arg, false, 503, null, null, null);
    }
  }
}
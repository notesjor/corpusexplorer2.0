using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Db;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService.Model;
using Diskursmonitor.Sdk;
using Diskursmonitor.Sdk.WebService.Abstract;
using Diskursmonitor.Sdk.WebService.Configuration;
using Microsoft.OpenApi.Models;
using Tfres;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService
{
  public class OpenThesaurusService : AbstractEasyWebService<EasyWebServiceConfiguration>
  {
    protected override void ConfigureEndpoints(Server server)
    {
      server.AddEndpoint(HttpVerb.POST, "/metric", RequestOpenThesaurus);
    }

    protected override void LoadAdditionalConfiguration(EasyWebServiceConfiguration config)
    {
    }

    protected override void LoadData()
    {
    }

    protected override OpenApiDocument GetDocumentation()
    {
      return new OpenApiDocument
      {
        Paths = new OpenApiPaths
        {
          {
            "/metric", new OpenApiPathItem
            {
              Operations = new Dictionary<OperationType, OpenApiOperation>
              {
                {
                  OperationType.Post, new OpenApiOperation
                  {
                    Description = "Liefert Informationen zu einem Lemma.",
                    Parameters = new List<OpenApiParameter>
                    {
                      new OpenApiParameter
                      {
                        Name = "query", In = ParameterLocation.Query, Required = true,
                        Description = "Lemma",
                        Schema = new OpenApiSchema{Type = "string"}
                      }
                    },
                    Responses = new OpenApiResponses
                    {
                      {"200", new OpenApiResponse {Description = "Informationen zum Lemma"}}
                    }
                  }
                }
              }
            }
          }
        }
      };
    }

    private Task RequestOpenThesaurus(HttpContext arg)
    {
      try
      {
        var data = arg.PostData<LexicalRequest>();

        var thesaurus = OpenThesaurusConnection.Open();
        var lemma = (from x in thesaurus.Terms where x.Word == data.Query select x).FirstOrDefault();
        if (lemma == null)
          return arg.Response.Send(HttpStatusCode.InternalServerError);

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

        var resSynset = synset?.Terms == null ? new[] {data.Query} : (from x in synset.Terms select x.Word).ToArray();
        var resAntonyms =
          (from x in antonyms
           select new LexicalReference
             {Direction = "<>", Entity = x.TermSource.Word == data.Query ? x.TermTarget.Word : x.TermSource.Word})
         .ToArray();
        var resHyper =
          (from x in hyperonyms select new LexicalReference {Direction = "<", Entity = string.Join(", ", x)}).ToArray();
        var resHypo =
          (from x in hyponyms select new LexicalReference {Direction = ">", Entity = string.Join(", ", x)}).ToArray();

        return arg.Response.Send(new LexicalResponse
        {
          Synset = resSynset,

          Antonyms = resAntonyms,
          Hyperonyms = resHyper,
          Hyponyms = resHypo
        });
      }
      catch
      {
        return arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }
  }
}

using CorpusExplorer.Sdk._3rdParty.Commercial.Metaphone3.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static AbstractFilterQuery[] _queries = new AbstractFilterQuery[]
    {
      new FilterQueryDocumentGuid(),
      new FilterQueryMetaContains(),
      new FilterQueryMetaContainsCaseSensitive(),
      new FilterQueryMetaEndsWith(),
      new FilterQueryMetaExactMatch(),
      new FilterQueryMetaExactMatchCaseSensitive(),
      new FilterQueryMetaIsEmpty(),
      new FilterQueryMetaRegex(),
      new FilterQueryMetaStartsWith(),
      new FilterQueryMultiLayerAll(),
      new FilterQueryMultiLayerAny(),
      new FilterQueryMultiLayerComplex(),
      new FilterQueryMultiLayerPhrase(),
      new FilterQuerySingleLayerAFollowedByBMatch(),
      new FilterQuerySingleLayerAFollowedByBSpanMatch(),
      new FilterQuerySingleLayerAllInExactSpanWords(),
      new FilterQuerySingleLayerAllInOneDocument(),
      new FilterQuerySingleLayerAllInOneSentence(),
      new FilterQuerySingleLayerAllInSpanSentences(),
      new FilterQuerySingleLayerAllInSpanWords(),
      new FilterQuerySingleLayerAlternativePhrase(),
      new FilterQuerySingleLayerAnyMatch(),
      new FilterQuerySingleLayerExactPhrase(),
      new FilterQuerySingleLayerFirstAndAnyOtherMatch(),
      new FilterQuerySingleLayerFirstFollowedByAnyOtherMatch(),
      new FilterQuerySingleLayerMarkedPhrase(),
      new FilterQuerySingleLayerRanked(),
      new FilterQuerySingleLayerRegex(),
      new FilterQuerySingleLayerRegexFulltext(),
      new FilterQuerySingleLayerFuzzy()
    };

    private static string _operators = null;

    private static void GetOperators(HttpContext obj)
    {
      if (_operators == null)
      {
        _operators = JsonConvert.SerializeObject(_queries, new JsonSerializerSettings
        {
          TypeNameHandling = TypeNameHandling.Objects,
          ContractResolver = new IgnorePropertiesResolver()
        });
      }

      obj.Response.Send(_operators);
    }

    private static AbstractFilterQuery ConvertRequestToQuery(HttpRequest request)
    {
      throw new NotImplementedException();
    }

    private class IgnorePropertiesResolver : DefaultContractResolver
    {
      private static HashSet<string> _ignore = new HashSet<string> { "Guid", "OrFilterQueries", "Verbal" };

      protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
      {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (_ignore.Contains(property.PropertyName))
          property.ShouldSerialize = instance => false;

        return property;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Json.Abstract;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy
{
  public class SpeedyScraper : AbstractGenericJsonFormatScraper<Model.Speedy>
  {
    public override string DisplayName => "SPEEDy";
    protected override AbstractGenericDataReader<Model.Speedy> DataReader { get; } = new SpeedyDataReader();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<Model.Speedy> model)
      => from x in model select new Dictionary<string, object> { { "Text", x.Text } };
  }
}

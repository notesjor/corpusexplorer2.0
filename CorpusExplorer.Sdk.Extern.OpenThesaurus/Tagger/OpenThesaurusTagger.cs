using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Parser;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.Tagger
{
  public class OpenThesaurusTagger : AbstractAdditionalTagger
  {
    private Dictionary<string, string> _index;
    public override string DisplayName => "OpenThesaurus";

    protected override void Cleanup()
    {
      _index.Clear();
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      var old = corpus.GetLayers("Wort").First();
      var gen = new LayerValueState("OpenThesaurus", corpus.Layers.Count() + 1);
      var loc = new object();
      Parallel.ForEach(corpus.DocumentGuids, dsel =>
      {
        var oldd = old[dsel];
        var newd = oldd.Select(sen => sen.Select(w => old[w])
                                         .Select(oldw => _index.ContainsKey(oldw) ? _index[oldw] : oldw)
                                         .ToArray()).ToArray();
        lock (loc)
        {
          gen.AddCompleteDocument(dsel, newd);
        }
      });

      return new[] {gen};
    }

    protected override void Initialize()
    {
      using (var model = OpenThesaurusParser.Read(Configuration.GetDependencyPath("OpenThesaurus/openthesaurus.txt")))
      {
        _index = model.ReverseEntries.ToDictionary(x => x.Key, x => x.Value.First());
      }
    }
  }
}
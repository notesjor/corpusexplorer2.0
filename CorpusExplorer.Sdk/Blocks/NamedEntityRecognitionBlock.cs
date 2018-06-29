using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class NamedEntityRecognitionBlock : AbstractBlock
  {
    public NamedEntityRecognition.Model Model { get; set; }

    public override void Calculate()
    {
      if (Model == null)
        return;

      var lock1 = new object();
      DetectedEntities = new Dictionary<string, Dictionary<Guid, HashSet<int>>>();

      Parallel.ForEach(Model.Entities, Configuration.ParallelOptions, entity =>
      {
        var lock2 = new object();
        var count = new Dictionary<Guid, HashSet<int>>();

        Parallel.ForEach(entity.Rules, Configuration.ParallelOptions, rule =>
        {
          var sub = Selection.CreateTemporary(new[] { rule.Filter });
          var sen = sub.GetSelectedSentences();

          lock (lock2)
            foreach (var s in sen)
            {
              if (count.ContainsKey(s.Key))
                foreach (var x in s.Value)
                  count[s.Key].Add(x);
              else
                count.Add(s.Key, new HashSet<int>(s.Value));
            }
        });

        lock (lock1)
          if (DetectedEntities.ContainsKey(entity.Name))
            foreach (var x in count)
              if (DetectedEntities[entity.Name].ContainsKey(x.Key))
                foreach (var y in x.Value)
                  DetectedEntities[entity.Name][x.Key].Add(y);
              else
                DetectedEntities[entity.Name].Add(x.Key, x.Value);
          else
            DetectedEntities.Add(entity.Name, count);
      });
    }

    public Dictionary<string, Dictionary<Guid, HashSet<int>>> DetectedEntities { get; set; }
  }
}

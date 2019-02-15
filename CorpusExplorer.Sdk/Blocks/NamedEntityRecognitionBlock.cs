using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.NamedEntityRecognition;

namespace CorpusExplorer.Sdk.Blocks
{
  public class NamedEntityRecognitionBlock : AbstractBlock
  {
    public NamedEntityRecognition.Model Model { get; set; }

    public Dictionary<Entity, HashSet<Guid>> DetectedEntities { get; set; }

    public override void Calculate()
    {
      if (Model == null)
        return;

      DetectedEntities = new Dictionary<Entity, HashSet<Guid>>();

      foreach (var entity in Model.Entities)
      {
        var count = new HashSet<Guid>();

        foreach (var rule in entity.Rules)
        {
          var sub = Selection.CreateTemporary(new[] {rule.Filter});
          if (sub == null || sub.CountDocuments == 0)
            continue;

          foreach (var dsel in sub.DocumentGuids)
            count.Add(dsel);
        }

        if (count.Count == 0)
          continue;

        DetectedEntities.Add(entity, count);
      }
    }
  }
}
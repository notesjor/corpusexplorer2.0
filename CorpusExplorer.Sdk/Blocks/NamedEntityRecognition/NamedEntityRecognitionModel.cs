#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#endregion

namespace CorpusExplorer.Sdk.Blocks.NamedEntityRecognition
{
  [XmlRoot]
  [Serializable]
  public class NamedEntityRecognitionModel
  {
    [XmlAttribute]
    public string Displayname { get; set; }

    [XmlArray]
    public Entity[] Entities { get; set; }

    private static NamedEntityRecognitionModel CompileModel(string path)
    {
      var lines = FileIO.ReadLines(path, Configuration.Encoding);
      var entities = new List<Entity>();

      for (var i = 1; i < lines.Length; i++)
      {
        var split = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length < 3)
          continue;

        var entity = new Entity { Name = split[0] };

        var rules = new List<Rule>
        {
          NewRule(1.0,
                  new FilterQuerySingleLayerExactPhrase
                  {
                    LayerDisplayname = "Wort",
                    LayerQueries = split[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  })
          /*
          NewRule(0.8, new FilterQuerySingleLayerAnyMatch
          {
            LayerDisplayname = "Wort",
            LayerQueries = new[] { split[2] }
          })
          */
        };

        if (split.Length == 4)
        {
          var query = new List<string> { split[2] };
          query.AddRange(split[3].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
          rules.Add(NewRule(1.0,
                            new FilterQuerySingleLayerFirstAndAnyOtherMatch
                              { LayerDisplayname = "Wort", LayerQueries = query.ToArray() }));
        }

        entity.Rules = rules.ToArray();
        entities.Add(entity);
      }

      return new NamedEntityRecognitionModel
        { Displayname = Path.GetFileNameWithoutExtension(path), Entities = entities.ToArray() };
    }

    public static NamedEntityRecognitionModel Load(string path) =>
      path.EndsWith(".cner") ? Serializer.Deserialize<NamedEntityRecognitionModel>(path) : CompileModel(path);

    private static Rule NewRule(double rank, AbstractFilterQuery query) => new Rule { Rank = rank, Filter = query };

    public void Save(string path)
    {
      Serializer.Serialize(this, path, false);
    }
  }
}
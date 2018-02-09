#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Layer;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Terminal;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Test
{
  /// <summary>
  ///   The silly corpus exploration test.
  /// </summary>
  [TestClass]
  public class SillyCorpusExplorationTest
  {
    /// <summary>
    ///   The _selection.
    /// </summary>
    private readonly Selection _selection;

    /// <summary>
    ///   The _terminal controler.
    /// </summary>
    private readonly TerminalController _terminalController = CorpusExplorerEcosystem.Initialize();

    /// <summary>
    ///   Initializes a new instance of the <see cref="SillyCorpusExplorationTest" /> class.
    /// </summary>
    public SillyCorpusExplorationTest()
    {
      var d1Guid = Guid.NewGuid();
      var d2Guid = Guid.NewGuid();
      var d3Guid = Guid.NewGuid();

      var wort = new LayerValueState("Wort", 0);
      wort.AddCompleteDocument(
        d1Guid,
        new[]
        {
          new[] {"As", "As", "B", "As", "Cs", "Cs", "B"},
          new[] {"As", "As", "B", "As", "Cs", "Cs", "B"},
          new[] {"As", "As", "B", "As", "Cs", "Cs", "B"},
          new[] {"As", "As", "B", "As", "Cs", "Cs", "B"},
          new[] {"As", "As", "B", "As", "Cs", "Cs", "B"}
        });
      wort.AddCompleteDocument(
        d2Guid,
        new[]
        {
          new[] {"B", "Cs", "B", "As", "As", "Cs", "B"},
          new[] {"B", "As", "B", "Cs", "Cs", "As", "B"},
          new[] {"B", "As", "B", "Cs", "Cs", "As", "B"},
          new[] {"B", "As", "B", "Cs", "Cs", "As", "B"},
          new[] {"B", "As", "B", "Cs", "Cs", "As", "B"}
        });
      wort.AddCompleteDocument(
        d3Guid,
        new[]
        {
          new[] {"As", "As", "B", "As", "As", "As", "B"},
          new[] {"As", "Cs", "Cs", "Cs", "As", "Cs", "B"},
          new[] {"As", "Cs", "Cs", "Cs", "As", "Cs", "B"},
          new[] {"As", "Cs", "Cs", "Cs", "As", "Cs", "B"},
          new[] {"As", "Cs", "Cs", "Cs", "As", "Cs", "B"}
        });

      var lemma = new LayerValueState("Lemma", 1);
      lemma.AddCompleteDocument(
        d1Guid,
        new[]
        {
          new[] {"C", "A", "B", "A", "B", "C", "A"},
          new[] {"A", "C", "B", "A", "A", "C", "B"},
          new[] {"A", "C", "B", "A", "A", "C", "B"},
          new[] {"A", "C", "B", "A", "A", "C", "B"},
          new[] {"A", "C", "B", "A", "A", "C", "B"}
        }
      );
      lemma.AddCompleteDocument(
        d2Guid,
        new[]
        {
          new[] {"C", "A", "C", "A", "C", "C", "A"},
          new[] {"A", "C", "C", "A", "A", "C", "C"},
          new[] {"A", "C", "C", "A", "A", "C", "C"},
          new[] {"A", "C", "C", "A", "A", "C", "C"},
          new[] {"A", "C", "C", "A", "A", "C", "C"}
        }
      );
      lemma.AddCompleteDocument(
        d3Guid,
        new[]
        {
          new[] {"A", "A", "B", "A", "A", "A", "B"},
          new[] {"A", "C", "C", "C", "A", "C", "B"},
          new[] {"A", "C", "C", "C", "A", "C", "B"},
          new[] {"A", "C", "C", "C", "A", "C", "B"},
          new[] {"A", "C", "C", "C", "A", "C", "B"}
        }
      );

      var pos = new LayerValueState("POS", 2);
      pos.AddCompleteDocument(
        d1Guid,
        new[]
        {
          new[] {"kB", "kA", "kB", "kA", "kB", "kB", "kB"},
          new[] {"kA", "kB", "kB", "kA", "kA", "kA", "kB"},
          new[] {"kA", "kB", "kB", "kA", "kA", "kA", "kB"},
          new[] {"kA", "kB", "kB", "kA", "kA", "kA", "kB"},
          new[] {"kA", "kB", "kB", "kA", "kA", "kA", "kB"}
        }
      );
      pos.AddCompleteDocument(
        d2Guid,
        new[]
        {
          new[] {"kA", "kA", "kA", "kA", "kB", "kA", "kB"},
          new[] {"kB", "kB", "kB", "kA", "kB", "kA", "kA"},
          new[] {"kB", "kB", "kB", "kA", "kB", "kA", "kA"},
          new[] {"kB", "kB", "kB", "kA", "kB", "kA", "kA"},
          new[] {"kB", "kB", "kB", "kA", "kB", "kA", "kA"}
        }
      );
      pos.AddCompleteDocument(
        d3Guid,
        new[]
        {
          new[] {"kA", "kA", "kB", "kA", "kA", "kA", "kB"},
          new[] {"kA", "kB", "kB", "kB", "kA", "kB", "kB"},
          new[] {"kA", "kB", "kB", "kB", "kA", "kB", "kB"},
          new[] {"kA", "kB", "kB", "kB", "kA", "kB", "kB"},
          new[] {"kA", "kB", "kB", "kB", "kA", "kB", "kB"}
        }
      );

      var layers = new List<AbstractLayerState> { wort, lemma, pos };

      var builder = new CorpusBuilderSingleFile();
      var corpus = builder.Create(layers, new Dictionary<Guid, Dictionary<string, object>>
      {
        {d3Guid, new Dictionary<string, object>()},
        {d1Guid, new Dictionary<string, object>()},
        {d2Guid, new Dictionary<string, object>()}
      }, null, null).First();

      _terminalController.ProjectNew();
      _terminalController.Project.Add(corpus);

      _selection =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAnyMatch
            {
              LayerDisplayname = "Wort",
              LayerQueries = new[] {"B"}
            }
          });
    }

    [TestMethod]
    public void ConvertLayerToConcept()
    {
      var layer = _terminalController.Project.SelectAll.GetLayers("POS").First();
      Assert.IsNotNull(layer);

      var concept = layer.ToConcept();
      Assert.IsNotNull(concept);

      Assert.AreEqual(21, concept.GetDocumentMarks(layer.DocumentGuids.First()).ToArray().Length);
    }

    /// <summary>
    ///   The explore frequency.
    /// </summary>
    [TestMethod]
    public void ExploreFrequency()
    {
      var block2 = _selection.CreateBlock<Frequency3LayerBlock>();

      block2.Calculate();

      Assert.IsNotNull(block2.Frequency);
    }

    /// <summary>
    ///   The explore frequency all.
    /// </summary>
    [TestMethod]
    public void ExploreFrequencyAll()
    {
      var block1 = _terminalController.Project.SelectAll.CreateBlock<Frequency3LayerBlock>();

      block1.Calculate();

      Assert.IsNotNull(block1.Frequency);
    }

    [TestMethod]
    public void PhraseQueryTest()
    {
      var selection = _selection.Create(
        new[]
        {
          new FilterQuerySingleLayerExactPhrase
          {
            LayerDisplayname = "Lemma",
            LayerQueries = new[] {"C", "C", "C"}
          }
        },
        "SEL");

      Assert.AreNotEqual(_selection.CountDocuments, selection.CountDocuments);
      Assert.AreNotEqual(0, selection.CountDocuments);
    }

    [TestMethod]
    public void TextSimilarity()
    {
      var block1 = _terminalController.Project.SelectAll.CreateBlock<DocumentSimilarityBlock>();
      block1.Similarity = new EuclideanDistance();
      block1.Calculate();

      Assert.IsNotNull(block1.DocumentGuids);
      Assert.IsNotNull(block1.RequestDocumentSimilarity(block1.DocumentGuids.First()));
      Assert.AreNotEqual(0, block1.MinimumInversDocumentFrequency);
    }
  }
}
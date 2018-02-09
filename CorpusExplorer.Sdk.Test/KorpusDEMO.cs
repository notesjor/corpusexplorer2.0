#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Terminal;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Test
{
  /// <summary>
  ///   The korpus demo.
  /// </summary>
  [TestClass]
  public class KorpusDEMO
  {
    /*
    [TestMethod]
    public void ExportTest()
    {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExportTest");
      if (Directory.Exists(path)) Directory.Delete(path, true);
      Directory.CreateDirectory(path);

      var exporter = new ExporterJson();
      exporter.Export(_terminalController.Project.CurrentSelection.Corpora.First(), path);
    }
    */

    private readonly MD5 _md5 = MD5.Create();

    /// <summary>
    ///   The _terminal controler.
    /// </summary>
    private readonly TerminalController _terminalController = CorpusExplorerEcosystem.Initialize();

    /// <summary>
    ///   Initializes a new instance of the <see cref="KorpusDEMO" /> class.
    /// </summary>
    public KorpusDEMO()
    {
      _terminalController.ProjectNew();
      _terminalController.Project.Add(
        CorpusAdapterSingleFile.Create(
          "C:/Projekte/Magisterarbeit/CorpusExplorerNext/CorpusExplorer/CorpusExplorer.Sdk.Test/EXAMPLE/KorpusDEMO.cec5"));
    }

    /// <summary>
    ///   The all cooccurrence test.
    /// </summary>
    [TestMethod]
    public void AllCooccurrenceTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var s1 = selection1.CountDocuments;

      var block1 = selection1.CreateBlock<CooccurrenceBlock>();
      block1.Calculate();
      var dt1 = block1.CooccurrenceSignificance.Count;
      Assert.AreNotEqual(0, dt1);

      var selection2 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAnyMatch
            {
              LayerQueries =
                new[] {"Assad"}
            }
          });
      var s2 = selection2.CountDocuments;

      Assert.AreNotEqual(s1, s2);

      var block2 = selection2.CreateBlock<CooccurrenceBlock>();
      block2.Calculate();

      var dt2 = block2.CooccurrenceSignificance.Count;

      var cd = block2.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      Assert.IsNotNull(cd);
      Assert.AreNotEqual(0, dt2);
      Assert.AreNotEqual(dt1, dt2);
    }

    /// <summary>
    ///   The all Cooccurrence test.
    /// </summary>
    [TestMethod]
    public void AllVersusSingleCooccurrenceTest()
    {
      Configuration.MinimumSignificance = 0;

      var selection = _terminalController.Project.SelectAll;
      Assert.AreNotEqual(0, selection.CountDocuments);

      var block1 = selection.CreateBlock<CooccurrenceBlock>();
      block1.Calculate();
      Assert.AreNotEqual(0, block1.CooccurrenceSignificance.Count);

      var block2 = selection.CreateBlock<CooccurrenceSpreadingBlock>();
      block2.LayerQueries = new[] {"Syrien"};
      block2.Calculate();
      Assert.AreNotEqual(0, block2.CountSentences);

      var dir1 = block1.CooccurrenceSignificance.CompleteDictionaryToFullDictionary()["Syrien"];
      var dir2 = block2.SignificanceAverageCooccurrence;
      Assert.AreEqual(dir2.Count, dir1.Count);

      foreach (var x in dir1)
      {
        var v = dir2[x.Key];
        Assert.AreEqual(x.Value, v);
      }

      Configuration.MinimumSignificance = 1;
    }

    [TestMethod]
    public void CollectionToSource()
    {
      var selection = _terminalController.Project.SelectAll.Create(
        new[]
        {
          new FilterQuerySingleLayerAnyMatch
          {
            LayerQueries =
              new[]
              {
                "Merkel",
                "CDU",
                "CSU",
                "Bundestag",
                "Kanzlerin",
                "Bundeskanzlerin"
              }
          }
        },
        "");

      var vmC = new CooccurrenceViewModel {Selection = selection};
      vmC.Analyse();
      var vmS = new TextLiveSearchViewModel {Selection = selection};

      foreach (var a in vmC.FrequencyDictionary)
      {
        foreach (var b in a.Value)
        {
          vmS.ClearQueries();
          vmS.AddQuery(
            new FilterQuerySingleLayerAllInOnDocument
            {
              Inverse = false,
              LayerDisplayname = "Wort",
              LayerQueries = new[] {a.Key, b.Key}
            });
          vmS.Analyse();
          Assert.AreEqual((int) b.Value, vmS.ResultCountSentences);
        }
      }
    }

    [TestMethod]
    public void CorpusMergeTest()
    {
      var files =
        Directory.GetFiles(
          Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "CorpusExplorer\\Meine Korpora"),
          "*.cec5");

      Assert.IsTrue(files.Length >= 2, "Testbedingung nicht erfüllt.");

      var fs = new[] {files[0], files[1]};
      var corpusA = CorpusAdapterSingleFile.Create(files[0]);
      var corpusB = CorpusAdapterSingleFile.Create(files[1]);

      var terminal = CorpusExplorerEcosystem.Initialize();
      terminal.ProjectNew();
      terminal.Project.Add(corpusA);
      terminal.Project.Add(corpusB);
      var select = terminal.Project.SelectAll;
      var corpusM = select.ToCorpus();

      Assert.IsNotNull(corpusA);
      Assert.IsNotNull(corpusB);
      Assert.IsNotNull(corpusM);

      var layersM = corpusM.GetLayers("Wort");
      var layersA = corpusA.GetLayers("Wort");
      var layersB = corpusB.GetLayers("Wort");

      Assert.IsNotNull(layersM);
      Assert.IsNotNull(layersA);
      Assert.IsNotNull(layersB);

      /*
      foreach (var guid in layersM.DocumentGuids)
      {
        var docM = CastToRealArray(layerM.GetReadableDocumentByGuid(guid));
        var docA = CastToRealArray(layerA.GetReadableDocumentByGuid(guid));
        var docB = CastToRealArray(layerB.GetReadableDocumentByGuid(guid));

        var hashM = HashReadableDocument(docM);
        var hashA = HashReadableDocument(docA);
        var hashB = HashReadableDocument(docB);

        Assert.AreNotEqual(hashA, hashB);
        if (hashA != null)
          Assert.AreEqual(hashM, hashA);
        if (hashB != null)
          Assert.AreEqual(hashM, hashB);
      }
      */
    }

    /// <summary>
    ///   The disambiguation blocktest.
    /// </summary>
    [TestMethod]
    public void DisambiguationBlocktest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var block1 = selection1.CreateBlock<DisambiguationBlock>();
      block1.LayerQuery = "Abdullah";
      block1.MinimumSignificance = 0.8d;
      block1.Calculate();
      var res = block1.RootCluster;

      Assert.IsNotNull(res);
      var clusters = res.GetClusters().ToArray()[0];
      Assert.IsNotNull(clusters);
    }

    [TestMethod]
    public void MultiCooccurrences()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var block1 = selection1.CreateBlock<NGramHighlightCooccurrencesBlock>();
      block1.NGramSize = 5;
      block1.Calculate();

      Assert.IsNotNull(block1.WeightedNgrams);
      Assert.IsTrue(block1.WeightedNgrams.Count > 0);
    }

    [TestMethod]
    public void DocumentQueryValueTest()
    {
      var selection = _terminalController.Project.SelectAll;
      var block = selection.CreateBlock<DocumentQueryValueBlock>();
      block.Calculate();

      Assert.IsNotNull(block.DocumentValueDictionary);

      var test1 = block.DocumentValueDictionary.First();
      Assert.IsNotNull(test1);

      var test2 = test1.Value.First();
      Assert.IsNotNull(test2);

      var test3 = block.GetDocumentsByValue(test2);
      Assert.IsNotNull(test3);

      var list = new List<Guid>(test3);
      Assert.IsTrue(list.Contains(test1.Key));

      Assert.AreEqual(selection.DocumentGuids.Count(), block.DocumentValueDictionary.Count);
    }

    /*
    /// <summary>
    /// The disambiguation blocktest.
    /// </summary>
    [TestMethod]
    public void DatabaseExportTest()
    {
      CorpusExplorerDatabaseConverter.ToDatabase(_terminalController.Project.SelectAll.Corpora.First(), "C:/Users/Jan/Desktop/db.s3db");
    }
    */

    /// <summary>
    ///   The filter block test.
    /// </summary>
    [TestMethod]
    public void FilterBlockTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var selection2 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAllInSpanWords
            {
              LayerDisplayname = "Wort",
              LayerQueries = new[] {"Assad", "Syrien"},
              WordSpan = 3
            }
          });

      Assert.IsNotNull(selection1);
      Assert.IsNotNull(selection2);

      var cnt1 = selection1.Sum(c => c.Value.Count);
      var cnt2 = selection2.Sum(c => c.Value.Count);

      Assert.AreNotEqual(cnt1, cnt2);
    }

    /// <summary>
    ///   The frequency test.
    /// </summary>
    [TestMethod]
    public void FrequencyTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var block1 = selection1.CreateBlock<Frequency3LayerBlock>();
      block1.Calculate();
      var b1 = block1.Frequency;

      var selection2 = selection1.CreateTemporary(
        new[]
        {
          new FilterQuerySingleLayerAnyMatch
          {
            LayerDisplayname = "Wort",
            LayerQueries = new[] {"Assad"}
          }
        });

      var block2 = selection2.CreateBlock<Frequency3LayerBlock>();
      block2.Calculate();
      var b2 = block2.Frequency;

      block2.UseHydraOptimization = true;
      block2.Calculate();
      var b2o = block2.Frequency;

      Assert.IsNotNull(block1.Frequency);
      Assert.IsNotNull(block2.Frequency);
      Assert.AreNotEqual(b1, b2);
      Assert.AreNotEqual(b2, b2o);
      Assert.AreNotEqual(selection1.CountDocuments, selection2.CountDocuments);
    }

    /// <summary>
    ///   The hypen block test.
    /// </summary>
    [TestMethod]
    public void HypenBlockTest()
    {
      var block = _terminalController.Project.SelectAll.CreateBlock<HyphenBlock>();
      block.Calculate();
      var res = block.HyphenFrequency;

      Assert.IsNotNull(res);
      Assert.AreNotEqual(0, res.Count);
    }

    /// <summary>
    ///   The load test.
    /// </summary>
    [TestMethod]
    public void LoadTest()
    {
      _terminalController.Project.CurrentSelection = _terminalController.Project.SelectAll;
      Assert.AreEqual(1, _terminalController.Project.CurrentSelection.CountCorpora);
      Assert.AreEqual(1882, _terminalController.Project.CurrentSelection.CountDocuments);
    }

    [TestMethod]
    public void MetadataCategoriserBlockTest()
    {
      var selection = _terminalController.Project.SelectAll;
      var block = selection.CreateBlock<MetadataCategoriserBlock>();
      block.Calculate();

      Assert.IsNotNull(block.Categories);

      var test1 = block.Categories.First();
      Assert.IsNotNull(test1);

      var test2 = test1.Value.First();
      Assert.IsNotNull(test2);

      var test3 = block.GetDocumentsByValue(test1.Key, test2.Key);
      Assert.IsNotNull(test3);

      var hash = new HashSet<Guid>();
      foreach (
        var guid in from category in block.Categories from value in category.Value from guid in value.Value select guid) hash.Add(guid);
      Assert.AreEqual(selection.DocumentGuids.Count(), hash.Count);
    }

    /// <summary>
    ///   The ngram pattern test.
    /// </summary>
    [TestMethod]
    public void NgramPatternTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var selection2 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAnyMatch
            {
              LayerQueries =
                new[] {"Assad"}
            }
          });

      var block1 = selection1.CreateBlock<Ngram1LayerPatternBlock>();
      var block2 = selection2.CreateBlock<Ngram1LayerPatternBlock>();

      block1.NGramSize = 2;
      block2.NGramSize = 3;

      block1.Calculate();
      var dt1 = block1.NGramFrequency;

      // block1 wird recyled

      block1.NGramSize = 3;
      block1.Calculate();
      block2.Calculate();

      var dt2 = block1.NGramFrequency;
      var dt3 = block2.NGramFrequency;

      Assert.IsNotNull(dt1);
      Assert.IsNotNull(dt2);
      Assert.IsNotNull(dt3);
      Assert.AreNotEqual(dt1.Count, dt2.Count);
      Assert.AreNotEqual(dt1.Count, dt3.Count);
      Assert.AreNotEqual(dt2.Count, dt3.Count);
    }

    [TestMethod]
    public void NgramPhoneticBlockTest()
    {
      var block = _terminalController.Project.SelectAll.CreateBlock<NgramPhoneticBlock>();
      block.Calculate();

      var res = block.NGramFrequency;

      Assert.IsNotNull(res);
      Assert.AreNotEqual(0, res.Count);
    }

    /// <summary>
    ///   The disambiguation blocktest.
    /// </summary>
    [TestMethod]
    public void PhraseLaboratoryTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var block1 = selection1.CreateBlock<PhrasesLaboratoryBlock>();

      var watch = new Stopwatch();
      block1.Grammar = new PhraseGrammar();

      block1.Grammar.Rules.Add(
        10,
        new List<AbstractGrammarRule>
        {
          new ExactGrammarRule("NP", "NN"),
          new ExactGrammarRule("NP", "NE"),
          new ExactGrammarRule("AP", "ADJA"),
          new ExactGrammarRule("AP", "ADJD"),
          new ExactGrammarRule("VP", "VVFIN"),
          new ExactGrammarRule("VP", "VVINF"),
          new ExactGrammarRule("VP", "VAINF")
        });

      block1.Grammar.Rules.Add(
        20,
        new List<AbstractGrammarRule>
        {
          new ExactGrammarRule("VP", "VP NP NP"),
          new ExactGrammarRule("NP", "ART AP NP")
        });

      block1.Grammar.Rules.Add(
        30,
        new List<AbstractGrammarRule>
        {
          new ExactGrammarRule("VP", "VP PP"),
          new ExactGrammarRule("VP", "VP NP"),
          new ExactGrammarRule("NP", "NP NP"),
          new ExactGrammarRule("NP", "ART NP"),
          new ExactGrammarRule("PP", "APPR NP")
        });

      watch.Start();
      block1.Calculate();
      watch.Stop();
      Debug.WriteLine(watch.ElapsedMilliseconds);
    }

    /// <summary>
    ///   The range single layer filter query test.
    /// </summary>
    [TestMethod]
    public void RangeSingleLayerFilterQueryTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var selection2 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAllInSpanWords
            {
              LayerDisplayname = "Wort",
              LayerQueries = new[] {"Assad", "Syrien"},
              WordSpan = 3
            }
          });
      var selection3 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAllInSpanWords
            {
              LayerDisplayname = "Wort",
              LayerQueries = new[] {"Assad", "Syrien"},
              WordSpan = 6
            }
          });

      /*
      var selection4 =
        _terminalController.Project.CreateSelection(new[]
        {
          new RangeSingleLayerFilterQuery(new Dictionary<string, object>
          {
            {"LayerDisplayname", "Wort"},
            {"LayerQueryA", "Assad"},
            {"LayerQueryB", "Syrien"},
            {"Range", 9}
          })
        });
      */
      var block1 = selection1.CreateBlock<Ngram1LayerPatternBlock>();
      var block2 = selection2.CreateBlock<Ngram1LayerPatternBlock>();
      var block3 = selection3.CreateBlock<Ngram1LayerPatternBlock>();

      // var block4 = selection4.CreateBlock<NgramBlock>();
      block1.NGramSize = 3;
      block2.NGramSize = 3;
      block3.NGramSize = 3;

      // block4.SetParameter("NGramSize", 3);
      block1.Calculate();
      block2.Calculate();
      block3.Calculate();

      // block4.Calculate();
      var dt1 = block1.NGramFrequency;
      var dt2 = block2.NGramFrequency;
      var dt3 = block3.NGramFrequency;

      // var dt4 = block4.NGramFrequency;
      Assert.IsNotNull(dt1);
      Assert.IsNotNull(dt2);
      Assert.IsNotNull(dt3);

      // Assert.IsNotNull(dt4);
      Assert.AreNotEqual(dt1.Count, dt2.Count);
      Assert.AreNotEqual(dt1.Count, dt3.Count);
      Assert.AreNotEqual(dt2.Count, dt3.Count);
    }

    /// <summary>
    ///   The read ease block test.
    /// </summary>
    [TestMethod]
    public void ReadEaseBlockTest()
    {
      var block = _terminalController.Project.SelectAll.CreateBlock<ReadingEaseBlock>();
      block.Calculate();
      var res = block.ReadingEaseIndices;

      Assert.IsNotNull(res);
      Assert.AreNotEqual(0, res.Count);
    }

    /// <summary>
    ///   The single Cooccurrence test.
    /// </summary>
    [TestMethod]
    public void SingleCooccurrenceTest()
    {
      var selection1 = _terminalController.Project.SelectAll;
      var block1 = selection1.CreateBlock<CooccurrenceSpreadingBlock>();
      block1.LayerQueries = new[] {"Assad"};
      block1.Calculate();
      var res1 = block1.SignificanceAverageCooccurrence;

      var selection2 =
        _terminalController.Project.CreateSelectionTemporary(
          new[]
          {
            new FilterQuerySingleLayerAnyMatch
            {
              LayerQueries =
                new[] {"Assad"},
              LayerDisplayname = "Wort"
            }
          });
      var block2 = selection2.CreateBlock<CooccurrenceSpreadingBlock>();
      block2.LayerQueries = new[] {"Assad"};
      block2.Calculate();
      var res2 = block2.SignificanceAverageCooccurrence;

      Assert.IsNotNull(res1);
      Assert.IsNotNull(res2);
      Assert.AreNotEqual(selection1.CountDocuments, selection2.CountDocuments);
      Assert.AreEqual(res1.Count, res2.Count);
    }

    private string[][] CastToRealArray(IEnumerable<IEnumerable<string>> array)
    {
      if (array == null) return null;
      var list = new List<string[]>();
      // ReSharper disable LoopCanBeConvertedToQuery
      foreach (var x in array) list.Add(x.ToArray());
      // ReSharper restore LoopCanBeConvertedToQuery
      return list.ToArray();
    }

    private string HashReadableDocument(IEnumerable<IEnumerable<string>> doc)
    {
      return doc == null
        ? null
        : Convert.ToBase64String(
          _md5.ComputeHash(
            Configuration.Encoding.GetBytes(
              string.Join(
                "",
                doc.Select(
                  w =>
                    string.Join("", w))))));
    }
  }
}
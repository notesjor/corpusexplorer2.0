#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class RandomSelectionBlock : AbstractBlock
  {
    private int _documentCount;

    public RandomSelectionBlock()
    {
      DocumentCount = 0;
    }

    public int DocumentCount
    {
      get => _documentCount;
      set => _documentCount = value;
    }

    public double DocumentPercent
    {
      get => _documentCount / (double) Selection.CountDocuments * 100d;
      set
      {
        if (value > 100)
          value = 100;
        _documentCount = (int) (Selection.CountDocuments / 100d * value);
        EnsureDocumentCountMax();
      }
    }

    public double DocumentProMillion
    {
      get => _documentCount / (double) Selection.CountDocuments * 1000000d;
      set
      {
        if (value > 1000000)
          value = 1000000;
        _documentCount = (int) (Selection.CountDocuments / 1000000d * value);
        EnsureDocumentCountMax();
      }
    }

    public Selection RandomInvertSelection { get; set; }

    public Selection RandomSelection { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var rnd = Configuration.Random;

      // Zufällig Dokumentenliste
      var rd = new List<Guid>();
      var sd = new List<Guid>(Selection.DocumentGuids);

      while (sd.Count > 0)
      {
        var guid = sd[rnd.Next(0, sd.Count)];
        rd.Add(guid);
        sd.Remove(guid);
      }

      // Erzeuge Auswahlliste
      var selD = new List<Guid>();

      while (selD.Count < DocumentCount)
      {
        var guid = rd[rnd.Next(0, rd.Count)];
        selD.Add(guid);
        rd.Remove(guid);
      }

      RandomSelection = Project.CreateSelection(
        selD,
        string.Format(
          Resources.SelectionRandomDescription,
          selD.Count,
          Math.Round(DocumentPercent, 2)),
        Selection);

      RandomInvertSelection = Project.CreateSelection(
        rd,
        string.Format(
          Resources.SelectionRandomDescription,
          rd.Count,
          Math.Round(100d - DocumentPercent, 2)),
        Selection);
    }

    private void EnsureDocumentCountMax()
    {
      if (_documentCount > Selection.CountDocuments)
        _documentCount = Selection.CountDocuments;
    }
  }
}
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
  public class RandomSelectionSplitBlock : AbstractBlock
  {
    private double _partAPercent;
    private double _partBPercent;

    public RandomSelectionSplitBlock()
    {
      PartAPercent = 50;
    }

    public double PartAPercent
    {
      get => _partAPercent;
      set
      {
        if (value > 100)
          value = 100;
        if (value < 0)
          value = 0;

        _partAPercent = value;
        _partBPercent = 100 - value;
      }
    }

    public double PartBPercent
    {
      get => _partBPercent;
      set
      {
        if (value > 100)
          value = 100;
        if (value < 0)
          value = 0;

        _partBPercent = value;
        _partAPercent = 100 - value;
      }
    }

    public Selection SelectionA { get; set; }
    public Selection SelectionB { get; set; }

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
      var max = Selection.CountDocuments / 100d * PartAPercent;

      while (selD.Count < max)
      {
        var guid = rd[rnd.Next(0, rd.Count)];
        selD.Add(guid);
        rd.Remove(guid);
      }

      // Erzeuge Selection-Dictionary
      SelectionA = Project.CreateSelection(
                                           selD,
                                           string.Format(Resources.SelectionRandimSplitA, PartAPercent),
                                           Selection);
      SelectionB = Project.CreateSelection(
                                           rd,
                                           string.Format(Resources.SelectionRandimSplitB, PartBPercent),
                                           Selection);
    }
  }
}
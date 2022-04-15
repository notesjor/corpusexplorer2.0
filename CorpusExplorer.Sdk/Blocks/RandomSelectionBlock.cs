#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private int documentMaxCount;

    public bool NoParent { get; set; } = false;

    public RandomSelectionBlock()
    {
      DocumentMaxCount = 0;
    }

    public int DocumentMaxCount
    {
      get => documentMaxCount;
      set => documentMaxCount = value;
    }

    public double DocumentMaxPercent
    {
      get => documentMaxCount / (double)Selection.CountDocuments * 100d;
      set
      {
        if (value > 100)
          value = 100;
        documentMaxCount = (int)(Selection.CountDocuments / 100d * value);
        EnsureDocumentCountMax();
      }
    }

    public double DocumentMaxProMillion
    {
      get => documentMaxCount / (double)Selection.CountDocuments * 1000000d;
      set
      {
        if (value > 1000000)
          value = 1000000;
        documentMaxCount = (int)(Selection.CountDocuments / 1000000d * value);
        EnsureDocumentCountMax();
      }
    }

    public long TokenMax { get; set; } = 0;

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

      if (DocumentMaxCount == 0 && TokenMax > 0)
        DocumentMaxCount = Selection.CountDocuments;

      var rdLock = new object();
      var token = (long)0;
      var tokenLock = new object();
      var selLock = new object();

      Parallel.For(0, DocumentMaxCount, Configuration.ParallelOptions, i =>
      {
        Guid guid;
        lock (rdLock)
        {
          guid = rd[rnd.Next(0, rd.Count)];
          rd.Remove(guid);
        }

        if (TokenMax == 0)
          lock (selLock)
            selD.Add(guid);
        else
        {
          lock (tokenLock)
            if (token >= TokenMax)
              return;

          var len = Selection.GetDocumentLengthInWords(guid);
          if (len < 1)
            return;

          lock (tokenLock)
          {
            if (token >= TokenMax)
              return;
            token += len;
            lock (selLock)
              selD.Add(guid);
          }
        }
      });

      RandomSelection = Project.CreateSelection(selD,
                                                string.Format(
                                                              Resources.SelectionRandomDescription,
                                                              selD.Count,
                                                              Math.Round(DocumentMaxPercent, 2)),
                                                NoParent ? null : Selection);

      RandomInvertSelection = Project.CreateSelection(rd,
                                                      string.Format(
                                                                    Resources.SelectionRandomDescription,
                                                                    rd.Count,
                                                                    Math.Round(100d - DocumentMaxPercent, 2)),
                                                      NoParent ? null : Selection);
    }

    private void EnsureDocumentCountMax()
    {
      if (documentMaxCount > Selection.CountDocuments)
        documentMaxCount = Selection.CountDocuments;
    }
  }
}
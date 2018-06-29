using System;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms.Model;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Reports;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting
{
  public class ReportingGenerator
  {
    public ReportTreeItem Execute(UniversalStorage universalStorage)
    {
      var mtitle = new SectionReport();
      mtitle.ReportParameters["Section"].Value = "Analysebericht";
      mtitle.ReportParameters["SectionInfo"].Value =
        $"Erstellt am: {DateTime.Now:dd.MM.yyyy}\nCorpusExplorer v2.0 (www.corpusexplorer.de)";
      var master = new ReportTreeItem("Analysebericht", mtitle, null);

      foreach (var selection in universalStorage.AllSelections)
      {
        var title = new SectionReport();
        title.ReportParameters["Section"].Value = selection;
        title.ReportParameters["SectionInfo"].Value = string.Empty;
        var resS = new ReportTreeItem(selection.Displayname, title, null);
        master.SubItems.Add(resS);

        var factor = (float) (from DataRow x in universalStorage.Get(selection, "CorpusBaseInfo", "").Rows
          where x["Metric"].ToString() == "Factor"
          select (double) x["Value"]).FirstOrDefault();

        if (universalStorage.Contains(selection, "CorpusDistribution", ""))
          resS.SubItems.Add(
            new ReportTreeItem(
              "Korpusverteilung",
              new CorpusDistribution(),
              universalStorage.Get(selection, "CorpusDistribution", "")));

        if (universalStorage.Contains(selection, "Frequency3LayerPosFilter", ""))
        {
          var cf = new CorpusFrequency();
          cf.ReportParameters["Factor"].Value = factor;
          resS.SubItems.Add(
            new ReportTreeItem("Frequenzen", cf, universalStorage.Get(selection, "Frequency3LayerPosFilter", "")));
        }

        if (universalStorage.Contains(selection, "KwicTopFrequencyPosFilter"))
        {
          var subtitle = new SectionReport();
          subtitle.ReportParameters["Section"].Value = "Belege";
          subtitle.ReportParameters["SectionInfo"].Value = "Belegestellen für TOP-Frequenzen";
          var resSS = new ReportTreeItem("Belege TOP-Frequenz", subtitle, null);
          resS.SubItems.Add(resSS);

          foreach (var mod in universalStorage.AllModificationsIn(selection, "KwicTopFrequencyPosFilter"))
          {
            var qk = new QueryKwicResults();
            qk.ReportParameters["Query"].Value = mod;
            resSS.SubItems.Add(new ReportTreeItem(mod, qk,
              universalStorage.Get(selection, "KwicTopFrequencyPosFilter", mod)));
          }
        }

        if (universalStorage.Contains(selection, "Cooccurreces", ""))
          resS.SubItems.Add(new ReportTreeItem("Kookkurrenzen", new CorpusCooccurrences(),
            universalStorage.Get(selection, "Cooccurreces", "")));

        if (universalStorage.Contains(selection, "KwicAnyMatch"))
        {
          var subtitle = new SectionReport();
          subtitle.ReportParameters["Section"].Value = "Gewünschte Belege";
          subtitle.ReportParameters["SectionInfo"].Value = "Von Ihnen gewünschte Belege";
          var resSS = new ReportTreeItem("Gewünschte Belege", subtitle, null);
          resS.SubItems.Add(resSS);

          foreach (var mod in universalStorage.AllModificationsIn(selection, "KwicAnyMatch"))
          {
            var qk = new QueryKwicResults();
            qk.ReportParameters["Query"].Value = mod;
            resSS.SubItems.Add(new ReportTreeItem(mod, qk, universalStorage.Get(selection, "KwicAnyMatch", mod)));
          }
        }

        if (universalStorage.Contains(selection, "SelectiveCooccurreces"))
        {
          var subtitle = new SectionReport();
          subtitle.ReportParameters["Section"].Value = "Gewünschte Kookkurrenzen";
          subtitle.ReportParameters["SectionInfo"].Value = "Von Ihnen gewünschte Kookkurrenzen";
          var resSS = new ReportTreeItem("Gewünschte Kookkurrenzen", subtitle, null);
          resS.SubItems.Add(resSS);

          foreach (var mod in universalStorage.AllModificationsIn(selection, "SelectiveCooccurreces"))
          {
            var qk = new QueryCooccurrences();
            qk.ReportParameters["Query"].Value = mod;
            resSS.SubItems.Add(new ReportTreeItem(mod, qk,
              universalStorage.Get(selection, "SelectiveCooccurreces", mod)));
          }
        }

        if (universalStorage.Contains(selection, "KwicSelectiveCooccurreces"))
        {
          var subtitle = new SectionReport();
          subtitle.ReportParameters["Section"].Value = "Belege für gewünschte Kookkurrenzen";
          subtitle.ReportParameters["SectionInfo"].Value = "Belegstellen enthalten Suchwort und Kookkurrenz";
          var resSS = new ReportTreeItem("Belege für gewünschte Kookkurrenzen", subtitle, null);
          resS.SubItems.Add(resSS);

          foreach (var mod in universalStorage.AllModificationsIn(selection, "KwicSelectiveCooccurreces"))
          {
            var qk = new QueryKwicResults();
            qk.ReportParameters["Query"].Value = mod;
            resSS.SubItems.Add(new ReportTreeItem(mod, qk,
              universalStorage.Get(selection, "KwicSelectiveCooccurreces", mod)));
          }
        }
      }

      return master;
    }
  }
}
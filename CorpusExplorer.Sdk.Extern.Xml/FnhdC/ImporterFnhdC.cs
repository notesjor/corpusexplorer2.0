using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.FnhdC
{
  public class ImporterFnhdC : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var xml = new XmlDocument();
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        xml.Load(bs);
      }

      var root = xml.DocumentElement.GetFirstSubNodeRecursive("text");

      var dsel = Guid.NewGuid();
      AddDocumentMetadata(dsel, GetMetadata(root));

      var sWor = new List<string[]>();
      var sPos = new List<string[]>();
      var sLem = new List<string[]>();
      var sFor = new List<string[]>();
      var sPer = new List<string[]>();
      var sNum = new List<string[]>();
      var sMod = new List<string[]>();
      var sTem = new List<string[]>();

      var cWor = new List<string>();
      var cPos = new List<string>();
      var cLem = new List<string>();
      var cFor = new List<string>();
      var cPer = new List<string>();
      var cNum = new List<string>();
      var cMod = new List<string>();
      var cTem = new List<string>();

      foreach (var seite in root.GetSubNodesRecursive("seite"))
      {
        foreach (var zeile in seite.GetSubNodesRecursive("zeile"))
        {
          foreach (var wortform in zeile.GetSubNodesRecursive("wortform"))
          {
            var word = wortform.GetFirstSubNodeRecursive("morph")?.InnerText;
            if (word == null)
              continue;

            cWor.Add(word);
            cPos.Add(wortform.GetAttribute("typ"));

            var anno = wortform.GetFirstSubNodeRecursive("annotation");
            cLem.Add(anno?.GetAttribute("lemma"));
            cFor.Add(anno?.GetAttribute("form"));
            cPer.Add(anno?.GetAttribute("person"));
            cNum.Add(anno?.GetAttribute("numers"));
            cMod.Add(anno?.GetAttribute("modus"));
            cTem.Add(anno?.GetAttribute("tempus"));
            
            var r = wortform.InnerText.Replace(word, "");
            var praefix = wortform.GetFirstSubNodeRecursive("praefix")?.InnerText;
            if (praefix != null)
              r = r.Replace(praefix, "");

            if (r.Length == 1)
            {
              cWor.Add(r);
              cPos.Add(r);
              cLem.Add(r);
              cFor.Add("");
              cPer.Add("");
              cNum.Add("");
              cMod.Add("");
              cTem.Add("");

              if (r == "." || r == "!" || r == "?")
              {
                sWor.Add(cWor.ToArray());
                sPos.Add(cPos.ToArray());
                sLem.Add(cLem.ToArray());
                sFor.Add(cFor.ToArray());
                sPer.Add(cPer.ToArray());
                sNum.Add(cNum.ToArray());
                sMod.Add(cMod.ToArray());
                sTem.Add(cTem.ToArray());

                cWor.Clear();
                cPos.Clear();
                cLem.Clear();
                cFor.Clear();
                cPer.Clear();
                cNum.Clear();
                cMod.Clear();
                cTem.Clear();
              }
            }
          }
        }
      }

      if (cWor.Count > 0)
      {
        sWor.Add(cWor.ToArray());
        sPos.Add(cPos.ToArray());
        sLem.Add(cLem.ToArray());
        sFor.Add(cFor.ToArray());
        sPer.Add(cPer.ToArray());
        sNum.Add(cNum.ToArray());
        sMod.Add(cMod.ToArray());
        sTem.Add(cTem.ToArray());
      }

      AddDocumet("Wort", dsel, sWor.ToArray());
      AddDocumet("POS", dsel, sPos.ToArray());
      AddDocumet("Lemma", dsel, sLem.ToArray());
      AddDocumet("Form", dsel, sFor.ToArray());
      AddDocumet("Person", dsel, sPer.ToArray());
      AddDocumet("Numerus", dsel, sNum.ToArray());
      AddDocumet("Modus", dsel, sMod.ToArray());
      AddDocumet("Tempus", dsel, sTem.ToArray());
    }

    private Dictionary<string, object> GetMetadata(XmlNode node)
    {
      var bib = node.GetFirstSubNodeRecursive("bibliographie");
      var bas = bib?.GetFirstSubNodeRecursive("Basis");

      return new Dictionary<string, object>
      {
        {"Name", node.GetAttribute("name")},
        {"Nr", node.GetAttribute("nr")},
        {"Datei", bib?.GetFirstSubNodeRecursive("datei")?.InnerText},
        {"Autor", bas?.GetFirstSubNodeRecursive("Autor")?.InnerText},
        {"Titel", bas?.GetFirstSubNodeRecursive("Titel")?.InnerText},
        {"Sprachraum", bas?.GetFirstSubNodeRecursive("Sprachraum")?.InnerText},
        {"Ort", bas?.GetFirstSubNodeRecursive("Ort")?.InnerText},
        {"Jahr", bas?.GetFirstSubNodeRecursive("Jahr")?.InnerText},
        {"Textart", bas?.GetFirstSubNodeRecursive("Textart")?.InnerText}
      };
    }
  }
}

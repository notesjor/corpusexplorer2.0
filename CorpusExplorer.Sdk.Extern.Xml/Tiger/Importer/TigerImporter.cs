using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Serializer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer
{
  public class TigerImporter : AbstractImporterSimple3Steps<corpus>
  {
    protected override corpus ImportStep_1_ReadFile(string path)
    {
      return new TigerSerializer().Deserialize(path);
    }

    protected override void ImportStep_2_ImportMetadata(Guid documentGuid, ref corpus data)
    {
      AddDocumentMetadata(documentGuid, "id", data.id);
    }

    protected override void ImportStep_3_ImportContent(Guid documentGuid, ref corpus data)
    {
      var sWord = new List<string[]>();
      var sLemma = new List<string[]>();
      var sPos = new List<string[]>();
      var sMorph = new List<string[]>();
      var sPhrase = new List<string[]>();
      var sEdge = new List<string[]>();
      var sPhraseC = new List<string[]>();
      var sEdgeC = new List<string[]>();

      foreach (var s in data.body)
      {
        var tWord = new List<string>();
        var tLemma = new List<string>();
        var tPos = new List<string>();
        var tMorph = new List<string>();

        var tIds = new Dictionary<string, int>(); // nötig für Zuordnung von nonterminals

        // Erfassung Basisdokument

        foreach (var t in s.graph.terminals.t)
        {
          tIds.Add(t.id, tIds.Count);
          tWord.Add(t.word);
          tLemma.Add(t.lemma);
          tPos.Add(t.pos);
          tMorph.Add(t.morph);
        }

        sWord.Add(tWord.ToArray());
        sLemma.Add(tLemma.ToArray());
        sPos.Add(tPos.ToArray());
        sMorph.Add(tMorph.ToArray());

        var length = tWord.Count;

        // Erfassung zusätzlicher Annotationen
        // Aktuell nur Linearisierung - ToDo: Datenstruktur besser abbilden

        var tPhrase = GetArray(length);
        var tEdge = GetArray(length);
        var tPhraseC = GetArray(length);
        var tEdgeC = GetArray(length);

        foreach (var n in s.graph.nonterminals)
        {
          if (n.edge != null)
            foreach (var e in n.edge)
              if (tIds.ContainsKey(e.idref))
              {
                var id = tIds[e.idref];
                tPhrase[id] = n.cat;
                tEdge[id] = e.label;
                tPhraseC[id] += $"{n.cat} ";
                tEdgeC[id] += $"{e.label} ";
              }

          if (n.secedge != null)
            foreach (var e in n.secedge)
              if (tIds.ContainsKey(e.idref))
              {
                var id = tIds[e.idref];
                tPhrase[id] = n.cat;
                tEdge[id] = e.label;
                tPhraseC[id] += $"{n.cat} ";
                tEdgeC[id] += $"{e.label} ";
              }
        }

        sPhrase.Add(tPhrase);
        sEdge.Add(tEdge);
        sPhraseC.Add(Trim(tPhraseC));
        sEdgeC.Add(Trim(tEdgeC));
      }

      AddDocumet("Wort", documentGuid, sWord.ToArray());
      AddDocumet("Lemma", documentGuid, sLemma.ToArray());
      AddDocumet("POS", documentGuid, sPos.ToArray());
      AddDocumet("Morph", documentGuid, sMorph.ToArray());
      AddDocumet("Phrase", documentGuid, sPhrase.ToArray());
      AddDocumet("Phrase (Info)", documentGuid, sEdge.ToArray());
      AddDocumet("Phrase*", documentGuid, sPhraseC.ToArray());
      AddDocumet("Phrase* (Info)", documentGuid, sEdgeC.ToArray());
    }

    private string[] Trim(string[] arr)
    {
      for (var i = 0; i < arr.Length; i++)
        arr[i] = arr[i].Trim();
      return arr;
    }

    private string[] GetArray(int length)
    {
      var res = new string[length];
      for (var i = 0; i < length; i++)
        res[i] = string.Empty;
      return res;
    }
  }
}

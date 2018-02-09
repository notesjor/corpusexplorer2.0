using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Serializer;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds
{
  public class ExporterDwdsTei : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var layer = hydra.GetLayers("Wort").FirstOrDefault();
      if (layer == null)
        return;

      var serializer = new DwdsTeiSerializer();

      foreach (var dsel in hydra.DocumentGuids)
      {
        if (!layer.ContainsDocument(dsel))
          continue;

        var doc = layer.GetReadableDocumentByGuid(dsel)?.ConvertToText();
        if (doc == null)
          continue;

        var meta = hydra.GetDocumentMetadata(dsel);
        var autor = GetMeta(ref meta, "Publisher") ?? GetMeta(ref meta, "Autor");

        var tei = new TEI
        {
          teiHeader = new teiHeader
          {
            fileDesc = new fileDesc
            {
              titleStmt = new titleStmt
              {
                title = new title
                {
                  type = "main",
                  Text = new[] {GetMeta(ref meta, "Titel")}
                }
              },
              publicationStmt = new publicationStmt
              {
                date = new date {Value = GetDate(ref meta), type = "publication"},
                availability = new availability
                {
                  status = "restricted",
                  p = new p {Text = new[] {"Internal use only."}}
                },
                idno = new idno {type = "corpusVersion", Value = "1.0"}
              },
              sourceDesc = new sourceDesc
              {
                biblFull = new biblFull
                {
                  titleStmt =
                    new titleStmt {title = new title {type = "main", Text = new[] {GetMeta(ref meta, "Titel")}}},
                  notesStmt = new notesStmt
                  {
                    relatedItem = new relatedItem()
                  },
                  publicationStmt =
                    new publicationStmt
                    {
                      date = new date {Value = GetDate(ref meta), type = "publication"},
                      publisher = new publisher {Text = new[] {autor}},
                      idno = new idno {type = "URL", Value = GetMeta(ref meta, "URL")}
                    },
                  seriesStmt = new seriesStmt
                  {
                    title = new title {Text = new[] {GetMeta(ref meta, "Titel")}},
                    biblScope = new[]
                    {
                      new biblScope {unit = "year", Text = new[] {GetDate(ref meta).Year.ToString()}},
                      new biblScope {unit = "categories", Text = new[] {GetMeta(ref meta, "Kategorie")}},
                      new biblScope {unit = "tags", Text = new[] {GetMeta(ref meta, "TAGs")}}
                    }
                  }
                }
              }
            }
          },
          group = new[]
          {
            new text {body = new body {Text = new[] {doc}}}
          }
        };

        serializer.Serialize(tei, Path.Combine(path, dsel.ToString("N") + ".xml"));
      }
    }

    private DateTime GetDate(ref Dictionary<string, object> meta)
    {
      return meta.ContainsKey("Datum") ? (DateTime) meta["Datum"] : DateTime.MinValue;
    }

    private string GetMeta(ref Dictionary<string, object> meta, string key)
    {
      return meta.ContainsKey(key) ? meta[key]?.ToString() : null;
    }
  }
}
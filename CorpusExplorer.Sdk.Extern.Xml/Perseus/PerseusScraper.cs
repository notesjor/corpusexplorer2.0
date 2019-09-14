using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Perseus
{
  public class PerseusScraper : AbstractScraper
  {
    public override string DisplayName => "Perseus Digital Library";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xml = new HtmlDocument();
      xml.Load(file, Encoding.UTF8);

      RemoveNodes(ref xml, "tei:bibl");

      return new[]
      {
        new Dictionary<string, object>
        {
          {"Datei", Path.GetFileNameWithoutExtension(file) },
          {"Autor", GetContent(ref xml, "tei:author")},
          {"Titel", GetContent(ref xml, "tei:title")},
          {"IDNO", GetContent(ref xml, "idno")},
          {"Text", GetContent(ref xml, "tei:text")},
          {"Sprache", GetLanguage(ref xml) },
          {"Textsorte", GetTextType(ref xml) }
        }
      };
    }

    /// <summary>
    /// Entfernt alle Knoten mit nodeName
    /// </summary>
    /// <param name="xml">Xml document</param>
    /// <param name="nodeName">Name der zu entfernenden Knoten</param>
    private void RemoveNodes(ref HtmlDocument xml, string nodeName)
    {
      var nodes = xml.DocumentNode.Descendants().Where(x => x.Name.Equals(nodeName)).ToArray();
      foreach (var n in nodes)
        n.ParentNode?.RemoveChild(n);
    }

    /// <summary>
    /// Gibt den Text-Inhalt des erstens Knotens zurück, der dem nodeName entspricht.
    /// </summary>
    /// <param name="xml">Xml document</param>
    /// <param name="nodeName">Name des Knotens</param>
    /// <returns>Text</returns>
    private string GetContent(ref HtmlDocument xml, string nodeName)
      => xml.DocumentNode.Descendants().FirstOrDefault(x => x.Name.Equals(nodeName)) // Erstes Vorkommen
           ?.InnerText; // Gebe Text zurück

    /// <summary>
    /// Sucht nach TEI text, um die Sprache zu bestimmen.
    /// </summary>
    /// <param name="xml">XML document</param>
    /// <returns>Sprache</returns>
    private string GetLanguage(ref HtmlDocument xml) =>
      xml.DocumentNode.Descendants()
         .FirstOrDefault(x => x.Name.Equals("tei:text")) // Erstes Vorkommen
        ?.GetAttributeValue("xml:lang", null); // Gebe Attribut zurück (falls vorhanden)

    /// <summary>
    /// Sucht nach TEI div, um die Textsorte zu bestimmen.
    /// </summary>
    /// <param name="xml">XML document</param>
    /// <returns>Textsorte</returns>
    private string GetTextType(ref HtmlDocument xml) =>
      xml.DocumentNode.Descendants()
         .FirstOrDefault(x => x.Name.Equals("tei:div")
                           && !string.IsNullOrEmpty(x.GetAttributeValue("type", null))) // sucht nach tei:div mit Attribut type
        ?.GetAttributeValue("type", null); // Gebe Attributwert zurück
  }
}

using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.ReMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CorpusExplorer.Sdk.Extern.Xml.SaltXml
{
  public class ExporterSaltXml : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      path = path.EndsWith(".salt") ? path.Substring(0, path.Length - 5) : path;
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var mapper = new ReMapperStandoff();

      Parallel.ForEach(hydra.DocumentGuids, Configuration.ParallelOptions, dsel =>
      {
        using (var fs = new FileStream(Path.Combine(path, $"{dsel:N}.salt"), FileMode.Create, FileAccess.Write))
        using (var writer = new StreamWriter(fs, Encoding.UTF8))
        {
          writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
          writer.WriteLine("<sDocumentStructure:SDocumentGraph xmlns:sDocumentStructure=\"sDocumentStructure\" xmlns:xmi=\"http://www.omg.org/XMI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:saltCore=\"saltCore\" xmi:version=\"2.0\">");
          writer.WriteLine($"\t<labels xsi:type=\"saltCore:SElementId\" namespace=\"salt\" name=\"id\" value=\"T::salt:{dsel}\"/>");
          writer.WriteLine($"\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SNAME\" value=\"T::{dsel}_graph\"/>");

          var doc = hydra.GetReadableMultilayerDocument(dsel).ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
          var tokens = doc["Wort"].Select(x => x.Select(y => HttpUtility.HtmlEncode(y)).ToArray()).ToArray();
          var text = $"T::{string.Join(" ", tokens.Select(x => string.Join(" ", x)))}";
          doc.Remove("Wort");

          writer.WriteLine($"\t<nodes xsi:type=\"sDocumentStructure:STextualDS\">");
          writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"saltCommon\" name=\"SDATA\" value=\"{text}\"/>");
          writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SElementId\" namespace=\"salt\" name=\"id\" value=\"T::salt:{dsel}#sText1\"/>");
          writer.WriteLine("\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SNAME\" value=\"T::sText1\"/>");
          writer.WriteLine("\t</nodes>");

          var entries = mapper.ExtractAlignment(text, tokens);
          var cnt = 1;

          foreach (var entry in entries)
          {
            writer.WriteLine("\t<nodes xsi:type=\"sDocumentStructure:SToken\">");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SNAME\" value=\"T::sTok{cnt}\"/>");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SElementId\" namespace=\"salt\" name=\"id\" value=\"T::salt:{dsel}#sTok{cnt}\"/>");
            foreach (var layer in doc)
              writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SAnnotation\" namespace=\"salt\" name=\"{layer.Key.ToLower()}\" value=\"T::{HttpUtility.HtmlEncode(layer.Value[entry.SentenceIndex][entry.TokenIndex])}\"/>");
            writer.WriteLine("\t</nodes>");

            writer.WriteLine($"\t<edges xsi:type=\"sDocumentStructure:STextualRelation\" source=\"//@nodes.{cnt}\" target=\"//@nodes.0\">");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SElementId\" namespace=\"salt\" name=\"id\" value=\"T::salt:{dsel}#sTextRel{cnt}\"/>");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SNAME\" value=\"T::sTextRel{cnt}\"/>");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SSTART\" value=\"N::{entry.TextCharFrom}\"/>");
            writer.WriteLine($"\t\t<labels xsi:type=\"saltCore:SFeature\" namespace=\"salt\" name=\"SEND\" value=\"N::{entry.TextCharTo}\"/>");
            writer.WriteLine("\t</edges>");

            cnt++;
          }
        }
      });
    }
  }
}

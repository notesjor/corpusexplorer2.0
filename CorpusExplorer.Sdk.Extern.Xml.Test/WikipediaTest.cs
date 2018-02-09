using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia;
using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public class WikipediaTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      var files =
        Directory.GetFiles(
          @"C:\Projekte\Magisterarbeit\CorpusExplorerNext\CorpusExplorer\CorpusExplorer.Sdk.Extern.Xml.Test\bin\Release\testdata\wiki",
          "*.xml");
      var scraper = new WikipediaScraper();
      var serializer = new WikipediaFullDumpSerializer();

      foreach (var file in files)
        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
          using (var xml = XmlReader.Create(fs, new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment }))
          {
            var i = 0;

            while (xml.Read())
            {
              if (xml.Name != "page")
                continue;

              var docs = new ConcurrentQueue<Dictionary<string, object>>();
              using (var ms = new MemoryStream(Configuration.Encoding.GetBytes(xml.ReadOuterXml())))
              {
                var temp = scraper.ScrapDocumentsInline(serializer.Deserialize(ms));
                foreach (var x in temp)
                  docs.Enqueue(x);
              }
              var origs = docs.Select(doc => doc["Text"].ToString()).ToArray();

              var clean1 = new WikipediaCleanup { Input = docs };
              clean1.Execute();

              var path = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file));
              if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

              File.WriteAllText(Path.Combine(path, i + ".orig.xml"), origs[i]);
              File.WriteAllText(Path.Combine(path, i + ".mod.xml"), clean1.Output.FirstOrDefault()?["Text"].ToString());

              i++;
            }
          }
        }
    }
  }
}
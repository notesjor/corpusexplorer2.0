using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy
{
  public class KorapLoadStrategyDirectory : AbstractKorapLoadStrategy
  {
    private string _basePath;
    private HashSet<string> _entries;
        
    public override AbstractKorapLoadStrategy Initialize(string path)
    {
      return new KorapLoadStrategyDirectory(path);
    }

    public static KorapLoadStrategyDirectory AddonInitialize() => new KorapLoadStrategyDirectory();

    private KorapLoadStrategyDirectory()
    {
    }

    private KorapLoadStrategyDirectory(string path)
    {
      _basePath = path;
      _entries = new HashSet<string>(Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories)
                                              .Select(x => x.Substring(_basePath.Length + 1)));
    }

    public override IEnumerable<string> Entries => _entries;

    public override bool Exists(string entry) => _entries.Contains(entry);

    public override HtmlDocument Read(string entry)
    {
      var res = new HtmlDocument();
      res.Load(Path.Combine(_basePath, entry), Encoding.UTF8);

      return res;
    }

    public override XmlDocument ReadXml(string entry)
    {
      var res = new XmlDocument();
      using (var reader = new StreamReader(Path.Combine(_basePath, entry), Encoding.UTF8))
        res.Load(reader);

      return res;
    }

    public override XmlDocument ReadXmlClean(string entry)
    {
      string xml;
      using (var ms = new MemoryStream(Bcs.IO.FileIO.ReadBytes(Path.Combine(_basePath, entry))))
      {
        xml = Encoding.UTF8.GetString(ms.ToArray());
      }

      // KorAP hat manchma ungültige Kommentare - z. B.:
      // <!-- /usr/bin/java -jar /opt/perl/perlbrew/perls/perl-5.24.0/lib/site_perl/5.24.0/auto/share/dist/tei2korapxml/KorAP-Tokenizer-2.0.0-standalone.jar --no-tokens --positions -->
      var s = xml.IndexOf("<!--");
      if (s > -1)
      {
        var e = xml.IndexOf("-->");
        xml = xml.Substring(0, s) + xml.Substring(e + 3);
      }

      var res = new XmlDocument();
      res.LoadXml(xml);

      return res;
    }

    public override void Dispose()
    {
      _entries.Clear();
      _entries = null;
    }
  }
}

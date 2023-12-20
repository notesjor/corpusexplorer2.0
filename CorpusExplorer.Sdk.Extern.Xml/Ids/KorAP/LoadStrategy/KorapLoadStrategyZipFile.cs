using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;
using HtmlAgilityPack;
using Telerik.Windows.Zip;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy
{
  public class KorapLoadStrategyZipFile : AbstractKorapLoadStrategy
  {
    private object _zipLock = new object();
    private FileStream _fs;
    private ZipArchive _zip;
    private Dictionary<string, ZipArchiveEntry> _entries = new Dictionary<string, ZipArchiveEntry>();

    public static KorapLoadStrategyZipFile AddonInitialize() => new KorapLoadStrategyZipFile();

    public override AbstractKorapLoadStrategy Initialize(string path)
    {
      return new KorapLoadStrategyZipFile(path);
    }

    private KorapLoadStrategyZipFile() { }

    private KorapLoadStrategyZipFile(string path)
    {
      if (!File.Exists(path))
        throw new FileNotFoundException();

      _fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      _zip = new ZipArchive(_fs, ZipArchiveMode.Read, true, null);

      if (_zip.Entries.First().FullName.StartsWith(".")) // Einige ältere Korpora starten mit einen './'-Root-Directory
        foreach (var entry in _zip.Entries)
          _entries.Add(entry.FullName.Substring(2), entry);
      else
        foreach (var entry in _zip.Entries)
          _entries.Add(entry.FullName, entry);
    }

    public override IEnumerable<string> Entries
      => _entries.Keys;

    public override HtmlDocument Read(string entry)
    {
      var res = new HtmlDocument();
      lock (_zipLock)
        res.Load(_entries[entry].Open(), Encoding.UTF8);

      return res;
    }

    public override XmlDocument ReadXml(string entry)
    {
      var res = new XmlDocument();
      lock (_zipLock)
        using (var reader = new StreamReader(_entries[entry].Open(), Encoding.UTF8))
          res.Load(reader);

      return res;
    }

    public override XmlDocument ReadXmlClean(string entry)
    {
      string xml;
      using (var ms = new MemoryStream())
      {
        lock (_zipLock)
          _entries[entry].Open().CopyTo(ms);
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
      _entries?.Clear();
      _zip?.Dispose();
      _fs?.Close();
    }

    public override bool Exists(string entry) => _entries.ContainsKey(entry);
  }
}
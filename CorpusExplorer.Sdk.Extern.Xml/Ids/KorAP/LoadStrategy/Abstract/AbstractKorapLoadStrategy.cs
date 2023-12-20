using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract
{
  public abstract class AbstractKorapLoadStrategy : IDisposable
  {
    protected AbstractKorapLoadStrategy() { }
    public abstract AbstractKorapLoadStrategy Initialize(string path);

    public abstract IEnumerable<string> Entries { get; }
    public abstract bool Exists(string entry);
    public abstract HtmlDocument Read(string entry);
    public abstract XmlDocument ReadXml(string entry);
    public abstract XmlDocument ReadXmlClean(string entry);
    public abstract void Dispose();
  }
}
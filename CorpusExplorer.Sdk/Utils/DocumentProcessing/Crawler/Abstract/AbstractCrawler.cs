#region

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler.Abstract
{
  [XmlRoot]
  [Serializable]
  public abstract class AbstractCrawler : AbstractDocumentProcessingStepOutputOnly<Dictionary<string, object>>
  {
  }
}
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Export;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Core.Exporter
{
  public class ExporterCec5 : ExporterSimpleGenericBase<CorpusBuilderSingleFile, CorpusAdapterSingleFile>
  {    
  }
}
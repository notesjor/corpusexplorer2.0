using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Db;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService.Model;
using Tfres;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.WebService
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var service = new OpenThesaurusService();
      service.Start();
    }
  }
}
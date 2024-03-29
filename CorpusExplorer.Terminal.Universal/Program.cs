﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CorpusExplorer.Core;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Terminal;
using CorpusExplorer.Sdk.Utils.WaitBehaviour;
using CorpusExplorer.Sdk.Utils.WaitBehaviour.Abstract;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static TerminalController _terminal;
    private static Server _server;

    public static void Main(string[] args)
    {
      System.Console.Write("Server: ");
      CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      _terminal = CorpusExplorerEcosystem.InitializeMinimalTerminal();
      InitializeAddons();

      var port = 12712;

      _server = new Server("127.0.0.1", port, GetDocumentation);
      
      _server.AddEndpoint(HttpMethod.Post, "/project/new", ProjectNew);
      _server.AddEndpoint(HttpMethod.Post, "/project/save", ProjectSave);
      _server.AddEndpoint(HttpMethod.Post, "/project/load", ProjectLoad);
      _server.AddEndpoint(HttpMethod.Post, "/project/settings", ProjectSettingsSet);
      _server.AddEndpoint(HttpMethod.Get, "/project/settings", ProjectSettingsGet);
      _server.AddEndpoint(HttpMethod.Get, "/project/info", ProjectInfo);

      _server.AddEndpoint(HttpMethod.Post, "/corpus/annotate", CorpusAnnotate);
      _server.AddEndpoint(HttpMethod.Get, "/corpus/annotate", CorpusAnnotateFormatOptions);
      _server.AddEndpoint(HttpMethod.Post, "/corpus/import", CorpusImport);
      _server.AddEndpoint(HttpMethod.Get, "/corpus/import", CorpusImportFormatOptions);

      _server.AddEndpoint(HttpMethod.Get, "/selection/operators", QuerySystemHelper.GetOperators);
      _server.AddEndpoint(HttpMethod.Post, "/selection/new", SelectionNew);      
      _server.AddEndpoint(HttpMethod.Post, "/selection/reduce", SelectionReduce);
      _server.AddEndpoint(HttpMethod.Get, "/selection/info", SelectionInfo);
      _server.AddEndpoint(HttpMethod.Get, "/selection/meta", SelectionMeta);
      _server.AddEndpoint(HttpMethod.Get, "/selection/change", SelectionChange);
      _server.AddEndpoint(HttpMethod.Get, "/selection/guids", SelectionGuids);

      _server.AddEndpoint(HttpMethod.Post, "/app/translate", SetTranslation);
      _server.AddEndpoint(HttpMethod.Get, "/news", GetNews);
      _server.AddEndpoint(HttpMethod.Get, "/available/corpora", GetAvailableCorpora);
      _server.AddEndpoint(HttpMethod.Get, "/available/addons", GetAvailableAddons);
      _server.AddEndpoint(HttpMethod.Get, "/download", GetCorpusOrAddon);

      _server.AddEndpoint(HttpMethod.Get, "/fs/get", FileSystemGet);
      _server.AddEndpoint(HttpMethod.Get, "/fs/set", FileSystemSet);

      _server.AddEndpoint(HttpMethod.Post, "/analyze", Analyze);      

      _server.AddEndpoint(HttpMethod.Get, "/fast/norm", FastNormData);
      _server.AddEndpoint(HttpMethod.Get, "/fast/count", FastCount);
      _server.AddEndpoint(HttpMethod.Get, "/fast/kwic", FastKwic);
      _server.AddEndpoint(HttpMethod.Get, "/fast/fulltext", FastFulltext);
      _server.AddEndpoint(HttpMethod.Get, "/fast/cooc", FastCooccurrences);
      _server.AddEndpoint(HttpMethod.Get, "/fast/timeline", FastTimeline);
      _server.AddEndpoint(HttpMethod.Get, "/fast/snapshot", QuerySystemHelper.GetOperators);
      _server.AddEndpoint(HttpMethod.Post, "/fast/snapshot", FastSnapshop);
      _server.AddEndpoint(HttpMethod.Get, "/fast/subscribe", FastSubscribe);

      System.Console.WriteLine($"localhost:{port}");

      AbstractWaitBehaviour wait = new WaitBehaviourWindows();
      wait.Wait();
    }

    private static void InitializeAddons()
    {
      InitializeAddons(new Core.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Binary.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Epub.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Json.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Plaintext.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Plaintext.WET.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Wiki.RepositoryManifest());
      InitializeAddons(new Sdk.Extern.Xml.RepositoryManifest());
    }

    private static void InitializeAddons(AbstractAddonRepository manifest)
    {
      //Configuration.AddonAdditionalTaggersAdd(manifest.AddonAdditionalTagger);
      Configuration.AddonBackendsAdd(manifest.AddonBackends);
      Configuration.AddonConsoleActionsAdd(manifest.AddonConsoleActions);
      Configuration.AddonExportersAdd(manifest.AddonExporters);
      Configuration.AddonImportersAdd(manifest.AddonImporter);
      Configuration.AddonScrapersAdd(manifest.AddonScrapers);
      Configuration.AddonTableWriterAdd(manifest.AddonTableWriter);
      Configuration.AddonTaggersAdd(manifest.AddonTagger);
    }

    private static void GetDocumentation(HttpContext obj)
    {
      obj.Response.Send(200); // TODO
    }
  }
}

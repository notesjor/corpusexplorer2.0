using System;

namespace CorpusExplorer.Installer.ImageBuilder
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args != null && args.Length == 1 && (args[0] == "/?" || args[0] == "--help" || args[0] == "-h"))
      {
        ShowHelp();
        return;
      }

      var vm = new ImageBuilderViewModel();

      if (args != null && args.Length == 1 && (args[0] == "list"))
      {
        ListAddons(vm);
        return;
      }

      vm.BuildImage(args);
    }

    private static void ListAddons(ImageBuilderViewModel imageBuilderViewModel)
    {
      Console.WriteLine("Available add-ons:");
      foreach (var name in imageBuilderViewModel.AddonNames)
        Console.WriteLine(name);
      Console.WriteLine("For more information about the add-ons, please visit:");
      Console.WriteLine("https://notes.jan-oliver-ruediger.de/software/corpusexplorer-overview/erweiterungen/");
    }

    private static void ShowHelp()
    {
      Console.WriteLine("CorpusExplorer v2.0 - [IMAGE BUILDER]");
      Console.WriteLine($"Copyright 2013-{DateTime.Now.Year} by Jan Oliver Rüdiger");

      Console.WriteLine();
      Console.WriteLine("--help/t/t-/tdisplay help information");
      Console.WriteLine("list/t/t-/tdisplay all available add-ons");
      Console.WriteLine();

      Console.WriteLine("usage examples:");
      Console.WriteLine("CorpusExplorer.Installer.ImageBuilder.exe");
      Console.WriteLine("> default CorpusExplorer installation / app-image");
      Console.WriteLine("CorpusExplorer.Installer.ImageBuilder.exe list");
      Console.WriteLine("> list all available add-ons");
      Console.WriteLine("CorpusExplorer.Installer.ImageBuilder.exe sqlite pandoc");
      Console.WriteLine("> default CorpusExplorer installation / app-image + sqlite + pandoc");
      Console.WriteLine("CorpusExplorer.Installer.ImageBuilder.exe CorpusExplorerOnSteroids");
      Console.WriteLine("> default CorpusExplorer installation / app-image + all available add-ons");
      Console.WriteLine();
      Console.WriteLine("NOTE 01: CorpusExplorer runs under Windows, Linux and MacOS");
      Console.WriteLine("NOTE 02: If you use CorpusExplorer on Linux or macOS, then you need to install the Mono-Framework: https://www.mono-project.com/");
      Console.WriteLine("NOTE 03: Not all add-ons running under Linux or MacOS propperly (work in progress)");
    }
  }
}

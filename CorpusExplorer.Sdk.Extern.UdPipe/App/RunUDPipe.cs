using System;
using System.Text;
using CorpusExplorer.Sdk.Extern.UdPipe.Model;

namespace CorpusExplorer.Sdk.Extern.UdPipe.App
{
  public class RunUDPipe
  {
    public static int Main(string[] args)
    {
      if (args.Length < 3)
      {
        Console.Error.WriteLine(
                                "Usage: RunUDPipe input_format(tokenize|conllu|horizontal|vertical) output_format(conllu) model");
        return 1;
      }

      Console.Error.Write("Loading model: ");
      var model = Model.Model.load(args[2]);
      if (model == null)
      {
        Console.Error.WriteLine("Cannot load model from file '{0}'", args[2]);
        return 1;
      }

      Console.Error.WriteLine("done");

      var pipeline = new Pipeline(model, args[0], Pipeline.DEFAULT, Pipeline.DEFAULT, args[1]);
      var error = new ProcessingError();

      // Read whole input
      var textBuilder = new StringBuilder();
      string line;
      while (!string.IsNullOrEmpty(line = Console.In.ReadLine()))
        textBuilder.AppendLine(line);

      // Process data
      var text = textBuilder.ToString();
      var processed = pipeline.process(text, error);

      if (error.occurred())
      {
        Console.Error.WriteLine("An error occurred in RunUDPipe: {0}", error.message);
        return 1;
      }

      Console.Write(processed);

      return 0;
    }
  }
}
#region

using System;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tagger.Parameter
{
  internal static class OpenNlpLocator
  {
    public static string BatchFile => Path.Combine(OpenNlpRootDirectory, @"bin\opennlp.bat");

    private static string OpenNlpRootDirectory => Configuration.GetDependencyPath(@"opennlp");

    public static string GetMaxentModel(string language)
    {
      switch (language)
      {
        case "Deutsch":
          return Path.Combine(OpenNlpRootDirectory, @"model\de-pos-maxent.bin");
        case "Englisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\en-pos-maxent.bin");
        case "Niederländisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\nl-pos-maxent.bin");
        case "Portugiesisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\pt-pos-maxent.bin");
        case "Sami":
          return Path.Combine(OpenNlpRootDirectory, @"model\se-pos-maxent.bin");
        default:
          throw new ArgumentException("language");
      }
    }

    public static string GetPerceptronModel(string language)
    {
      switch (language)
      {
        case "Deutsch":
          return Path.Combine(OpenNlpRootDirectory, @"model\de-pos-perceptron.bin");
        case "Englisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\en-pos-perceptron.bin");
        case "Niederländisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\nl-pos-perceptron.bin");
        case "Portugiesisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\pt-pos-perceptron.bin");
        case "Sami":
          return Path.Combine(OpenNlpRootDirectory, @"model\se-pos-perceptron.bin");
        case "Dänisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\da-pos-perceptron.bin");
        default:
          throw new ArgumentException("language");
      }
    }

    public static string GetTokenizerModel(string language)
    {
      switch (language)
      {
        case "Deutsch":
          return Path.Combine(OpenNlpRootDirectory, @"model\de-token.bin");
        case "Englisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\en-token.bin");
        case "Niederländisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\nl-token.bin");
        case "Portugiesisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\pt-token.bin");
        case "Dänisch":
          return Path.Combine(OpenNlpRootDirectory, @"model\da-token.bin");
        case "Sami":
          return Path.Combine(OpenNlpRootDirectory, @"model\se-token.bin");
        default:
          throw new ArgumentException("language");
      }
    }
  }
}
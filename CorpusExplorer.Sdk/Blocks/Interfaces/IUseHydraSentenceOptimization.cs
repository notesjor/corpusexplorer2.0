namespace CorpusExplorer.Sdk.Blocks.Interfaces
{
  public interface IUseHydraSentenceOptimization
  {
    /// <summary>
    ///   Soll die Hydra-Optimierung verwendet werden. In diesem Fall nur die Fundsätze und nicht das gesamte Dokument
    ///   betrachtet.
    /// </summary>
    bool UseHydraOptimization { get; set; }
  }
}
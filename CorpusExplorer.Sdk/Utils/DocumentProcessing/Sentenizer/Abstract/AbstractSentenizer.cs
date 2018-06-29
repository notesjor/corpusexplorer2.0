namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer.Abstract
{
  public abstract class AbstractSentenizer
  {
    public abstract string DisplayName { get; }
    public abstract string Language { get; set; }

    /// <summary>
    ///   Erkennt die Saztgrenzen
    /// </summary>
    /// <param name="input">NutzenSie AbstractTokenizer.ExecuteToArray um den input aus einem String zu erzeugen.</param>
    /// <returns></returns>
    public abstract string[][] Execute(string[] input);
  }
}
namespace CorpusExplorer.Sdk.Extern.DtaCAB
{
  public static class DtaCabValidator
  {
    public static string ErrorRuleCorpus => "Limit von 1000 Dokumente überschritten.";

    public static string ErrorRuleCorpusLength => "Limit von 100MB (Gesamtgröße) überschritten.";
    public static string ErrorRuleSingleTextLength => "Ein/Mehrere Dokumente sind größer als 1MB.";

    public static string ErrorTemplate =>
      "DTA::CAB steht nicht zur Verfügung weil: {0}\n" +
      "Kontaktieren Sie Bryan Jurish direkt per E-Mail: b.y@bbaw.de, um das Korpus zu normalisieren.";

    public static int MaxCorpusLength => 100000000;
    public static int MaxSingleTextLength => 1000000;
    public static int MaxTotalDocuments => 1000;

    public static bool RuleCorpus(int documentCount) => documentCount <= MaxTotalDocuments;

    public static bool RuleCorpusLength(int allDocumentsLength) => allDocumentsLength <= MaxCorpusLength;

    public static bool RuleSingleTextLength(int textLength) => textLength <= MaxSingleTextLength;
  }
}
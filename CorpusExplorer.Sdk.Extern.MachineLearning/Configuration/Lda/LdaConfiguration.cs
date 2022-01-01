using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Lda;
using CorpusExplorer.Sdk.Helper.Verbalizer;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda
{
  public class LdaConfiguration : IVerbalizerComplex
  {
    private VerbalizerComplexStorage _verbalizerComplexStorage;

    public LdaConfiguration()
    {
      _verbalizerComplexStorage = new VerbalizerComplexStorage();
      _verbalizerComplexStorage.Add("MaximumNgramsCount", "Max. Anzahl N-Gramme", "Legen Sie die maximale Anzahl an N-Grammen fest (Standardwert: 10000000)");
      _verbalizerComplexStorage.Add("UseAllLengths", "Variable Länge?", "Sollen alle Längen zwischen Min./Max. Länge genutzt werden");
      _verbalizerComplexStorage.Add("SkipLength", "Min. Länge", "Minimale Länge für N-Gramme");
      _verbalizerComplexStorage.Add("NgramLength", "Max. Länge", "Maximale Länge für N-Gramme");
      _verbalizerComplexStorage.Add("MaximumNumberOfKeys", "Max. Schlüssel Anzahl", "Maximale Anzahl an Schlüsseln (Standardwert: 1000000)");
      _verbalizerComplexStorage.Add("KeepNumbers", "Behalte Zahlen?", "Sollen Zahlen beibehalten werden?");
      _verbalizerComplexStorage.Add("KeepPunctuations", "Behalte Satzzeichen?", "Sollen Satzzeichen beibehalten werden?");
      _verbalizerComplexStorage.Add("KeepDiacritics", "Behalte Diakritika?", "Sollen diakritisches Zeichen (z. B. äöüÄÖÜ) beibehalten werden?");
      _verbalizerComplexStorage.Add("LayerDisplayname", "Layer", "Layer für die Analyse?");
      _verbalizerComplexStorage.Add("CaseMode", "Zeichen Modifikation?", "Soll eine Zeichen-Konvertierung (z. B. alles kleinschreiben) erfolgen?");
      _verbalizerComplexStorage.Add("Language", "Sprache", "Welche Sprache soll genutzt werden.");
      _verbalizerComplexStorage.Add("WeightingCriteria", "Gewichtungskriterium", "Welches Kriterium soll für die Gewichtung herangezogen werden?");
      _verbalizerComplexStorage.Add("NumberOfBurninIterations", "Burnin-Interationen", "Wieviele Burnin-Interationen sollen durchgeführt werden?");
      _verbalizerComplexStorage.Add("NumberOfSummaryTermsPerTopic", "Anzahl Terme pro Topic", "Wieviele Terme sollen pro Topic ausgegeben werden?");
      _verbalizerComplexStorage.Add("MaximumTokenCountPerDocument", "Max. Top-Token Anzahl pro Dokument", "Wieviele Token pro Dokument sollen max. berücksichtigt werden?");
      _verbalizerComplexStorage.Add("LikelihoodInterval", "Likelihood-Intervall", "");
      _verbalizerComplexStorage.Add("MaximumNumberOfIterations", "Anzahl Runden", "Maximale Anzahl an Interationen");
      _verbalizerComplexStorage.Add("SamplingStepCount", "Sampling Schrittgröße", "Größe der Sampling-Schritte.");
      _verbalizerComplexStorage.Add("Beta", "Beta", "");
      _verbalizerComplexStorage.Add("AlphaSum", "Summe von Alpha", "");
      _verbalizerComplexStorage.Add("NumberOfTopics", "Anzahl Topics", "Wieviele Topics sollen berechnet werden?");
    }

    public int MaximumNgramsCount { get; set; } = 10000000;
    public bool UseAllLengths { get; set; } = true;
    public int SkipLength { get; set; } = 0;
    public int NgramLength { get; set; } = 2;
    public int MaximumNumberOfKeys { get; set; } = 1000000;
    public bool KeepNumbers { get; set; } = false;
    public bool KeepPunctuations { get; set; } = true;
    public bool KeepDiacritics { get; set; } = true;
    public string LayerDisplayname { get; set; } = "Wort";
    public CaseMode CaseMode { get; set; } = CaseMode.None;
    public Language Language { get; set; } = Language.German;
    public int NumberOfBurninIterations { get; set; } = 10;
    public int NumberOfSummaryTermsPerTopic { get; set; } = 100;
    public int MaximumTokenCountPerDocument { get; set; } = 512;
    public int LikelihoodInterval { get; set; } = 5;
    public int MaximumNumberOfIterations { get; set; } = 200;
    public int SamplingStepCount { get; set; } = 4;
    public float Beta { get; set; } = 0.01f;
    public float AlphaSum { get; set; } = 100;
    public int NumberOfTopics { get; set; } = 10;

    public LdaConfiguration Load(string path)
    {
      try
      {
        return JsonConvert.DeserializeObject<LdaConfiguration>(File.ReadAllText(path));
      }
      catch
      {
        var obj = new LdaConfiguration();
        File.WriteAllText(path, JsonConvert.SerializeObject(obj), Encoding.UTF8);
        return obj;
      }
    }

    public VerbalizerComplexStorage VerbalizerComplexStorage => _verbalizerComplexStorage;
  }
}

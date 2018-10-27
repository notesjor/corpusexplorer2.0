using System;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Tlv.Model
{
  [Serializable]
  public class TlvEntry
  {
    public TlvEntry(string layer, string value, int start, int stop)
    {
      Layer = layer;
      Value = value;
      Start = start;
      Stop = stop;
    }

    private TlvEntry()
    {
    }

    public string Layer { get; set; }
    public int Length => Stop - Start;

    public int Start { get; set; }
    public int Stop { get; set; }
    public string Value { get; set; }
  }
}
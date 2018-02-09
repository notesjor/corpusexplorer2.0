using System;

namespace CorpusExplorer.Core.Exporter.Tlv.Model
{
  [Serializable]
  public class TlvEntry
  {
    private TlvEntry() { }

    public TlvEntry(string layer, string value, int start, int stop)
    {
      Layer = layer;
      Value = value;
      Start = start;
      Stop = stop;
    }

    public int Start { get; set; }
    public int Stop { get; set; }
    public int Length => Stop - Start;
    public string Layer { get; set; }
    public string Value { get; set; }
  }
}
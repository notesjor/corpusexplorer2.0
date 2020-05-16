using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Helper
{
  public class ProcessingDocumentSticher
  {
    private Dictionary<Guid, Dictionary<string, object>> _data = new Dictionary<Guid, Dictionary<string, object>>();
    private HashSet<Guid> _done = new HashSet<Guid>();

    public ProcessingDocumentSticher(
      AbstractTokenizer tokenizer = null,
      string processingSeparator = "\r\n<ENDOFCORPUSEXPLORERFILE>\r\n")
    {
      Tokenizer = tokenizer ?? new HighSpeedSpaceTokenizer();
      ProcessingSeparator = processingSeparator;
    }

    public string ProcessingSeparator { get; set; }
    public AbstractTokenizer Tokenizer { get; set; }

    public void Add(ConcurrentQueue<Dictionary<string, object>> queue)
    {
      while (queue.Count > 0)
      {
        Dictionary<string, object> doc;
        if (!queue.TryDequeue(out doc))
          continue;

        Add(doc);
      }
    }

    public void Add(IEnumerable<Dictionary<string, object>> items)
    {
      foreach (var item in items)
        Add(item);
    }

    public void Add(Dictionary<string, object> item)
    {
      // Stellt sicher, dass Text vorhanden ist.
      var text = item?.Get("Text") as string;
      if (string.IsNullOrWhiteSpace(text))
        return;

      // Stellt sicher, dass ein GUID vergeben wurde.
      var guid = Guid.Empty;
      if (item.ContainsKey("GUID"))
      {
        switch (item["GUID"])
        {
          case Guid _:
            guid = (Guid)item["GUID"];
            break;
          case string _:
            Guid.TryParse(item["GUID"] as string, out guid);
            break;
        }
      }
      if (guid == Guid.Empty)
        guid = Guid.NewGuid();
      if (item.ContainsKey("GUID")) // Setzt GUID auf einen einheitlichen Standard
        item["GUID"] = guid;
      else
        item.Add("GUID", guid);

      _data.Add(guid, item);
    }

    public Guid[][] GetClustersByDocumentCount(int documentsPerCluster)
    {
      var res = new List<Guid[]>();
      var current = new List<Guid>();
      foreach (var x in _data.Keys)
      {
        if (_done.Contains(x))
          continue;

        if (current.Count == documentsPerCluster)
        {
          res.Add(current.ToArray());
          current.Clear();
        }
        current.Add(x);
      }
      if (current.Count > 0)
        res.Add(current.ToArray());
      return res.ToArray();
    }

    public Guid[][] GetClustersByTextLength(int textLengthLimit)
    {
      var res = new List<Guid[]>();
      var current = new List<Guid>();
      var length = 0;

      foreach (var x in _data)
      {
        if (_done.Contains(x.Key))
          continue;

        length += x.Value.Get("Text", string.Empty).Length;

        if (length >= textLengthLimit)
        {
          res.Add(current.ToArray());
          current.Clear();
          length = 0;
        }

        current.Add(x.Key);
      }
      if (current.Count > 0)
        res.Add(current.ToArray());
      return res.ToArray();
    }

    public Dictionary<Guid, Dictionary<string, object>> GetMetadata(IEnumerable<Guid> guids)
      => guids.Where(guid =>
        _data.ContainsKey(guid)).ToDictionary(guid => guid,
        guid => _data[guid].Where(x => !x.Key.StartsWith("!") && x.Key != "Text")
          .ToDictionary(x => x.Key, x => x.Value));

    public Dictionary<Guid, string> GetText(IEnumerable<Guid> guids)
      => guids.Where(guid => _data.ContainsKey(guid)).ToDictionary(guid => guid, guid => _data[guid]["Text"] as string);

    public Dictionary<Guid, Dictionary<string, object>> GetAll(bool ignoreInternalValues = true) => GetAll(_done, ignoreInternalValues);

    public Dictionary<Guid, Dictionary<string, object>> GetAll(IEnumerable<Guid> guids, bool ignoreInternalValues = true)
      => guids.Where(guid => _data.ContainsKey(guid))
        .ToDictionary(guid => guid, guid => ignoreInternalValues
          ? _data[guid].Where(x => !x.Key.StartsWith("!")).ToDictionary(x => x.Key, x => x.Value)
          : _data[guid]);

    public IEnumerable<Dictionary<string, object>> GetAllSimple(bool ignoreInternalValues = true) => GetAllSimple(_done, ignoreInternalValues);

    public IEnumerable<Dictionary<string, object>> GetAllSimple(IEnumerable<Guid> guids, bool ignoreInternalValues = true)
      => guids.Where(guid => _data.ContainsKey(guid))
      .Select(guid => ignoreInternalValues
        ? _data[guid].Where(x => !x.Key.StartsWith("!")).ToDictionary(x => x.Key, x => x.Value)
        : _data[guid]);

    public string GetStickedText(IEnumerable<Guid> guids)
    {
      if (Tokenizer == null)
        Tokenizer = new HighSpeedSpaceTokenizer();

      return Tokenizer.Execute(string.Join(ProcessingSeparator, from guid in guids where _data.ContainsKey(guid) select _data[guid].Get("Text", string.Empty)));
    }

    public IEnumerable<Guid> ValidateProcessing(ref string processingOutput, ref Guid[] guids)
    {
      var items = processingOutput.Split(new[] { ProcessingSeparator }, StringSplitOptions.None);
      var max = items.Length == guids.Length ? items.Length : items.Length - 1;

      var res = new List<Guid>();
      for (var i = 0; i < max; i++)
      {
        _data[guids[i]].Set("Text", items[i]);
        res.Add(guids[i]);
        _done.Add(guids[i]);
      }
      return res;
    }
  }
}

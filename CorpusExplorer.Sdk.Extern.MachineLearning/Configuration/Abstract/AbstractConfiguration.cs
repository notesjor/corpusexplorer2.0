using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Abstract
{
  public abstract class AbstractConfiguration<T> where T : new()
  {
    public T Load(string path)
    {
      try
      {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
      }
      catch
      {
        var obj = new T();
        File.WriteAllText(path, JsonConvert.SerializeObject(obj), Encoding.UTF8);
        return obj;
      }
    }
  }
}

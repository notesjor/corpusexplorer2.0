using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Blocks.Measure;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Cache;
using CorpusExplorer.Terminal.Universal.Message.Request.File;
using CorpusExplorer.Terminal.Universal.Message.Response.Size;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void ProjectNew(HttpContext obj)
    {
      _terminal.ProjectNew();
      _fast_selection = null;
      
      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectSave(HttpContext obj)
    {
      var path = obj.Request.PostData<RequestFileSingle>()?.Path;
      _terminal.Project.Save(path, false);
      
      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectLoad(HttpContext obj)
    {
      var path = obj.Request.PostData<RequestFileSingle>()?.Path;
      _terminal.ProjectLoad(path, out var error, Path.GetDirectoryName(path));
      _fast_selection = null;

      obj.Response.Send(HttpStatusCode.OK);
    }

    private static void ProjectSettingsGet(HttpContext obj)
    {
      var settings = Configuration.GetSettings();
      settings.Add("Cache-System", Configuration.Cache.GetType().Name);
      settings.Add("Similarity", Configuration.Measure.GetType().Name);
      settings.Add("Minimum (Frequency)", Configuration.MinimumFrequency);
      settings.Add("Minimum (Significance)", Configuration.MinimumSignificance);
      settings.Add("Significance", Configuration.GetSignificanceType().Name);

      obj.Response.Send(settings);
    }

    private static void ProjectSettingsSet(HttpContext obj)
    {
      var data = obj.Request.PostData<Dictionary<string, object>>();
      if(data.ContainsKey("Cache-System"))
      {
        switch(data["Cache-System"].ToString())
        {
          case "CacheStrategyCurrentSelection":
            Configuration.Cache = new CacheStrategyCurrentSelection();
            break;
          case "CacheStrategyClearCacheManually":
            Configuration.Cache = new CacheStrategyClearCacheManually();
            break;
          default:
            Configuration.Cache = new CacheStrategyDisableCaching();
            break;
        }
        data.Remove("Cache-System");
      }
      if(data.ContainsKey("Similarity"))
      {
        switch(data["Similarity"].ToString())
        {
          case "DiceCoefficient":
            Configuration.Measure = new DiceCoefficient();
            break;
          case "PhiMeasure":
            Configuration.Measure = new PhiMeasure();
            break;
          case "YuleMeasure":
            Configuration.Measure = new YuleMeasure();
            break;
        }

        data.Remove("Similarity");
      }
      if(data.ContainsKey("Minimum (Frequency)"))
      {
        Configuration.MinimumFrequency = Convert.ToInt32(data["Minimum (Frequency)"]);

        data.Remove("Minimum (Frequency)");
      }
      if(data.ContainsKey("Significance"))
      {
        switch (data["Significance"].ToString())
        {
          case "ChiSquaredSignificance":
            Configuration.SetSignificance(new ChiSquaredSignificance());
            break;
          case "LogLikelihoodSignificance":
            Configuration.SetSignificance(new LogLikelihoodSignificance());
            break;
          default:
            Configuration.SetSignificance(new PoissonSignificance());
            break;
        }

        data.Remove("Significance");
      }
      if (data.ContainsKey("Minimum (Significance)"))
      {
        Configuration.MinimumSignificance = Convert.ToDouble(data["Minimum (Significance)"]);

        data.Remove("Minimum (Significance)");
      }

      Configuration.SetSettings(data);
    }

    private static void ProjectInfo(HttpContext obj)
    {
      obj.Response.Send(new ResponseSize
      {
        Corpora = _terminal.Project.CountCorpora,
        Documents = _terminal.Project.CountDocuments,
        Tokens =  _terminal.Project.CountToken,
        Layers = new HashSet<string>(_terminal.Project.LayerDisplaynames).Count
      });
    }
  }
}

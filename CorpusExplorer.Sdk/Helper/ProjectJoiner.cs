using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ProjectJoiner
  {
    public static Project JoinFull(this Project projectA, Project projectB, string newProjectDisplayname = null)
    {
      var res = Project.Create(newProjectDisplayname ?? $"{projectA.Displayname} ++ {projectB.Displayname}");

      foreach (var c in projectA.CorporaGuids)
        res.Add(projectA.GetCorpus(c));

      foreach (var c in projectB.CorporaGuids)
        res.Add(projectB.GetCorpus(c));

      return res;
    }

    public static Project JoinInner(this Project projectA, Project projectB, string newProjectDisplayname = null)
    {
      var res = Project.Create(newProjectDisplayname ?? $"{projectA.Displayname} >< {projectB.Displayname}");
      var prB = new HashSet<Guid>(projectB.CorporaGuids);

      foreach (var c in projectA.CorporaGuids)
        if (prB.Contains(c))
          res.Add(projectA.GetCorpus(c));

      return res;
    }

    public static Project JoinLeft(this Project projectA, Project projectB, string newProjectDisplayname = null)
    {
      var res = Project.Create(newProjectDisplayname ?? $"{projectA.Displayname} >> {projectB.Displayname}");
      var prB = new HashSet<Guid>(projectB.CorporaGuids);

      foreach (var c in projectA.CorporaGuids)
        if (!prB.Contains(c))
          res.Add(projectA.GetCorpus(c));

      return res;
    }

    public static Project JoinOuter(this Project projectA, Project projectB, string newProjectDisplayname = null)
    {
      var res = Project.Create(newProjectDisplayname ?? $"{projectA.Displayname} <> {projectB.Displayname}");
      var prB = new HashSet<Guid>(projectB.CorporaGuids);

      foreach (var c in projectA.CorporaGuids)
        if (!prB.Contains(c))
          res.Add(projectA.GetCorpus(c));

      var prA = new HashSet<Guid>(projectA.CorporaGuids);
      foreach (var c in projectB.CorporaGuids)
        if (!prA.Contains(c))
          res.Add(projectB.GetCorpus(c));

      return res;
    }
  }
}
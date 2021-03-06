﻿using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Extension
{
  public static class PersNameExtension
  {
    public static string Name(this persName obj)
    {
      var val = obj.Items.OfType<name>().FirstOrDefault()?.Text;
      return val == null ? string.Empty : string.Join(" ", val);
    }
  }
}
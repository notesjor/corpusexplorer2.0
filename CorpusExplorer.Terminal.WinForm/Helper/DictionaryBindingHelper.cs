#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class DictionaryBindingHelper
  {
    public static void BindDictionary<T>(IEnumerable<T> dictionary, RadDropDownList radDropDownList)
    {
      try
      {
        BindDictionary(dictionary.ToDictionary(x => x, x => x), radDropDownList);
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(IEnumerable<KeyValuePair<T, K>> dictionary, RadDropDownList radDropDownList)
    {
      try { BindDictionary(dictionary.ToDictionary(x => x.Key, x => x.Value), radDropDownList); }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(Dictionary<T, K> dictionary, RadDropDownList radDropDownList)
    {
      if (dictionary == null)
        return;
      if (radDropDownList == null)
        return;

      try
      {
        radDropDownList.DataBindings.Clear();

        radDropDownList.DisplayMember = "Value";
        radDropDownList.ValueMember = "Key";

        radDropDownList.DataSource = dictionary;
        radDropDownList.AutoCompleteMode = AutoCompleteMode.Append;
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(
      IEnumerable<KeyValuePair<T, K>> dictionary,
      CommandBarDropDownList radDropDownList)
    {
      try
      {
        BindDictionary(dictionary.ToDictionary(x => x.Key, x => x.Value), radDropDownList);
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(Dictionary<T, K> dictionary, CommandBarDropDownList radDropDownList)
    {
      if (dictionary == null)
        return;
      if (radDropDownList == null)
        return;

      try
      {
        radDropDownList.DataBindings.Clear();

        radDropDownList.DisplayMember = "Value";
        radDropDownList.ValueMember = "Key";

        radDropDownList.DataSource = dictionary;
        radDropDownList.AutoCompleteMode = AutoCompleteMode.Append;
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(IEnumerable<KeyValuePair<T, K>> dictionary, RadListView radDropDownList)
    {
      try
      {
        BindDictionary(dictionary.ToDictionary(x => x.Key, x => x.Value), radDropDownList);
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary<T, K>(Dictionary<T, K> dictionary, RadListView radDropDownList)
    {
      if (dictionary == null)
        return;
      if (radDropDownList == null)
        return;

      try
      {
        radDropDownList.DataBindings.Clear();

        radDropDownList.DisplayMember = "Value";
        radDropDownList.ValueMember = "Key";

        radDropDownList.DataSource = dictionary;
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary(
      Dictionary<string, string> dictionary,
      RadDropDownButton radDropDownButton,
      EventHandler func)
    {
      if (dictionary == null)
        return;
      if (radDropDownButton == null)
        return;

      try
      {
        radDropDownButton.Items.Clear();

        foreach (var btn in dictionary.Select(entry => new RadMenuItem(entry.Value) { Tag = entry.Key }))
        {
          btn.Click += func;
          radDropDownButton.Items.Add(btn);
        }
      }
      catch
      {
        // ignore
      }
    }

    public static void BindDictionary(Dictionary<string, string> dictionary, RadMenuItem radMenuItem, EventHandler func)
    {
      if (dictionary == null)
        return;
      if (radMenuItem == null)
        return;

      try
      {
        radMenuItem.Items.Clear();

        foreach (var btn in dictionary.Select(entry => new RadMenuItem(entry.Value) { Tag = entry.Key }))
        {
          btn.Click += func;
          radMenuItem.Items.Add(btn);
        }
      }
      catch
      {
        // ignore
      }
    }
  }
}
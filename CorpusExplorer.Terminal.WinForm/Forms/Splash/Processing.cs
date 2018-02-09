﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms;

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash
{
  public static class Processing
  {
    private static Task _thread;

    public static string Message { get; set; }

    public static bool Show { get; set; }

    public static void Invoke(string message, Action action)
    {
      SplashShow(message);

      try
      {        
        action();
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      SplashClose();
    }

    public static void SplashClose()
    {
      InMemoryErrorConsole.ActionStop();
      Show = false;
    }

    public static void SplashShow(string message)
    {
      Show = true;

      if ((_thread == null) || (_thread.Status != TaskStatus.Running))
      {
        Message = message;
        _thread = Task.Factory.StartNew(
            () =>
            {
              try
              {
                var splashForm = new ProcessingForm();
                InMemoryErrorConsole.ActionStart(message);
                splashForm.ShowDialog();
              }
              catch {}
            });
      }
      else
        Message = message;           
    }
  }
}
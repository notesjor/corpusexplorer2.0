using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Cache;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.WaitBehaviour;
using CorpusExplorer.Terminal.Console.Web;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Publishing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.Bridge
{
  public partial class BridgeForm : AbstractForm
  {
    private Project _project;
    private string _ip;
    private int _port;
    private WebServiceBridge _bridge = null;    
    private HashSet<string> _corpora = new HashSet<string>();

    public BridgeForm()
    {
      InitializeComponent();

      _project = CorpusExplorerEcosystem.InitializeMinimal(new CacheStrategyDisableCaching());

      Shown += MainForm_Shown;
      FormClosing += MainForm_FormClosing;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      _bridge.Dispose();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      ServiceStartCall();
    }

    private void btn_serviceRestart_Click(object sender, EventArgs e)
    {
      ServiceRestart();
    }

    private void ServiceRestart()
    {
      try
      {
        ServiceStartCall();

        var client = new HttpClient();
        client.Timeout = TimeSpan.FromMilliseconds(100);
        try
        {
          client.GetAsync($"http://{_ip}:{_port}/restart").Wait();
        }
        catch
        {
          // ignore
        }
        AddCorpora(_corpora.ToArray());

        ServiceStartCall();
      }
      catch
      {
        // ignore
      }
    }

    private void ServiceStartCall()
    {
      try
      {
        _ip = txt_ip.Text.Replace(" ", "");
        _port = int.Parse(txt_port.Text);

        _bridge = new WebServiceBridge(ref _project, new JsonTableWriter { WriteTid = false }, _ip, _port);
        _bridge.Selection = _project.SelectAll;
        _bridge.Run(new WaitBehaviourNone(), ServiceStoppedCall);        

        lbl_status.Invoke(new Action(() =>
        {
          lbl_status.ForeColor = Color.Green;
          lbl_status.Text = "LÄUFT";
        }));
      }
      catch
      {
        // ignore
      }

      Refresh();
    }

    private void ServiceStoppedCall(Task task)
    {
      if (lbl_status.InvokeRequired)
      {
        lbl_status.Invoke(new Action(() =>
        {
          lbl_status.Text = "ABBRUCH";
          lbl_status.ForeColor = Color.Red;
        }));
      }

      _bridge.Dispose();
    }

    private void btn_corpusAdd_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = "CorpusExplorer (*.cec6)|*.cec6;*.cec6.gz;*.cec6.lz4",
        CheckFileExists = true,
        Multiselect = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      AddCorpora(ofd.FileNames);

      RefeshCorpusList();
    }

    private void AddCorpora(IEnumerable<string> corpora)
    {
      panel_load.Visible = false;
      lbl_load.Visible = true;

      Refresh();

      foreach (var file in corpora)
      {
        if (_corpora.Contains(file))
          continue;

        var res = false;
        if (file.StartsWith("http"))
          res = AddCorpora_Url(file);
        else
          res = AddCorpora_File(file);


        if (!res)
          continue;

        _corpora.Add(file);
      }

      _bridge.Selection = _project.SelectAll;

      panel_load.Visible = true;
      lbl_load.Visible = false;
    }

    private bool AddCorpora_File(string file)
    {
      try
      {
        var corpus = CorpusAdapterWriteDirect.Create(file);
        if(corpus == null)
          return false;

        _project.Add(corpus);
        return true;
      }
      catch
      {
        return false;
      }
    }

    private bool AddCorpora_Url(string url)
    {
      if (url.EndsWith(".drm"))
      {
        try
        {
          using (var temp = new TemporaryDirectory())
          using (var wc = new WebClient())
          {
            var file = Path.Combine(temp.Path, Path.GetFileName(url));
            wc.DownloadFile(url, file);
            wc.DownloadFile(url, file + "db");

            var corpus = PublishingController.ReadCryptedCorpora(new[] { file }).FirstOrDefault();
            if (corpus == null)
              return false;

            _project.Add(corpus);
            return true;
          }
        }
        catch
        {
          return false;
        }
      }
      else if (url.Contains(".cec6"))
      {
        try
        {
          using (var temp = new TemporaryDirectory())
          using (var wc = new WebClient())
          {
            var file = Path.Combine(temp.Path, Path.GetFileName(url));
            wc.DownloadFile(url, file);

            var corpus = CorpusAdapterWriteDirect.Create(file);
            if(corpus == null)
              return false;

            _project.Add(corpus);
            return true;
          }
        }
        catch
        {
          return false;
        }
      }
      return false;
    }

    private void RefeshCorpusList()
    {
      radListView1.Items.Clear();
      foreach (var corpus in _corpora)
        radListView1.Items.Add(new ListViewDataItem(corpus));
    }

    private void btn_new_Click(object sender, EventArgs e)
    {      
      _corpora.Clear();
      RefeshCorpusList();
      ServiceRestart();
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = "CorpusExplorerBridge (*.ceb)|*.ceb",
        CheckFileExists = true,
        Multiselect = false
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _corpora.Clear();
      var corpora = File.ReadAllLines(ofd.FileName);

      AddCorpora(corpora);

      RefeshCorpusList();
      ServiceRestart();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        Filter = "CorpusExplorerBridge (*.ceb)|*.ceb",
        CheckPathExists = true,
        OverwritePrompt = true
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.WriteAllLines(sfd.FileName, _corpora);
    }

    private void btn_loadUrl_Click(object sender, EventArgs e)
    {
      var form = new AddUrl();
      if (form.ShowDialog() != DialogResult.OK)
        return;
      AddCorpora(form.Result);
    }
  }
}

using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.WaitBehaviour;
using CorpusExplorer.Terminal.Console.Web;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Bridge
{
  public partial class MainForm : AbstractForm
  {
    private HashSet<string> _corpora = new HashSet<string>();
    private string _ip;
    private int _port;
    private WebServiceBridge _bridge = null;

    public MainForm()
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      InitializeComponent();

      Shown += MainForm_Shown;
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      ServiceStartCall();
    }

    private void btn_serviceRestart_Click(object sender, EventArgs e)
    {
      try
      {
        _bridge.Cancel();

        var client = new RestClient();
        var request = new RestRequest($"http://{_ip}:{_port}/restart");
        request.Timeout = 100;
        client.Execute(request);

        ServiceStartCall();

        AddCorpora(_corpora);
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

        _bridge = new WebServiceBridge(new JsonTableWriter(), _ip, _port);
        _bridge.Run(new WaitBehaviourNone(), ServiceStoppedCall);

        lbl_status.Invoke(new Action(() =>
        {
          lbl_status.ForeColor = Color.Green;
          lbl_status.Text = "Läuft";
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
          lbl_status.Text = "Gestoppt";
          lbl_status.ForeColor = Color.Red;
        }));
      }
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
          res = _bridge.LoadCorpus(new Uri(file));
        else
          res = _bridge.LoadCorpus(file);


        if (!res)
          continue;

        _corpora.Add(file);
      }

      panel_load.Visible = true;
      lbl_load.Visible = false;
    }

    private void RefeshCorpusList()
    {
      radListView1.Items.Clear();
      foreach (var corpus in _corpora)
        radListView1.Items.Add(new ListViewDataItem(corpus));
    }

    private void btn_new_Click(object sender, EventArgs e)
    {
      _bridge.UnloadCorpora();
      _corpora.Clear();
      RefeshCorpusList();
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

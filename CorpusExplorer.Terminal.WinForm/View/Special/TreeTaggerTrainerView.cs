using System;
using System.Windows.Forms;
using CorpusExplorer.Port.TreeTaggerTrainer.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class TreeTaggerTrainerView : AbstractView
  {
    private readonly TreeTaggerTrainerViewModel _model;
    private string _fileDialogFilter;
    private string _selectedLayerDisplayname;

    public TreeTaggerTrainerView()
    {
      _model = new TreeTaggerTrainerViewModel();

      InitializeComponent();

      ShowView += (sender, args) => { combo_layer.DataSource = Project.CurrentSelection.LayerDisplaynames; };
    }

    private void btn_add_lexica_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {CheckFileExists = true, Filter = GetFileDialogFilter(Resources.Lexikon, "ttlex")};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      _model.AddLexicon(ofd.FileName);
      RefreshCounter();
    }

    private void btn_add_traindata_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = GetFileDialogFilter(Resources.Trainingsdaten, "tttrain")
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      _model.AddTraindata(ofd.FileName);
      RefreshCounter();
    }

    private void btn_del_lexica_Click(object sender, EventArgs e) { _model.ClearAllLexicons(); }

    private void btn_del_traindata_Click(object sender, EventArgs e) { _model.ClearAllTraindata(); }

    private void btn_gen_lexica_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {CheckPathExists = true, Filter = GetFileDialogFilter(Resources.Lexikon, "ttlex")};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _model.GenerateLexicon(Project.CurrentSelection, _selectedLayerDisplayname, sfd.FileName);
      _model.AddLexicon(sfd.FileName);
      RefreshCounter();
    }

    private void btn_gen_traindata_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = GetFileDialogFilter(Resources.Trainingsdaten, "tttrain")
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _model.GenerateTraindata(Project.CurrentSelection, _selectedLayerDisplayname, sfd.FileName);
      _model.AddTraindata(sfd.FileName);
      RefreshCounter();
    }

    private void btn_selectExe_Click(object sender, EventArgs e)
    {
      // ReSharper disable once LocalizableElement
      var ofd = new OpenFileDialog {CheckFileExists = true, Filter = "train-tree-tagger.exe|train-tree-tagger.exe"};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      _model.TrainTreeTaggerPath = ofd.FileName;
      label1.Text = ofd.FileName;
    }

    private void btn_selectOutput_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {CheckPathExists = true, Filter = Resources.FileExtension_PAR};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _model.ParOutputPath = sfd.FileName;
    }

    private void btn_start_Click(object sender, EventArgs e) { _model.StartTraining(); }

    private void combo_layer_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (combo_layer.SelectedIndex == -1)
        return;

      _selectedLayerDisplayname = combo_layer.SelectedItem.Text;

      _fileDialogFilter = string.Format(
        Resources.ToLayerOutputPattern,
        _selectedLayerDisplayname.Replace(" ", "_"));
    }

    private string GetFileDialogFilter(string label, string extension)
    {
      return string.Format(_fileDialogFilter.Replace("[0]", "{0}").Replace("[1]", "{1}"), label, extension);
    }

    private void RefreshCounter()
    {
      lbl_lexicaCount.Text = _model.CountLexcions.ToString();
      lbl_traindataCount.Text = _model.CountTraindata.ToString();
    }
  }
}
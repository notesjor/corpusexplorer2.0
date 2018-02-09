#region

using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  /// <summary>
  ///   The abstract visualisation.
  /// </summary>
  [ToolboxItem(false)]
  public partial class AbstractView : AbstractUserControl
  {
    private GuiModelBuilderProjectRequestDelegate _getProjectDelegate;

    private Type _viewModelType;

    protected AbstractView() { InitializeComponent(); }

    protected Project Project { get { return _getProjectDelegate(); } }

    public IViewModel ViewModel { get; set; }

    public event EventHandler CloseView;

    protected void CreateSelection(IEnumerable<AbstractFilterQuery> queries)
    {
      if (queries == null)
        return;

      var list = queries.ToList();
      var first = list.FirstOrDefault();
      if (first == null)
        return;

      if (list.Count > 1)
      {
        list.RemoveAt(0);
        first.OrFilterQueries = list;
      }

      var form = new SimpleTextInput(
        Resources.SchnappschussErstellen,
        Resources.GebenSieDemNeuenSchnappschussEinenNamen,
        Resources.camera,
        Resources.NameHierEintragen);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      Project.CreateSelection(new[] { first }, form.Result, Project.CurrentSelection);
    }

    internal void InitializeVisualisation(GuiModelBuilderProjectRequestDelegate getProjectDelegate)
    {
      _getProjectDelegate = getProjectDelegate;
    }

    public void OnShowVisualisation()
    {
      if (ShowView != null)
        Processing.Invoke(Resources.LoadModule, () => ShowView(null, null));
    }

    public event EventHandler ShowView;

    public void ViewModelClear()
    {
      ViewModel = null;
      CloseView?.Invoke(null, null);
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    protected T ViewModelGet<T>() where T : class, IViewModel, new()
    {
      if ((ViewModel == null) || (typeof(T) != _viewModelType))
      {
        ViewModel = new T { Selection = Project.CurrentSelection };
        _viewModelType = typeof(T);
      }

      if (!Equals(ViewModel.Selection, Project.CurrentSelection))
        ViewModel.Selection = Project.CurrentSelection;

      return (T)ViewModel;
    }
  }
}
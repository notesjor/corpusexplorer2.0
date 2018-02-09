namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Tagger
{
  /// <summary>
  ///   Delegate SelectedTaggerItemChange
  /// </summary>
  /// <param name="satz">The satz.</param>
  /// <param name="wort">The wort.</param>
  /// <param name="selected">
  ///   if set to <c>true</c> [selected].
  /// </param>
  public delegate void SelectedTaggerItemChange(int satz, int wort, bool selected);
}
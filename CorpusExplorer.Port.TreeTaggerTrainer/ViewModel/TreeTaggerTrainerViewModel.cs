#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Port.TreeTaggerTrainer.Model;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Port.TreeTaggerTrainer.ViewModel
{
  public class TreeTaggerTrainerViewModel
  {
    private List<string> _lexicons;
    private List<string> _trainDatas;

    public TreeTaggerTrainerViewModel()
    {
      TrainTreeTaggerPath = @"C:\TreeTagger\bin\train-tree-tagger.exe";
      _lexicons = new List<string>();
      _trainDatas = new List<string>();
    }

    public int CountLexcions => _lexicons.Count;

    public int CountTraindata => _trainDatas.Count;

    public string ParOutputPath { get; set; }

    public bool ReadyToTrain
    {
      get
      {
        if (!TrainTreeTaggerValid)
          return false;
        if (_lexicons.Count == 0)
          return false;
        if (_trainDatas.Count == 0)
          return false;
        return !string.IsNullOrEmpty(ParOutputPath);
      }
    }

    public string TrainTreeTaggerPath { get; set; }

    public bool TrainTreeTaggerValid => !string.IsNullOrEmpty(TrainTreeTaggerPath) && File.Exists(TrainTreeTaggerPath);

    public void AddLexicon(string path)
    {
      _lexicons.Add(path);
      _lexicons = ValidateList(_lexicons);
    }

    public void AddTraindata(string path)
    {
      _trainDatas.Add(path);
      _trainDatas = ValidateList(_trainDatas);
    }

    public void ClearAllLexicons()
    {
      _lexicons.Clear();
    }

    public void ClearAllTraindata()
    {
      _trainDatas.Clear();
    }

    public void GenerateLexicon(Selection selection, string layerDisplayname, string path)
    {
      var lex = new Lexicon(selection, layerDisplayname);
      Serializer.Serialize(lex, path, true);
      lex.GenerateTextFile(path + ".txt");
    }

    public void GenerateTraindata(Selection selection, string layerDisplayname, string path)
    {
      FileIO.Write(path, Traindata.Create(selection, layerDisplayname));
    }

    public void StartTraining()
    {
      if (!ReadyToTrain)
        return;

      if (File.Exists(ParOutputPath))
        File.Delete(ParOutputPath);

      var trainPath = Path.Combine(
                                   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                   "CorpusExplorer/temp");
      if (Directory.Exists(trainPath))
        Directory.CreateDirectory(trainPath);

      var lexPath = Path.Combine(trainPath, "lex.txt");
      var traPath = Path.Combine(trainPath, "training.txt");
      var unkPath = Path.Combine(trainPath, "unknown.txt");
      if (File.Exists(unkPath))
      {
        File.Delete(unkPath);
        File.Create(unkPath).Close();
      }

      MergeTrainingData(traPath);
      MergeLexicons(lexPath);

      var process = Process.Start(
                                  new ProcessStartInfo
                                  {
                                    FileName = TrainTreeTaggerPath,
                                    Arguments =
                                      $"{lexPath} {unkPath} {traPath} {ParOutputPath}",
                                    CreateNoWindow = true,
                                    WindowStyle = ProcessWindowStyle.Hidden
                                  });

      process?.WaitForExit();

      MessageBox.Show(File.Exists(ParOutputPath) ? "Training erfolgreich!" : "PAR-Model konnte nicht erstellt werden");
    }

    private void MergeLexicons(string path)
    {
      new Lexicon(_lexicons.Select(Serializer.Deserialize<Lexicon>)).GenerateTextFile(path);
    }

    private void MergeTrainingData(string path)
    {
      var stb = new StringBuilder();

      foreach (var file in _trainDatas)
        stb.AppendLine(FileIO.ReadText(file));

      FileIO.Write(path, stb.ToString());
    }

    /// <summary>
    ///   Überprüft, ob die Dateien exsisitieren und verhindert doppelte Einträge.
    /// </summary>
    /// <param name="dic">The dic.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    private List<string> ValidateList(IEnumerable<string> dic)
    {
      var hash = new HashSet<string>();
      foreach (var entry in dic.Where(File.Exists))
        hash.Add(entry);
      return hash.ToList();
    }
  }
}
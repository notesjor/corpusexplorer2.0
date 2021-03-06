﻿using System.Data;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.Interface;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel.Abstract
{
  public abstract class AbstractLdaViewModel : AbstractViewModel, IProvideDataTable, ILda
  {
    public abstract DataTable GetDataTable();

    public int MaximumNgramsCount { get; set; } = 10000000;
    public bool UseAllLengths { get; set; } = true;
    public int SkipLength { get; set; } = 0;
    public int NgramLength { get; set; } = 2;
    public int MaximumNumberOfKeys { get; set; } = 1000000;
    public bool KeepNumbers { get; set; } = false;
    public bool KeepPunctuations { get; set; } = true;
    public bool KeepDiacritics { get; set; } = true;
    public string LayerDisplayname { get; set; } = "Lemma";
    public CaseMode CaseMode { get; set; } = CaseMode.None;
    public Language Language { get; set; } = Language.German;
    public WeightingCriteria WeightingCriteria { get; set; } = WeightingCriteria.Tf;
    public int NumberOfBurninIterations { get; set; } = 10;
    public int NumberOfSummaryTermsPerTopic { get; set; } = 10;
    public int MaximumTokenCountPerDocument { get; set; } = 512;
    public int LikelihoodInterval { get; set; } = 5;
    public int MaximumNumberOfIterations { get; set; } = 200;
    public int SamplingStepCount { get; set; } = 4;
    public float Beta { get; set; } = 0.01f;
    public float AlphaSum { get; set; } = 100;
    public int NumberOfTopics { get; set; } = 5;
  }
}

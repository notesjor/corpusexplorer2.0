namespace CorpusExplorer.Sdk.Blocks.ClusterMetadata
{
  public class ClusterMetadataItem
  {
    public ClusterMetadataItem(string label, object data)
    {
      Label = label;
      Data = data;
      Similarity = 1;
    }

    public ClusterMetadataItem(ClusterMetadataItem cA, ClusterMetadataItem cB, string label, object data,
                               double similarity)
    {
      CA = cA;
      CB = cB;
      Label = label;
      Data = data;
      Similarity = similarity;

      CA.DisposeData();
      CB.DisposeData();
    }

    public ClusterMetadataItem CA { get; }
    public ClusterMetadataItem CB { get; }
    public string Label { get; }
    public object Data { get; private set; }
    public double Similarity { get; }

    public void DisposeData()
    {
      Data = null;
    }
  }
}
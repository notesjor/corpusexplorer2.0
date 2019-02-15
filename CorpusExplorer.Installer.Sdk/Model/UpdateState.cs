namespace CorpusExplorer.Installer.Sdk.Model
{
  public class UpdateState
  {
    private UpdateState()
    {
    }

    public UpdateState(string url)
    {
      Url = url;

      if (Url.ToLower().EndsWith(".cec5.gz") || Url.ToLower().EndsWith(".cec5"))
        Type = UpdateStateType.Cec5;
      else if (Url.ToLower().EndsWith(".cec6.gz") || Url.ToLower().EndsWith(".cec6"))
        Type = UpdateStateType.Cec6;
      else if (Url.ToLower().EndsWith(".cec7.gz") || Url.ToLower().EndsWith(".cec7"))
        Type = UpdateStateType.Cec7;
      else if (Url.ToLower().EndsWith(".cec8.gz") || Url.ToLower().EndsWith(".cec8"))
        Type = UpdateStateType.Cec8;
      else if (Url.ToLower().EndsWith(".cec9.gz") || Url.ToLower().EndsWith(".cec9"))
        Type = UpdateStateType.Cec9;
      else if (Url.ToLower().EndsWith(".cecp"))
        Type = UpdateStateType.Cecp;
      else if (Url.ToLower().EndsWith(".cedb"))
        Type = UpdateStateType.Cedb;
      else if (Url.ToLower().EndsWith(".cefs"))
        Type = UpdateStateType.Cefs;
      else if (Url.ToLower().EndsWith(".cml"))
        Type = UpdateStateType.Cml;
      else if (Url.StartsWith("LINK#"))
        Type = UpdateStateType.Link;
      else if (Url.StartsWith("CALL#"))
        Type = UpdateStateType.Call;
      else if (Url.ToLower().EndsWith(".zip"))
        Type = UpdateStateType.Zip;
      else
        Type = UpdateStateType.None;
    }

    public string Delete { get; set; }
    public bool InstallationCompleted { get; set; }
    public UpdateStateType Type { get; }
    public string OnlineVersion { get; set; }
    public string Url { get; }
  }
}
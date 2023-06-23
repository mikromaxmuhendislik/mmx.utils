namespace V7.BaseApplication.Utilies.Models.Ftp
{
    public class GetFileFromFtpQuery
    {
        public FtpSettings FtpSettings { get; set; }
        public string RemoteFileName { get; set; }
        public string FtpFileName { get => $"{FtpSettings.BasePath}{RemoteFileName}"; }
    }
}

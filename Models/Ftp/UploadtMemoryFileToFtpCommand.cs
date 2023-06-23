namespace V7.BaseApplication.Utilies.Models.Ftp
{
    public class UploadtMemoryFileToFtpCommand : UploadFileToFtpCommand
    {
        public new byte[] File { get; set; }
    }
}

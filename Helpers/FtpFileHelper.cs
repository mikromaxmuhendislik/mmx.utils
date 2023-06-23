using FluentFTP;
using FluentFTP.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;
using V7.BaseApplication.Utilies.Exceptions;
using V7.BaseApplication.Utilies.Models.Ftp;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class FtpFileHelper
    {
        public async static Task UploadFileAsync(UploadFileToFtpCommand cmd)
        {
            ChechBasePath(cmd.FtpSettings.BasePath);
            using (var client = new AsyncFtpClient(cmd.FtpSettings.Server))
            {
                client.Credentials = new System.Net.NetworkCredential(cmd.FtpSettings.User, cmd.FtpSettings.Password);
                await client.AutoConnect();

                var result = await client.UploadFile(cmd.File, cmd.FtpFileName, FtpRemoteExists.Overwrite, createRemoteDir: true, FtpVerify.OnlyChecksum);
                if (result.IsFailure())
                {
                    throw new FtpFileUploadException();
                }
                await client.Disconnect();
            }

        }

        private static void ChechBasePath(string basePath)
        {
            if (!basePath.EndsWith("/"))
            {
                throw new ArgumentException("BasePath ayarı yanlış. FtpBasePath backslash ile bitmeli.");
            }
        }

        public async static Task UploadMemoryFileAsync(UploadtMemoryFileToFtpCommand cmd)
        {
            ChechBasePath(cmd.FtpSettings.BasePath);
            using (var client = new AsyncFtpClient(cmd.FtpSettings.Server))
            {
                client.Credentials = new System.Net.NetworkCredential(cmd.FtpSettings.User, cmd.FtpSettings.Password);
                await client.AutoConnect();
                await client.UploadStream(new MemoryStream(cmd.File), cmd.FtpFileName, FtpRemoteExists.Overwrite, createRemoteDir: true);
                await client.Disconnect();
            }
        }
        public static async Task GetFileFromFtp(GetFileFromFtpQuery query, MemoryStream output)
        {

            ChechBasePath(query.FtpSettings.BasePath);
            using (var client = new AsyncFtpClient(query.FtpSettings.Server))
            {
                client.Credentials = new System.Net.NetworkCredential(query.FtpSettings.User, query.FtpSettings.Password);
                await client.AutoConnect();

                var success = await client.DownloadStream(output, query.FtpFileName);
                if (!success)
                {
                    throw new InvalidOperationException();
                }

            }
        }
    }
}

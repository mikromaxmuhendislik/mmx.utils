using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Models.Ftp
{
    public class FtpSettings
    {
        /// <summary>
        /// Sunucu IP adresi 
        /// </summary>
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// Ftp'deki base klasör ismi. Her zaman backslash ile bitmeli.
        /// </summary>
        public string BasePath { get; set; }
        public string HttpPath { get; set; }
    }
}

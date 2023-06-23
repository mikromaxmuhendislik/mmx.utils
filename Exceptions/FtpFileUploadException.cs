using System;
using System.Runtime.Serialization;

namespace V7.BaseApplication.Utilies.Exceptions
{
    public class FtpFileUploadException : Exception
    {
        public FtpFileUploadException()
        {
        }

        public FtpFileUploadException(string message) : base(message)
        {
        }

        public FtpFileUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FtpFileUploadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

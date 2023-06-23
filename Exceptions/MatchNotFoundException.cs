using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Exceptions {
    public class MatchNotFoundException : Exception {
        public MatchNotFoundException() {
        }

        public MatchNotFoundException(string message) : base(message) {
        }

        public MatchNotFoundException(string message, Exception innerException) : base(message, innerException) {
        }

        protected MatchNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.IOHelpers
{
    public static class StreamConvertionHelpers
    {
        public static async Task<MemoryStream> ToByteStream(this string layoutData)
        {
            var stream = new MemoryStream();
            await stream.WriteAsync(Encoding.UTF8.GetBytes(layoutData), 0, layoutData.Length);
            return stream;

        }
    }
}

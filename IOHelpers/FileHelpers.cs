using System;
using System.IO;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.IOHelpers
{
    public static class FileHelpers
    {
        /// <summary>
        /// Creates a new file with the given name and write the content to it.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <exception cref="ArgumentException">Error if file exists allready.</exception>
        /// <returns></returns>
        public static async Task WriteBytesToNewFileAsync(string fileName, byte[] content)
        {
            using (Stream fileStream = EnsureFile(fileName))
            {
                await fileStream.WriteAsync(content, 0, content.Length);
            }
        }

        private static Stream EnsureFile(string fileName)
        {
            if (File.Exists(fileName))
                throw new ArgumentException("Dosya zaten var.");
            return File.Create(fileName);
        }
        public static bool CheckFileExists(this string fileName)
        {
            return File.Exists(fileName);
        }
    }
}

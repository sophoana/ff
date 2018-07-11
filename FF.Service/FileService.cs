using System.IO;
using System.Text;
using FF.Contracts.Service;

namespace FF.Service
{
    public class FileService : IFileService
    {
        public string[] ReadAllLines(string filePath)
        {
            ValidateFileExists(filePath);
            return File.ReadAllLines(filePath, Encoding.ASCII);
        }

        /// <summary>
        /// Verifies that a file exists
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="System.IO.IOException">Throws an IO exception</exception>
        private static void ValidateFileExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) ||
                !File.Exists(filePath))
            {
                throw new IOException("File not found");
            }
        }
    }
}

using System.IO;

namespace os.FileParser.Common.Utilities
{
    public class FileManipulator
    {
        public static bool SaveByteArrayFile(byte[] content, string filePath)
        {
            var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            fs.Write(content, 0, content.Length);
            fs.Close();

            return true;
        }
    }
}

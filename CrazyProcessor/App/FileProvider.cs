using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyProcessor.App
{
    public class FileProvider : IFileProvider
    {
        private const string FilePath = "data";

        public string? ReadFile(string fileName)
        {
            var fullFileName = Path.Combine(FilePath, fileName);
            if (!File.Exists(fullFileName))
            {
                return null;
            }

            return File.ReadAllText(fullFileName);
        }
    }
}

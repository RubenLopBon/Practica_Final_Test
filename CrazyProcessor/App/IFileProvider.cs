using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyProcessor.App
{
    public interface IFileProvider
    {
        string? ReadFile(string fileName);
    }
}

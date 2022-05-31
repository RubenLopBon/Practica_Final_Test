using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyProcessor.Processor
{
    public interface ITextProcessor
    {
        string ProcessText(string text, Operation operation);
        
        
    }
}

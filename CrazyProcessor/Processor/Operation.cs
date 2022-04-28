using System.ComponentModel;

namespace CrazyProcessor.Processor
{
    public enum Operation
    {
        [Description("Convertir a minúsculas")]
        ToLowerCase,

        [Description("Convertir a mayúsculas")]
        ToUpperCase,
    }
}

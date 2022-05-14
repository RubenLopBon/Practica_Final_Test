using System.ComponentModel;

namespace CrazyProcessor.Processor
{
    public enum Operation
    {
        [Description("Convertir a minúsculas")]
        ToLowerCase,

        [Description("Convertir a mayúsculas")]
        ToUpperCase,

        [Description("Contar mayúsculas y minúsculas")]
        ToCountCase,

        [Description("Invertir contenido")]
        ToTextInverser,

        [Description("Contar palabras")]
        WordCounter,

        [Description("Encriptar el texto")]
        textEncrypter,
    }
}

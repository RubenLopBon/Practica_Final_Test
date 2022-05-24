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

        [Description("Invertir contenido alfanumérico")]
        ToTextInverser,

        [Description("Contar palabras")]
        WordCounter,

        [Description("Encriptar el texto")]
        textEncrypter,

        [Description("Eliminar blancos con palabras en mayúsculas")]
        EliminarBlancos,

        [Description("Invertir palabras separadas por mayúsculas")]
        InvertirPalabras,
    }
}

namespace CrazyProcessor.Processor
{
    public class TextProcessor : ITextProcessor
    {
        public string ProcessText(string text, Operation operation)
        {
            switch (operation)
            {
                case Operation.ToLowerCase:
                    return this.ConvertToLowerCase(text);
                case Operation.ToUpperCase:
                    return this.ConvertToUpperCase(text);
                case Operation.ToCountCase:
                    return this.CountUpperAndLowerCase(text);
                case Operation.ToTextInverser:
                    return this.TextInverser(text);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        //Profe
        private string ConvertToLowerCase(string text)
        {
            return text.ToLowerInvariant();
        }

        private string ConvertToUpperCase(string text)
        {
            return text.ToUpperInvariant();
        }

        //Obligatorias
        //Marc


        //Ruben
        private string CountUpperAndLowerCase(string text)
        {
            String result = "El número de mayúsculas es: 0\n" +
                "El número de minúsculas es: 0";
            return result;
        }


        //Laura
        private string TextInverser(string text)
        {
            return "Inverso";
        }
        //TDD(6)
        //Marc

        //Laura

        //Ruben
    }
}

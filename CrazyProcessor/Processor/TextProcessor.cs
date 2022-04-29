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
                case Operation.WordCounter:
                    return this.WordCounter(text);
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

        // ************************** FUNCIONALIDADES EXTRAS OBLIGATORIAS *************************
        private string WordCounter(string text) // MARC //
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
        }

        private string CountUpperAndLowerCase(string text) // RUBÉN //
        {
            int countUpper = 0;
            int countLower = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i])) countUpper++;
                if (char.IsLower(text[i])) countLower++;
            }

            String result = "El número de mayúsculas es: " + countUpper + "\n" +
                "El número de minúsculas es: "+ countLower;
            return result;
        }

        private string TextInverser(string text) // LAURA //
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;

            for (int i = cArray.Length - 1; i >= 0; i--)
            {
                reverse += cArray[i];
            }

            return reverse;
        }

        // ************************ FUNCIONALIDADES TDD EXTRAS OBLIGATORIAS ***********************
        //Marc

        //Laura

        //Ruben
    }
}

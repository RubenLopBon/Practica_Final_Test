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

                case Operation.textEncrypter:
                    return this.TextEncrypter(text);

                case Operation.eliminarBlancos:
                    return this.EliminarBlancos(text);
                case Operation.invertirPalabras:
                    return this.InvertirPalabras(text);
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
       
        public string TextEncrypter(string text)
        {
     
                text = text.Replace("a", "i");
                text = text.Replace("e", "i");
                text = text.Replace("i", "i");
                text = text.Replace("o", "i");
                text = text.Replace("u", "i");

            
                string[] texts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
                for(int i=0 ; i < texts.Length; i++)
                {
                    if(i%2 == 0 && i != 0)
                    {
                        texts[i] = texts[i].ToUpper();
                    }
                    else
                    {
                        texts[i] = texts[i].ToLower();
                    }
                }

                return string.Join(" ", texts).Trim();
        }

        public string EliminarBlancos(string text) // LAURA //
        {
            return "Funcionalidad no desarrollada";
        }

        public string InvertirPalabras(string text) // LAURA //
        {
            return "Funcionalidad no desarrollada";
        }

        //Ruben
    }
}

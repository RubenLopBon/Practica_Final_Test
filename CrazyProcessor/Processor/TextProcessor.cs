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

                case Operation.EliminarBlancos:
                    return this.EliminarBlancos(text);
                case Operation.InvertirPalabras:
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
                "El número de minúsculas es: " + countLower;
            return result;
        }

        private string TextInverser(string text) // LAURA //
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;

            for (int i = cArray.Length - 1; i >= 0; i--)
            {
                if (!char.IsLetterOrDigit(cArray[i]) && !char.IsWhiteSpace(cArray[i])) 
                    throw new Exception("Conjunto de palabras incorrecto");
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

            for (int i = 0; i < texts.Length; i++)
            {
                if (i % 2 == 0 && i != 0)
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

        private string EliminarBlancos(string texto) // LAURA //
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            string[] palabras = texto.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            char[] letras; string frase = "";

            if (palabras.Length == 0) throw new Exception("Conjunto de palabras incorrecto");

            for (int i = 0; i <= palabras.Length - 1; i++)
            {
                letras = palabras[i].ToCharArray();
                for (int j = 0; j < letras.Length; j++)
                {
                    if (!char.IsLetter(letras[j])) throw new Exception("Conjunto de palabras incorrecto");

                    else if (j == 0)
                    {
                        if (char.IsLower(letras[0])) letras[0] = char.ToUpper(letras[0]);
                    }

                    else letras[j] = char.ToLower(letras[j]);

                    frase += letras[j];
                }
            }
            return frase;
        }

        private string InvertirPalabras(string text) // LAURA //
        {
            string aux = text.Replace(" ", "");
            string frase = "";

            if (aux.Length == 0) throw new Exception("Conjunto de palabras incorrecto");

            for (int i = 0; i < aux.Length; i++)
            {
                if (!char.IsLetter(aux[i])) throw new Exception("Conjunto de palabras incorrecto");
                else if (char.IsUpper(aux[i])) frase += " ";

                frase += aux[i];
            }

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            string[] palabras = frase.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            char[] letras; string reverse;

            frase = "";
            for (int j = 0; j < palabras.Length; j++)
            {
                letras = palabras[j].ToCharArray();
                Array.Reverse(letras);
                reverse = new string(letras);

                frase += reverse + " ";
            }
            return frase.Trim();
        }

        //Ruben
    }
}

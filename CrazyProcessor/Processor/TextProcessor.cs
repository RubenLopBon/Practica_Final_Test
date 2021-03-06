using System.Text;
using System.Text.RegularExpressions;

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

                case Operation.ContadorPorPalabra:
                    return this.ContadorPorPalabra(text);

                case Operation.ContadorVocales:
                    return this.ContadorVocales(text);
            
                case Operation.makeItEven:
                    return this.makeItEven(text);

                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

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

        private String makeItEven(string text)
        {

            string[] texts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = texts.Length;

            if (n == 0)
            {
                return "even MAKEITEVEN";
            }

            if (texts[0].Length % 2 != 0)
            {
                texts[0] = "even " + texts[0];
            }

            text = string.Join(" ", texts);
            texts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            n = texts.Length;

            if (texts[n - 1].Length % 2 != 0)
            {
                texts[n - 1] = texts[n - 1] + " even";
            }

            text = string.Join(" ", texts);
            texts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            n = texts.Length;

            text = string.Join(" ", texts).Trim();
            if (n % 2 != 0)
            {
                text = text + " MAKEITEVEN";
            }
            return text;
        }

        private String TextEncrypter(string text)
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

        //TDD Ruben
        private string ContadorPorPalabra(string text)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            string[] palabras = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int contador = 0;
            string solution = "";
            
            if (palabras.Length == 0) return "0";

            for (int i = 0; i < palabras.Length; i++)
            {
                for (int j = 0; j < palabras[i].Length; j++)
                {
                    if (char.IsLetter(palabras[i][j]))
                    {
                        contador++;
                    }
                }
                solution += palabras[i] + ":"+ contador + " ";
                contador = 0;
            }
            solution = solution.TrimEnd();
            return solution;
        }
       
        private string ContadorVocales(string text)
        {
            text = Regex.Replace(text.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
            int[] contador = new int[5];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < vocales.Length; j++)
                {
                    if (char.ToLower(text[i]) == vocales[j])
                    {
                        contador[j]++;
                    }
                }
            }
            string solution = "";
            for (int i = 0; i < vocales.Length; i++)
            {
                solution += vocales[i] + ":" + contador[i] + " ";
            }
            solution = solution.TrimEnd();
            return solution;
        }
        

    }
}

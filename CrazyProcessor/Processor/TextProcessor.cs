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


        //Rubén
        private string CountUpperAndLowerCase(string text)
        {
            return text.ToUpperInvariant();
        }


        //Laura
        private string TextInverser(string text)
        {
            return text.ToUpperInvariant();
        }
        //TDD(6)
        //Marc

        //Laura

        //Rubén
    }
}

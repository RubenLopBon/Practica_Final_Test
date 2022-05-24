namespace TDDTests
{
    public class TestTextProcessor
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("   ", "   ")]

        [InlineData("a", "a")]
        [InlineData("3", "3")]
        [InlineData("?", "?")]

        [InlineData("Mi Nombre Es Laura", "aruaL sE erbmoN iM")]
        [InlineData("Mi  Nombre    Es Laura", "aruaL sE    erbmoN  iM")]
        [InlineData(" Mi nombre es Laura", "aruaL se erbmon iM ")]
        [InlineData("   Mi nombre es Laura", "aruaL se erbmon iM   ")]
        public void TextInverser_TextoInvertido_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.TextInverser(texto);

            // ASSERT
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("💙", "💙")]
        [InlineData("💙", "��")]
        public void TextInverser_TextoInvertido_Error(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.TextInverser(texto);

            // ASSERT
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}

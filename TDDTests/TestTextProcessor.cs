namespace Tests
{
    public class TestTextProcessor
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("   ", "   ")]

        [InlineData("a", "a")]
        [InlineData("3", "3")]

        [InlineData("Mi Nombre Es Laura", "aruaL sE erbmoN iM")]
        [InlineData("Mi  Nombre    Es Laura", "aruaL sE    erbmoN  iM")]
        [InlineData(" Mi nombre es Laura", "aruaL se erbmon iM ")]
        [InlineData("   Mi nombre es Laura", "aruaL se erbmon iM   ")]
        public void TextInverser_StringValido_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.ToTextInverser);

            // ASSERT
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("?")]
        [InlineData("💙")]
        [InlineData("♡")]
        public void TextInverser_ExcepcionCaracterInvalido_Success(string texto)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            var exception = Assert.Throws<Exception>(() => sut.ProcessText(texto, Operation.ToTextInverser));

            // ASSERT
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }
    }
}

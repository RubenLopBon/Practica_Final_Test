namespace Tests
{
    public class TestTextProcessor
    {
        [Theory]
       
        [InlineData("probando texto test", "probando texto test")]
        [InlineData("PROBANDO TEXTO TEST", "probando texto test")]
        [InlineData("PrObAnDo TeXtO TeSt", "probando texto test")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("  ", "  ")]
        public void ToLowerCase_StringValido_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.ToLowerCase);

            // ASSERT
            Assert.Equal(resultadoEsperado, resultado);
                
        }

        [Theory]

        [InlineData("probando texto test", "PROBANDO TEXTO TEST")]
        [InlineData("PROBANDO TEXTO TEST", "PROBANDO TEXTO TEST")]
        [InlineData("PrObAnDo TeXtO TeSt", "PROBANDO TEXTO TEST")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("  ", "  ")]
        public void ToUpperCase_StringValido_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.ToUpperCase);

            // ASSERT
            Assert.Equal(resultadoEsperado, resultado);

        }
        [Theory]

        [InlineData("", "0")]
        [InlineData("hola", "1")]
        [InlineData("probando contar test dos", "4")]
        [InlineData("💔", "1")]
        [InlineData("💔 hola que tal", "4")]
        [InlineData(" ", "0")]
        [InlineData("  ", "0")]
        public void WordCounter_StringValido_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.WordCounter);

            // ASSERT
            Assert.Equal(resultadoEsperado, resultado);

        }

        [Theory]
        [InlineData("", "El número de mayúsculas es: 0\nEl número de minúsculas es: 0")]
        [InlineData("hOLa", "El número de mayúsculas es: 2\nEl número de minúsculas es: 2")]
        [InlineData("PROBANDO contar tEsT Dos", "El número de mayúsculas es: 11\nEl número de minúsculas es: 10")]
        [InlineData("💔", "El número de mayúsculas es: 0\nEl número de minúsculas es: 0")]
        [InlineData("💔 hOLa que tal", "El número de mayúsculas es: 2\nEl número de minúsculas es: 8")]
        [InlineData(" ", "El número de mayúsculas es: 0\nEl número de minúsculas es: 0")]
        [InlineData("  ", "El número de mayúsculas es: 0\nEl número de minúsculas es: 0")]
        public void CountUpperAndLowerCase_EntradaValida_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.ToCountCase);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }

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
        public void TextInverser_CaracterInvalido_Excepcion(string texto)
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
